using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork.PLL.Views
{
    public class UserMenuView
    {
        UserService _userService;
        MessageService _messageService;
        FriendService _friendService;
        bool _isLogged;
        public UserMenuView(UserService userService, MessageService messageService, FriendService friendService)
        {
            _userService = userService;
            _messageService = messageService;
            _friendService = friendService;
        }
        public void Show(User user)
        {
            _isLogged = true;
            while (_isLogged == true)
            {
                Console.WriteLine($"Входящих сообщений - {_messageService.GetReceivedMessagesCount(user)}");
                Console.WriteLine($"Отправленных сообщений - {_messageService.GetSentMessagesCount(user)}");
                Console.WriteLine($"Заявок в друзья - {_friendService.GetFriendRequestsCount(user)}\n");

                Console.WriteLine(">>Просмотреть информацию о моём профиле (введите 1)");
                Console.WriteLine(">>Редактировать мой профиль (введите 2)");
                Console.WriteLine(">>Отправить заявку в друзья (введите 3)");
                Console.WriteLine(">>Принять заявку в друзья (введите 4)");
                Console.WriteLine(">>Написать сообщение (введите 5)");
                Console.WriteLine(">>Посмотреть входящие сообщения (введите 6)");
                Console.WriteLine(">>Посмотреть отправленные сообщения (введите 7)");
                Console.WriteLine(">>Выйти из профиля (введите 8)");

                switch (Console.ReadLine()) 
                {
                    case "8":
                        _isLogged = false;
                        break;

                    case "1":
                        Program.userInfoView.Show(user);
                        break;

                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;

                    case "3":
                        Program.userFriendRequestSendingView.Show(user);
                        break;

                    case "4":
                        Program.userFriendRequestAcceptingView.Show(user);
                        break;

                    case "5":
                        Program.messageSendingView.Show(user);
                        break;

                    case "6":
                        Program.userReceivedMessageView.Show(user);
                        break;

                    case "7":
                        Program.userSentMessageView.Show(user);
                        break;
                }
            }
        }
    }
}
