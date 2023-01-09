namespace larionov_lab_3_oop_trains
{
    internal class Stantion
    {
        private ModelStation stantion = new ModelStation();

        public void addTrain()
        {
            MyInput myInput = new MyInput();
            ModelTrain train = new ModelTrain();

            train.Number = MyMessages.capitalize(myInput.inputText("Введите номер поезда (может содержать буквы и цифры): "));
            train.DepartureTime = myInput.inputTime("Введите время отправления: ");
            train.Destination = MyMessages.capitalize(myInput.inputText("Введите название пункта назначения: "));

            stantion.addTrain(train);
        }

        public List<ModelTrain> getAllTrains()
        {
            return stantion.getAllTrains();
        }

        public void setAllTrains(List<ModelTrain> trains)
        {
            stantion.setAllTrains(trains);
        }

        public List<ModelTrain> getTrainsDepartureTimeMoreThem(MyTime time)
        {
            List<ModelTrain> result = new List<ModelTrain>();

            foreach (ModelTrain item in getAllTrains())
                if (item.DepartureTime > time)
                    result.Add(item);

            return result;
        }

        public List<ModelTrain> trainsWithDestination(string destination)
        {
            List<ModelTrain> result = new List<ModelTrain>();
            destination = destination.ToLower();

            foreach (ModelTrain item in getAllTrains())
                if (item.Destination.ToLower() == destination)
                    result.Add(item);

            return result;
        }

        public void printTrains(List<ModelTrain> data)
        {
            Console.WriteLine("{0,30}|   {1,30}|   {2,30}", "Номер поезда", "Время отправления", "Пункт назначения");

            foreach (var item in data)
                Console.WriteLine("{0,30}|   {1,30}|   {2,30}", item.Number, item.DepartureTime.getTimeString(), item.Destination);

            if(data.Count != 0)
                MyMessages.printMessage($"\nКоличество поездов: {data.Count}", ConsoleColor.Yellow);
            else
                MyMessages.printMessage($"\nПоездов нет!", ConsoleColor.Red);
        }

        public bool saveToFile(string fileName, List<ModelTrain> data)
        {
            StreamWriter file = null;
            bool result = false;
            try
            {
                file = new StreamWriter(fileName);
                foreach (var item in data)
                    file.WriteLine($"{item.Number}, {MyMessages.capitalize(item.Destination)}, {item.DepartureTime.getTimeString()}");

                file.Close();
                result = true;
            }
            catch (Exception e)
            {
                MyMessages.printMessage($"Ошибка при записи в файл: {e.Message}", ConsoleColor.Red);
                result = false;
            }
            finally
            {
                try
                {
                    file.Close();
                }
                catch (Exception ignore) { }
            }

            if (result)
                MyMessages.printMessage($"\nДанные успешно сохранены в файл: {fileName}!", ConsoleColor.Green);
            else
                MyMessages.printMessage($"\nОшибка при сохранении данных в файл: {fileName}!", ConsoleColor.Red);

            return result;
        }

        public List<ModelTrain> loadFromFile(string kFileName)
        {
            if (!File.Exists(kFileName))
            {
                MyMessages.printMessage($"Файл {kFileName} не существует!", ConsoleColor.Red);
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
                        train.Destination = MyMessages.capitalize(destination);

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
                MyMessages.printMessage($"Ошибка при чтении из файла: {e.Message}", ConsoleColor.Red);
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

        public List<ModelTrain> sort(List<ModelTrain> data)
        {
            data.Sort(new ModelTrainSort());
            return data;
        }
    }
}
