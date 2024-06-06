using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.PLL.Views
{
    public class UserFriendListView
    {
        FriendService _friendService;

        public UserFriendListView(FriendService friendService)
        {
            _friendService = friendService;
        }

        public void Show(User user)
        {
            var friendList = _friendService.GetFriendsInfo(user.Id);

            if (friendList.Count() == 0)
                Console.WriteLine("\nУ вас пока что нет друзей...\n");
            else
            {
                int friendCount = 1;
                Console.WriteLine("\nСписок ваших друзей:\n");
                foreach (UserEntity friend in friendList)
                {
                    Console.WriteLine($"{friendCount}. Имя и фамилия: {friend.firstname} {friend.lastname}.\n" +
                                      $"    Email: {friend.email}\n");
                    friendCount++;
                }
            }
            Console.WriteLine();
        }
    }
}
