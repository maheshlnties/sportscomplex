namespace SportsComplex.Models
{
    public class ResourceSettings
    {
        public ResourceSettingKeys Name { get; set; }

        public string Value { get; set; }
    }

    public enum ResourceSettingKeys
    {
        BadmintonHeaders,
        NoOfBadmintonCourt,
        BilliardHeaders,
        NoOfBilliarCourt
    }
}
