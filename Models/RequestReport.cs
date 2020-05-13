using System.Runtime.Serialization;

namespace NBPPRegixClient.Models
{
    /// <summary>
    /// Клас за заявка, за изпълнение на справка
    /// </summary>
    [DataContract]
    public class RequestReport
    {
        /// <summary>
        /// Адресът на справката в Regix
        /// </summary>
        [DataMember]
        public string RequestOperation { get; set; }

        /// <summary>
        /// Вид на идентенфикация: ЕГН = 1, ЛНЧ = 2
        /// </summary>
        [DataMember]
        public int RequestIdType { get; set; }

        /// <summary>
        /// Идентенфикатор ЕГН или ЛНЧ
        /// </summary>
        [DataMember]
        public string RequestID { get; set; }
    }
}