using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.PLL.AlertWriters;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendRequestAcceptingView
    {
        FriendService _friendService;

        public UserFriendRequestAcceptingView(FriendService friendService)
        {
            _friendService = friendService;
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
                    Console.WriteLine($"\n№{request.Key}. Пользователь с Id {request.Value.user_id} хочет добавить вас в друзья\n");
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
