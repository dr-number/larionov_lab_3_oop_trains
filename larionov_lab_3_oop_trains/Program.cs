namespace larionov_lab_3_oop_trains
{
    class Class1
    {
        private const string EXIT = "0";

        private const int MIN_COUNT_TRAIN = 3;
        private const int MAX_COUNT_TRAIN = 10;
        private const string FILE_TRAINS = "file_trains.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Варинат №16. Железнодорожный вокзал. Ларионов Никита Юрьевич. гр. 210з\n");
            MyInput myInput = new MyInput();

            string select;
            Stantion stantion;
            MyTime afterTime;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine($"\nЧтобы выйти ввидите {EXIT}");
                select = Console.ReadLine();

                stantion = new Stantion();

                if (select == EXIT)
                    break;
                
                if (MyMessages.isQuestion(Constants.QUESTION_LOAD_FROM_FILE))
                    stantion.loadFromFile(FILE_TRAINS);
                else
                {
                    int countTrains = myInput.inputInterval("Сколько поездов добавить на станцию?: ", MIN_COUNT_TRAIN, MAX_COUNT_TRAIN);

                    for (int i = 0; i < countTrains; i++)
                        stantion.addTrain();

                }

                MyMessages.printMessage("Исходные данные: ", ConsoleColor.Yellow);
                stantion.printTrains(stantion.getAllTrains());

                afterTime = myInput.inputTime("Введите время");

                MyMessages.pause();
            }

        }
    }
}