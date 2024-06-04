using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.AlertWriters;

namespace SocialNetwork.PLL.Views
{
    public class RegistrationView
    {
        UserService _userService;

        public RegistrationView(UserService userService)
        {
            _userService = userService;
        }

        public void Show() 
        {
            var userRegistrationData = new UserRegistrationData();

            Console.Write("Для создания нового профиля введите ваше имя: ");
            userRegistrationData.FirstName = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            userRegistrationData.LastName = Console.ReadLine();

            Console.Write("Пароль: ");
            userRegistrationData.Password = Console.ReadLine();

            Console.Write("Почтовый адрес: ");
            userRegistrationData.Email = Console.ReadLine();

            try
            {
                _userService.Register(userRegistrationData);

                SuccessMessage.ShowMessage("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
            }
            catch (ArgumentNullException)
            {
                ErrorMessage.ShowMessage("Введите корректное значение.");
            }
            catch (Exception)
            {
                ErrorMessage.ShowMessage("Произошла ошибка при регистрации.");
            }
        }
    }
}
