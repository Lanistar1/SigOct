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
    public partial class More : ContentPage
    {
        public More()
        {
            InitializeComponent();
        }

        private void To_details(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TerminalPage());
        }
    }
}