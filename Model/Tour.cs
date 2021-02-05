using System;
using System.Xml;

namespace TestTask.Model
{
    public class Tour : Offer
    {
        public int LocalDeliveryCost { get; set; }
        public string WorldRegion { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int Days { get; set; }
        public DateTime DataTourStart { get; set; }
        public DateTime DataTourFinish { get; set; }
        public string Name { get; set; }
        public string HotelStars { get; set; }
        public string Room { get; set; }
        public string Meal { get; set; }
        public string Included { get; set; }
        public string Transport { get; set; }
        public bool Delivery { get; set; }


        public Tour(XmlNode node) : base(node)
        {
            LocalDeliveryCost = int.Parse(node["local_delivery_cost"].InnerText);
            WorldRegion = node["worldRegion"].InnerText;
            Country = node["country"].InnerText;
            Region = node["region"].InnerText;
            Days = int.Parse(node["days"].InnerText);
            Name = node["name"].InnerText;
            Room = node["room"].InnerText;
            HotelStars = node["hotel_stars"].InnerText;
            Meal = node["meal"].InnerText;
            Included = node["included"].InnerText;
            Transport = node["transport"].InnerText;
            Delivery = bool.Parse(node["delivery"].InnerText);
        }
    }
}
