using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace NBPPRegixClient.RegixClass.ASP
{
    /// <summary>
    /// Клас за обработка на справки от АСП
    /// </summary>
    public class ASPReport
    {
        public ASPReport() { }

        /// <summary>
        /// Сериализира всеки резултат на справките към XML
        /// </summary>
        /// <param name="o">Резултат от справка</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }

        /// <summary>
        /// Изпълнение на справка от Regix за "Справка по ЕГН/ЛНЧ за издадени заповеди за ползване на социални услуги"
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement SocialServicesDecisions(string ident, int identType)
        {
            GetSocialServicesDecisionsRequest sendParas = new GetSocialServicesDecisionsRequest();
            sendParas.PersonData.Identifier = ident;
            sendParas.PersonData.IdentifierType = IdentifierType.EGN;
            return SerializeToXmlElement(sendParas);
        }

        /// <summary>
        /// Изпълнение на справка от Regix за "Справка по ЕГН/ЛНЧ за отпуснати помощи по чл. 9 от ППЗСП"
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement GetMonthlySocialBenefits(string ident, int identType)
        {
            GetMonthlySocialBenefitsRequest sendParas = new GetMonthlySocialBenefitsRequest();
            sendParas.PersonData.Identifier = ident;
            sendParas.PersonData.IdentifierType = IdentifierType.EGN;
            return SerializeToXmlElement(sendParas);
        }

        /// <summary>
        /// Изпълнение на справка от Regix за "Справка по ЕГН/ЛНЧ за отпуснати помощи за отопление по Наредба РД-07-5"
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement GetBenefitsForHeating(string ident, int identType)
        {
            GetBenefitsForHeatingRequest sendParas = new GetBenefitsForHeatingRequest();
            sendParas.PersonData.Identifier = ident;
            sendParas.PersonData.IdentifierType = IdentifierType.EGN;
            return SerializeToXmlElement(sendParas);
        }

        /// <summary>
        /// Методът преобразува XML към предварително дефинирани HTML-и.
        /// </summary>
        /// <param name="xmlString">XML с данни</param>
        /// <param name="type">Вид темплейт, в който да се преобразува. 1 = SocialServicesDecisions.xslt; 2 = MonthlySocialBenefits.xslt; 3 = BenefitsForHeating.xslt;</param>
        /// <returns>HTML с данните представени в избраният темплейт.</returns>
        public static string GetHTMLString(string xmlString, string type)
        {
            string fileName = string.Empty;
            switch (type)
            {
                case "1": fileName = "SocialServicesDecisions.xslt"; break;
                case "2": fileName = "MonthlySocialBenefits.xslt"; break;
                case "3": fileName = "BenefitsForHeating.xslt"; break;
                default:  fileName = "SocialServicesDecisions.xslt"; break;
            }
            StringReader rdr = new StringReader(xmlString);
            XmlReader xReader = XmlReader.Create(rdr);
            XslCompiledTransform docTrans = new XslCompiledTransform();
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/RegixClass/ASP");
            using (var xml = XmlReader.Create(Path.Combine(path, fileName)))
            {
                docTrans.Load(xml);
                xml.Close();
            }
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            docTrans.Transform(xReader, null, htw);
            return sb.ToString();
        }
    }
}
