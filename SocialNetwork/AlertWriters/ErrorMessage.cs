namespace SocialNetwork.PLL.AlertWriters
{
    public class ErrorMessage
    {
        public static void ShowMessage(string message) 
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}
