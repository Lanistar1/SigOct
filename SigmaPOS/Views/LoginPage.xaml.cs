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
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel(Navigation);
        }

        //private void click_me(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new Tabbed());



        //    //application.current.MainPage = new NavigationPage(new Tabbed());

        //}

        private void Click_me(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ResetPasswordPage());
        }

        private void T0_forgetpassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }
    }
}