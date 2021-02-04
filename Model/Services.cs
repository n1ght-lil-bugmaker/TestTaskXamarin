using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace TestTask.Model
{
    public static class Services
    { 
        private static string url = "http://partner.market.yandex.ru/pages/help/YML.xml";
        private static string filename = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory,
                                                     "data2.xml");

        static Services()
        {
            if (!File.Exists(filename))
            {
                GetData();
            }
        }
        private static void GetData()
        {
            using (var wc = new WebClient())
            {
                var res = Encoding.GetEncoding(1251).GetString(wc.DownloadData(url));
                Console.Write(res);
                File.WriteAllText(filename, res, Encoding.GetEncoding(1251));
                //return await wc.DownloadStringTaskAsync(Url);
                
            }
        }

        public static IEnumerable<Offer> GetOffers()
        {
            var doc = new XmlDocument();
            doc.Load(filename);

            var root = doc.DocumentElement;

            foreach (XmlNode node in root)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "offers")
                    {
                        foreach (XmlNode grandchild in child.ChildNodes)
                        {
                            //yield return grandchild.Attributes.GetNamedItem("id").Value;
                            yield return Offer.GetOfferByNode(grandchild);
                        }
                    }
                }
            }
        }
    }
}