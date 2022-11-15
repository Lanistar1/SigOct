using SigmaPOS.Controls;
using SigmaPOS.Helpers;
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
    public partial class WithdrawPage : ContentPage
    {
        private string accountType;
        public WithdrawPage()
        {
            InitializeComponent();
            BindingContext = new initiateTransactionViewmodel(Navigation);
        }

        private void transTypePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            accountType = picker.SelectedItem.ToString();
            Global.accountType = accountType;
        }

        //private void proceed(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new BluetoothConnectPage());
        //}
    }
}