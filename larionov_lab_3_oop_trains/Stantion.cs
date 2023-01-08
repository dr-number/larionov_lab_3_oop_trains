namespace larionov_lab_3_oop_trains
{
    internal class Stantion
    {
        private ModelStation stantion = null;
        public Stantion(ModelStation stantion)
        {
            this.stantion = stantion;
        }
        public void addTrain()
        {
            MyInput myInput = new MyInput();
            ModelTrain train = new ModelTrain();

            train.Number = myInput.inputText("Введите номер поезда (может содержать буквы и цифры): ");
            train.DepartureTime = myInput.inputTime("Введите время отправления: ");
            train.Destination = myInput.inputText("Введите название пункта назначения: ");

            stantion.addTrain(train);
        }
    }
}
