using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM
{

    public class MtDetail
    {
        public Meta meta { get; set; }
        public bool loadQQMapScript { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string keyword { get; set; }
        public Detailinfo detailInfo { get; set; }
        public Photos photos { get; set; }
        public Recommended[] recommended { get; set; }
        public Crumbnav[] crumbNav { get; set; }
        public Prefer[] prefer { get; set; }
        public Deallist dealList { get; set; }
        public string poiId { get; set; }
        public int userId { get; set; }
        public string ci { get; set; }
        public string uuid { get; set; }
        public string comHeader { get; set; }
        public string comFooter { get; set; }
    }

    public class Meta
    {
        public string knbJS { get; set; }
        public string adunionJS { get; set; }
        public string uuid { get; set; }
        public string iuuid { get; set; }
        public int userId { get; set; }
        public string cityId { get; set; }
        public string cityName { get; set; }
        public string userName { get; set; }
        public string title { get; set; }
    }

    public class Detailinfo
    {
        public int poiId { get; set; }
        public string name { get; set; }
        public int avgScore { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string openTime { get; set; }
        public object[] extraInfos { get; set; }
        public bool hasFoodSafeInfo { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public int avgPrice { get; set; }
        public int brandId { get; set; }
        public string brandName { get; set; }
        public int showStatus { get; set; }
    }

    public class Photos
    {
        public string frontImgUrl { get; set; }
        public string[] albumImgUrls { get; set; }
    }

    public class Deallist
    {
        public Deal[] deals { get; set; }
        public object[] vouchers { get; set; }
        public string iconUrl { get; set; }
    }

    public class Deal
    {
        public int id { get; set; }
        public string frontImgUrl { get; set; }
        public string title { get; set; }
        public int soldNum { get; set; }
        public int price { get; set; }
        public int value { get; set; }
    }

    public class Recommended
    {
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string frontImgUrl { get; set; }
    }

    public class Crumbnav
    {
        public string title { get; set; }
        public string url { get; set; }
    }

    public class Prefer
    {
        public string itemId { get; set; }
        public string title { get; set; }
        public string imgUrl { get; set; }
        public string score { get; set; }
        public object consumeNum { get; set; }
        public string areaName { get; set; }
        public string lowPrice { get; set; }
        public object saleNum { get; set; }
        public int commentNum { get; set; }
        public string detailUrl { get; set; }
        public int[] firstCate { get; set; }
        public int avgPrice { get; set; }
    }

}
