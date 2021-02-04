using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestTask.Model
{
    public class ArtistTitle : Offer
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Media { get; set; }
        public string Starring { get; set; }
        public string Director { get; set; }
        public string OriginalName { get; set; }
        public string Country { get; set; }
        public bool Delivery { get; set; }

        public ArtistTitle(XmlNode node) : base(node)
        {
            Artist = node["artist"]?.InnerText;
            Title = node["title"]?.InnerText;
            Year = int.Parse(node["year"]?.InnerText);
            Media = node["media"]?.InnerText;
            Starring = node["starring"]?.InnerText;
            Director = node["director"]?.InnerText;
            OriginalName = node["originalName"]?.InnerText;
            Country = node["country"]?.InnerText;
            Delivery = bool.Parse(node["delivery"]?.InnerText);
        }
    }
}
