namespace larionov_lab_3_oop_trains
{
    class MyInput
    {
        public string inputText(string text)
        {
            string xStr;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);
                xStr = Console.ReadLine();

                if (xStr == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Constants.ERROR_EMPTY_STRING);
                }
                else break;
            }

            return xStr;
        }

        public int inputInterval(string text, int minValue, int maxValue)
        {

            string xStr = "";
            bool isNumber = false;
            int x = 0;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else if (x < minValue || x > maxValue)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Введите число в промежутке от {minValue} до {maxValue} включительно!\n");
                }
                else
                    break;
            }

            return x;
        }

        public MyTime inputTime(string text)
        {
            Console.ResetColor();
            Console.WriteLine(text);

            MyTime myTime = new MyTime();
            myTime.setHour(inputInterval("Введите час: ", 0, 23));
            myTime.setMinute(inputInterval("\nВведите минуты: ", 0, 59));
            return myTime;
        }

        public int inputInt(string text)
        {
            string xStr;
            bool isNumber;
            int x;

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine();
                isNumber = int.TryParse(xStr, out x);

                if (!isNumber)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{xStr} - не число\n");
                }
                else
                    break;
            }

            return x;
        }

    }
}
