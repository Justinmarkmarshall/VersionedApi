using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VersionedApi.Models.v1
{
    [XmlRoot("EventRequest")]
    public class EventRequest
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        // This will serialize as <EventDate>2025-07-20</EventDate>
        [XmlElement("EventDate", DataType = "date")]
        public DateTime EventDate { get; set; }
    }
}
