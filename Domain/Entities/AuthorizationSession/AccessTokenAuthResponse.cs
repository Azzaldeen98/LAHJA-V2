namespace Domain.Entities.AuthorizationSession
{
    public class AccessTokenAuthResponse
    {
        public string SpaceId { get; set; }        // معرف الـ Space
        public string Subscription { get; set; }   // نوع الاشتراك (مجاني/مدفوع)
        public string AccessToken { get; set; }    // رمز الوصول (Access Token)
        public string ApiEndpoint { get; set; }    // بوابة API
        public DateTime CreationDate { get; set; } // تاريخ الإنشاء
        public bool Status { get; set; }           // الحالة (فعال / غير فعال)
    }

}
