using System;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Text;

namespace DAxZE.Extension
{
    internal class WebRequestHelper
    {
        /// <summary>
        /// GET访问网址
        /// </summary>
        /// <param name="Url">网址</param>
        public static string HttpGet(string Url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
