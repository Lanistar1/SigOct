using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using SigmaPOS.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class ResetPasswordViewModel : BaseViewModel
    {
        public ResetPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ResetPasswordCommand = new Command(async () => await ResetPasswordCommandsExecute());
        }
        #region Binding Properties
        private bool isBtnEnabled = false;

        public bool IsBtnEnabled
        {
            get => isBtnEnabled;
            set
            {
                isBtnEnabled = value;
                OnPropertyChanged(nameof(IsBtnEnabled));
            }
        }

        private bool isMessageVisible = false;
        public bool IsMessageVisible
        {
            get => isMessageVisible;
            set
            {
                isMessageVisible = value;
                OnPropertyChanged(nameof(IsMessageVisible));
            }
        }

        private string messageLabel;

        public string MessageLabel
        {
            get => messageLabel;
            set
            {
                messageLabel = value;
                OnPropertyChanged(nameof(MessageLabel));
            }
        }

        private bool IsBusy = false;
        public bool IsBuy
        {
            get => IsBusy;
            set
            {
                IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public Command ResetPasswordCommand { get; }

        #endregion
        private async Task ResetPasswordCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(Password))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct Password";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                IsBtnEnabled = true;
                IsBusy = true;
                HttpClient client = new HttpClient();
                ResetPasswordRequest request = new ResetPasswordRequest(Password);

                string body = JsonConvert.SerializeObject(request);

                string url = Global.ResetPasswordUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ResetPasswordModel data = JsonConvert.DeserializeObject<ResetPasswordModel>(result);
                    MessageLabel = data.message;
                    Navigation.PushModalAsync(new NavigationPage(new Tabbed()));
                    Console.WriteLine("dfnkdjhkjfgh");

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ResetPasswordModel data = JsonConvert.DeserializeObject<ResetPasswordModel>(result);

                    IsMessageVisible = true;
                    MessageLabel = data.message;
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    ResetPasswordModel data = JsonConvert.DeserializeObject<ResetPasswordModel>(result);
                    MessageLabel = data.message;
                    response.Dispose();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($" An error with {ex.Message} occured here");
            }
            finally
            {
                IsMessageVisible = false;
                //IsBtnEnabled = false;
                IsBusy = false;
            }
        }

    }
}
