namespace larionov_lab_3_oop_trains
{
    class Class1
    {
        private const string EXIT = "0";

        private const int MIN_COUNT_TRAIN = 3;
        private const int MAX_COUNT_TRAIN = 10;

        private const string INPUT_FILE_TRAINS = "file_trains.txt";
        private const string OUT_FILE_TRAINS_AFTER_TIME = "file_trains_after_time.txt";
        private const string OUT_FILE_TRAINS_WITH_DESTINATION = "file_trains_with_destination.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Варинат №16. Железнодорожный вокзал. Ларионов Никита Юрьевич. гр. 210з\n");
            MyInput myInput = new MyInput();

            string select, findWithDestination;
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

                afterTime = myInput.inputTime("Поиск поездов время отправления которых больше чем: ");
                List<ModelTrain> trainsAfterTime = stantion.sort(stantion.getTrainsDepartureTimeMoreThem(afterTime));

                MyMessages.printMessage($"Поезда, отправляющиеся после: {afterTime.getTimeString()}", ConsoleColor.Yellow);
                stantion.printTrains(trainsAfterTime);

                if (trainsAfterTime.Count != 0 && MyMessages.isQuestion(Constants.QUESTION_SAVE_TO_FILE))
                    stantion.saveToFile(OUT_FILE_TRAINS_AFTER_TIME, trainsAfterTime);

                findWithDestination = myInput.inputText("Поиск поездов по пункту назначения: ");
                List<ModelTrain> trainsWithDestination = stantion.sort(stantion.trainsWithDestination(findWithDestination));

                MyMessages.printMessage($"Поезда, отправляющиеся в пункт назначения: {findWithDestination}", ConsoleColor.Yellow);
                stantion.printTrains(trainsWithDestination);

                if (trainsWithDestination.Count != 0 && MyMessages.isQuestion(Constants.QUESTION_SAVE_TO_FILE))
                    stantion.saveToFile(OUT_FILE_TRAINS_WITH_DESTINATION, trainsWithDestination);

                MyMessages.pause();
            }

        }
    }
}