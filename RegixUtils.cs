using NBPPRegixClient.Log;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;

namespace NBPPRegixClient
{
    public class RegixUtils
    {
        #region Properties
        private static bool? _isDebug = null;
        private static string _regixURL = string.Empty;
        private static string _certSerialNumber = string.Empty;
        
        /// <summary>
        /// Основен адрес на Regix
        /// </summary>
        public static string RegixURL
        {
            get
            {
                if (string.IsNullOrEmpty(_regixURL)) { _regixURL = System.Configuration.ConfigurationManager.AppSettings["RegixURL"]; }
                return _regixURL;
            }
        }
        /// <summary>
        /// С разширено писане на логове
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                if (!_isDebug.HasValue) { _isDebug = System.Configuration.ConfigurationManager.AppSettings["DEBUG"] == "1"; }
                return _isDebug.Value;
            }
        }
        /// <summary>
        /// Сериен номер на сертификат, който да се ползва за комуникация с Regix
        /// </summary>
        public static string CertSerialNumber
        {
            get
            {
                if (string.IsNullOrEmpty(_certSerialNumber)) { _certSerialNumber = System.Configuration.ConfigurationManager.AppSettings["CertSerialNumber"]; }
                return _certSerialNumber;
            }
        }
        #endregion

        /// <summary>
        /// Приемане и на selfsign сертификати при https връзка
        /// </summary>
        public static void ConfirmCertificate()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                delegate (Object sender1, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };
        }

        /// <summary>
        /// Прикачване на сертификат към заявката към Regix. Сертификатът се търси по сериен номер в инсталираните на сървъра сертификати.
        /// </summary>
        /// <param name="srv">Regix заявка</param>
        /// <param name="serialNo">Сериен номер на сертификат</param>
        public static void BindCertificates(RegiXEntryPointClient srv, string serialNo)
        {
            string certSerialNum = serialNo;

            X509Store store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.MaxAllowed);
            X509Certificate2Collection cers = store.Certificates.Find(X509FindType.FindBySerialNumber, certSerialNum, false);
            if (cers.Count > 0)
            {
                X509Certificate2 pfx = cers[0];
                srv.ClientCredentials.ClientCertificate.Certificate = pfx;
            }
            else
            {
                SLog.log("CERTIFICATE NOT FOUND: " + certSerialNum);
            }
            store.Close();
        }

        /// <summary>
        /// Превръща всяка заявка в xml и го записва в подпапка ~/Logs/DEBUG/
        /// </summary>
        /// <param name="data">Обект за сериализиране</param>
        public static void SeriliazeForDebug(object data)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Logs/DEBUG");
            if (!System.IO.Directory.Exists(path)) { System.IO.Directory.CreateDirectory(path); }

            StringBuilder strBulder = new StringBuilder();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(data.GetType());
            path = System.IO.Path.Combine(path, "RegixRequest_" + DateTime.Now.ToString("HHmmssfff") + ".xml");
            System.IO.FileStream file = System.IO.File.Create(path);
            x.Serialize(file, data);
            file.Close();
        }

        /// <summary>
        /// Превръща всеки отговор в xml и го записва в подпапка ~/Logs/DEBUG/
        /// </summary>
        /// <param name="data">Обект за сериализиране</param>
        public static void SeriliazeForDebugResult(object data)
        {
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Logs/DEBUG");
            if (!System.IO.Directory.Exists(path)) { System.IO.Directory.CreateDirectory(path); }

            StringBuilder strBulder = new StringBuilder();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(data.GetType());
            path = System.IO.Path.Combine(path, "RegixResponse_" + DateTime.Now.ToString("HHmmssfff") + ".xml");
            System.IO.FileStream file = System.IO.File.Create(path);
            x.Serialize(file, data);
            file.Close();
        }

        /// <summary>
        /// Изпълнение на заявка към Regix сървис
        /// </summary>
        /// <param name="xml">Параметри на справката</param>
        /// <param name="operation">Адрес на справката</param>
        /// <returns></returns>
        public static string GetRegixData(System.Xml.XmlElement xml, string operation)
        {
            string res = string.Empty;

            WSHttpBinding bind = new WSHttpBinding();
            bind.Security.Mode = SecurityMode.Transport;
            bind.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
            bind.MaxReceivedMessageSize = 200000;
            bind.OpenTimeout = new TimeSpan(0, 5, 0);
            bind.SendTimeout = new TimeSpan(0, 5, 0);
            bind.ReceiveTimeout = new TimeSpan(0, 5, 0);
            bind.CloseTimeout = new TimeSpan(0, 5, 0);

            SLog.log("START Regix: { " + operation + " }");

            try
            {
                EndpointAddress endp = new EndpointAddress(RegixUtils.RegixURL);
                RegiXEntryPointClient rgx_srv = new RegiXEntryPointClient(bind, endp);
                RegixUtils.BindCertificates(rgx_srv, RegixUtils.CertSerialNumber);
                RegixUtils.ConfirmCertificate();

                ServiceRequestData rd = new ServiceRequestData();
                rd.CallContext = new CallContext();
                rd.CallContext.LawReason = "Закон за правната помощ";
                rd.CallContext.ServiceURI = string.Empty;
                rd.CallContext.Remark = string.Empty;
                rd.CallContext.ServiceType = "2";
                rd.CallContext.AdministrationName = "Национално Бюро за Правна Помощ";
                rd.CallbackURL = string.Empty;
                rd.EIDToken = string.Empty;
                rd.EmployeeEGN = string.Empty;
                rd.Argument = xml;
                rd.Operation = operation;

                if (RegixUtils.IsDebug)
                {
                    RegixUtils.SeriliazeForDebug(rd);
                }

                ServiceResultData all_data = rgx_srv.ExecuteSynchronous(rd);
                if (all_data == null)
                {
                    return RegixUtils.GetErrorString("Няма данни"); 
                }
                else if (all_data.HasError)
                {
                    SLog.log(all_data.Error);
                    return RegixUtils.GetErrorString(all_data.Error);
                }
                else
                {
                    if (RegixUtils.IsDebug)
                    {
                        RegixUtils.SeriliazeForDebugResult(all_data);
                    }
                    if (all_data.Data != null && all_data.Data.Response != null)
                    {
                        res = all_data.Data.Response.Any.OuterXml;
                    }
                }
            }
            catch (Exception exIn)
            {
                SLog.log("ERROR Regix:");
                SLog.log(exIn);
                res = RegixUtils.GetErrorString("Няма връзка с услугата");
            }
            SLog.log("END Regix: { " + operation + " }");
            return res;
        }

        private static string GetErrorString(string error)
        {
            return string.Format("<Error>{0}</Error>", error);
        }
    }
}