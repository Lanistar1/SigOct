using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class DashBoardViewModel : BaseViewModel
    {
        private bool buttonShow = true;
        public bool ButtonShow
        {
            get => buttonShow;
            set
            {
                buttonShow = value;
                OnPropertyChanged(nameof(ButtonShow));
            }
        }

        private bool buttonHide = false;
        public bool ButtonHide
        {
            get => buttonHide;
            set
            {
                buttonHide = value;
                OnPropertyChanged(nameof(ButtonHide));
            }
        }

        private bool showAmount = true;
        public bool ShowAmount
        {
            get => showAmount;
            set
            {
                showAmount = value;
                OnPropertyChanged(nameof(ShowAmount));
            }
        }
        private bool hideAmount = false;
        public bool HideAmount
        {
            get => hideAmount;
            set
            {
                hideAmount = value;
                OnPropertyChanged(nameof(HideAmount));
            }
        }

        public DashBoardViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ButtonShowCommand = new Command(async () => await ButtonShowCommandExecute());
            ButtonHideCommand = new Command(async () => await ButtonHideCommandExecute());
            //ButtonShowCommand = new Command<DashboardModel>(async (model) => await ButtonShowCommandExecute(model));
            //ButtonHideCommand = new Command(async () => await ButtonHideCommandExecute());
        }
        public ICommand ButtonShowCommand { get; }
        public ICommand ButtonHideCommand { get; }

        private async Task ButtonShowCommandExecute()
        {
            try
            {

                ShowAmount = false;
                HideAmount = true;
                ButtonHide = true;
                ButtonShow = false;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task ButtonHideCommandExecute()
        {
            try
            {
                ShowAmount = true;
                HideAmount = false;
                ButtonHide = false;
                ButtonShow = true;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
