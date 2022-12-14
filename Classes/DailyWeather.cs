using System;

namespace DailyWeatherData.Classes
{
    internal class DailyWeather
    {
        public string DisplayData { get; set; }
        public DateTime Date { get; set; }
        public bool Sunny { get; set; }
        public double Windspeed { get; set; }
        public double Degrees { get; set; }

        public DailyWeather(bool sunny, double windspeed, double degrees, DateTime date)
        {
            Sunny = sunny;
            Windspeed = windspeed;
            Degrees = degrees;
            Date = date;

            if (sunny)
            {
                DisplayData = $"Dag: {Date.ToString("yy/MM/dd")}\nSoligt Vind: {windspeed}m/s  Grader: {degrees} C";
            }
            else
            {
                DisplayData = $"Dag: {Date.ToString("yy/MM/dd")}\nInte Soligt Vind: {windspeed}m/s  Grader: {degrees} C";
            }

        }
    }
}
