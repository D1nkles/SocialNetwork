using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.AlertWriters;

namespace SocialNetwork.PLL.Views
{
    public class AuthenticationView
    {
        UserService userService;

        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show() 
        {
            var authenticationData = new UserAuthenticationData();

            Console.Write("Введите почтовый адрес: ");
            authenticationData.Email = Console.ReadLine();

            Console.Write("Введите пароль: ");
            authenticationData.Password = Console.ReadLine();

            try
            {
                User user = userService.Authenticate(authenticationData);

                SuccessMessage.ShowMessage($"Вы успешно вошли в социальную сеть! " +
                    $"Добро пожаловать {user.FirstName}.\n");

                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException)
            {
                ErrorMessage.ShowMessage("Пароль не корректный!\n");
            }
            catch (UserNotFoundException)
            {
                ErrorMessage.ShowMessage("Пользователь не найден!\n");
            }
        }
    }
}
