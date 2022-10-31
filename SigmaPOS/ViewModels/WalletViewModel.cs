using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using SigmaPOS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace SigmaPOS.ViewModels
{
    public class WalletViewModel : BaseViewModel
    {
        private INavigation Navigation;

        private wallet wallet;
        public wallet Wallet
        {
            get => wallet;
            set
            {
                wallet = value;
                OnPropertyChanged(nameof(Wallet));
            }
        }

        private ObservableCollection<WalletData> SelectedItems = new ObservableCollection<WalletData>();

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


        private ObservableCollection<wallet> transaction;
        public ObservableCollection<wallet> Transaction
        {
            get => transaction;
            set
            {
                transaction = value;
            }
        }
        public WalletViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = GetWalletExecute();
            Task _tasks = GetMetricExecute();

            TappedCommand = new Command<WalletData>(async (model) => await GetTappedExecute(model));
            ButtonShowCommand = new Command(async () => await ButtonShowCommandExecute());
            ButtonHideCommand = new Command(async () => await ButtonHideCommandExecute());

            Transaction = new ObservableCollection<wallet>{
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                new wallet { amount = "9,000.00", card = "MasterCard", date = "20 October 2022", day = "Monday", details = "53********67", name = "Tolani Emmanuel", time = "09:20:05", type = "Withdrawal"},
                

             };
        }
        public ICommand ButtonShowCommand { get; }
        public ICommand ButtonHideCommand { get; }

        private Task ButtonShowCommandExecute()
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

            return Task.CompletedTask;
        }

        private Task ButtonHideCommandExecute()
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

            return Task.CompletedTask;
        }


        public Command TappedCommand { get; }

        private async Task GetTappedExecute(WalletData model)
        {
            try
            {
                var mod = model;

                model.isSelected = model.isSelected ? false : true;
                if (SelectedItems.Count > 0)
                {
                    SelectedItems.Clear();
                }
                SelectedItems.Add(model);

                //await Navigation.PushAsync(new TransactionDetailsPage(SelectedItems), true);
            }
            catch
            {

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
                    Wallet = wallet;
                    WalletId = data.data.walletId;
                    WalletAmount = data.data.availableBalance;
                    //Helps.Constant.Transact = new ObservableCollection<Response>(transacts);
                    Console.WriteLine(Wallet);
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
    }
}
