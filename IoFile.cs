using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Webcrawler
{
    class IoFile
    {
        public static void JsonWriteAll(string path, List<string> list)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(list));
        }
        public static void JsonWriteLine(string path, List<string> list)
        {
            path = path + "UrlList_" + DateTime.Now.ToString("yyyy.MM.dd_HH.mm") + ".json";
            //Gui.WriteLine(path);
            File.WriteAllLines(path, list);
        }
        public static void WriteOneLine(string path, string text)
        {
            //path = path + "UrlList_" + DateTime.Now.ToString("yyyy.MM.dd_HH.mm") + ".json";
            path = path + "UrlList.json";
            File.AppendAllText(path, text + Environment.NewLine);
        }
    }
}
