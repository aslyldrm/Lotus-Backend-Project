using AutoMapper;
using Entities.DataTransferObjects.User;
using Entities.Exceptions.User;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings.Web;
using Services.Contracts.Features;
using Entities.Exceptions;
using Entities.Exceptions.Article;
using static Entities.Exceptions.NotFoundException;
using Entities.DataTransferObjects.Forum;
using Entities.Exceptions.Forum;
using Services.Dictionary;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Azure.Storage;
using Services.Features;

namespace Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _loggerService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
  
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AzureBlobForPregnancyPictures _azureBlobForPregnancyPictures;
        private User? _user;
      

        public AuthenticationManager(ILoggerService loggerService, IMapper mapper, UserManager<User> userManager, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IUrlHelperFactory urlHelperFactory, IEmailSender emailSender, AzureBlobForPregnancyPictures azureBlobForPregnancyPictures)
        {
            _loggerService = loggerService;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;

            _httpContextAccessor = httpContextAccessor;
            _urlHelperFactory = urlHelperFactory;
            _emailSender = emailSender;
            _azureBlobForPregnancyPictures = azureBlobForPregnancyPictures;
        }


        public async Task<IdentityResult> RegisterUser(UserDtoForRegistration userDtoForRegistration, ActionContext actionContext)
        {
         
            var user = _mapper.Map<User>(userDtoForRegistration);

         

            var result = await _userManager.CreateAsync(user, userDtoForRegistration.Password);

            if (result.Succeeded)
            {
                var baseUri = _configuration["ApplicationSettings:BaseUrl"];
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var urlHelper = _urlHelperFactory.GetUrlHelper(actionContext);

                var callbackUrl = urlHelper.Action(
                    "ConfirmEmail",  // Action method name
                    "Authentication", // Controller name
                    new { userId = user.Id, code = code }, // Route values
                    protocol: new Uri(baseUri).Scheme, // Scheme
                    host: new Uri(baseUri).Host);

                if (string.IsNullOrEmpty(callbackUrl))
                {
                    throw new InvalidOperationException("Callback URL cannot be null.");
                }

                // Log the generated callback URL for debugging purposes
                _loggerService.LogInfo($"Generated callback URL: {callbackUrl}");

                await _emailSender.SendEmailAsync(userDtoForRegistration.Email, "Confirm your email",
                    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                var roles = new List<string> { "user" };
                await _userManager.AddToRolesAsync(user, roles);
            }

            return result;
        }


        public async Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto)
        {
            _user = await _userManager.FindByEmailAsync(userForAuthenticationDto.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthenticationDto.Password));

            if (!result )
            {
                _loggerService.LogWarning($"{nameof(ValidateUser)} : Authentication failed. Wrong username or password.");
            }
            if(!_user.EmailConfirmed)
                throw new BadRequest("You must confirm your email before you can log in.");
            return result;

            
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if(populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };



        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"]
                )),
                signingCredentials: signinCredentials);

            return tokenOptions;



        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private SigningCredentials GetSigninCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using(var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            //ref, out, parameters is like a parameter modifiers

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
                out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if(jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase)) {
                throw new SecurityTokenException("Invalid token.");
            }

            return principal;
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user is null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequestException();

            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<User> FindByIdAsync(string userId, bool trackChanges)
        {
            return await _userManager.FindByIdAsync(userId);
        }

     

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<bool> UpdateRoles(string id, string role)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                throw new BadRequest("User not found.");
            if (role.ToLower() == "admin")
            {
                var roles = new List<string> { "admin" };
                await _userManager.RemoveFromRoleAsync(user, "user");
                await _userManager.AddToRolesAsync(user, roles);
                user.UserType = 2;
                await _userManager.UpdateAsync(user);
            }
            else if (role.ToLower() == "doctor") {
                var roles = new List<string> { "doctor" };
                await _userManager.RemoveFromRoleAsync(user,"user");
                await _userManager.AddToRolesAsync(user, roles);
                user.UserType = 1;
                await _userManager.UpdateAsync(user);

            }
            else if (role.ToLower() == "user")
            {
                var roles = new List<string> { "user" };
                if(user.UserType == 1)
                {
                    await _userManager.RemoveFromRoleAsync(user, "doctor");
                }
                if (user.UserType == 2)
                {
                    await _userManager.RemoveFromRoleAsync(user, "admin");
                }


                await _userManager.AddToRolesAsync(user, roles);
                user.UserType = 1;
                await _userManager.UpdateAsync(user);

            }
            else
            {
                throw new BadRequest("This role doesn't exist");
            }
            await _userManager.UpdateAsync(user);

            return true;

        }

        public async Task DeleteOneUserAsync(string id, bool trackChanges)
        {
            var entity = await this.FindByIdAsync(id,false);
            if (entity == null)
            {
                throw new UserNotFoundException(id);
            }

            await _userManager.DeleteAsync(entity);
            
        }

        public async Task UpdateOneUserAsync(string id, UserDtoForUpdate userDto, bool trackChanges)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
            {
                throw new UserNotFoundException(id);
            }

            if (!string.IsNullOrWhiteSpace(userDto.Username) && userDto.Username != "string")
            {
                entity.UserName = userDto.Username;
            }

            if (!string.IsNullOrWhiteSpace(userDto.Surname) && userDto.Surname != "string")
            {
                entity.Surname = userDto.Surname;
            }

            if (!string.IsNullOrWhiteSpace(userDto.PregnancyStatus) && userDto.PregnancyStatus != "string")
            {
                entity.PregnancyStatus = userDto.PregnancyStatus;
            }

            if (!string.IsNullOrWhiteSpace(userDto.Email) && userDto.Email != "string")
            {
                entity.Email = userDto.Email;
            }

            if (userDto.Image != null && userDto.Image.Length > 0)
            {
                entity.Image = await UploadImageToBlobAsync(userDto.Image);
            }

            var result = await _userManager.UpdateAsync(entity);
            if (!result.Succeeded)
            {
                throw new Exception("Error updating user.");
            }
        }


        public async Task<User> FindingUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user; // Assuming `user` is an instance of your User class
        }

        public async Task<(byte[] fileBytes, string contentType)> GetFetusPicture(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            // Hamilelik ayını hesapla
            int? pregnancyMonths = CalculatePregnancyMonth(user.PregnancyStatus);

            // Hamilelik ayına göre fetus resmi dosya yolunu al
            string fetusPicturePath = pregnancyMonths.HasValue
                ? FetusPictureDictionary.GetFetusPictureUrl(pregnancyMonths.Value)
                : FetusPictureDictionary.GetFetusPictureUrl(0);

            if (!System.IO.File.Exists(fetusPicturePath))
            {
                throw new NotFoundFetusPicture("Fetus picture not found");
            }

            // Dosyayı okumak
            var fileBytes = await System.IO.File.ReadAllBytesAsync(fetusPicturePath);
            var contentType = "image/webp"; // Resimlerinizin content type'ı

            return (fileBytes, contentType);
        }

        private int? CalculatePregnancyMonth(string pregnancyWeekString)
        {
           
            if (int.TryParse(pregnancyWeekString, out int pregnancyWeek))
            {
                if(pregnancyWeek == 0)
                {
                    return 0;
                }
                return (pregnancyWeek / 4) + 1; 
            }
            return 0; 
        }

        private async Task<string> UploadImageToBlobAsync(IFormFile image)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=lotususerpictures;AccountKey=jw2c3I6FsBnttRSjJB00UbS/XuK368UiUTpfHVul4xCPROXR1Bfm9D6M32GFdyirA8Wok1icphQr+ASt/X6dBw==;EndpointSuffix=core.windows.net";
            string containerName = "lotususerpictures";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            await containerClient.CreateIfNotExistsAsync();

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                ms.Position = 0;
                await blobClient.UploadAsync(ms, true);
            }

            // SAS token oluşturma
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            DateTimeOffset utcExpiry = utcNow.AddYears(1); // SAS URL'nin geçerlilik süresi


            BlobSasBuilder sasBuilder = new BlobSasBuilder
            {
                BlobContainerName = containerClient.Name,
                BlobName = blobClient.Name,
                Resource = "b",
                StartsOn = utcNow,
                ExpiresOn = utcExpiry
            };

            sasBuilder.SetPermissions(BlobSasPermissions.Read);

            string sasToken = sasBuilder.ToSasQueryParameters(new StorageSharedKeyCredential(blobServiceClient.AccountName, "jw2c3I6FsBnttRSjJB00UbS/XuK368UiUTpfHVul4xCPROXR1Bfm9D6M32GFdyirA8Wok1icphQr+ASt/X6dBw==")).ToString();
            UriBuilder sasUri = new UriBuilder(blobClient.Uri)
            {
                Query = sasToken
            };

            return sasUri.ToString();
        }
        public async Task<UserDto> FindByIdAsyncForPictures(string userId, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            int pregnancyWeeks = CalculatePregnancyWeeks(user.PregnancyStatus);
            int pregnancyMonths = CalculatePregnancyMonth(pregnancyWeeks);

            user.PregnancyStatus = pregnancyWeeks.ToString();

            await _userManager.UpdateAsync(user);

            var fetusPictureUrl = await GetFetusPictureUrlAsync(user.Id, pregnancyMonths);

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Surname = user.Surname,
                FetusPicture = fetusPictureUrl,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PregnancyStatus = user.PregnancyStatus,
                UserType = user.UserType,
                Image = user.Image
            };
        }

        private int CalculatePregnancyWeeks(string pregnancyWeekString)
        {
            if (int.TryParse(pregnancyWeekString, out int pregnancyWeek))
            {
                if(pregnancyWeek == 0)
                {
                    return 0;
                }
                return pregnancyWeek;
            }
            return 0; // Geçerli bir sayı değilse 0 döner
        }

        private int CalculatePregnancyMonth(int pregnancyWeeks)
        {
            if (pregnancyWeeks == 0)
            {
                return 0;
            }
           
            else if(pregnancyWeeks >36 && pregnancyWeeks <= 38)
            {
                return 9;
            }
            return (pregnancyWeeks / 4) +1 ; // Her 4 hafta bir ay olarak kabul edilir
        }

      
        public async Task<string> GetFetusPictureUrlAsync(string userId, int pregnancyStatus)
        {
            var blobName = GetBlobNameByPregnancyStatus(pregnancyStatus);
            if(blobName == "0.jpg")
            {
                blobName = "NotPregnant.webp";
            }
            return await _azureBlobForPregnancyPictures.GetFileUrlAsync(blobName);
        }

        private string GetBlobNameByPregnancyStatus(int pregnancyStatus)
        {
            // Logic to determine the blob name based on pregnancy status
            return $"{pregnancyStatus}.jpg"; // Adjust the naming convention as needed
        }


        public async Task ResetPasswordAsync(string email, string code, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserNotFoundException(email);
            }

            // Check if the reset code is correct and not expired
            if (user.PasswordResetCode != code || user.PasswordResetCodeExpiryTime < DateTime.UtcNow)
            {
                throw new Exception("Invalid or expired password reset code.");
            }

            // Remove the existing password reset code to prevent reuse
            user.PasswordResetCode = null;
            user.PasswordResetCodeExpiryTime = null;
            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                throw new Exception("Failed to update user with new password reset code.");
            }

            // Reset the user's password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetResult = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!resetResult.Succeeded)
            {
                throw new Exception("Error resetting password.");
            }
        }

        public async Task SendForgotPasswordEmailAsync(string email, HttpContext httpContext)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UserNotFoundException(email);
            }

            var code = GenerateVerificationCode();

            // Save the code to the user entity (you may want to save this in a separate table)
            user.PasswordResetCode = code;
            user.PasswordResetCodeExpiryTime = DateTime.UtcNow.AddMinutes(15); // Code is valid for 15 minutes
            await _userManager.UpdateAsync(user);

            var callbackUrl = $"Doğrulama kodunuz: {code}";

            await _emailSender.SendEmailAsync(email, "Reset Password",
                $"Your password reset verification code is: {code}.");
        }


        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }


    }
}
