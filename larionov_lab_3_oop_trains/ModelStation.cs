namespace larionov_lab_3_oop_trains
{
    internal class ModelStation
    {
        private List<ModelTrain> trains = new List<ModelTrain>();

        public ModelTrain getTrain(int index)
        {
            if (trains == null || index < 0 || index >= trains.Count)
                return null;

            return trains[index];
        }


        public void addTrain(ModelTrain train)
        {
            trains.Add(train);
        }

        public List<ModelTrain> getAllTrains()
        {
            return trains;
        }

        public List<ModelTrain> getTrainsDepartureTimeMoreThem(MyTime time)
        {
            List<ModelTrain> result = new List<ModelTrain>();

            foreach (ModelTrain item in trains)
                if(item.DepartureTime > time)
                    result.Add(item);

            return result;
        }

    }
}
