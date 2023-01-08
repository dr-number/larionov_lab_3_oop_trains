namespace larionov_lab_3_oop_trains
{
    internal class ModelTrain
    {
        private string number;
        public string Number
        {
            get => number;
            set => number = value;
        }
        private string destination;
        
        public string Destination
        {
            get => destination;
            set => destination = value;
        }

        private MyTime departureTime;
        public MyTime DepartureTime
        {
            get => departureTime;
            set => departureTime = value;
        }

        public int CompareTo(ModelTrain t)
        {
            if (DepartureTime > t.DepartureTime)
            {
                return 1;
            }
            else if (DepartureTime < t.DepartureTime)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public string getTimeString()
        {
            return $"{departureTime.getHour()}:{departureTime.getMinute()}";
        }

        public static bool operator >(ModelTrain t1, ModelTrain t2)
        {
            return t1.DepartureTime > t2.DepartureTime;
        }
        public static bool operator <(ModelTrain t1, ModelTrain t2)
        {
            return t1.DepartureTime < t2.DepartureTime;
        }
        public static bool operator ==(ModelTrain t1, ModelTrain t2)
        {
            return t1.DepartureTime == t2.DepartureTime;
        }
        public static bool operator !=(ModelTrain t1, ModelTrain t2)
        {
            return t1.DepartureTime != t2.DepartureTime;
        }

    }

    class ModelTrainSort : IComparer<ModelTrain>
    {
        public int Compare(ModelTrain t1, ModelTrain t2)
        {
            return t1.CompareTo(t2);
        }
    }

}
