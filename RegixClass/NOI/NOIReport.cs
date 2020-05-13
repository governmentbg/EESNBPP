using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace NBPPRegixClient.RegixClass.NOI
{
    /// <summary>
    /// Клас за обработка на справки от НОИ
    /// </summary>
    public class NOIReport
    {
        public NOIReport()
        {
        }

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
        /// Изпълнение на справка от Regix за "Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст"
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement GetPensionRightRequest(string ident, int identType)
        {
            PensionRightRequestType sendParas = new PensionRightRequestType();
            sendParas.Identifier = ident;
            sendParas.IdentifierType = IdentifierType.ЕГН;
            sendParas.Month.Month = "--" + DateTime.Now.ToString("MM");
            sendParas.Month.Year = DateTime.Now.ToString("yyyy");
            return SerializeToXmlElement(sendParas);
        }
        
        /// <summary>
        /// Изпълнение на справка от Regix за "Справка за размер и вид на пенсия и добавка (УП-7)". Справктата се изпълнява към текущият месец.
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement GetUP7(string ident, int identType)
        {
            UP7RequestType sendParas = new UP7RequestType();
            sendParas.Identifier = ident;
            sendParas.IdentifierType = IdentifierType.ЕГН;
            sendParas.Month.Month = "--" + DateTime.Now.ToString("MM");
            sendParas.Month.Year = DateTime.Now.ToString("yyyy");
            return SerializeToXmlElement(sendParas);
        }


        /// <summary>
        /// Изпълнение на справка от Regix за "Справка за доход от пенсия и добавка (УП-8)". 
        /// Справктата се изпълнява за периода от началото на текущата година, до края момента на изпълнението й.
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement GetUP8(string ident, int identType)
        {
            UP8RequestType sendParas = new UP8RequestType();
            sendParas.Identifier = ident;
            sendParas.IdentifierType = IdentifierType.ЕГН;
            sendParas.Period.From.Month = "--01";
            sendParas.Period.From.Year = DateTime.Now.ToString("yyyy");
            sendParas.Period.To.Month = "--" + DateTime.Now.ToString("MM");
            sendParas.Period.To.Year = DateTime.Now.ToString("yyyy");
            return SerializeToXmlElement(sendParas);
        }

        /// <summary>
        /// Методът преобразува XML към предварително дефинирани HTML-и.
        /// </summary>
        /// <param name="xmlString">XML с данни</param>
        /// <param name="type">Вид темплейт, в който да се преобразува. 1 = NOIReport.xslt; 2 = NOIUP7.xslt; 3 = NOIUP8.xslt;</param>
        /// <returns>HTML с данните представени в избраният темплейт.</returns>
        public static string GetHTMLString(string xmlString, string type)
        {
            string fileName = string.Empty;
            switch (type)
            {
                case "1": fileName = "NOIReport.xslt"; break;
                case "2": fileName = "NOIUP7.xslt"; break;
                case "3": fileName = "NOIUP8.xslt"; break;
                default: fileName = "NOIReport.xslt"; break;
            }
            
            StringReader rdr = new StringReader(xmlString);
            XmlReader xReader = XmlReader.Create(rdr);
            XslCompiledTransform docTrans = new XslCompiledTransform();
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/RegixClass/NOI");
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
