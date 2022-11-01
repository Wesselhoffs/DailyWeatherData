using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace DailyWeatherData.Classes
{
    internal class DailyWeather
    {
        public string DisplayData { get; set; }
        public DateTime Date { get; set; }
        public bool Sunny { get; set; }
        public double Windspeed { get; set; }
        public double Degrees { get; set; }

        public DailyWeather()
        {
        }

        public DailyWeather(bool sunny, double windspeed, double degrees)
        {
            Sunny = sunny;
            Windspeed = windspeed;
            Degrees = degrees;
            Date = DateTime.Now;

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
