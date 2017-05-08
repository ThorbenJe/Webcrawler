using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Webcrawler
{
    class Crawler
    {
        public static string GetWebCode(string url, string startUrl)
        {
            if (url.Contains(startUrl))
            {
                if (url.Contains("http://") || url.Contains("https://") && !url.Contains("mailto"))
                {
                    try
                    {
                        WebRequest request = WebRequest.Create(url);
                        request.Credentials = CredentialCache.DefaultCredentials;
                        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                Console.WriteLine("The connection is: " + response.StatusDescription);
                                Stream dataStream = response.GetResponseStream();
                                StreamReader reader = new StreamReader(dataStream);
                                string responseFromServer = reader.ReadToEnd();
                                reader.Close();
                                dataStream.Close();
                                response.Close();
                                return responseFromServer;
                            }
                        }
                    }
                    catch (WebException) {}
                    catch (UriFormatException) {}
                }
            }
            return "";
        }
        public static List<string> GetUrlList(string responseFromServer, string startUrl, List<string> urlList, string path)
        {
            string linkedUrl;

            Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

            foreach (var match in regexLink.Matches(responseFromServer))
            {
                if (!urlList.Contains(match.ToString()))
                {
                    linkedUrl = GetLinkedUrl(match.ToString(), startUrl);
                    if (!urlList.Contains(linkedUrl))
                    {
                        urlList.Add(linkedUrl);
                        //System.Threading.Thread.Sleep(500);
                        IoFile.WriteOneLine(path, linkedUrl);
                    }
                }
            }
            return urlList;
        }

        public static string GetLinkedUrl(string url, string startUrl)
        {
            if (!url.Contains("http://") && !url.Contains("https://")) //https://de-de.facebook.com/  http://stackoverflow.com/   http://google.com
            {
                if (url.IndexOf("/", 0) != -1)
                {
                    url = startUrl + url;
                }
                else
                {
                    url = startUrl + "/" + url;
                }
            }
            return url;
        }
    }
}