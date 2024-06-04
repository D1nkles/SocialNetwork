using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService() 
        {
            _userRepository = new UserRepository();
        }
        public void Register(UserRegistrationData userRegistrationData) 
        {
            if (string.IsNullOrEmpty(userRegistrationData.FirstName) || string.IsNullOrEmpty(userRegistrationData.LastName) ||
                string.IsNullOrEmpty(userRegistrationData.Password) || string.IsNullOrEmpty(userRegistrationData.Email))
            {
                throw new ArgumentNullException();
            }

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                email = userRegistrationData.Email,
                password = userRegistrationData.Password,
            };

            if (_userRepository.Create(userEntity) == 0)
                throw new Exception();
        }
    }
}
