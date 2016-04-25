using System.Configuration;

namespace SportsComplex.Utilities
{
    public static class Settings
    {
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
    }
}
