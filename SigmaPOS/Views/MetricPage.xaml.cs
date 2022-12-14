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
    public partial class MetricPage : ContentPage
    {
        public MetricPage()
        {
            InitializeComponent();
            BindingContext = new MetricViewModel(Navigation);
        }
    }
}