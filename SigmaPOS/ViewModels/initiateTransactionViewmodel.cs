using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
using SigmaPOS.Views;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Forms;

namespace SigmaPOS.ViewModels
{
    public class initiateTransactionViewmodel : BaseViewModel
    {

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

        private string pin;

        public string Pin
        {
            get => pin;
            set
            {
                pin = value;
                OnPropertyChanged(nameof(Pin));
            }
        }
        
        private int amount;

        public int Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public initiateTransactionViewmodel(INavigation navigation)
        {
            Navigation = navigation;

            //Task _task = GetCompleteTransactionExecute();

            InitiateTransactionCommand = new Command(async () => await GetInitiateTransactionExecute());

            //CompleteTransactionCommand = new Command(async () => await GetCompleteTransactionExecute());

        }


        public Command InitiateTransactionCommand { get; }

        public async Task GetInitiateTransactionExecute()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Pin))
                {
                    IsBtnEnabled = false;
                    IsMessageVisible = true;
                    MessageLabel = "Please enter a correct pin";
                    await Task.Delay(5000);
                    Console.WriteLine("hgjdshfg");
                    IsMessageVisible = false;
                    return;
                }

                Console.WriteLine(Pin);
                Console.WriteLine(Amount);

                HttpClient client = new HttpClient();
                string accountType = Global.accountType;

                Console.WriteLine(accountType);

                string Id = Global.CurrentUserData.id;
                string phone = Global.CurrentUserData.phoneNumber;
                string email = Global.CurrentUserData.email;

                Facilitator facilitator = new Facilitator() { email = email, id = Id, phone = phone, pin = "Pin" };

                BeneficiaryTerminal beneficiaryTerminal = new BeneficiaryTerminal() { accountType = accountType };
                CardDetails cardDetails = new CardDetails() { cardExpiry = "2023-09-09", cardPan = "2056****098", cardType = "VISA" };
                //InitiateTransactionModel initiateTransactionModel = new InitiateTransactionModel() { amount = 5000, narration = "enu gbe", transactionType = "CARDWITHDRAWAL", isChargeIncluded = false };

                InitiateTransactionModel requestPayload = new InitiateTransactionModel() { amount = Amount, cardDetails = cardDetails, facilitator = facilitator, isChargeIncluded = false, transactionType = "CARDWITHDRAWAL", narration = "enu gbe" };

                string payloadJson = JsonConvert.SerializeObject(requestPayload);

                string url = Global.InitiateTransactionUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(payloadJson, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");
                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                var test = Global.token;
                Console.WriteLine(test);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<InitiateTransactionModel>(result);
                    MessageLabel = " card read successfully";
                    Console.WriteLine(MessageLabel);
                    Console.WriteLine("gubkfuwgyliwerli");
                    await Navigation.PushAsync(new BluetoothConnectPage());
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    IsMessageVisible = true;
                    MessageLabel = "insert your card properly";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    MessageLabel = "Something went wrong. Please try again later.";
                    IsMessageVisible = false;
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public Command CompleteTransactionCommand { get; }
        public async Task GetCompleteTransactionExecute()
        {
            try
            {
                UserCardDetails userCardDetails = new UserCardDetails() { cardExpiry = "2023-09-09", cardPan = "2056****098", cardType = "VISA" };

                InterswitchDetails interswitchDetails = new InterswitchDetails() { interswitchRef = "003925492013", interswitchResponseCode = "51", interswitchResponseMessage = "Insufficient funds" };

                CompleteTransactionModel requestPayload = new CompleteTransactionModel() { cardDetails = userCardDetails, interswitchDetails = interswitchDetails, status = "SUCCESSFUL", transactionId = "1628245681523661" };

                HttpClient client = new HttpClient();

                string PayloadJson = JsonConvert.SerializeObject(requestPayload);

                Console.WriteLine(PayloadJson);

                string url = Global.CompleteTransactionUrl;
                Console.WriteLine(url);
                StringContent content = new StringContent(PayloadJson, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

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
                    var data = JsonConvert.DeserializeObject<CompleteTransactionModel>(result);
                    MessageLabel = " Transaction completed";
                    Console.WriteLine(MessageLabel);
                    Console.WriteLine("gubkfuwgyliwerli");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    IsMessageVisible = true;
                    MessageLabel = "insert your card properly";
                    await Task.Delay(2000);
                    IsMessageVisible = false;
                }
                else
                {
                    MessageLabel = "Something went wrong. Please try again later.";
                    IsMessageVisible = false;
                    response.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
