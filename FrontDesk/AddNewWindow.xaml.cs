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
    /// Interaction logic for AddNewWindow.xaml
    /// </summary>
    public partial class AddNewWindow : Window
    {
        public AddNewWindow()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullName;
            int numberOfBeds;
            DateTime checkInDate;
            DateTime checkOutTime;

            try
            {
                numberOfBeds = int.Parse(NumBeds.Text);
                fullName = CustomerName.Text;
                checkInDate = DateTime.Parse(CheckInDate.Text);
                checkOutTime = DateTime.Parse(CheckOutDate.Text);

                //Get the list of available rooms from the database, with the correct amount of beds
                //List<Room> availableRooms = 
                //Room room = null


                //foreach (var a in availableRooms)
                //{
                //    if(checkDate(checkInDate, checkOutTime, roomId))
                //    {
                //        room = a;
                //        break;
                //    }
                //}
                //    if(room != null)
                //    {
                //        try
                //        {
                //            Booking b = new Booking(fullName, numberOfBeds, checkInDate, checkOutTime, checkedIn = false);
                //            //Add booking to database
                //            //Save changes
                //            this.Close();
                //        }
                //        catch (NullReferenceException ex)
                //        {
                //            Console.WriteLine(ex);
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("No room available");
                //    }


             }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Wrong input");
            }
        }

        private bool checkDate(DateTime checkInDate, DateTime checkOutTime, int roomId)
        {
            bool available = false;

            //if(checkInDate.CompareTo(checkOutTime) < 0) //Check in date is before check out date.
            //{
            //    //Need to get all the bookings on that room from the database
            //    //List<Booking> bookings = 
            //    if(bookings.Count > 0)
            //    {
            //        foreach(var b in bookings)
            //        {
            //            //Need to check if either the check in date or the check out date crashes with any other booking
            //            if ()
            //            {
            //                available = true;
            //            }
            //            else
            //            {
            //                available = false;
            //                break;
            //            }

            //        }
            //    }
            //    else
            //    {
            //        available = true;
            //    }
            //}



            return available;
        }
    }
}
