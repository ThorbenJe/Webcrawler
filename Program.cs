using System;
using System.Collections.Generic;

namespace Webcrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @".\";
            Gui.Write("Please enter a full url: ");
            var url = Gui.UserRequest();
            var startUrl = url;
            var httpHttps = url.Substring(4, 1);
            url = Crawler.GetLinkedUrl(url, startUrl, httpHttps);
            var urlList = new List<string>() {url};
            var counter = 0;

            var myUri = new Uri(startUrl);
            var domain = myUri.Host;

            try
            {
                while (urlList[counter].Length > 4)
                {
                    url = urlList[counter];
                    counter++;
                    Gui.WriteLine(startUrl);
                    Gui.WriteLine(url);
                    Console.WriteLine("We are at Link Nr. " +counter);

                    var responseFromServer = Crawler.GetWebCode(url, startUrl, domain);
                    if (responseFromServer != "")
                    {
                        urlList = Crawler.GetUrlList(responseFromServer, startUrl, urlList, path, httpHttps);
                        Gui.WriteLine("Links exist " + urlList.Count);
                        Gui.WriteGreen("Link Checked");
                    }
                    else
                    {
                        Gui.WriteRed("ERROR");
                    }
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                Gui.WriteRed(e.Message);
            }
            Gui.Write("Please press any key to close this application.");
            Console.ReadKey();
        }
    }
}
