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
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private void click(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Tabbed());
            Navigation.PushModalAsync(new NavigationPage(new Tabbed()));
            //Navigation.PushModalAsync(new Tabbed());
        }
    }
}