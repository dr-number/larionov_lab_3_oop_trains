namespace larionov_lab_3_oop_trains
{
    internal class MyMessages
    {
        public static bool isQuestion(string textQuestion)
        {
            Console.WriteLine("\n" + textQuestion);
            return Console.ReadLine()?.ToLower() != "n";
        }

        public static string capitalize(string s)
        {
            if (s == "")
                return "";

            return s.Substring(0, 1).ToUpper() + s.Remove(0, 1);
        }

        public static string convertToTitle(string text)
        {
            return capitalize(text.Trim());
        }
    }
}
