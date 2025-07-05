using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Contracts.Categories;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IAuthenticationService AuthenticationService { get; }
        IArticleService ArticleService { get; }
        IProductService ProductService { get; }
        IArticleCategoryService ArticleCategoryService { get; }

        IProductCategoryService ProductCategoryService { get; }
        IForumService ForumService { get; }
        IForumQuestionAnswerService ForumQuestionAnswerService { get; }
        IForumQuestionCategoryService ForumQuestionCategoryService { get; }
        IPodcastService PodcastService { get; }
        IProductImageService ProductImageService { get; }
        IDoctorService DoctorService { get; }
        IDoctorCategoryService DoctorCategoryService { get; }
        IAppointmentService AppointmentService { get; } 
        IDoctorScheduleService AppointmentScheduleService { get; }

        IMessageService MessageService { get; }
        IContentModerationService ContentModerationService { get; }

    }
}
