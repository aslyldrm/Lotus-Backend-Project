using AutoMapper;
using Entities.DataTransferObjects.Article;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.ForumQuestion;

using Entities.Exceptions.Article;
using Entities.Exceptions.Forum;
using Entities.Exceptions.ProductCategory;
using Entities.Models;
using Entities.Models.Categories;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ForumManager : IForumService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ForumManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<ForumDto> CreateOneForum(ForumDtoForInsertion forumDto)
        {
            try
            {
                var entity = _mapper.Map<Forum>(forumDto);

                _manager.Forum.CreateOneForum(entity);
                await _manager.SaveAsync();

                return _mapper.Map<ForumDto>(entity);
            }
            catch (DbUpdateException dbEx)
            {
                // Veritabanı güncelleme hatası loglama
                Console.WriteLine($"Veritabanı Hatası: {dbEx.Message}");
                Console.WriteLine($"Inner Exception: {dbEx.InnerException?.Message}");
                throw;
            }
            catch (ValidationException valEx)
            {
                // Doğrulama hatası loglama
                Console.WriteLine($"Doğrulama Hatası: {valEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Genel hata loglama
                Console.WriteLine($"Hata: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
           
        }

        //public async Task DeleteOneForum(int id, bool trackChanges)
        //{
        //    var entity = await _manager.Forum.GetOneForumAsync(id, trackChanges);
        //    if (entity == null)
        //    {
        //        throw new ForumNotFoundException(id);
        //    }

        //    _manager.Forum.DeleteOneForum(entity);
        //    await _manager.SaveAsync();
        //}

        public async Task DeleteOneForumQuestion(int questionId, bool trackChanges)
        {
            var forumQuestion = await _manager.Forum.GetOneForumAsync(questionId, trackChanges);
            if (forumQuestion == null)
            {
                throw new ForumNotFoundException(questionId);
            }

            var forumAnswers = await _manager.ForumQuestionAnswer.GetAnswersByQuestionIdAsync(questionId, trackChanges);
            foreach (var answer in forumAnswers)
            {
                _manager.ForumQuestionAnswer.Delete(answer);
            }

            _manager.Forum.Delete(forumQuestion);
            await _manager.SaveAsync();
        }


        public async Task<IEnumerable<Forum>> GetAllForumAsync(bool trackChanges)
        {
            return await _manager.Forum.GetAllForumAsync(trackChanges);

        }

        public async Task<ForumDto> GetOneForumByIdAsync(int id, bool trackChanges)
        {
            var forum = await _manager.Forum.GetOneForumAsync(id, trackChanges);


            if (forum == null)
                throw new ForumNotFoundException(id);

            return _mapper.Map<ForumDto>(forum);
        }

        public async Task UpdateOneForum(int id, ForumDtoForUpdate forumDto, bool trackChanges)
        {
            var entity = await _manager.Forum.GetOneForumAsync(id, trackChanges);
            if (entity == null)
            {
                throw new ForumNotFoundException(id);


            }
            entity = _mapper.Map<Forum>(forumDto);
            _manager.Forum.Update(entity);
            await _manager.SaveAsync();
        }
        public async Task<IEnumerable<ForumFilterDto>> GetFilteredForumAsync(ForumFilterParameters forumParameters, bool trackChanges)
        {
            var forums = await _manager.Forum.GetFilteredForumQuestionAsync(forumParameters, trackChanges);

         
            var forumDtos = _mapper.Map<IEnumerable<ForumFilterDto>>(forums);

          
            foreach (var forumDto in forumDtos)
            {
                var answers = await _manager.ForumQuestionAnswer.GetAnswersByQuestionIdAsync(forumDto.QuestionId, trackChanges);
                var answerDtos = _mapper.Map<IEnumerable<ForumAnswerDto>>(answers);
                forumDto.Answers = answerDtos;
            }

            return forumDtos;
        }
        public async Task<IEnumerable<ForumWithAnswersDto>> SearchForumQuestionsByQuestionTitleAsync(string questionTitle, bool trackChanges)
        {
            var forumQuestionsQuery = _manager.Forum.FindAll(trackChanges);

            if (!string.IsNullOrWhiteSpace(questionTitle))
            {
                questionTitle = questionTitle.ToLower();
                forumQuestionsQuery = forumQuestionsQuery.Where(a => a.Question.ToLower().Contains(questionTitle));
            }

            var forumQuestions = await forumQuestionsQuery
                .Include(a => a.ForumQuestionCategory)
                .ToListAsync();

            var forumDtos = _mapper.Map<IEnumerable<ForumWithAnswersDto>>(forumQuestions);

            foreach (var forumDto in forumDtos)
            {
                var answers = await _manager.ForumQuestionAnswer.GetAnswersByQuestionIdAsync(forumDto.QuestionId, trackChanges);
                var answerDtos = _mapper.Map<IEnumerable<ForumAnswerDto>>(answers);
                forumDto.Answers = answerDtos.ToList(); // Convert to List to satisfy ICollection
            }

            return forumDtos;
        }

        public async Task<IEnumerable<ForumDto>> GetUserForumQuestionsAsync(string userId, bool trackChanges)
        {
            var forumQuestions = await _manager.Forum.FindByCondition(f => f.UserId == userId, trackChanges)
                                                     .ToListAsync();

            var forumQuestionDtos = _mapper.Map<IEnumerable<ForumDto>>(forumQuestions);
            return forumQuestionDtos;
        }

    }
}
