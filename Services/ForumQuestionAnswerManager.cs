using AutoMapper;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.Exceptions.Forum;
using Entities.Exceptions.ForumQuestionAnswer;
using Entities.Exceptions.User;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ForumQuestionAnswerManager : IForumQuestionAnswerService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ForumQuestionAnswerManager(IRepositoryManager manager, IMapper mapper, UserManager<User> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ForumAnswerDto> CreateOneForumQuestionAnswer(ForumAnswerDtoForInsertion forumAnswerDto)
        {
            var forumAnswerEntity = _mapper.Map<ForumQuestionAnswers>(forumAnswerDto);
            Forum question = await _manager.Forum.GetOneForumAsync(forumAnswerEntity.QuestionId, false);
            //if(forumAnswerEntity.UserId == question.UserId)
            //{
            //    throw new BadRequestAnswerException("Cevap yazan kişi aynı kullanıcı olamaz");
            //}
            var user = await _userManager.FindByIdAsync(forumAnswerDto.UserId);
            if(user.UserType != forumAnswerDto.UserType)
            {
                throw new BadRequestAnswerException("Kullanıcının user çeşidi verilen değer ile uyuşmamaktadır");
            }

            _manager.ForumQuestionAnswer.Create(forumAnswerEntity);
            await _manager.SaveAsync();

            var forumAnswerToReturn = _mapper.Map<ForumAnswerDto>(forumAnswerEntity);
          

            return forumAnswerToReturn;
        }

        public async Task DeleteOneForumQuestionAnswer(int questionId, int answerId, bool trackChanges)
        {
            var forumAnswerEntity = await _manager.ForumQuestionAnswer.GetAnswerByIdAsync(questionId, answerId, trackChanges);
            if (forumAnswerEntity == null)
            {
                throw new ForumAnswerNotFoundException(answerId);
            }

            _manager.ForumQuestionAnswer.Delete(forumAnswerEntity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<ForumAnswerDto>> GetAnswersByQuestionIdAsync(int questionId, bool trackChanges)
        {
            var forumAnswers = await _manager.ForumQuestionAnswer.GetAnswersByQuestionIdAsync(questionId, trackChanges);
            var forumAnswerDtos = _mapper.Map<IEnumerable<ForumAnswerDto>>(forumAnswers);
            return forumAnswerDtos;
        }

        public async Task<ForumAnswerDto> GetOneForumQuestionAnswerByIdAsync(int questionId, int answerId, bool trackChanges)
        {
            var forumAnswerEntity = await _manager.ForumQuestionAnswer.GetAnswerByIdAsync(questionId, answerId, trackChanges);
            if (forumAnswerEntity == null)
            {
                throw new ForumAnswerNotFoundException(answerId);
            }

            var forumAnswerDto = _mapper.Map<ForumAnswerDto>(forumAnswerEntity);
            return forumAnswerDto;
        }

        public async Task UpdateOneForumQuestionAnswer(int questionId, int answerId, ForumAnswerDtoForUpdate forumAnswerDto, bool trackChanges)
        {
            var forumAnswerEntity = await _manager.ForumQuestionAnswer.GetAnswerByIdAsync(questionId, answerId, trackChanges);
            if (forumAnswerEntity == null)
            {
                throw new ForumAnswerNotFoundException(answerId);
            }

            _mapper.Map(forumAnswerDto, forumAnswerEntity);
            _manager.ForumQuestionAnswer.Update(forumAnswerEntity);
            await _manager.SaveAsync();
        }




       
    }
}
