using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDM
{

    public class MtMobileLst
    {
        public int status { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Poilist poiList { get; set; }
        public object[] tips { get; set; }
        public string notification { get; set; }
        public Webview webView { get; set; }
        public Tracedata traceData { get; set; }
    }

    public class Poilist
    {
        public Poilist()
        {
            poiInfos = new List<Poiinfo>();
        }
        public int totalCount { get; set; }
        public List<Poiinfo> poiInfos { get; set; }
    }

    public class Poiinfo
    {
        public Poiinfo()
        {
            smartTags = new List<Smarttag>();
        }
        public int avgPrice { get; set; }
        public float avgScore { get; set; }
        public string cateName { get; set; }
        public string channel { get; set; }
        public string showType { get; set; }
        public string frontImg { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string name { get; set; }
        public string poiid { get; set; }
        public string areaName { get; set; }
        public string iUrl { get; set; }
        public Poiimgextra poiImgExtra { get; set; }
        public Extraservicetag[] extraServiceTags { get; set; }
        public List<Smarttag> smartTags { get; set; }
        public Preferentialinfo preferentialInfo { get; set; }
        public string ctPoi { get; set; }
        public string distance { get; set; }
    }

    public class Poiimgextra
    {
    }

    public class Preferentialinfo
    {
        public int hiddenNumber { get; set; }
        public Maidan maidan { get; set; }
        public Combo combo { get; set; }
    }

    public class Maidan
    {
        public Maidan()
        {
            entries = new List<Entry>();
        }
        public int defaultShowNum { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Entry
    {
        public string discount { get; set; }
        public string discountColor { get; set; }
        public string content { get; set; }
        public string icon { get; set; }
        public string promotion { get; set; }
        public int hasBorder { get; set; }
        public string borderColor { get; set; }
    }

    public class Combo
    {
        public int defaultShowNum { get; set; }
        public object[] entries { get; set; }
    }

    public class Extraservicetag
    {
        public string icon { get; set; }
        public Text text { get; set; }
    }

    public class Text
    {
        public string content { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
    }

    public class Smarttag
    {
        public string icon { get; set; }
        public Text1 text { get; set; }
    }

    public class Text1
    {
        public string content { get; set; }
        public string color { get; set; }
        public string backgroundColor { get; set; }
    }

    public class Webview
    {
        public string viewType { get; set; }
        public string viewUrl { get; set; }
        public int position { get; set; }
        public string impressionUrl { get; set; }
        public object[] impressionUrls { get; set; }
    }

    public class Tracedata
    {
        public string _apimeishi_rerank_report_data { get; set; }
    }

}
