using Entities.Models;
using Entities.Models.Categories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryContext : IdentityDbContext<User>
    {

        public RepositoryContext(DbContextOptions options) : base(options)
            {

            }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<ForumQuestionAnswers> ForumQuestionAnswers { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<ForumQuestionCategory> ForumQuestionCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }  
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorCategories> DoctorCategories { get; set; }
        public DbSet<DoctorSchedule> DoctorSchedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Conversation> Conversation { get; set; }   
        






        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.ApplyConfiguration(new ArticleConfig());
            //builder.Entity<ForumQuestionCategory>(entity =>
            //{
            //    entity.HasKey(e => e.ForumQuestionCategoryId);
            //});

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
