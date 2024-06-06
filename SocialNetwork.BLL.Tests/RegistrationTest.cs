using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
namespace SocialNetwork.BLL.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            UserService userService = new UserService();

            UserRegistrationData registrationData = new UserRegistrationData()
            {
                FirstName = "Мэттью",
                LastName = "Бэллами",
                Email = "matthew@gmail.com",
                Password = "museCool"
            };

            userService.Register(registrationData);

            var user = userService.FindByEmail(registrationData.Email);
            Assert.That(user.Email == registrationData.Email && user.FirstName == registrationData.FirstName &&
                        user.LastName == registrationData.LastName && user.Password == registrationData.Password);
        }
    }
}