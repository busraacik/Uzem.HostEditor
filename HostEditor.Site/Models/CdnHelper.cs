using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostEditor
{
    public static class CdnHelper
    {
        public static string CdnUrl()
        {
            return "http://cdn.lms.sabis.sakarya.edu.tr";
        }
        public static string CdnContent(string file)
        {
            return CdnUrl() + file;
        }
        public static string AceCss(string file, string version = "v1.3.3")
        {
            return CdnUrl() + "/Content/ace/" + version + "/assets/css/" + file;
        }
        public static string AceCssDist(string file, string version = "v1.3.3")
        {
            return CdnUrl() + "/Content/ace/" + version + "/dist/css/" + file.Replace(".css", ".min.css");
        }
        public static string AceJs(string file, string version = "v1.3.3")
        {
            return CdnUrl() + "/Content/ace/" + version + "/assets/js/" + file;
        }
        public static string AceJsDist(string file, string version = "v1.3.3")
        {
            return CdnUrl() + "/Content/ace/" + version + "/dist/js/" + file.Replace(".js", ".min.js");
        }
    }
}