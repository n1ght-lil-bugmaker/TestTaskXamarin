using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestTask.Model
{
    public static class Services
    { 
        private static string _url = "http://partner.market.yandex.ru/pages/help/YML.xml";
        private static string _filename = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory,
                                                     "data.xml");
                                                     

        static Services()
        {
            if(!File.Exists(_filename))
            {
                GetDataAsync().Wait();
            }
        }
        private async static Task<Task> GetDataAsync()
        {
            using (var wc = new WebClient())
            {
                string res = Encoding.GetEncoding(1251).GetString(await wc.DownloadDataTaskAsync(_url));
                File.WriteAllText(_filename, res, Encoding.GetEncoding(1251));
            }
            return Task.CompletedTask;
        }

        public static IEnumerable<Offer> GetOffers()
        {
           
            var doc = new XmlDocument();
            doc.Load(_filename);

            XmlElement root = doc.DocumentElement;

            foreach (XmlNode node in root)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "offers")
                    {
                        foreach (XmlNode grandchild in child.ChildNodes)
                        {
                            yield return Offer.GetOfferByNode(grandchild);
                        }
                    }
                }
            }
        }
    }
}