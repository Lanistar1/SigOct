using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    class ForgetPasswordViewModel : BaseViewModel
    {
        public ForgetPasswordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ForgetPasswordCommand = new Command(async () => await ForgetPasswordCommandsExecute());
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
        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public Command ForgetPasswordCommand { get; }

        #endregion
        private async Task ForgetPasswordCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(PhoneNumber))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct Phonenumber";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                IsBtnEnabled = true;
                IsBusy = true;
                HttpClient client = new HttpClient();
                ForgetPasswordRequest request = new ForgetPasswordRequest(PhoneNumber);

                string body = JsonConvert.SerializeObject(request);

                string url = Global.ForgetPasswordUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ForgetPasswordResponse data = JsonConvert.DeserializeObject<ForgetPasswordResponse>(result);
                    MessageLabel = data.message;

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ForgetPasswordResponse data = JsonConvert.DeserializeObject<ForgetPasswordResponse>(result);

                    IsMessageVisible = true;
                    MessageLabel = data.message;
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    ForgetPasswordResponse data = JsonConvert.DeserializeObject<ForgetPasswordResponse>(result);
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
