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
            var sentMessages = _messageService.GetSentMessages(user);

            if (sentMessages.Count() == 0)
                Console.WriteLine("\nВы не отправляли сообщений.\n");
            else
                foreach (MessageEntity sentMessage in sentMessages)
                {
                    Console.WriteLine($"\nId получателя: {sentMessage.recipient_id}\n" +
                        $"Сообщение: {sentMessage.content}\n");
                }
        }
    }
}
