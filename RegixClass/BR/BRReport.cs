using System.IO;
using System.Text;
using System.Web.UI;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using NBPPRegixClient.BR;

namespace NBPPRegixClient.RegixClass.BR
{
    /// <summary>
    /// Клас за обработка на справки от ГРАО
    /// </summary>
    public class BRReport
    {
        public BRReport() { }

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
        /// Изпълнение на справка от Regix за "Справка за семейно положение"
        /// </summary>
        /// <param name="ident">Идентификатор</param>
        /// <param name="identType">ЕГН или ЛНЧ</param>
        /// <returns>Резултатът представен като XML</returns>
        public static XmlElement MaritalStatusRequest(string ident, int identType)
        {
            MaritalStatusRequestType sendParas = new MaritalStatusRequestType();
            sendParas.EGN = ident;
            return SerializeToXmlElement(sendParas);
        }

        /// <summary>
        /// Методът преобразува XML към предварително дефинирани HTML-и.
        /// </summary>
        /// <param name="xmlString">XML с данни</param>
        /// <param name="type">Вид темплейт, в който да се преобразува. 1 = MaritalStatus.xslt;</param>
        /// <returns>HTML с данните представени в избраният темплейт.</returns>
        public static string GetHTMLString(string xmlString, string type)
        {
            string fileName = string.Empty;
            switch (type)
            {
                case "1": fileName = "MaritalStatus.xslt"; break;
                default: fileName = "MaritalStatus.xslt"; break;
            }
            
            StringReader rdr = new StringReader(xmlString);
            XmlReader xReader = XmlReader.Create(rdr);
            XslCompiledTransform docTrans = new XslCompiledTransform();
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/RegixClass/BR");
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
