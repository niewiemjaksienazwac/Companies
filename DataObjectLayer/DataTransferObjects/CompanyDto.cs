using System.Runtime.Serialization;

namespace DataObjectLayer.DataTransferObjects
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string InternetAddress { get; set; }
        public string NipNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
