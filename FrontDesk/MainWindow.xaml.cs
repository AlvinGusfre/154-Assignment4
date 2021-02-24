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

namespace FrontDesk
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

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckOutWindow().ShowDialog();
        }

        private void CheckInBtn_Click(object sender, RoutedEventArgs e)
        {
            new CheckInWindow().ShowDialog();
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            new AddNewWindow().ShowDialog();
        }

        private void OrderRoomService_Click(object sender, RoutedEventArgs e)
        {
            string type = "Room Service";
            int roomNumber;
            string description;
            string status;

            try
            {
                roomNumber = int.Parse(TaskEntryRoomNr.Text);
                DateTime timeAdded = DateTime.Now;
                status = "Pending";
                description = TaskEntryDescription.Text.Trim();

                //Lage en ny RoomServiceTask
                //legge denne i databasen
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Room number does not exist", "Room entry error", MessageBoxButton.OK);
            }
        }

        private void OrderMaintenance_Click(object sender, RoutedEventArgs e)
        {
            string type = "Maintenance";
            int roomNumber;
            string description;
            string status;

            try
            {
                roomNumber = int.Parse(TaskEntryRoomNr.Text);
                DateTime timeAdded = DateTime.Now;
                status = "Pending";
                description = TaskEntryDescription.Text.Trim();

                //Lage en ny MaintenanceTask
                //legge denne i databasen
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Room number does not exist", "Room entry error", MessageBoxButton.OK);
            }
        }

        private void reservationsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult msgResult = MessageBox.Show("Are you sure you want to delete this reservation?", "Delete", MessageBoxButton.YesNo);
            if(msgResult == MessageBoxResult.Yes)
            {
                //Delete reservation from database
            }
        }
    }
}
