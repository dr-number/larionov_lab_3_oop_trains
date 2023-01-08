namespace larionov_lab_3_oop_trains
{
    internal class MyFiles
    {
        public bool saveToFile(string fileName, List<String> data)
        {
            StreamWriter file = null;
            bool result = false;
            try
            {
                file = new StreamWriter(fileName);
                foreach (var item in data)
                    file.WriteLine(item);

                file.Close();
                result = true;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка при записи в файл: {e.Message}");
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
                Console.WriteLine($"\nДанные успешно сохранены в файл: {fileName}!");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nОшибка при сохранении данных в файл: {fileName}!");
            }

            return result;
        }
    }
}
