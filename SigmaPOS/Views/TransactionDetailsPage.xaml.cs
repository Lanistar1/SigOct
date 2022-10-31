using SigmaPOS.Models;
using SigmaPOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigmaPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TransactionDetailsPage : ContentPage
    {
        public TransactionDetailsPage()
        {
            InitializeComponent();
            //BindingContext = new TransactionDetailsViewModel(Navigation, selectedItems);
        }
        //public TransactionDetailsPage(ObservableCollection<WalletData> selectedItems)
        //{
        //    InitializeComponent();
        //    BindingContext = new TransactionDetailsViewModel(Navigation, selectedItems);
        //}
    }
}