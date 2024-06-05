using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.AlertWriters;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;
        static FriendService friendService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserReceivedMessageView userReceivedMessageView;
        public static UserSentMessageView userSentMessageView;
        public static UserFriendRequestSendingView userFriendRequestSendingView;
        public static UserFriendRequestAcceptingView userFriendRequestAcceptingView;

        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView(userService, messageService, friendService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(userService, messageService);
            userReceivedMessageView = new UserReceivedMessageView(messageService);
            userSentMessageView = new UserSentMessageView(messageService);
            userFriendRequestSendingView = new UserFriendRequestSendingView(friendService);
            userFriendRequestAcceptingView = new UserFriendRequestAcceptingView(friendService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}