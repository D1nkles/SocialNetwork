namespace SocialNetwork.PLL.AlertWriters
{
    public class SuccessMessage
    {
        public static void ShowMessage(string message)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}
