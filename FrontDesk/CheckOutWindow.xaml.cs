using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for CheckOutWindow.xaml
    /// </summary>
    public partial class CheckOutWindow : Window
    {
        public CheckOutWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void reservationsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Select that booking
            //need the databasemodel for this
            //var selectedBooking = (Booking)reservationsList.SelectedItem;
            //RoomNum.Text = selectedBooking.roomId.ToString();
            //CustomerName.Text = 
        }

        private void CheckOutBtn_Click(object sender, RoutedEventArgs e)
        {
            string name;
            int roomId;

            try
            {
                name = CustomerName.Text;
                roomId = int.Parse(RoomNum.Text);

                //Find the username from Customer and use that to find the right booking

                //Then remove the booking from the database and saving
                CustomerName.Text = RoomNum.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("This customer does not exist, try again!");
            }
        }
    }
}
