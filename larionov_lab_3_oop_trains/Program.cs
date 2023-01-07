namespace larionov_lab_3_oop_trains
{
    class Class1
    {
        private const string REGISTRATION = "r";
        private const string AUTHORIZATION = "a";
        private const string LOGOUT = "z";
        private const string CATEGORY = "c";
        private const string BOOK = "b";
        private const string MY_BOOK = "m";
        private const string TASK_INFO = "i";
        private const string HELP_INFO = "h";
        private const string EXIT = "e";

        private static readonly string[] SELECT = new string[]
        {
            REGISTRATION,
            AUTHORIZATION,
            LOGOUT,
            CATEGORY,
            BOOK,
            TASK_INFO,
            HELP_INFO,
            MY_BOOK,
            EXIT
        };

        

        static void Main(string[] args)
        {
            Console.WriteLine("Варинат №16. Домашняя библиотека. Ларионов Никита Юрьевич. гр. 210з\n");

           

        }
    }
}