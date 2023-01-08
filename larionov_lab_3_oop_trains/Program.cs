namespace larionov_lab_3_oop_trains
{
    class Class1
    {
        private const string EXIT = "0";

        private const int MIN_COUNT_TRAIN = 3;
        private const int MAX_COUNT_TRAIN = 10;

        static void Main(string[] args)
        {
            Console.WriteLine("Варинат №16. Железнодорожный вокзал. Ларионов Никита Юрьевич. гр. 210з\n");
            MyInput myInput = new MyInput();

            bool isGo = true;
            string select;
            Stantion stantion;

            while (isGo)
            {
                Console.ResetColor();
                Console.WriteLine($"\nЧтобы выйти ввидите {EXIT}");
                select = Console.ReadLine();

                stantion = new Stantion();

                if (select == EXIT)
                    isGo = false;
                else
                {
                    if (MyMessages.isQuestion(Constants.QUESTION_LOAD_FROM_FILE))
                    {

                    }
                    else
                    {
                        int countTrains = myInput.inputInterval("Сколько поездов добавить на станцию?: ", MIN_COUNT_TRAIN, MAX_COUNT_TRAIN);

                        for (int i = 0; i < countTrains; i++)
                            stantion.addTrain();

                    }
                }

            }

        }
    }
}