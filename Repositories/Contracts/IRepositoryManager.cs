using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Contracts.Categories;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        //IUserRepository User { get; }
        IArticleRepository Article { get; }
        IProductRepository Product { get; }
        IProductCategoryRepository ProductCategory { get; }
        IArticleCategoryRepository ArticleCategory { get; }
        IForumRepository Forum { get; }
        IForumAnswerRepository ForumQuestionAnswer { get; }
        IForumQuestionCategory ForumQuestionCategory { get; }

        IPodcastRepository Postcast { get; }

        IProductImageRepository ProductImage { get; }
        IDoctorRepository Doctor { get; }

        IDoctorCategoryRepository DoctorCategory { get; }
        IAppointmentRepository Appointment { get; }

        IDoctorScheduleRepository DoctorSchedule { get; }

        IConversationRepository Conversation { get; }
        IMessageRepository Message { get; }
        Task SaveAsync();

    }
}
