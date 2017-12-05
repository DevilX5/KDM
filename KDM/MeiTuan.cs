using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace KDM
{
    public class FormParam
    {
        public int areaId { get; set; }
        public int cateId { get; set; }
        public string deal_attr_23 { get; set; }
        public string deal_attr_24 { get; set; }
        public string deal_attr_25 { get; set; }
        public int limit { get; set; }
        public int lineId { get; set; }
        public int offset { get; set; }
        public string poi_attr_20033 { get; set; }
        public string poi_attr_20043 { get; set; }
        public string sort { get; set; }
        public int stationId { get; set; }
    }
    public class MeiTuan
    {
        public MtLst GetDatas()
        {
            var payload = new FormParam() { areaId = 0, cateId = 1, deal_attr_23 = "", deal_attr_24 = "", deal_attr_25 = "", limit = 15, lineId = 0, offset = 0, poi_attr_20033 = "", poi_attr_20043 = "", sort = "default", stationId = 0 };
            var client = new RestClient();
            client.BaseUrl = new Uri("http://meishi.meituan.com");
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";
            var request = new RestRequest("/i/api/channel/deal/list",Method.POST);
            request.AddHeader("Referer", "http://meishi.meituan.com/i/?ci=906&stid_b=1&cevent=imt%2Fhomepage%2Fcategory1%2F1");
            request.AddCookie("cityname", "%E7%BB%B5%E7%AB%B9");
            var response = client.Execute(request);
            var mtlst = SimpleJson.SimpleJson.DeserializeObject<MtLst>(response.Content);
            return mtlst;
        }
    }
}
