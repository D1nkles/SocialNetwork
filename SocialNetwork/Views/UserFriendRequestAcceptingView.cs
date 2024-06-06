using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.AlertWriters;
using System.Reflection.Metadata;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendRequestAcceptingView
    {
        FriendService _friendService;
        UserService _userService;

        public UserFriendRequestAcceptingView(FriendService friendService, UserService userService)
        {
            _friendService = friendService;
            _userService = userService;
        }

        public void Show(User user) 
        {
            if(_friendService.GetFriendRequestsCount(user) == 0)
                Console.WriteLine("\nВходящих заявок в друзья нет.\n");
            else
            {
                var requestList = _friendService.GetFriendRequests(user);
                
                foreach (KeyValuePair<string, FriendEntity> request in requestList) 
                {
                    var friend = _userService.FindById(request.Value.user_id);
                    Console.WriteLine($"\n№{request.Key}. Пользователь {friend.FirstName} {friend.LastName} хочет добавить вас в друзья\n");
                }
                Console.WriteLine("Одобрить заявку (введите номер заявки)\n" +
                                  "Вернуться в меню пользователя (введите 0)");
                string userInput = Console.ReadLine();

                if (requestList.ContainsKey(userInput))
                    _friendService.AcceptFriendRequest(user.Id, requestList[userInput].user_id);
                else if (userInput == "0")
                    return;
                else
                    ErrorMessage.ShowMessage("Ошибка! Введено неверное значение.");
            }
        }
    }
}
