using Repositories.Contracts;
using Repositories.Contracts.Categories;
using Repositories.EFCore.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{

    public class RepositoryManager(RepositoryContext context) : IRepositoryManager
    {
        private readonly RepositoryContext _context = context;

       

        public IArticleRepository Article => new ArticleRepository(_context);
        public IProductRepository Product => new ProductRepository(_context);
        public IProductCategoryRepository ProductCategory => new ProductCategoryRepository(_context);

        public IArticleCategoryRepository ArticleCategory => new ArticleCategoryRepository(_context);

        public IForumRepository Forum => new ForumRepository(_context);
        public IForumAnswerRepository ForumQuestionAnswer => new ForumAnswerRepository(_context);
        public IForumQuestionCategory ForumQuestionCategory => new ForumQuestionCategoryRepository(_context);

        public IPodcastRepository Postcast => new PodcastRepository(_context);

        public IProductImageRepository ProductImage => new ProductImageRepository(_context);

        public IDoctorRepository Doctor =>  new DoctorRepository(_context);
        public IDoctorCategoryRepository DoctorCategory => new DoctorCategoryRepository(_context);

        public IAppointmentRepository Appointment => new AppointmentRepository(_context);

        public IDoctorScheduleRepository DoctorSchedule => new DoctorScheduleRepository(_context);

        public IConversationRepository Conversation => new ConversationRepository(_context);

        public IMessageRepository Message => new MessageRepository(_context);

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
