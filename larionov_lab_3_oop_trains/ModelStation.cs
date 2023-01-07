namespace larionov_lab_3_oop_trains
{
    internal class ModelStation
    {
        private List<ModelTrain> trains;

        public ModelTrain getTrain(int index)
        {
            if (trains == null || index < 0 || index >= trains.Count)
                return null;

            return trains[index];
        }

        public List<ModelTrain> getTrains(DateTime afterDepartureTime)
        {
            List <ModelTrain> result = new List<ModelTrain>();

            foreach (var item in trains)
                if(item.DepartureTime > afterDepartureTime)
                    result.Add(item);

            return result;
        }

        public static bool operator ==(ModelTrain train1, ModelTrain train2)
        {
            return train1.DepartureTime == train2.DepartureTime;
        }

        public static bool operator !=(ModelTrain train1, ModelTrain train2)
        {
            return train1.DepartureTime != train2.DepartureTime;
        }
    }
}
