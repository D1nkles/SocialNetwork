using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IFriendRepository _friendRepository;
        IUserRepository _userRepository;

        public FriendService() 
        {
            _friendRepository = new FriendRepository();
            _userRepository = new UserRepository();
        }

        public void SendFriendRequest(FriendRequestData friendRequestData) 
        {
            if (!new EmailAddressAttribute().IsValid(friendRequestData.RecipientEmail))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(friendRequestData.RecipientEmail) == null)
                throw new UserNotFoundException();

            if (CheckIfFriendAlready(friendRequestData))
                throw new UserIsFriendAlreadyException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendRequestData.SenderId,
                friend_id = _userRepository.FindByEmail(friendRequestData.RecipientEmail).id
            };

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public Dictionary<string, FriendEntity> GetFriendRequests(User user) 
        {
            var friendsAndRequesters = _friendRepository.FindAllByFriendId(user.Id).ToList();
            //Вот здесь добавил обработку этого случая
            if (friendsAndRequesters.Count == 0)
            {
                return new Dictionary<string, FriendEntity>();
            }

            var requests = new List<FriendEntity>();
            var requestDictionary = new Dictionary<string, FriendEntity>();
            int requestNum = 1;

            foreach (FriendEntity friend in friendsAndRequesters) 
            {
                bool check = CheckIfFriendAlready(friend.user_id, user.Id);
                if (!check)
                    requests.Add(friend);

                if (friendsAndRequesters.Count == 0)
                    return requestDictionary;
            }

            foreach (FriendEntity friend in requests) 
            {
                requestDictionary.Add(requestNum.ToString(), friend);
                requestNum++;
            }
            return requestDictionary;
        }

        public int GetFriendRequestsCount(User user)
        {
            return GetFriendRequests(user).Count;
        }

        public void AcceptFriendRequest(int userId, int friendId) 
        {
            var friendEntity = new FriendEntity()
            {
                user_id = userId,
                friend_id = friendId
            };

            if (_friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }

        public bool CheckIfFriendAlready(FriendRequestData friendRequestData) 
        {
            var friendList = GetAllFriends(friendRequestData.SenderId);
            int friendId = _userRepository.FindByEmail(friendRequestData.RecipientEmail).id;

            foreach (FriendEntity friend in friendList) 
            {
                if ( friendId == friend.friend_id) 
                    return true;
            }
            return false;
        }

        public bool CheckIfFriendAlready(int friendId, int userId)
        {
            var friendList = GetAllFriends(userId);

            foreach (FriendEntity friend in friendList)
            {
                if (friendId == friend.friend_id)
                    return true;
            }
            return false;
        }

        public List<UserEntity> GetFriendsInfo(int userId) 
        {
            var friends = GetAllFriends(userId);
            var friendsInfo = new List<UserEntity>();

            foreach(FriendEntity friend in friends)
            {
                var friendInfo = _userRepository.FindById(friend.friend_id);
                friendsInfo.Add(friendInfo);
            }
            return friendsInfo;
        }

        public IEnumerable<FriendEntity> GetAllFriends(int userId) 
        {
            return _friendRepository.FindAllByUserId(userId);
        }
    }
}
