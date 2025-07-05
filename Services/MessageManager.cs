using AutoMapper;
using Entities.DataTransferObjects.Conversation;
using Entities.DataTransferObjects.Message;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageManager : IMessageService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAppointmentService _appointmentService;

        public MessageManager(IRepositoryManager repository, IMapper mapper, UserManager<User> userManager, IAppointmentService appointmentService)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _appointmentService = appointmentService;
        }


        public async Task<IEnumerable<ConversationDto>> GetConversationsAsync(string userId)
        {
            var conversations = await _repository.Conversation.GetConversationsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<ConversationDto>>(conversations);
        }
        public async Task<IEnumerable<ConversationDto>> GetConversationsAsync(string participant1Id, string participant2Id)
        {
            var conversations = await _repository.Conversation
      .FindByCondition(c =>
          (c.Participant1Id == participant1Id && c.Participant2Id == participant2Id) ||
          (c.Participant1Id == participant2Id && c.Participant2Id == participant1Id), false)
      .Include(c => c.Messages)
      .ToListAsync();

            return _mapper.Map<IEnumerable<ConversationDto>>(conversations);
        }

        public async Task<ConversationDto> GetConversationByIdAsync(int conversationId)
        {
            var conversation = await _repository.Conversation.GetByIdAsync(conversationId);
            return _mapper.Map<ConversationDto>(conversation);
        }

        public async Task<Message> SendUserMessageAsync(MessageDto messageDto)
        {
            var sender = await _userManager.FindByIdAsync(messageDto.SenderId);
            if (sender == null)
            {
                throw new Exception("Sender not found");
            }

            var recipient = await _userManager.FindByIdAsync(messageDto.RecipientId);
            if (recipient == null)
            {
                throw new Exception("Recipient not found");
            }

            var conversation = await GetOrCreateConversationAsync(sender.Id, recipient.Id);

            var message = _mapper.Map<Message>(messageDto);
            message.ConversationId = conversation.Id;
            //message.SentAt = DateTime.UtcNow;

            await _repository.Message.CreateMessageAsync(message);
            await _repository.SaveAsync();

            return message;
        }
        private async Task<Conversation> GetOrCreateConversationAsync(string senderId, string recipientId)
        {
            var conversation = await _repository.Conversation
                .FindByCondition(c =>
                    (c.Participant1Id == senderId && c.Participant2Id == recipientId) ||
                    (c.Participant1Id == recipientId && c.Participant2Id == senderId), false)
                .FirstOrDefaultAsync();

            if (conversation == null)
            {
                conversation = new Conversation
                {
                    Participant1Id = senderId,
                    Participant2Id = recipientId,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.Conversation.CreateConversationAsync(conversation);
                await _repository.SaveAsync();
            }

            return conversation;
        }
        public async Task<Message> SendDoctorMessageAsync(MessageDto messageDto)
        {
            var sender = await _userManager.FindByIdAsync(messageDto.SenderId);
            if (sender == null)
            {
                throw new Exception("Sender not found");
            }

            var recipient = await _userManager.FindByIdAsync(messageDto.RecipientId);
            if (recipient == null)
            {
                throw new Exception("Recipient not found");
            }

           

            if (!await IsDoctorAvailable(recipient.Id) )
            {
                throw new Exception("Doktor mesajlaşmaya uygun değil");
            }

            var conversation = await GetOrCreateConversationAsync(sender.Id, recipient.Id);

            var message = _mapper.Map<Message>(messageDto);
            message.ConversationId = conversation.Id;
          //  message.SentAt = DateTime.UtcNow;

            await _repository.Message.CreateMessageAsync(message);
            await _repository.SaveAsync();

            return message;
        }

   
        private async Task<bool> IsDoctorAvailable(string doctorId)
        {
            var currentDateTime = DateTime.UtcNow;
            var availableSlots = await _appointmentService.GetAvailableSlotsAsync(doctorId, currentDateTime);

            // Şu anki zaman diliminde doktorun müsait olup olmadığını kontrol et
            return availableSlots.Any(slot => slot.StartTime <= currentDateTime && slot.EndTime > currentDateTime && !slot.IsBooked);
        }


        public async Task DeleteMessageAsync(int messageId)
        {
            var message = await _repository.Message.GetByIdAsync(messageId);
            if (message == null)
            {
                throw new Exception("Message not found");
            }

         

            await _repository.Message.DeleteMessageAsync(message);
            await _repository.SaveAsync();
        }

        public async Task DeleteConversationMessageAsync(int conversationId)
        {
            var conversation = await _repository.Conversation.GetByIdAsync(conversationId);
            if (conversation == null)
            {
                throw new Exception("Conversation not found");
            }

            foreach (var message in conversation.Messages)
            {
                _repository.Message.Delete(message);
            }

            _repository.Conversation.Delete(conversation);
            await _repository.SaveAsync();
        }

    }
}
