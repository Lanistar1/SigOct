using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class TransactionDetailsViewModel : BaseViewModel
    {
        private ObservableCollection<WalletData> transactionDetails;
        public ObservableCollection<WalletData> TransactionDetails
        {
            get => transactionDetails;
            set
            {
                transactionDetails = value;
                OnPropertyChanged(nameof(TransactionDetails));
            }
        }

        public ObservableCollection<WalletData> selectedItems;
        public ObservableCollection<WalletData> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
            }
        }

        public TransactionDetailsViewModel(INavigation navigation, ObservableCollection<WalletData> selectedItems)
        {
            Navigation = navigation;

            SelectedItems = selectedItems;

            TransactionDetails = new ObservableCollection<WalletData>(SelectedItems);

            Console.WriteLine(TransactionDetails);

        }
    }
}
