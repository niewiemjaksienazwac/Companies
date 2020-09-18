using System.Runtime.Serialization;

namespace DataObjectLayer.DataTransferObjects
{
    [DataContract]
    public class CompanyDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string PhysicalAddress { get; set; }
        [DataMember]
        public string InternetAddress { get; set; }
        [DataMember]
        public string NipNumber { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
    }
}
