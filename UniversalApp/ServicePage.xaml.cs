using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.DateTimeFormatting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace UniversalApp
{
    public sealed partial class ServicePage : Page
    {
        private string ServiceType;

        public ServicePage()
        {
            this.InitializeComponent();
            UpdateTaskList();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ServiceType = e.Parameter.ToString();
            typeOfService.Text = ServiceType;
        }


        public void UpdateTaskList()
        {



        }

        private void ReturnHomeClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void StartTaskClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            UpdateTaskList();
        }

        private void CompleteTaskClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (TaskListView.SelectedItem != null)
            {
                ServiceObject so = TaskListView.SelectedItem as ServiceObject;
                so.ServiceStatus = "Completed";

                var newServiceTask = JsonConvert.SerializeObject(so);
                var buffer = System.Text.Encoding.UTF8.GetBytes(newServiceTask);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var client = new HttpClient())
                {
                    Task task = Task.Run(async () =>
                    {
                        await client.PutAsync(new Uri(String.Format("http://localhost:52285/api/ServiceTasks/{0}", so.ServiceId)), byteContent);
                    });
                    task.Wait();
                }
                UpdateTaskList();
            }
        }

        private void DeleteTaskClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            UpdateTaskList();
        }

        private void AddTaskClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {


            UpdateTaskList();
        }

        private void AddTaskClearClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            TaskEntryDescription.Text = "";
            TaskEntryRoomNumber.Text = "";
        }
    }
}
