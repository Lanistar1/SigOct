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
    public class ResetPinViewModel : BaseViewModel
    {
        public ResetPinViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ResetPinCommand = new Command(async () => await ResetPinCommandsExecute());
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
        private string oldPin;
        public string OldPin
        {
            get => oldPin;
            set
            {
                oldPin = value;
                OnPropertyChanged(nameof(OldPin));
            }
        }

        private string newPin;
        public string NewPin
        {
            get => newPin;
            set
            {
                newPin = value;
                OnPropertyChanged(nameof(NewPin));
            }
        }

        public Command ResetPinCommand { get; }

        #endregion
        private async Task ResetPinCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(OldPin))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct OldPin";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                if (string.IsNullOrWhiteSpace(NewPin))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter your NewPin";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                    return;
                }
                IsBtnEnabled = true;
                IsBusy = true;
                HttpClient client = new HttpClient();
                ResetPinRequestModel requestPayload = new ResetPinRequestModel(OldPin, NewPin);

                string PayloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(PayloadJson);

                string url = Global.ResetPinUrl;
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
                    ResetPinResponseModel data = JsonConvert.DeserializeObject<ResetPinResponseModel>(result);
                    MessageLabel = data.message;

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ResetPinResponseModel data = JsonConvert.DeserializeObject<ResetPinResponseModel>(result);

                    IsMessageVisible = true;
                    MessageLabel = data.message;
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    ResetPinResponseModel data = JsonConvert.DeserializeObject<ResetPinResponseModel>(result);
                    MessageLabel = data.message;
                    response.Dispose();
                }
            }
            catch (Exception ex)
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
