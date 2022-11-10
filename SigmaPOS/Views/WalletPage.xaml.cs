using SigmaPOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SigmaPOS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WalletPage : ContentPage
    {
        public WalletPage()
        {
            InitializeComponent();
            BindingContext = new WalletViewModel(Navigation);
        }

        //private void proceed(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new TransactionDetailsPage());
        //}
    }
}