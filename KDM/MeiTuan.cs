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
        public MeiTuan()
        {
            client = new RestClient();
            client.BaseUrl = new Uri("http://www.meituan.com");
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36";
            //client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
            client.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063";
            //client.UserAgent = "Baiduspider";
        }
        public RestClient client { get; set; }
        public MtMobileLst MobileGetDatas(int offset)
        {
            client.BaseUrl = new Uri("http://meishi.meituan.com");
            var request = new RestRequest("/i/api/channel/deal/list",Method.POST);
            request.AddCookie("ci", "906");
            var payload = new FormParam() { areaId = 0, cateId = 1, deal_attr_23 = "", deal_attr_24 = "", deal_attr_25 = "", limit = 15, lineId = 0, offset = offset, poi_attr_20033 = "", poi_attr_20043 = "", sort = "default", stationId = 0 };
            request.AddJsonBody(payload);
            var response = client.Execute(request);
            var mtlst = SimpleJson.SimpleJson.DeserializeObject<MtMobileLst>(response.Content);
            return mtlst;
        }
        public MtWebLst WebGetDatas(string page)
        {
            var request = new RestRequest("/meishi/api/poi/getPoiList", Method.GET);
            request.AddParameter("cityName", "绵竹");
            request.AddParameter("page", page);
            request.AddCookie("ci", "906");
            request.AddCookie("ci3", "1");
            var response = client.Execute(request);
            var mtlst = SimpleJson.SimpleJson.DeserializeObject<MtWebLst>(response.Content);
            return mtlst;
        }
        public string GetDetail(string poiId= "5750537")
        {
            var request = new RestRequest($"/meishi/{poiId}/", Method.GET);
            request.AddCookie("ci", "906");
            request.AddCookie("i_extend", "H__a100001__b5");
            var response = client.Execute(request);
            var r = response.Content;
            var startindex = r.IndexOf("window._appState");
            r=r.Substring(startindex).Replace(" ","");
            var middlestartindex = r.IndexOf("=");
            r = r.Substring(middlestartindex + 1);
            var end = r.IndexOf(";</script>");
            r = r.Substring(0, end);
            var m = SimpleJson.SimpleJson.DeserializeObject<MtDetail>(r);
            return m.detailInfo.phone;
        }
    }
}
