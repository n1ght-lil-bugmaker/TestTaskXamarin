using System.Xml;

namespace TestTask.Model
{
    public class VendorModel : Offer
    { 
        public int LocalDeliveryCost { get; set; }
        public string TypePrefix { get; set; }
        public string Vendor { get; set; }
        public string VendorCode { get; set; }
        public string Model { get; set; }
        public bool ManufacturerWarranty { get; set; }
        public string CountrOfOrigin { get; set; }
        public bool Delivery { get; set; }
        public VendorModel(XmlNode node) : base(node)
        {
            LocalDeliveryCost = int.Parse(node["local_delivery_cost"].InnerText);
            TypePrefix = node["typePrefix"].InnerText;
            Vendor = node["vendor"].InnerText;
            VendorCode = node["vendorCode"].InnerText;
            Model = node["model"].InnerText;
            ManufacturerWarranty = bool.Parse(node["manufacturer_warranty"].InnerText);
            CountrOfOrigin = node["country_of_origin"].InnerText;
            Delivery = bool.Parse(node["delivery"].InnerText);
        }
    }
}