using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels 
{
    public class TerminalViewModel : BaseViewModel
    {
        private string terminal;
        public string Terminal
        {
            get => terminal;
            set
            {
                terminal = value;
                OnPropertyChanged(nameof(Terminal));
            }
        }

        private string serialNumber;
        public string SerialNumber
        {
            get => serialNumber;
            set
            {
                serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }
        
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        
        private string status;
        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        
        private string id;
        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        
        private string modelNumber;
        public string ModelNumber
        {
            get => modelNumber;
            set
            {
                modelNumber = value;
                OnPropertyChanged(nameof(ModelNumber));
            }
        }
        
        private string deviceKey;
        public string DeviceKey
        {
            get => deviceKey;
            set
            {
                deviceKey = value;
                OnPropertyChanged(nameof(DeviceKey));
            }
        }

        public TerminalViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = TerminalExecute();

            TerminalCommand = new Command(async () => await TerminalExecute());
        }
        public Command TerminalCommand { get; }

        public async Task TerminalExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Global.ProfileUrl;

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
                    var data = JsonConvert.DeserializeObject<TerminalData>(result);
                    Console.WriteLine(data);
                    SerialNumber = data.serialNumber;
                    Name = data.name;
                    Id = data.id;
                    ModelNumber = data.modelNumber;
                    DeviceKey = data.deviceKey;
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
