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

            ApplicationContext db = new ApplicationContext();
            User user = new User(db);
            Library library = new Library(db);

            MyAuth myAuth = new MyAuth(user);

            Books books = new Books(library);
            Categories categories = new Categories(library, books);
            books.setCategoies(categories);

            bool isGo = true;
            bool isAuth, isAdmin;
            string select;

            while (isGo)
            {
                isAuth = myAuth.isAuth();
                isAdmin = isAuth ? myAuth.isAdmin(myAuth.getCurrentUser()) : false;
                NavigationMenu.updateAdminInfo(isAdmin);

                NavigationMenu.setTitle();

                Console.ResetColor();
                Console.WriteLine("\nВыберите действие: ");

                if (!isAuth)
                {
                    Console.WriteLine($"{REGISTRATION}) {Constants.REGISTRATION}");
                    Console.WriteLine($"{AUTHORIZATION}) {Constants.AUTHORIZATION}");
                }
                else
                {
                    Console.WriteLine($"{BOOK}) Книги");
                    Console.WriteLine($"{CATEGORY}) Категории");
                    Console.WriteLine($"{MY_BOOK}) Мои книги");
                    Console.WriteLine($"\n{LOGOUT}) {Constants.LOGOUT}");
                }

                Console.WriteLine($"\n{TASK_INFO}) О задании");
                Console.WriteLine($"{HELP_INFO}) Справка");
                Console.WriteLine($"\nДля выхода введите \"{EXIT}\": ");
                select = Console.ReadLine();

                if (!SELECT.Contains(select))
                {
                    MyMessages.printMessage(Constants.INCORRECT_DATA, ConsoleColor.Red);
                    continue;
                }

                if (select == EXIT)
                    isGo = false;
                else if (select == TASK_INFO)
                    MyMessages.printMessage(Constants.TASK_INFO, ConsoleColor.Yellow);
                else if (select == HELP_INFO)
                    MyMessages.printMessage(Constants.HELP_INFO, ConsoleColor.Yellow);
                else if (isAuth)
                {
                    if (select == CATEGORY)
                    {
                        NavigationMenu.setCurrentItem(NavigationMenu.CATEGORYES);
                        categories.open(isAdmin);
                    }
                    else if (select == BOOK)
                    {
                        NavigationMenu.setCurrentItem(NavigationMenu.BOOKS);
                        books.open(isAdmin);
                    }
                    else if (select == MY_BOOK)
                    {
                        NavigationMenu.setCurrentItem(NavigationMenu.BOOKS);
                        books.open(isAdmin, myAuth.getCurrentUser());
                    }
                    else if (select == LOGOUT)
                        myAuth.logout();
                }
                else
                {
                    if (select == REGISTRATION)
                    {
                        NavigationMenu.setCurrentItem(NavigationMenu.REGISTRATION);
                        myAuth.registration();
                    }
                    else if (select == AUTHORIZATION)
                    {
                        NavigationMenu.setCurrentItem(NavigationMenu.AUTHORIZATION);
                        myAuth.authorization();
                    }
                }

                NavigationMenu.setCurrentItem(NavigationMenu.MAIN);
                MyMessages.pause();
            }

        }
    }
}