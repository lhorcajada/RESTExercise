namespace System
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime dateTime)
        {
            return DateTime.Today.AddTicks(-dateTime.Ticks).Year - 1;
        }
    }
}
