using System.Xml;

namespace TestTask.Model
{
    public class Book : Offer
    {
        public int LocalDeliveryCost { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Series { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int Volume { get; set; }
        public int Part { get; set; }
        public string Language { get; set; }
        public string Binding { get; set; }
        public int PageExtent { get; set; }
        public bool Downloadable { get; set; }
        public bool Delivery { get; set; }


        public Book(XmlNode node) : base(node)
        {
            LocalDeliveryCost = int.Parse(node["local_delivery_cost"].InnerText);
            Delivery = bool.Parse(node["delivery"].InnerText);
            Author = node["author"].InnerText;
            Name = node["name"].InnerText;
            Publisher = node["publisher"].InnerText;
            Series = node["series"].InnerText;
            Year = int.Parse(node["year"].InnerText);
            ISBN = node["ISBN"].InnerText;
            Volume = int.Parse(node["volume"]?.InnerText);
            Part = int.Parse(node["part"]?.InnerText);
            Language = node["language"].InnerText;
            Binding = node["binding"]?.InnerText;
            PageExtent = int.Parse(node["page_extent"]?.InnerText);
            Downloadable = bool.Parse(node["downloadable"].InnerText);

        }

    }
}