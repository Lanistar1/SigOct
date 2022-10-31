using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class MetricViewModel : BaseViewModel
    {

        private TransactionMetric metric;
        public TransactionMetric Metric
        {
            get => metric;
            set
            {
                metric = value;
                OnPropertyChanged(nameof(Metric));
            }
        }


        private string walletId;
        public string WalletId
        {
            get => walletId;
            set
            {
                walletId = value;
                OnPropertyChanged(nameof(WalletId));
            }
        }

        private int walletAmount;
        public int WalletAmount
        {
            get => walletAmount;
            set
            {
                walletAmount = value;
                OnPropertyChanged(nameof(WalletAmount));
            }
        }

        public MetricViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetMetricExecute();
            Task _tasks = GetWalletExecute();

        }


        private async Task GetMetricExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Global.MetricUrl;

                Console.WriteLine(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

                HttpResponseMessage response = await client.GetAsync(url);

                var test = Global.token;
                Console.WriteLine(test);

                //var rest = url + Helps.Constant.user_id;
                //Console.WriteLine(rest);
                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);


                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<TransactionMetric>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    Console.WriteLine(data);


                    var metric = data;
                    
                    Console.WriteLine(metric);
                    Metric = metric;
                    
                    Console.WriteLine(Metric);
                    Console.WriteLine("vdhvg hdsh");
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

        private async Task GetWalletExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Global.WalletUrl;

                Console.WriteLine(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

                HttpResponseMessage response = await client.GetAsync(url);

                var test = Global.token;
                Console.WriteLine(test);

                //var rest = url + Helps.Constant.user_id;
                //Console.WriteLine(rest);
                response = await client.GetAsync(url);
                //response = await client.GetAsync(url + Helps.Constant.user_id);


                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<WalletModel>(result);
                    Console.WriteLine("passedjiojiojiojio");
                    Console.WriteLine(data.data);

                    WalletAmount = data.data.availableBalance;
                    WalletId = data.data.walletId;

                    Console.WriteLine(WalletAmount);
                    Console.WriteLine(WalletId);
                    Console.WriteLine("vdhvg hdsh");
                }

                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
