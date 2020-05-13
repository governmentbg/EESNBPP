using NBPPRegixClient.Models;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Web;
using System.Text;

namespace NBPPRegixClient
{
    /// <summary>
    /// 
    /// </summary>
    public class Service : IService
    {
        /// <summary>
        /// Мeтодът връща информация за поддържаните справки на API-то
        /// </summary>
        /// <returns>списък от ReportInfo, съдържащ информация за всяка поддържаща справка</returns>
        public ReportInfo[] GetSupportedReports()
        {
            List<ReportInfo> res = new List<ReportInfo>();
            int idIndx = 1;
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*1*/
                Name = "Справка по ЕГН / ЛНЧ за издадени заповеди за ползване на социални услуги",
                RequestOperation = "TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetSocialServicesDecisions",
                GroupName = "АСП"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*2*/
                Name = "Справка по ЕГН / ЛНЧ за отпуснати помощи по чл. 9 от ППЗСП",
                RequestOperation = "TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetMonthlySocialBenefits",
                GroupName = "АСП"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*3*/
                Name = "Справка по ЕГН / ЛНЧ за отпуснати помощи за отопление по Наредба РД - 07 - 5",
                RequestOperation = "TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetBenefitsForHeating",
                GroupName = "АСП"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*4*/
                Name = "Справка за наличието на упражнено право на пенсия за осигурителен стаж и възраст",
                RequestOperation = "TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionRightInfoReport",
                GroupName = "НОИ"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*5*/
                Name = "Справка за размер и вид на пенсия и добавка (УП-7)",
                RequestOperation = "TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionTypeAndAmountReport",
                GroupName = "НОИ"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*6*/
                Name = "Справка за доход от пенсия и добавка(УП - 8)",
                RequestOperation = "TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionIncomeAmountReport",
                GroupName = "НОИ"
            });
            res.Add(new ReportInfo()
            {
                ID = idIndx++, /*7*/
                Name = "Справка за семейно положение",
                RequestOperation = "TechnoLogica.RegiX.GraoBRAdapter.APIService.IBRAPI.MaritalStatusSearch",
                GroupName = "ГРАО"
            });            
            return res.ToArray();
        }

        /// <summary>
        /// Изпълнява списък от справки и връща резултат в предварително дефиниран HTML формат
        /// </summary>
        /// <param name="req">списък на желаните за изпълнение справки и нужните критерии за тях</param>
        /// <returns>резултатът от всички поискани справки, обединени в един общ HTML. Резултатът е HTML стринг, представен като Stream с UTF-8 енкодинг.</returns>
        public Stream GetRegixReport(RequestReport[] req)
        {
            Log.SLog.log("GetRegixReport -> Count: " + req.Length);
            Dictionary<string, string> resp = new Dictionary<string, string>();
            if (req != null)
            {
                foreach (var r in req)
                {
                    switch (r.RequestOperation)
                    {
                        case ("TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetSocialServicesDecisions"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.ASP.ASPReport.SocialServicesDecisions(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.ASP.ASPReport.GetHTMLString(res, "1"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetMonthlySocialBenefits"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.ASP.ASPReport.GetMonthlySocialBenefits(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.ASP.ASPReport.GetHTMLString(res, "2"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.ASPSocialAdapter.APIService.IASPSocialAPI.GetBenefitsForHeating"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.ASP.ASPReport.GetBenefitsForHeating(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.ASP.ASPReport.GetHTMLString(res, "3"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionRightInfoReport"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.NOI.NOIReport.GetPensionRightRequest(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.NOI.NOIReport.GetHTMLString(res, "1"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionTypeAndAmountReport"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.NOI.NOIReport.GetUP7(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.NOI.NOIReport.GetHTMLString(res, "2"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.NoiRPAdapter.APIService.IRPAPI.GetPensionIncomeAmountReport"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.NOI.NOIReport.GetUP8(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.NOI.NOIReport.GetHTMLString(res, "3"));
                                break;
                            }
                        case ("TechnoLogica.RegiX.GraoBRAdapter.APIService.IBRAPI.MaritalStatusSearch"):
                            {
                                System.Xml.XmlElement xmlRequest = RegixClass.BR.BRReport.MaritalStatusRequest(r.RequestID, r.RequestIdType);
                                string res = RegixUtils.GetRegixData(xmlRequest, r.RequestOperation);
                                resp.Add(r.RequestOperation, RegixClass.BR.BRReport.GetHTMLString(res, "1"));
                                break;
                            }
                        default: { break; }
                    }
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (string s in resp.Values) { sb.AppendLine(s); }

            byte[] resultBytes = Encoding.UTF8.GetBytes(sb.ToString());
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html;charset=utf-8";
            return new MemoryStream(resultBytes);
        }
    }
}
