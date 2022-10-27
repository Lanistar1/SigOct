using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Helpers
{
    public static class Global
    {
        public static string BaseUrl => "https://icesset.herokuapp.com";
        public static string token { get; set; }
        public static UserData CurrentUserData { get; set; }
        public static string user_id { get; set; }
        public static string LoginUrl => $"{BaseUrl}/api/v1/agent/login/";
        public static string ResetPasswordUrl => $"{BaseUrl}/api/v1/agent/password-reset";

    }
}
