using System.ServiceModel;
using System.ServiceModel.Web;
using RestfulServiceTask.Data;

namespace RestfulServiceTask.MagazineService
{
    [ServiceContract]
    public interface IMagazineService
    {
        [WebGet(UriTemplate = "Years", ResponseFormat = WebMessageFormat.Json)]
        int[] GetYears();

        [WebInvoke(Method = "POST", UriTemplate = "SaveYear/{year}", ResponseFormat = WebMessageFormat.Json)]
        string SaveYear(string year);

        [WebGet(UriTemplate = "Magazines/{year}", ResponseFormat = WebMessageFormat.Json)]
        string[] GetMagazineNames(string year);

        [WebGet(UriTemplate = "Magazines/{year}/{magazineName}/{month}", ResponseFormat = WebMessageFormat.Json)]
        Article[] GetArticles(string year, string magazineName, string month);

        [WebInvoke(Method = "POST", UriTemplate = "SaveMagazine/{year}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        void SaveMagazine(string year, Magazine magazine);
    }
}
