using NBPPRegixClient.Models;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace NBPPRegixClient
{
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Мотодът връща информация за поддържаните справки на API-то
        /// </summary>
        /// <returns>списък от ReportInfo, съдържащ информация за всяка поддържаща справка</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/GetSupportedReports")]
        ReportInfo[] GetSupportedReports();

        /// <summary>
        /// Изпълнява списък от справки и връща резултат в предварително дефиниран HTML формат
        /// </summary>
        /// <param name="req">списък на желаните за изпълнение справки и нужните критерии за тях</param>
        /// <returns>резултатът от всички поискани справки, обединени в един общ HTML. Резултатът е стринг, представен като Stream с UTF-8 енкодинг.</returns>
        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/GetRegixReport")]
        Stream GetRegixReport(RequestReport[] req);
    }
}
