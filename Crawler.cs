using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Webcrawler
{
    class Crawler
    {
        public static string GetWebCode(string url, string startUrl, string domain)
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
                                //Console.WriteLine("The connection is: " + response.StatusDescription);
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
        public static List<string> GetUrlList(string responseFromServer, string startUrl, List<string> urlList, string path, string httpHttps)
        {
            string linkedUrl;
            

            Regex regexLink = new Regex("(?<=<a\\s*?href=(?:'|\"))[^'\"]*?(?=(?:'|\"))");

            foreach (var match in regexLink.Matches(responseFromServer))
            {
                if (!urlList.Contains(match.ToString()))
                {
                    linkedUrl = GetLinkedUrl(match.ToString(), startUrl, httpHttps);
                    if (!urlList.Contains(linkedUrl))
                    {
                        urlList.Add(linkedUrl);
                        IoFile.WriteOneLine(path, linkedUrl);
                    }
                }
            }
            return urlList;
        }

        public static string GetLinkedUrl(string url, string startUrl, string httpHttps)
        {
            if (!url.Contains("http://") && !url.Contains("https://"))
            {
                if (url.IndexOf("/", 0) != -1)
                {
                    //url = startUrl + url;
                    Uri myUri = new Uri(startUrl);
                    string host = myUri.Host;
                    if (httpHttps == "s")
                    {
                        url = "https://" + host + url;
                    }
                    else
                    {
                        url = "http://" + host + url;
                    }
                }
                else
                {
                    //url = startUrl + "/" + url;
                    Uri myUri = new Uri(startUrl);
                    string host = myUri.Host;
                    if (httpHttps == "s") {
                        url = "https://" + host + "/" + url;
                    }else
                    {
                        url = "http://" + host + "/" + url;
                    }
                }
            }
            return url;
        }
    }
}
