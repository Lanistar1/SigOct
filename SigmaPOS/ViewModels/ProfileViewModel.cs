using Newtonsoft.Json;
using SigmaPOS.Helpers;
using SigmaPOS.Models;
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
    public class ProfileViewModel : BaseViewModel
    {
        private ProfileData profile;
        public ProfileData Profile
        {
            get => profile;
            set
            {
                profile = value;
                OnPropertyChanged(nameof(Profile));
            }
        }

        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
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

        public ProfileViewModel(INavigation navigation)
        {
            Navigation = navigation;

            Task _task = ProfileExecute();

            ProfileCommand = new Command(async () => await ProfileExecute());
        }
        public Command ProfileCommand { get; }

        public async Task ProfileExecute()
        {
            try
            {
                HttpClient client = new HttpClient();

                string url = Global.ProfileUrl;

                Console.WriteLine(url);

                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Helpers.Global.token}");

                HttpResponseMessage response;


                var test = Global.token;
                Console.WriteLine(test);

                response = await client.GetAsync(url);
                Console.WriteLine(response);

                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var data = JsonConvert.DeserializeObject<ProfileData>(result);
                    Console.WriteLine(data);
                    FirstName = data.firstName;
                    LastName = data.lastName;
                    Email = data.email;
                    PhoneNumber = data.phoneNumber;
                    Profile = data;
                    Console.WriteLine("ffdjhhdh");
                }
                else
                {
                    Console.WriteLine("Someting went wrong");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
