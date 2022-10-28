using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class WalletViewModel : BaseViewModel
    {
        private INavigation Navigation;

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
    }
}
