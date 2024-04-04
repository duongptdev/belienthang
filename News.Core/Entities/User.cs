using News.Core.Enums;

namespace News.Core.Entities
{
    public class User 
    {
        public string UserID { get; set; }
        public string Username { get; set; }

        public string PasswordHash{ get; set; }

        public EnumRole Type { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        public string Code { get; set; }
        public string ReferrerCode { get; set; }
        public string ReferrerId { get; set; }
        public string Status { get; set; }
        public string FcmToken { get; set; }
        public string Group { get; set; }
        public string LevelId { get; set; }
        public int Level { get; set; }
        public string BillingInfor { get; set; }
        public string RefId { get; set; }




    }
}
