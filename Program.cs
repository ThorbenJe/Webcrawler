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
            url = Crawler.GetLinkedUrl(url, startUrl);
            List<string> urlList = new List<string>() {url};
            int counter = 0;

            try
            {
                while (urlList[counter].Length > 4)
                {
                    if (urlList[counter].Length > 4)
                    {
                        url = urlList[counter];
                        counter++;
                        Gui.WriteLine(url);

                        string responseFromServer = Crawler.GetWebCode(url, startUrl);
                        if (responseFromServer != "")
                        {
                            urlList = Crawler.GetUrlList(responseFromServer, startUrl, urlList, path);
                        }
                        else
                        {
                            Gui.WriteFontRed("ERROR");
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException) {}
            Gui.Write("Please press any key to close this application.");
            Console.ReadKey();
        }
    }
}
