using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    public class MainView
    {
        public void Show() 
        {
            Console.WriteLine("Войти в профиль (введите 1)");
            Console.WriteLine("Зарегистрироваться (введите 2)");

            switch (Console.ReadLine()) 
            {
                case "1":
                    Program.authenticationView.Show();
                    break;

                case "2":
                    Program.registrationView.Show();
                    break;
            }
        }
    }
}
