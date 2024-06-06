using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views
{
    public class UserSentMessageView
    {
        MessageService _messageService;
        UserService _userService;

        public UserSentMessageView(MessageService messageService, UserService userService) 
        {
            _messageService = messageService;
            _userService = userService;
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
                    var recipient = _userService.FindById(sentMessage.recipient_id);
                    Console.WriteLine($"\nПолучатель: {recipient.FirstName} {recipient.LastName}\n" +
                        $"Сообщение: {sentMessage.content}\n");
                }
            }
        }
    }
}
