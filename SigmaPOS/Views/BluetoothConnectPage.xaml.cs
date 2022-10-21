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
    public partial class BluetoothConnectPage : ContentPage
    {
        public BluetoothConnectPage()
        {
            InitializeComponent();
        }

        private void Tap_me(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConnectPage());
        }
    }
}