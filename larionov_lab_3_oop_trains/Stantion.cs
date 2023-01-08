namespace larionov_lab_3_oop_trains
{
    internal class Stantion
    {
        private ModelStation stantion = new ModelStation();

        public void addTrain()
        {
            MyInput myInput = new MyInput();
            ModelTrain train = new ModelTrain();

            train.Number = myInput.inputText("Введите номер поезда (может содержать буквы и цифры): ");
            train.DepartureTime = myInput.inputTime("Введите время отправления: ");
            train.Destination = myInput.inputText("Введите название пункта назначения: ");

            stantion.addTrain(train);
        }

        private List<ModelTrain> loadFromFile(string kFileName)
        {
            if (!File.Exists(kFileName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл {kFileName} не существует!");
                return null;
            }

            StreamReader file = null;
            List<ModelTrain> result = new List<ModelTrain>();

            try
            {
                ModelTrain train;
                file = new StreamReader(kFileName);

                while (!file.EndOfStream)
                {
                    try
                    {
                        var (number, destination, departureTime) = file.ReadLine().Split(", ") switch { var a => (a[0], a[1], a[2]) };
                        var (hour, minute) = departureTime.Split(":") switch { var a => (a[0], a[1]) };

                        train = new ModelTrain();
                        train.Number = number;
                        train.Destination = destination;

                        MyTime time = new MyTime();
                        time.setHour(int.Parse(hour));
                        time.setMinute(int.Parse(minute));

                        train.DepartureTime = time;
                        result.Add(train);
                    }
                    catch (Exception ignore) { }

                }
                file.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при чтении из файла: {e.Message}");
            }
            finally
            {
                try
                {
                    file.Close();
                }
                catch (Exception ignore) { }
            }

            return result;
        }
    }
}
