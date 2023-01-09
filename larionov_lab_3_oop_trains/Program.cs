namespace larionov_lab_3_oop_trains
{
    class Class1
    {
        private const string EXIT = "0";

        private const int MIN_COUNT_TRAIN = 3;
        private const int MAX_COUNT_TRAIN = 10;

        private const string INPUT_FILE_TRAINS = "file_trains.txt";
        private const string OUT_FILE_TRAINS_AFTER_TIME = "file_trains_after_time.txt";

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
                    stantion.loadFromFile(INPUT_FILE_TRAINS);
                else
                {
                    int countTrains = myInput.inputInterval("Сколько поездов добавить на станцию?: ", MIN_COUNT_TRAIN, MAX_COUNT_TRAIN);

                    for (int i = 0; i < countTrains; i++)
                        stantion.addTrain();

                }

                MyMessages.printMessage("Исходные данные: ", ConsoleColor.Yellow);
                stantion.printTrains(stantion.sort(stantion.getAllTrains()));

                afterTime = myInput.inputTime("Введите время");

                MyMessages.printMessage($"Поезда, отправляющиеся после: {afterTime.getTimeString()}", ConsoleColor.Yellow);

                List<ModelTrain> trainsAfterTime = stantion.sort(stantion.getTrainsDepartureTimeMoreThem(afterTime));
                stantion.printTrains(trainsAfterTime);

                if (trainsAfterTime.Count != 0 && MyMessages.isQuestion(Constants.QUESTION_SAVE_TO_FILE))
                    stantion.saveToFile(OUT_FILE_TRAINS_AFTER_TIME, trainsAfterTime);

                MyMessages.pause();
            }

        }
    }
}