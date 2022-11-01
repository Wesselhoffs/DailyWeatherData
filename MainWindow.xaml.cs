using DailyWeatherData.Classes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DailyWeatherData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DailyWeather> dailyWeathers = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addWeatherDatabtn_Click(object sender, RoutedEventArgs e)
        {
            bool sunnyOrNot = false, degreesParsed = false, windParsed = false;
            double windSpeed = 0, degrees = 0;
            if ((bool)sunnyRadiobtn.IsChecked)
            {
                sunnyOrNot = true;
            }
            else if ((bool)notSunnyRadiobtn.IsChecked)
            {
                sunnyOrNot = false;
            }
            else
            {
                MessageBox.Show("Du måste välja soligt eller inte", "Soligt?");
            }

            if (degreesTextBox.Text != null)
            {
                degreesParsed = double.TryParse(degreesTextBox.Text, out degrees);
                if (!degreesParsed)
                {
                    MessageBox.Show("Du har inte angett ett giltigt gradantal\nEndast siffror och kommatecken", "Fel gradantal");
                }
            }
            else
            {
                MessageBox.Show("Du måste ange grader", "Ange grader");
            }


            if (windspeedTextBox.Text != null)
            {
                windParsed = double.TryParse(windspeedTextBox.Text, out windSpeed);
            }
            else
            {
                MessageBox.Show("Du måste ange temperatur", "Ange temp");
            }
            if (windParsed && degreesParsed && ((bool)sunnyRadiobtn.IsChecked || (bool)notSunnyRadiobtn.IsChecked))
            {
                DailyWeather weather = new DailyWeather(sunnyOrNot, windSpeed, degrees);
                dailyWeathers.Add(weather);
                MessageBox.Show("Dagen tillagd!");
                ClearContent();
                DisplayContent();
            }
        }

        private void ClearContent()
        {
            windspeedTextBox.Clear();
            degreesTextBox.Clear();
            sunnyRadiobtn.IsChecked = false;
            notSunnyRadiobtn.IsChecked = false;
        }

        public void DisplayContent()
        {
            weatherList.ItemsSource = null;
            weatherList.ItemsSource = dailyWeathers;
        }
    }
}
