using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views
{
    public class UserReceivedMessageView
    {
        MessageService _messageService;
        UserService _userService;

        public UserReceivedMessageView(MessageService messageService, UserService userService) 
        {
            _messageService = messageService;
            _userService = userService;
        }

        public void Show(User user) 
        {

            if (_messageService.GetReceivedMessagesCount(user) == 0)
                Console.WriteLine("\nВходящих сообщений нет.\n");
            else
            {
                var receivedMessages = _messageService.GetReceivedMessages(user);

                foreach (MessageEntity receivedMessage in receivedMessages)
                {
                    var sender = _userService.FindById(receivedMessage.sender_id);
                    Console.WriteLine($"\nОтправитель: {sender.FirstName} {sender.LastName}\n" +
                        $"Сообщение: {receivedMessage.content}\n");
                }
            }
        }
    }
}
