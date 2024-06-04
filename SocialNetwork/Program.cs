using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace SocialNetwork
{
    class Program
    {
        public static UserService userService = new UserService();
        public static MessageService messageService = new MessageService();
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в нашу соц-сеть\n\n");

            while (true)
            {
                Console.WriteLine("Войти в профиль (введите 1)");
                Console.WriteLine("Зарегистрироваться (введите 2)");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            var authenticationData = new UserAuthenticationData();
                            
                            Console.Write("Введите почтовый адрес: ");
                            authenticationData.Email = Console.ReadLine();

                            Console.Write("Введите пароль: ");
                            authenticationData.Password = Console.ReadLine();

                            try
                            {
                                User user = userService.Authenticate(authenticationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Вы успешно вошли в социальную сеть! Добро пожаловать {user.FirstName}");
                                Console.ForegroundColor = ConsoleColor.White;

                                while (true)
                                {
                                    Console.WriteLine("Просмотреть информацию о моём профиле (введите 1)");
                                    Console.WriteLine("Редактировать мой профиль (введите 2)");
                                    Console.WriteLine("Добавить в друзья (введите 3)");
                                    Console.WriteLine("Написать сообщение (введите 4)");
                                    Console.WriteLine("Посмотреть сообщения (введите 5)");
                                    Console.WriteLine("Выйти из профиля (введите 6)");

                                    switch (Console.ReadLine())
                                    {
                                        case "1":
                                            {
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Информация о моем профиле");
                                                Console.WriteLine($"Мой идентификатор: {user.Id}");
                                                Console.WriteLine($"Меня зовут: {user.FirstName}");
                                                Console.WriteLine($"Моя фамилия: {user.LastName}");
                                                Console.WriteLine($"Мой пароль: {user.Password}");
                                                Console.WriteLine($"Мой почтовый адрес: {user.Email}");
                                                Console.WriteLine($"Ссылка на моё фото: {user.Photo}");
                                                Console.WriteLine($"Мой любимый фильм: {user.FavoriteMovie}");
                                                Console.WriteLine($"Моя любимая книга: {user.FavoriteBook}");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.Write("Меня зовут: ");
                                                user.FirstName = Console.ReadLine();

                                                Console.Write("Моя фамилия: ");
                                                user.LastName = Console.ReadLine();

                                                Console.Write("Ссылка на моё фото: ");
                                                user.Photo = Console.ReadLine();

                                                Console.Write("Мой любимый фильм: ");
                                                user.FavoriteMovie = Console.ReadLine();

                                                Console.Write("Моя любимая книга: ");
                                                user.FavoriteBook = Console.ReadLine();

                                                userService.Update(user);

                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Ваш профиль успешно обновлён!");
                                                Console.ForegroundColor = ConsoleColor.White;

                                                break;
                                            }
                                        case "4":
                                            {
                                                MessageData message = new MessageData();

                                                message.SenderId = user.Id;

                                                Console.Write("Введите адрес электронной почты получателя: ");
                                                message.RecipientEmail = Console.ReadLine();

                                                Console.Write("Введите текст сообщения: ");
                                                message.Content = Console.ReadLine();
                                                try 
                                                {
                                                    messageService.SendMessage(message);
                                                }
                                                catch (ArgumentNullException) 
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка! Введены некорректные данные.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch(UserNotFoundException) 
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка! Получатель с такой почтой не зарегистрирован.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch (ArgumentOutOfRangeException) 
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Ошибка! Превышена максимальная длина сообщения.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                catch (Exception) 
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Произошла ошибка при отправке сообщения.");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                                break;
                                            
                                            }
                                        case "5":
                                            {
                                                var receivedMessages = messageService.GetReceivedMessages(user);
                                                foreach (var receivedMessage in receivedMessages)
                                                {
                                                    Console.WriteLine($"Id отправителя: {receivedMessage.sender_id}\n" +
                                                        $"Сообщение: {receivedMessage.content}\n");
                                                }
                                                break;
                                            }
                                    }
                                }

                            }
                            catch (WrongPasswordException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пароль не корректный!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (UserNotFoundException)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Пользователь не найден!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            break;
                        }

                    case "2":
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
                                userService.Register(userRegistrationData);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Ваш профиль успешно создан. Теперь Вы можете войти в систему под своими учетными данными.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            catch (ArgumentNullException)
                            {
                                Console.WriteLine("Введите корректное значение.");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Произошла ошибка при регистрации.");
                            }

                            break;
                        }
                }
            }
        }
    }
}