using SocialNetwork.BLL.Models;

namespace SocialNetwork.PLL.Views
{
    public class UserInfoView
    {
        public void Show(User user) 
        {
            Console.WriteLine("Информация о моем профиле");
            Console.WriteLine($"Мой идентификатор: {user.Id}");
            Console.WriteLine($"Меня зовут: {user.FirstName}");
            Console.WriteLine($"Моя фамилия: {user.LastName}");
            Console.WriteLine($"Мой пароль: {user.Password}");
            Console.WriteLine($"Мой почтовый адрес: {user.Email}");
            Console.WriteLine($"Ссылка на моё фото: {user.Photo}");
            Console.WriteLine($"Мой любимый фильм: {user.FavoriteMovie}");
            Console.WriteLine($"Моя любимая книга: {user.FavoriteBook}");
        }
    }
}
