namespace System
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Calcula la edad a partir de la fecha dada.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int CalculateAge(this DateTime dateTime)
        {
            return DateTime.Today.AddTicks(-dateTime.Ticks).Year - 1;
        }
    }
}
