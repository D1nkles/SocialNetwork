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
            var requesters = _friendRepository.FindAllByFriendId(user.Id).ToList();
            if (requesters.Count == 0)
            {
                return new Dictionary<string, FriendEntity>();
            }

            var requestDictionary = new Dictionary<string, FriendEntity>();
            int requestNum = 1;

            foreach (FriendEntity friend in requesters) 
            {
                bool check = CheckIfFriendAlready(friend.user_id, user.Id);
                if (check)
                    requesters.Remove(friend);

                if (requesters.Count == 0)
                    return requestDictionary;
            }

            foreach (FriendEntity friend in requesters) 
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

        public IEnumerable<FriendEntity> GetAllFriends(int userId) 
        {
            return _friendRepository.FindAllByUserId(userId);
        }
    }
}
