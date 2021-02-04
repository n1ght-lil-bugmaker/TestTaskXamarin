using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace TestTask.Model
{
    public abstract class Offer
    {
        public int Id { get; set; }
        public int Bid { get; set; }
        public int Cbid { get; set; }
        public bool Available { get; set; }
        public string Url { get; set; }
        public int Price { get; set; }
        public string CurrencyId { get; set; }
        public int CategoryId { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }

        public Offer(XmlNode node)
        {
            Id = int.Parse(node.Attributes.GetNamedItem("id").Value);
            Bid = int.Parse(node.Attributes?.GetNamedItem("bid").Value);
            //Cbid = int.Parse(node.Attributes?.GetNamedItem("cbid")?.Value);
            Available = bool.Parse(node.Attributes?.GetNamedItem("available").Value);

            Url = node["url"].InnerText;
            Price = int.Parse(node["price"].InnerText);
            CurrencyId = node["currencyId"].InnerText;
            CategoryId = int.Parse(node["categoryId"].InnerText);
            Picture = node["picture"].InnerText;
            Description = node["description"].InnerText;
        }

        private static Dictionary<string, Type> _typeNames = new Dictionary<string, Type>
        {
            {"vendor.model", typeof(VendorModel) },
            {"book", typeof(Book) },
            {"audiobook", typeof(AudioBook) },
            {"artist.title", typeof(ArtistTitle) },
            {"tour", typeof(Tour) },
            {"event-ticket", typeof(EventTicket) }
        };


        public virtual string SereilizeToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Offer GetOfferByNode(XmlNode node)
        {
            var typeName = node.Attributes.GetNamedItem("type").Value;
            var type = _typeNames[typeName];
            var consrtuctor = type.GetConstructor(new Type[] { typeof(XmlNode) });

            return consrtuctor.Invoke(new object[] { node }) as Offer;
        }
    }
}