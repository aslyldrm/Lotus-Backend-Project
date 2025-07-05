using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserDtoForRegistration userDtoForRegistration, ActionContext actionContext);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuthenticationDto );
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

        Task<UserDto> FindByIdAsyncForPictures(string userId, bool trackChanges);
        Task<User> FindByIdAsync(string userId, bool trackChanges);
        Task<IdentityResult> UpdateUserAsync(User user);

        Task<bool> UpdateRoles(string id, string role);
        Task DeleteOneUserAsync(string id, bool trackChanges);

        Task UpdateOneUserAsync(string id, UserDtoForUpdate userDto, bool trackChanges);
        Task<User> FindingUserByEmail(string email);
        Task<(byte[] fileBytes, string contentType)> GetFetusPicture(string userId);
        Task<string> GetFetusPictureUrlAsync(string userId, int pregnancyStatus);
        Task ResetPasswordAsync(string email, string code, string newPassword);
        Task SendForgotPasswordEmailAsync(string email, HttpContext httpContext);







    }
}
