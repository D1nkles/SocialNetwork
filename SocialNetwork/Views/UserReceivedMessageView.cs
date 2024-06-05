using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views
{
    public class UserReceivedMessageView
    {
        MessageService _messageService;

        public UserReceivedMessageView(MessageService messageService) 
        {
            _messageService = messageService;
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
                    Console.WriteLine($"\nId отправителя: {receivedMessage.sender_id}\n" +
                        $"Сообщение: {receivedMessage.content}\n");
                }
            }
        }
    }
}
