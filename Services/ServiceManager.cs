using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using Services.Contracts.Categories;
using Services.Contracts.Features;
using Services.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Utilities.AzureBlobForProduct;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IArticleService> _articleService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IProductCategoryService> _productCategoryService;
        private readonly Lazy<IArticleCategoryService> _articleCategoryService;

        private readonly Lazy<IForumService> _forumService;
        private readonly Lazy<IForumQuestionAnswerService> _forumQuestionAnswerService;
        private readonly Lazy<IForumQuestionCategoryService> _forumQuestionCategoryService;
        private readonly Lazy<IProductImageService> _productImageService;
        private readonly Lazy<IDoctorCategoryService> _doctorCategoryService;
        private readonly Lazy<IPodcastService> _podcastService;
        private readonly Lazy<IDoctorService> _doctorService;


        private readonly Lazy<IAppointmentService> _appointmentService;
        private readonly Lazy<IDoctorScheduleService> _doctorSchedule;
        private readonly Lazy<IMessageService> _messageService;

        private readonly Lazy<IContentModerationService> _contentModerationService;



        //We are doing this because we don't want to add to things in Ioc
        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            UserManager<User> userManager,
            IConfiguration configuration,
            IMapper mapper,
            BlobService blobService,
            ProductPictureBlobStorageService productPictureBlobStorageService,
            AzureBlobForPregnancyPictures azureBlobForPregnancyPictures,
            
       



            IHttpContextAccessor httpContextAccessor,
            IUrlHelperFactory urlHelperFactory,
            IEmailSender emailSender)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration,
            httpContextAccessor, urlHelperFactory, emailSender, azureBlobForPregnancyPictures));

            _articleService = new Lazy<IArticleService>(() =>
         new ArticleManager(repositoryManager, logger, mapper));

            _productCategoryService = new Lazy<IProductCategoryService>(() =>
            new ProductCategoryManager(repositoryManager,mapper));


            _articleCategoryService = new Lazy<IArticleCategoryService>(() =>
            new ArticleCategoryManager(repositoryManager, mapper));

            _productService = new Lazy<IProductService>(() =>
         new ProductManager(repositoryManager, logger, mapper, userManager));

            _forumService = new Lazy<IForumService>(() =>
        new ForumManager(repositoryManager, mapper));

            _forumQuestionAnswerService = new Lazy<IForumQuestionAnswerService>(() =>
        new ForumQuestionAnswerManager(repositoryManager, mapper,userManager));

            _podcastService = new Lazy<IPodcastService>(() =>
        new PodcastManager(repositoryManager,blobService));

            _forumQuestionCategoryService = new Lazy<IForumQuestionCategoryService>(() =>
            new ForumQuestionCategoryManager(repositoryManager, mapper));


            _productImageService = new Lazy<IProductImageService>(() =>
         new ProductImageService(repositoryManager,  productPictureBlobStorageService));
            _doctorService = new Lazy<IDoctorService>(() => new 
            DoctorManager(repositoryManager,mapper, this, userManager));

            _doctorCategoryService = new Lazy<IDoctorCategoryService>(() =>
            new DoctorCategoryManager(repositoryManager, mapper));

            _appointmentService = new Lazy<IAppointmentService>(() =>
           new AppointmentManager(repositoryManager, mapper,userManager));

            _doctorSchedule = new Lazy<IDoctorScheduleService>(() => 
            new DoctorScheduleManager(repositoryManager,mapper));

            _messageService = new Lazy<IMessageService>(() =>
          new MessageManager(repositoryManager, mapper, userManager, _appointmentService.Value));

            _contentModerationService = new Lazy<IContentModerationService>(() => new ContentModerationService(repositoryManager, mapper,userManager));

        }

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
        public IArticleService ArticleService => _articleService.Value;
        public IProductService ProductService => _productService.Value;

        public IProductCategoryService ProductCategoryService => _productCategoryService.Value;
        public IArticleCategoryService ArticleCategoryService => _articleCategoryService.Value;
        public IForumService ForumService => _forumService.Value;

        public IForumQuestionAnswerService ForumQuestionAnswerService => _forumQuestionAnswerService.Value;

        public IPodcastService PodcastService => _podcastService.Value;

        public IForumQuestionCategoryService ForumQuestionCategoryService => _forumQuestionCategoryService.Value;

        public IProductImageService ProductImageService => _productImageService.Value;

        public IDoctorService DoctorService => _doctorService.Value;

        public IDoctorCategoryService DoctorCategoryService => _doctorCategoryService.Value;

        public IAppointmentService AppointmentService => _appointmentService.Value;

        public IDoctorScheduleService AppointmentScheduleService => _doctorSchedule.Value;

        public IMessageService MessageService => _messageService.Value;

        public IContentModerationService ContentModerationService => _contentModerationService.Value;
    }
}
