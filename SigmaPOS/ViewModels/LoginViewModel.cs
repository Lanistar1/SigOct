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
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;

            LoginCommand = new Command(async () => await LoginCommandsExecute());
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

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private string username;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
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
        
        private string merchantID;

        public string MerchantID
        {
            get => merchantID;
            set
            {
                merchantID = value;
                OnPropertyChanged(nameof(MerchantID));
            }
        }
        #endregion

        #region Binding Commands

        public Command LoginCommand { get; }

        #endregion
        #region Functions, Methods, Events and others
        private async Task LoginCommandsExecute()
        {
            try
            {
                Console.WriteLine("something pressed");
                if (string.IsNullOrWhiteSpace(Username))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct username";
                    await Task.Delay(5000);
                    Console.WriteLine("hgjdshfg");
                    IsMessageVisible = false;
                    return;
                }

                if (string.IsNullOrWhiteSpace(Password))
                {
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct password";
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                    return;
                }
                
                if (string.IsNullOrWhiteSpace(MerchantID))
                {
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct merchantID";
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                    return;
                }

                IsBtnEnabled = true;
                IsBusy = true;
                IsMessageVisible = true;
                HttpClient client = new HttpClient();
                LoginRequest request = new LoginRequest(Password, Username, MerchantID);
                Console.WriteLine(request.password);
                Console.WriteLine(request.username);
                Console.WriteLine(request.merchantID);

                string body = JsonConvert.SerializeObject(request);
                Console.WriteLine(Username);
                Console.WriteLine(Password);
                Console.WriteLine(MerchantID);

                string url = Global.LoginUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(body, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    LoginResponse data = JsonConvert.DeserializeObject<LoginResponse>(result);
                    Console.WriteLine(data.data.token);
                    Helpers.Global.token = data.data.token;
                    Helpers.Global.user_id = data.data.id;
                    Helpers.Global.CurrentUserData = data.data;
                    Helpers.Global.FirstName = data.data.firstName;
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    Console.WriteLine(MessageLabel);
                    await Navigation.PushAsync(new ResetPasswordPage());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    LoginResponse data = JsonConvert.DeserializeObject<LoginResponse>(result);
                    IsMessageVisible = true;
                    //MessageLabel = data.message;
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    IsMessageVisible = false;
                }
                else
                {
                    LoginResponse data = JsonConvert.DeserializeObject<LoginResponse>(result);
                    MessageLabel = data.message;
                    await Task.Delay(5000);
                    response.Dispose();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($" An error with {ex.Message} occured here");
                MessageLabel = "Check your internet connection";
            }
            finally
            {
                IsMessageVisible = false;
                IsBtnEnabled = false;
                IsBusy = false;
            }
        }
        #endregion
    }
}
