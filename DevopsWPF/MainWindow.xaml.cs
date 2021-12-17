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


namespace DevopsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        ClubRepository clubRepository = new ClubRepository();

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
                listClub.Items.Remove(i);

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
