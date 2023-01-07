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

        private DateTime departureTime;
        public DateTime DepartureTime
        {
            get => departureTime;
            set => departureTime = value;
        }

    }
}
