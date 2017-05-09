using System;
using System.Collections.Generic;

namespace Webcrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\T. Jezioro\Documents\Visual Studio 2015\Projects\Webcrawler\";
            Gui.Write("Please enter a full url: ");
            string url = Gui.UserRequest();
            string startUrl = url;
            string httpHttps = url.Substring(4, 1);
            //path = IoFile.CreatFile(path);
            url = Crawler.GetLinkedUrl(url, startUrl, httpHttps);
            List<string> urlList = new List<string>() {url};
            int counter = 0;

            Uri myUri = new Uri(startUrl);
            string domain = myUri.Host;

            try
            {
                while (urlList[counter].Length > 4)
                {
                    url = urlList[counter];
                    counter++;
                    Gui.WriteLine(startUrl);
                    Gui.WriteLine(url);
                    Console.WriteLine("We are at Link Nr. " +counter);
                    //System.Threading.Thread.Sleep(300);

                    string responseFromServer = Crawler.GetWebCode(url, startUrl, domain);
                    if (responseFromServer != "")
                    {
                        urlList = Crawler.GetUrlList(responseFromServer, startUrl, urlList, path, httpHttps);
                        Console.WriteLine("Links exist " +urlList.Count);
                        Gui.WriteFontGreen("Link Checked");
                    }
                    else
                    {
                        Gui.WriteFontRed("ERROR");
                    }
                }
            }
            catch (ArgumentOutOfRangeException) {}
            Gui.Write("Please press any key to close this application.");
            Console.ReadKey();
        }
    }
}
