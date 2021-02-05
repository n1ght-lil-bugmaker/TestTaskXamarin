using System.Xml;

namespace TestTask.Model
{
    public class AudioBook : Offer
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public string PerformedBy { get; set; }
        public string PerformanceType { get; set; }
        public string Storage { get; set; }
        public string Format { get; set; }
        public string RecordingLength { get; set; }
        public bool Downloadable { get; set; }
        public AudioBook(XmlNode node) : base(node)
        {
            Author = node["author"].InnerText;
            Name = node["name"].InnerText;
            Publisher = node["publisher"].InnerText;
            Year = int.Parse(node["year"].InnerText);
            ISBN = node["ISBN"].InnerText;
            Language = node["language"].InnerText;

            PerformedBy = node["performed_by"].InnerText;
            PerformanceType = node["performance_type"].InnerText;
            Storage = node["storage"].InnerText;
            Format = node["format"].InnerText;
            RecordingLength = node["recording_length"].InnerText;
            Downloadable = bool.Parse(node["downloadable"].InnerText);
        }


    }
}