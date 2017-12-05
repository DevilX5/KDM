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
            request.AddHeader("cityname", "%E7%BB%B5%E7%AB%B9");
            request.AddCookie("IJSESSIONID", "1iws39wmu0vymmoktu8s22cdo");
            request.AddCookie("__mta", "177495962.1512457738699.1512467803130.1512467929018.6");
            request.AddCookie("__mta", "177495962.1512457738699.1512467929018.1512473243581.7");
            request.AddCookie("__utma", "74597006.961756497.1512467116.1512467721.1512472511.3");
            request.AddCookie("__utmb", "74597006.23.9.1512473651112");
            request.AddCookie("__utmc", "74597006");
            request.AddCookie("__utmz", "74597006.1512472511.3.3.utmcsr=shifang.meituan.com|utmccn=(referral)|utmcmd=referral|utmcct=/s/%E6%9C%A8%E5%B1%8B%E7%83%A7%E7%83%A4%EF%BC%88%E5%AE%9D%E6%9D%A8%E5%BA%97%EF%BC%89/");
            request.AddCookie("_hc.v", "5342fb13-e5fa-a007-7297-8a67268efa02.1512467118");
            request.AddCookie("_lx_utm", "utm_source%3DBaidu%26utm_medium%3Dorganic");
            request.AddCookie("_lx_utm", "utm_source%3DBaidu%26utm_medium%3Dorganic");
            request.AddCookie("_lxsdk_cuid", "160258197f2c8-0b96ea23d2ba0a-7b113d-1fa400-160258197f3c8");
            request.AddCookie("_lxsdk_s", "160260f36e4-488-089-7dd%7C%7C50");
            request.AddCookie("ci", "906");
            request.AddCookie("ci3", "1");
            request.AddCookie("cityname", "\"%E7%BB%B5%E7%AB%B9\"");
            request.AddCookie("client-id", "cf41a0cd-8b04-49f6-acbd-4ccb2f9bda9c");
            request.AddCookie("i_extend", "C_b1Gimthomepagecategory11H__a");
            request.AddCookie("idau", "1");
            request.AddCookie("iuuid", "8EA8368FE4BB3D427E1B023447AD6E0B38B93948889BCD58DC6BDE24B6FEB74B");
            //request.AddCookie("latlng", "31.126856,104.397894,1512473627841");
            request.AddCookie("oc", "AIPbgpNI1VcIa3pmn-zB4GpzJRZl-h6SYEQyTJDzB2akH0dC4IO_M3s5g5X9kA3W9aTMY0WE2CWOTqdW0kQBcjeZQWRuEo6iPIHs6ISoldIzwh6QhMOrD244kXaYfu2O402XvpjFL4qW5E4g_XzSLF-X_Oa7s97RIQDFI4J86kc");
            request.AddCookie("rvct", "953%2C585%2C593%2C305%2C906");
            request.AddCookie("uuid", "fe7879038cf2426c84e6.1512457737.1.0.0");
            request.AddCookie("webp", "1");

            var response = client.Execute(request);
            var mtlst = SimpleJson.SimpleJson.DeserializeObject<MtLst>(response.Content);
            return mtlst;
        }
    }
}
