using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.AlertWriters;

namespace SocialNetwork.PLL.Views
{
    public class MessageSendingView
    {
        UserService _userService;
        MessageService _messageService;

        public MessageSendingView(UserService userService, MessageService messageService) 
        {
            _userService = userService;
            _messageService = messageService;
        }

        public void Show(User user) 
        {
            MessageData message = new MessageData();

            message.SenderId = user.Id;

            Console.Write("Введите адрес электронной почты получателя: ");
            message.RecipientEmail = Console.ReadLine();

            Console.Write("Введите текст сообщения (не больше 5000 символов): ");
            message.Content = Console.ReadLine();

            try
            {
                _messageService.SendMessage(message);

                SuccessMessage.ShowMessage("Сообщение успешно отправленно!\n");
            }
            catch (ArgumentNullException)
            {
                ErrorMessage.ShowMessage("Ошибка! Введены некорректные данные.\n");
            }
            catch (UserNotFoundException)
            {
                ErrorMessage.ShowMessage("Ошибка! Получатель с такой почтой не зарегистрирован.\n");
            }
            catch (ArgumentOutOfRangeException)
            {
                ErrorMessage.ShowMessage("Ошибка! Превышена максимальная длина сообщения.\n");
            }
            catch (Exception)
            {
                ErrorMessage.ShowMessage("Произошла ошибка при отправке сообщения.\n");
            }
        }
    }
}
