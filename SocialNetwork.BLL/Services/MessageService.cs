using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace SocialNetwork.BLL.Services
{
    public class MessageService
    {
        IMessageRepository _messageRepository;
        IUserRepository _userRepository;
        public MessageService() 
        {
            _userRepository = new UserRepository();
            _messageRepository = new MessageRepository();
        }

        public void SendMessage(MessageData messageData) 
        {
            if (!new EmailAddressAttribute().IsValid(messageData.RecipientEmail))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(messageData.RecipientEmail) == null)
                throw new UserNotFoundException();

            if (string.IsNullOrEmpty(messageData.Content))
                throw new ArgumentNullException();

            if (messageData.Content.Length > 5000)
                throw new ArgumentOutOfRangeException();

            var messageEntity = new MessageEntity() 
            {
                content = messageData.Content,
                sender_id = messageData.SenderId,
                recipient_id = _userRepository.FindByEmail(messageData.RecipientEmail).id,
            };

            if (_messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<MessageEntity> GetReceivedMessages(User user) 
        {
            var messages = _messageRepository.FindByRecipientId(user.Id);
            return messages;
        }
    }
}
