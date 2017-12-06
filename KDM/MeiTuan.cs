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
        public List<UA> UALst { get; set; }
        public List<UA> SetUA()
        {
            UALst = new List<UA>();
            UALst.Add(new UA() { Used = false, Name ="win10-chrome",  UserAgent= "User-Agent,Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/62.0.3202.94 Safari/537.36" });
            UALst.Add(new UA() { Used = false, Name = "win10-Edge", UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 Edge/15.15063" });
            UALst.Add(new UA() { Used = false, Name = "win10-360", UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36" });
            UALst.Add(new UA() { Used = false, Name = "safari 5.1 – MAC", UserAgent = "Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_6_8; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50" });
            UALst.Add(new UA() { Used = false, Name = "safari 5.1 – Windows", UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-us) AppleWebKit/534.50 (KHTML, like Gecko) Version/5.1 Safari/534.50" });
            UALst.Add(new UA() { Used = false, Name = "IE 9.0", UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0;" });
            UALst.Add(new UA() { Used = false, Name = "IE 8.0", UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0)" });
            UALst.Add(new UA() { Used = false, Name = "IE 7.0", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0)" });
            UALst.Add(new UA() { Used = false, Name = "IE 6.0", UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)" });
            UALst.Add(new UA() { Used = false, Name = "Firefox 4.0.1 – MAC", UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.6; rv,2.0.1) Gecko/20100101 Firefox/4.0.1" });
            UALst.Add(new UA() { Used = false, Name = "Firefox 4.0.1 – Windows", UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv,2.0.1) Gecko/20100101 Firefox/4.0.1" });
            UALst.Add(new UA() { Used = false, Name = "Opera 11.11 – MAC", UserAgent = "Opera/9.80 (Macintosh; Intel Mac OS X 10.6.8; U; en) Presto/2.8.131 Version/11.11" });
            UALst.Add(new UA() { Used = false, Name = "Opera 11.11 – Windows", UserAgent = "Opera/9.80 (Windows NT 6.1; U; en) Presto/2.8.131 Version/11.11" });
            UALst.Add(new UA() { Used = false, Name = "Chrome 17.0 – MAC", UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_0) AppleWebKit/535.11 (KHTML, like Gecko) Chrome/17.0.963.56 Safari/535.11" });
            UALst.Add(new UA() { Used = false, Name = "傲游（Maxthon）", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Maxthon 2.0)" });
            UALst.Add(new UA() { Used = false, Name = "腾讯TT", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; TencentTraveler 4.0)" });
            UALst.Add(new UA() { Used = false, Name = "世界之窗（The World） 2.x", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)" });
            UALst.Add(new UA() { Used = false, Name = "世界之窗（The World） 3.x", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; The World)" });
            UALst.Add(new UA() { Used = false, Name = "搜狗浏览器 1.x", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; SE 2.X MetaSr 1.0; SE 2.X MetaSr 1.0; .NET CLR 2.0.50727; SE 2.X MetaSr 1.0)" });
            UALst.Add(new UA() { Used = false, Name = "360浏览器", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; 360SE)" });
            UALst.Add(new UA() { Used = false, Name = "Avant", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Avant Browser)" });
            UALst.Add(new UA() { Used = false, Name = "Green Browser", UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)" });
            
            return UALst;
        }
        public MeiTuan()
        {
            SetUA();
            client = new RestClient();
            client.BaseUrl = new Uri("http://www.meituan.com");
            client.UserAgent = UALst.First().UserAgent;
        }
        public RestClient client { get; set; }
        public MtMobileLst MobileGetDatas(int offset)
        {
            try
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
            catch
            {
                UALst.First(n => n.UserAgent.Equals(client.UserAgent)).Used = true;
                var cua = UALst.FirstOrDefault(n => n.Used != true);
                if (cua != null)
                {
                    client.UserAgent = cua.UserAgent;
                    return MobileGetDatas(offset);
                }
                else
                {
                    return new MtMobileLst();
                }
            }
        }
        public MtWebLst WebGetDatas(string page)
        {
            try
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
            catch 
            {
                UALst.First(n => n.UserAgent.Equals(client.UserAgent)).Used = true;
                var cua = UALst.FirstOrDefault(n => n.Used != true);
                if (cua != null)
                {
                    client.UserAgent = cua.UserAgent;
                    return WebGetDatas(page);
                }
                else
                {
                    return new MtWebLst();
                }
            }
        }
        public string GetDetail(string poiId = "5750537")
        {
            try
            {
                var request = new RestRequest($"/meishi/{poiId}/", Method.GET);
                request.AddCookie("ci", "906");
                request.AddCookie("i_extend", "H__a100001__b5");
                var response = client.Execute(request);
                var r = response.Content;
                var startindex = r.IndexOf("window._appState");
                r = r.Substring(startindex).Replace(" ", "");
                var middlestartindex = r.IndexOf("=");
                r = r.Substring(middlestartindex + 1);
                var end = r.IndexOf(";</script>");
                r = r.Substring(0, end);
                var m = SimpleJson.SimpleJson.DeserializeObject<MtDetail>(r);
                return m.detailInfo.phone;
            }
            catch
            {
                UALst.First(n => n.UserAgent.Equals(client.UserAgent)).Used = true;
                var cua = UALst.FirstOrDefault(n => n.Used != true);
                if (cua != null)
                {
                    client.UserAgent = cua.UserAgent;
                    return GetDetail(poiId);
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
