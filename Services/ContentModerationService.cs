using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Forum;
using Entities.DataTransferObjects.ForumAnswers;
using Entities.DataTransferObjects.ForumQuestion;
using Entities.DataTransferObjects.User;
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
    public class ContentModerationService : IContentModerationService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public ContentModerationService(IRepositoryManager manager, IMapper mapper, UserManager<User> userManager)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
        }

        private readonly List<string> inappropriateKeywords = new List<string>
    {
      "aptal", "salak", "ahmak", "gerizekalı", "serseri",
        "reklam", "spam", "ucuz ürün", "satış", "şok fiyat", "kolay para", "hemen al", "şimdi sipariş",
        "nefret1", "nefret2", "ırkçı1", "ırkçı2", "ırkçı3", "faşist", "nazi", "terörist",
        "pornografi", "porno", "cinsel içerik", "müstehcen", "erotik", "seks", "tecavüz", "fetish",
        "intihar", "kendine zarar", "öldürme", "şiddet", "dayak", "kavga", "katil", "cinayet", "işkence",
        "uyuşturucu", "esrar", "kokain", "alkol", "içki", "sigara", "bağımlılık", "şarap", "bira", "uyuşturucu madde",
        "taciz", "saldırı", "istismar", "tecavüz", "rahatsız etme", "zorbalık", "tacizci", "stalker",
        "yanlış bilgi", "sahte bilgi", "yanıltıcı bilgi", "yanlış yönlendirme", "bilinçsiz", "eksik bilgi",
        "kürtaj", "düşük yapma", "tehlikeli yöntemler", "hamilelikte ilaç kullanımı", "düşük tehdidi",
        "yanlış bilgi hamilelik", "zararlı besinler", "yanlış diyetler", "doğum kontrol yöntemleri", "gebelikte içki", "hamilelikte sigara",
        "çocuk dövme", "çocuk istismarı", "çocuk pornosu", "çocuk ihmali", "çocuk kaçırma", "çocuk zorbalığı",
        "zararlı oyunlar", "zararlı yiyecekler", "aşırı diyet", "yanlış beslenme", "tehlikeli oyuncaklar",
        "ölüm", "felaket", "hastalık", "panik", "tehlike", "riskli davranış", "kanser", "hastane", "ölümcül"
    };


        public async Task<ModerationResultDto> ModerateContentAsync()
        {
            var questions = await _manager.Forum.GetAllForumAsync(trackChanges: true);
            var questionsWithAnswers = new List<ModerationForumUserDetails>();

            foreach (var question in questions)
            {
                var user = await _userManager.FindByIdAsync(question.UserId);
                var userDto = _mapper.Map<UserDtoSmallInfo>(user);

                var answers = await _manager.ForumQuestionAnswer.GetAnswersByQuestionIdAsync(question.QuestionId, trackChanges: true);
                var questionDto = _mapper.Map<ModerationForumUserDetails>(question);
                questionDto.User = userDto;
                questionDto.Answers = _mapper.Map<IEnumerable<ForumAnswerDtoForControl>>(answers).ToList();

                // Her cevabın kullanıcısını da alalım
                foreach (var answer in questionDto.Answers)
                {
                    var answerUser = await _userManager.FindByIdAsync(answer.UserId);
                    answer.User = _mapper.Map<UserDtoSmallInfo>(answerUser);
                }

                questionsWithAnswers.Add(questionDto);
            }

            var inappropriateQuestions = new List<ModerationForumUserDetails>();
            var inappropriateAnswers = new List<ForumAnswerDtoForControl>();
            var minLength = 10; // Minimum acceptable length for questions and answers

            foreach (var question in questionsWithAnswers)
            {
                if (IsContentInappropriate(question.Question) || IsContentTooShort(question.Question, minLength))
                {
                    inappropriateQuestions.Add(question);
                }

                foreach (var answer in question.Answers)
                {
                    if (IsContentInappropriate(answer.AnswerContent) || IsContentTooShort(answer.AnswerContent, minLength))
                    {
                        inappropriateAnswers.Add(answer);
                    }
                }
            }

            return new ModerationResultDto
            {
                InappropriateQuestions = inappropriateQuestions,
                InappropriateAnswers = inappropriateAnswers
            };
        }

        private bool IsContentInappropriate(string content)
        {
            foreach (var keyword in inappropriateKeywords)
            {
                if (content.ToLower().Contains(keyword.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsContentTooShort(string content, int minLength)
        {
            return content.Length < minLength;
        }
    }
}
