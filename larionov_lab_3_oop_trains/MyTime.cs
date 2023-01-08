
namespace larionov_lab_3_oop_trains
{
    internal class MyTime
    {
        private int hour;
        public void setHour(int hour) { this.hour = hour; }
        public int getHour() { return hour; }

        public int minute;
        public void setMinute(int minute) { this.minute = minute; }
        public int getMinute() { return minute; }


        public static bool operator >(MyTime t1, MyTime t2)
        {
            int time1 = t1.hour * 60 + t1.minute;
            int time2 = t2.hour * 60 + t2.minute;
            return time1 > time2;
        }
        public static bool operator <(MyTime t1, MyTime t2)
        {
            int time1 = t1.hour * 60 + t1.minute;
            int time2 = t2.hour * 60 + t2.minute;
            return time1 < time2;
        }
        public static bool operator ==(MyTime t1, MyTime t2)
        {
            int time1 = t1.hour * 60 + t1.minute;
            int time2 = t2.hour * 60 + t2.minute;
            return time1 == time2;
        }
        public static bool operator !=(MyTime t1, MyTime t2)
        {
            int time1 = t1.hour * 60 + t1.minute;
            int time2 = t2.hour * 60 + t2.minute;
            return time1 != time2;
        }

    }
}
