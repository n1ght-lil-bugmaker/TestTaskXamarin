using System;
using System.Xml;

namespace TestTask.Model
{
    public class EventTicket : Offer
    {
        public bool Delivery { get; set; }
        public int LocalDeliveryCost { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Hall { get; set; }
        public string HallPart { get; set; }
        public DateTime Date { get; set; }
        public int IsPremiere { get; set; }
        public int IsKids { get; set; }

        public EventTicket(XmlNode node) : base(node)
        {
            Delivery = bool.Parse(node["delivery"].InnerText);
            LocalDeliveryCost = int.Parse(node["local_delivery_cost"].InnerText);
            Name = node["name"].InnerText;
            Place = node["place"].InnerText;
            Hall = node["hall"].InnerText;
            HallPart = node["hall_part"].InnerText;
            Date = DateTime.Parse(node["date"].InnerText);
            IsPremiere = int.Parse(node["is_premiere"].InnerText);
            IsKids = int.Parse(node["is_kids"].InnerText);

        }

    }
}
