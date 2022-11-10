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
    public partial class ResetPasswordPage : ContentPage
    {
        public ResetPasswordPage()
        {
            InitializeComponent();
            //BindingContext = new ResetPasswordViewModel(Navigation);
        }

        private void click(object sender, EventArgs e)
        {
            //navigation.pushasync(new tabbed());
            Navigation.PushModalAsync(new NavigationPage(new Tabbed()));
            //Navigation.PushModalAsync(new Tabbed());
        }
    }
}