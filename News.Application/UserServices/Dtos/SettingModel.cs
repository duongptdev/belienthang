namespace News.Application.UserServices.Dtos
{
    public class SettingModel
    {
        public string PartnerCode { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string Endpoint { get; set; }

        public decimal Amount { get; set; }
    }
}
