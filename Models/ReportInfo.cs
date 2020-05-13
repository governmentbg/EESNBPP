using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NBPPRegixClient.Models
{
    /// <summary>
    /// Клас описващ справка
    /// </summary>
    [DataContract]
    public class ReportInfo
    {
        /// <summary>
        /// Уникален номер
        /// </summary>
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// Наименование на справката
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Адресът на справката в Regix
        /// </summary>
        [DataMember]
        public string RequestOperation { get; set; }

        /// <summary>
        /// Група на справка
        /// </summary>
        [DataMember]
        public string GroupName { get; set; }
    }
}