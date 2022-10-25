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
    public partial class DashBoardPage : ContentPage
    {
        public DashBoardPage()
        {
            InitializeComponent();
            BindingContext = new DashBoardViewModel(Navigation);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WithdrawPage());
        }

        private void Tapped_me(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MetricPage());
        }

        private void To_Transaction(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WalletPage());
        }
    }
}