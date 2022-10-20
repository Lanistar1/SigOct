using SigmaPOS.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("Poppins-Black.ttf", Alias = "Poppins")]
[assembly: ExportFont("Poppins-Light.ttf", Alias = "Poppins-Light")]
[assembly: ExportFont("Poppins-Medium.ttf", Alias = "Poppins-Medium")]
[assembly: ExportFont("Euclid Circular A Medium.ttf", Alias = "Euclid-Medium")]
[assembly: ExportFont("Euclid Circular A Regular.ttf", Alias = "Euclid-Regular")]
[assembly: ExportFont("Euclid Circular A Bold.ttf", Alias = "Euclid-Bold")]
[assembly: ExportFont("Euclid Circular A SemiBold.ttf", Alias = "Euclid-SemiBold")]
namespace SigmaPOS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
