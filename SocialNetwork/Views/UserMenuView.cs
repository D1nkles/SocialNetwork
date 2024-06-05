using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService _userService;
        MessageService _messageService;
        bool _isLogged;
        public UserMenuView(UserService userService, MessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }
        public void Show(User user)
        {
            _isLogged = true;
            while (_isLogged == true)
            {
                Console.WriteLine($"Входящих сообщений - {_messageService.GetReceivedMessagesCount(user)}");
                Console.WriteLine($"Отправленных сообщений - {_messageService.GetSentMessagesCount(user)}\n");

                Console.WriteLine(">>Просмотреть информацию о моём профиле (введите 1)");
                Console.WriteLine(">>Редактировать мой профиль (введите 2)");
                Console.WriteLine(">>Добавить в друзья (введите 3)");
                Console.WriteLine(">>Написать сообщение (введите 4)");
                Console.WriteLine(">>Посмотреть входящие сообщения (введите 5)");
                Console.WriteLine(">>Посмотреть отправленные сообщения (введите 6)");
                Console.WriteLine(">>Выйти из профиля (введите 7)");

                switch (Console.ReadLine()) 
                {
                    case "7":
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

                    case "6":
                        Program.userSentMessageView.Show(user);
                        break;
                }
            }
        }
    }
}
