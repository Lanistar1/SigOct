using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        private List<NotificationData> notification;
        public List<NotificationData> Notification
        {
            get => notification;
            set
            {
                notification = value;
                OnPropertyChanged(nameof(Notification));
            }
        }

        public NotificationViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = NotificationExecute();

            NotificationCommand = new Command(async () => await NotificationExecute());
        }

        public Command NotificationCommand { get; }

        public async Task NotificationExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Global.TerminalUrl;

                Console.WriteLine(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

                HttpResponseMessage response;


                var test = Global.token;
                Console.WriteLine(test);

                response = await client.GetAsync(url);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<NotificationModel>(result);
                    Console.WriteLine(data);
                    Notification = data.data;

                    //Terminal = data;
                    Console.WriteLine("ffdjhhdh");
                }
                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
