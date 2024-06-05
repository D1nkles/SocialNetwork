using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views
{
    public class UserSentMessageView
    {
        MessageService _messageService;

        public UserSentMessageView(MessageService messageService) 
        {
            _messageService = messageService;
        }

        public void Show(User user) 
        {
            if (_messageService.GetSentMessagesCount(user) == 0)
                Console.WriteLine("\nВы не отправляли сообщений.\n");
            else
            {
                var sentMessages = _messageService.GetSentMessages(user);

                foreach (MessageEntity sentMessage in sentMessages)
                {
                    Console.WriteLine($"\nId получателя: {sentMessage.recipient_id}\n" +
                        $"Сообщение: {sentMessage.content}\n");
                }
            }
        }
    }
}
