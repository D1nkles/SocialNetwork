using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork 
{
    class Program 
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в нашу соц-сеть\n\n");

            while (true)
            {
                Console.Write("Для регистрации введите имя пользователя: ");

                string firstname = Console.ReadLine();

                Console.Write("фамилию: ");

                string lastname = Console.ReadLine();

                Console.Write("пароль: ");

                string password = Console.ReadLine();

                Console.Write("адрес электронной почты: ");

                string email = Console.ReadLine();

                var userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистрация прошла успешно!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Ошибка! В поля с данными введены некоректные значения.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка! Не удалось создать учетную запись.");
                }

                Console.ReadLine();
            }
        }
    }
}