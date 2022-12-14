using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        private bool buttonShow = true;
        public bool ButtonShow
        {
            get => buttonShow;
            set
            {
                buttonShow = value;
                OnPropertyChanged(nameof(ButtonShow));
            }
        }

        private bool buttonHide = false;
        public bool ButtonHide
        {
            get => buttonHide;
            set
            {
                buttonHide = value;
                OnPropertyChanged(nameof(ButtonHide));
            }
        }

        private bool showAmount = true;
        public bool ShowAmount
        {
            get => showAmount;
            set
            {
                showAmount = value;
                OnPropertyChanged(nameof(ShowAmount));
            }
        }
        private bool hideAmount = false;
        public bool HideAmount
        {
            get => hideAmount;
            set
            {
                hideAmount = value;
                OnPropertyChanged(nameof(HideAmount));
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
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

        private int credit;
        public int Credit
        {
            get => credit;
            set
            {
                credit = value;
                OnPropertyChanged(nameof(Credit));
            }
        }

        private int debit;
        public int Debit
        {
            get => debit;
            set
            {
                debit = value;
                OnPropertyChanged(nameof(Debit));
            }
        }

        public DashBoardViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetMetricExecute();
            Task _tasks = GetWalletExecute();

            ButtonShowCommand = new Command(async () => await ButtonShowCommandExecute());
            ButtonHideCommand = new Command(async () => await ButtonHideCommandExecute());

            //FirstName = Helpers.Global.CurrentUserData.firstName;

        }
        public ICommand ButtonShowCommand { get; }
        public ICommand ButtonHideCommand { get; }

        private async Task ButtonShowCommandExecute()
        {
            try
            {
                ShowAmount = false;
                HideAmount = true;
                ButtonHide = true;
                ButtonShow = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ButtonHideCommandExecute()
        {
            try
            {
                ShowAmount = true;
                HideAmount = false;
                ButtonHide = false;
                ButtonShow = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
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
                    Credit = metric.totalCredits;
                    Debit = metric.totalDebits;

                    Console.WriteLine(Credit);
                    Console.WriteLine(Debit);
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

                    var wallet = data.data.wallet;

                    Console.WriteLine(wallet);
                    WalletId = data.data.walletId;
                    WalletAmount = data.data.availableBalance;
                    Console.WriteLine(WalletId);
                    Console.WriteLine(WalletAmount);
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
