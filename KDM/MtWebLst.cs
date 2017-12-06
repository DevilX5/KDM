using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM
{

    public class MtWebLst
    {
        public int status { get; set; }
        public WebData data { get; set; }
    }

    public class WebData
    {
        public WebData()
        {
            poiInfos = new List<WebPoiinfo>();
        }
        public int totalCounts { get; set; }
        public List<WebPoiinfo> poiInfos { get; set; }
    }

    public class WebPoiinfo
    {
        public WebPoiinfo()
        {
            dealList = new List<WebDeallist>();
        }
        public int poiId { get; set; }
        public string frontImg { get; set; }
        public string title { get; set; }
        public float avgScore { get; set; }
        public int allCommentNum { get; set; }
        public string address { get; set; }
        public int avgPrice { get; set; }
        public string dh { get; set; }

        public string Deal
        {
            get {
                return string.Join(";",dealList.Select(n => $"{n.title}|价格:{n.price}|已售:{n.soldCounts}"));
            }
        }

        public List<WebDeallist> dealList { get; set; }
    }

    public class WebDeallist
    {
        public string title { get; set; }
        public float price { get; set; }
        public int soldCounts { get; set; }
    }

}
