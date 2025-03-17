using DotNetBase.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Entities.SupplierManagement
{
    public class Supplier : BaseEntity, ISoftDeletable
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string ContactPerson { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string TaxNumber { get; set; }
        public string TaxOffice { get; set; }
        public bool isApproved { get; set; } = false;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
