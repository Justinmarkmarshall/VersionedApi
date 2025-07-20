using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VersionedApi.Models.v2
{
    [XmlRoot("EventRequest")]
    public class EventRequest
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        // This will serialize as full datetime ISO 8601 (e.g. 2025-07-20T14:23:00Z)
        [XmlElement("EventDate")]
        public DateTime EventDate { get; set; }
    }
}
