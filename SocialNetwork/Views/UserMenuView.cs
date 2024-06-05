using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService _userService;
        bool _isLogged;
        public UserMenuView(UserService userService)
        {
            _userService = userService;
        }
        public void Show(User user)
        {
            _isLogged = true;
            while (_isLogged == true)
            {
                Console.WriteLine(">>Просмотреть информацию о моём профиле (введите 1)");
                Console.WriteLine(">>Редактировать мой профиль (введите 2)");
                Console.WriteLine(">>Добавить в друзья (введите 3)");
                Console.WriteLine(">>Написать сообщение (введите 4)");
                Console.WriteLine(">>Посмотреть входящие сообщения (введите 5)");
                Console.WriteLine(">>Выйти из профиля (введите 6)");

                switch (Console.ReadLine()) 
                {
                    case "6":
                        _isLogged = false;
                        break;

                    case "1":
                        Program.userInfoView.Show(user);
                        break;

                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;

                    case "4":
                        Program.messageSendingView.Show(user);
                        break;

                    case "5":
                        Program.userReceivedMessageView.Show(user);
                        break;
                }
            }
        }
    }
}
