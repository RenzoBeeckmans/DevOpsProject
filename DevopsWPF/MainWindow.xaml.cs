using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevopsWPF.Models;
using DevopsWPF.Dal;
using System.Net.Http;
using System.Net.Http.Headers;


namespace DevopsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ClubRepository clubRepository;
        private SortedSet<Club> clubs;
        public MainWindow()
        {
            InitializeComponent();
            clubRepository = new ClubRepository();
            clubs = new SortedSet<Club>(clubRepository.GetClubs());
           foreach (Club club in clubs)
            {
                string name = club.Name;
                listClub.Items.Add(name);
            }
        }

        private async Task ProcessRepositories()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v3.football.api-sports.io/standings?season=2020&league=39"),
                Headers =
    {
        { "x-rapidapi-host", "v3.football.api-sports.io" },
        { "x-rapidapi-key", "400a397821952a96300b0acd9bf8d12e" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                TestBox.Text = body;
            }
        }

        private void Button_Add_Club(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textClub.Text) && !listClub.Items.Contains(textClub.Text))
            {
                string name = textClub.Text;
                listClub.Items.Add(name);
                Club club = new Club { Name = name };
                clubRepository.InsertClub(club);
                textClub.Clear();    
            }
        }

        private void Button_Delete_Club(object sender, EventArgs e)
        {
            var i = listClub.SelectedItem;
            string name = listClub.SelectedValue.ToString();
            clubRepository.DeleteClub(name);
            Console.WriteLine(name);
                listClub.Items.Remove(i);

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
