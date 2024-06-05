using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.AlertWriters;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendRequestSendingView
    {
        FriendService _friendService;

        public UserFriendRequestSendingView(FriendService friendService) 
        {
            _friendService = friendService;
        }

        public void Show(User user) 
        {
            var friendRequestData = new FriendRequestData();

            friendRequestData.SenderId = user.Id;

            Console.Write("Введите адрес электронной почты пользователя, которого хотите добавить в друзья: ");
            friendRequestData.RecipientEmail = Console.ReadLine();

            try
            {
                _friendService.SendFriendRequest(friendRequestData);
                SuccessMessage.ShowMessage("Заявка в друзья успешно отправленна!\n");
            }
            catch (ArgumentNullException)
            {
                ErrorMessage.ShowMessage("Ошибка! Введены некорректные данные.\n");
            }
            catch (UserNotFoundException)
            {
                ErrorMessage.ShowMessage("Ошибка! Получатель с такой почтой не зарегистрирован.\n");
            }
            catch (UserIsFriendAlreadyException)
            {
                ErrorMessage.ShowMessage("Ошибка! Данный пользователь уже является вашим другом.\n");
            }
            catch (Exception)
            {
                ErrorMessage.ShowMessage("Произошла ошибка при отправке заявки в друзья!");
            }
        }
    }
}
