using System.Configuration;

namespace SportsComplex.Utilities
{
    public static class Settings
    {
        public static string NetworkEmailId
        {
            get { return ConfigurationManager.AppSettings["NetworkEmailId"]; }
        }

        public static string NetworkPassword
        {
            get { return ConfigurationManager.AppSettings["NetworkPassword"]; }
        }

        public static string EmailHost
        {
            get { return ConfigurationManager.AppSettings["EmailHost"]; }
        }

        public static string EmailHostPort
        {
            get { return ConfigurationManager.AppSettings["EmailHostPort"]; }
        }

        public static string FromEmailId
        {
            get { return ConfigurationManager.AppSettings["FromEmailId"]; }
        }

        public static string PayrollEmailId
        {
            get { return ConfigurationManager.AppSettings["PayrollEmailId"]; }
        }

        public static string GymFee
        {
            get { return ConfigurationManager.AppSettings["GymFee"]; }
        }

        public static string BadmintonFee
        {
            get { return ConfigurationManager.AppSettings["BadmintonFee"]; }
        }

        public static string BilliardFee
        {
            get { return ConfigurationManager.AppSettings["BilliardFee"]; }
        }

        public static string BadmintonHeaders
        {
            get { return ConfigurationManager.AppSettings["BadmintonHeaders"]; }
        }

        public static string BilliardHeaders
        {
            get { return ConfigurationManager.AppSettings["BilliardHeaders"]; }
        }

        public static string NoOfBadmintonCourt
        {
            get { return ConfigurationManager.AppSettings["NoOfBadmintonCourt"]; }
        }

        public static string NoOfBilliarCourt
        {
            get { return ConfigurationManager.AppSettings["NoOfBilliarCourt"]; }
        }
    }
}
