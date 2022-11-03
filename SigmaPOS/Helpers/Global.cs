using SigmaPOS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SigmaPOS.Helpers
{
    public static class Global
    {
        public static string BaseUrl => "https://5e2a4d68-831e-403b-808e-df1932de1801.mock.pstmn.io";
        public static string token { get; set; }
        public static UserData CurrentUserData { get; set; }
        public static string accountType { get; set; }
        public static string FirstName { get; set; }
        public static string user_id { get; set; }
        public static string LoginUrl => $"{BaseUrl}/api/v1/agent/login/";
        public static string ResetPasswordUrl => $"{BaseUrl}/api/v1/agent/password-reset";
        public static string ForgetPasswordUrl => $"{BaseUrl}/api/v1/agent/forgot-password";
        public static string ChangePasswordUrl => $"{BaseUrl}/api/v1/agent/password-change";
        public static string SetPinUrl => $"{BaseUrl}/api/v1/agent/security-pins";
        public static string ResetPinUrl => $"{BaseUrl}/api/v1/agent/security-pins";
        public static string ProfileUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/my-profile";
        public static string TerminalUrl => $"{BaseUrl}/api/v1/agent/terminals/businesses/jst2443636001KHTw/:terminalSerialNumber";
        public static string WalletUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/my-wallet";
        public static string InitiateTransactionUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/transactions";
        public static string CompleteTransactionUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/transactions";
        public static string NotificationUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/my-notifications?from_date=2022-05-01 &to_date=2022-10-30&is_read=FALSE";
        public static string ReadNotificationUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/my-notifications/:id/read";
        public static string MetricUrl => $"{BaseUrl}/api/v1/agent/businesses/jst2443636001KHTw/transactions/metrics?from_date=2022-05-01 &to_date=2022-10-30&status=SUCCESSFUL&type=CREDIT";

    }
}
