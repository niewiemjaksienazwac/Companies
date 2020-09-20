using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class CompanyEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Www { get; set; }
        public string Nip { get; set; }
        public string Phone { get; set; }

        public CompanyEntity(string Id, string Name, string Address, string Www, string Nip, string Phone)
        {
            this.Id = Id;
            this.Name = Name;
            this.Address = Address;
            this.Www = Www;
            this.Nip = Nip;
            this.Phone = Phone;
        }

        public CompanyEntity() { }
    }
}
