using DailyWeatherData.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace DailyWeatherData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<DailyWeather>? dailyWeathers = new();
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
                if (!windParsed)
                {
                    MessageBox.Show("Du har inte angett en giltid vindhastighet\nEndast siffror och kommatecken", "Fel vindhastighet");
                }
            }
            else
            {
                MessageBox.Show("Du måste ange temperatur", "Ange temp");
            }
            if (windParsed && degreesParsed && ((bool)sunnyRadiobtn.IsChecked || (bool)notSunnyRadiobtn.IsChecked))
            {
                DateTime? date = datePicker.SelectedDate;
                if (date != null)
                {
                    DailyWeather weather = new DailyWeather(sunnyOrNot, windSpeed, degrees, (DateTime)date);
                    dailyWeathers.Add(weather);
                    MessageBox.Show("Dagen tillagd!", "Grattis!");
                    ClearContent();
                    DisplayContent();
                }
                else
                {
                    MessageBox.Show("Du måste ange ett datum", "Ange Datum!!!!");
                    return;
                }
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

        private async void saveDatabtn_Click(object sender, RoutedEventArgs e)
        {
            await SerializeList();
            weatherList.ItemsSource = null;
        }
        private async void loadDatabtn_Click(object sender, RoutedEventArgs e)
        {
            await DeserializeList();
            DisplayContent();
        }

        private async Task DeserializeList()
        {
            using (FileStream fileStream = File.OpenRead("weatherdata.json"))
            {
                dailyWeathers = await JsonSerializer.DeserializeAsync<List<DailyWeather>>(fileStream);
            }
        }

        private async Task SerializeList()
        {
            using (FileStream fileStream = File.Create("weatherdata.json"))
            {
                await JsonSerializer.SerializeAsync(fileStream, dailyWeathers);
                await fileStream.DisposeAsync();
            }
        }

    }
}
