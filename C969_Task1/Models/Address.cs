using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Task1.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LastUpdateBy { get; set; }

        public Address() { }

        public Address(int AddressID, string Address1, string Address2, int CityId, string PostalCode, string Phone, DateTime CreateDate, string CreatedBy, DateTime LastUpdate, string lastUpdatedBy)
        {
            this.AddressId = AddressID;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.CityId = CityId;
            this.PostalCode = PostalCode;
            this.Phone = Phone;
            this.CreateDate = CreateDate;
            this.CreatedBy = CreatedBy;
            this.LastUpdate = LastUpdate;
            this.LastUpdateBy = LastUpdateBy;
        }
        public void AddAddress()
        {
            // Add address to database

        }

        public void UpdateAddress()
        {
            // Update address in database
        }

        public void DeleteAddress()
        {
            // Delete address from database
        }

        public void GetAddress(int AddressID)
        {
            // Get address from database
        }
    }
}
