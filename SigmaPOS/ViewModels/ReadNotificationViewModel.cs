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
    public class ReadNotificationViewModel : BaseViewModel
    {
        private ReadNotificationData readNotification;
        public ReadNotificationData ReadNotification
        {
            get => readNotification;
            set
            {
                readNotification = value;
                OnPropertyChanged(nameof(ReadNotification));
            }
        }

        public ReadNotificationViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = ReadNotificationExecute();

            ReadNotificationCommand = new Command(async () => await ReadNotificationExecute());
        }

        public Command ReadNotificationCommand { get; }

        public async Task ReadNotificationExecute()
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
                    var data = JsonConvert.DeserializeObject<ReadNotificationModel>(result);
                    Console.WriteLine(data);
                    ReadNotification = data.data;

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
