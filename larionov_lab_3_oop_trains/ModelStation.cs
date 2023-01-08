﻿namespace larionov_lab_3_oop_trains
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

    }
}
