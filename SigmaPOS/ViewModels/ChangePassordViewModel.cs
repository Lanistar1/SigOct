using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using SigmaPOS.Views;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class ChangePassordViewModel : BaseViewModel
    {
        public ChangePassordViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ChangePasswordCommand = new Command(async () => await ChangePasswordCommandsExecute());
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
        private string oldPassword;
        public string OldPassword
        {
            get => oldPassword;
            set
            {
                oldPassword = value;
                OnPropertyChanged(nameof(OldPassword));
            }
        }
        
        private string newPassword;
        public string NewPassword
        {
            get => newPassword;
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        public Command ChangePasswordCommand { get; }

        #endregion
        private async Task ChangePasswordCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(OldPassword))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct OldPassword";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                if (string.IsNullOrWhiteSpace(NewPassword))
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
                ChangePasswordRequest requestPayload = new ChangePasswordRequest(OldPassword, NewPassword);

                string PayloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(PayloadJson);

                string url = Global.ChangePasswordUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(PayloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

                //HttpResponseMessage response = null;
                //response = await client.PostAsync(url, content);

                var method = new HttpMethod("PATCH");

                var request = new HttpRequestMessage(method, url)
                {
                    Content = content
                };

                var response = await client.SendAsync(request);

                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ChangePasswordResponse data = JsonConvert.DeserializeObject<ChangePasswordResponse>(result);
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                    await Navigation.PushAsync(new LoginPage());

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ChangePasswordResponse data = JsonConvert.DeserializeObject<ChangePasswordResponse>(result);

                    IsMessageVisible = true;
                    MessageLabel = data.message;
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    ChangePasswordResponse data = JsonConvert.DeserializeObject<ChangePasswordResponse>(result);
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
