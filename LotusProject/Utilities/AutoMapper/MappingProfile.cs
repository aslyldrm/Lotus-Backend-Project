using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Appointment;
using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Categories.DoctorCategory;
using Entities.DataTransferObjects.Category.ArticleCategory;
using Entities.DataTransferObjects.Category.ForumQuestionCategory;
using Entities.DataTransferObjects.Category.ProductCategory;
using Entities.DataTransferObjects.Conversation;
using Entities.DataTransferObjects.Doctor;
using Entities.DataTransferObjects.DoctorSchedule;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.ForumQuestion;
using Entities.DataTransferObjects.Message;
using Entities.DataTransferObjects.Podcast;
using Entities.DataTransferObjects.Product;
using Entities.DataTransferObjects.User;
using Entities.Models;
using Entities.Models.Categories;

namespace WebApi.Utilities.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
       
            CreateMap<UserDtoForRegistration, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDtoForUpdate, User>();
            CreateMap<User, UserDtoSmallInfo>().ReverseMap();


            CreateMap<ArticleDtoForUpdate, Article>();
            CreateMap<Article, ArticleDto>();
            CreateMap<ArticleDtoForInsertion, Article>();


            CreateMap<ArticleCategory, ArticleCategoryDto>();
            CreateMap<ArticleCategoryDtoForUpdate, ArticleCategory>();
            CreateMap<ArticleCategoryDtoForInsertion, ArticleCategory>();


            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForUpdate, Product>();
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<Product, ProductGetAllWithPictures>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDtoUpdate, ProductCategory>();
            CreateMap<ProductCategoryDtoInsertion, ProductCategory>();


            CreateMap<Forum, ForumDto>();
            CreateMap<ForumDtoForUpdate, Forum>();
            CreateMap<ForumDtoForInsertion, Forum>();
            CreateMap<ForumAnswerDtoForControl, Forum>();
            CreateMap<ForumQuestionAnswers, ForumAnswerDtoForControl>().ReverseMap();    

            CreateMap<UserDto,UserDtoSmallInfo>().ReverseMap(); 


            CreateMap<Forum, ForumFilterDto>();
            CreateMap<Forum, ForumWithAnswersDto>();
            CreateMap<Forum, ModerationForumUserDetails>();
            CreateMap<ForumFilterDto, ModerationForumUserDetails>().ReverseMap();




            CreateMap<ForumQuestionAnswers, ForumAnswerDto>();
            CreateMap<ForumAnswerDtoForUpdate, ForumQuestionAnswers>();
            CreateMap<ForumAnswerDtoForInsertion, ForumQuestionAnswers>();


            CreateMap<Podcast, PodcastDto>();
            CreateMap<PodcastDtoForUpdate, Podcast>();
            CreateMap<PodcastDtoForInsertion, Podcast>();


            CreateMap<ForumQuestionCategory, ForumQuestionCategoryDto>();
            CreateMap<ForumQuestionCategoryForUpdate, ForumQuestionCategory>();
            CreateMap<ForumQuestionCategoryDtoForInsertion, ForumQuestionCategory>();

            CreateMap<DoctorCategories, DoctorCategoryDto>();
            CreateMap<DoctorCategoryDtoForUpdate, DoctorCategories>();
            CreateMap<DoctorCategoryDtoForInsertion, DoctorCategories>();

            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDtoForUpdate, Doctor>();
            CreateMap<DoctorDtoForInsertion, Doctor>();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();

            CreateMap<DoctorSchedule, DoctorScheduleDto>();
            CreateMap<UpdateDoctorScheduling, DoctorSchedule>().ReverseMap();

            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, GetMessageDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();


            CreateMap<Product, ProductDtoWithDetails>();






        }

    }
}
