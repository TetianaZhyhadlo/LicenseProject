using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class Selling:IModel
    {
        [Key]public int ID { get; set; }
        public int InvoiceNumber { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")] public Customer Customer { get; set; }
        public int SoftID { get; set; }
        [ForeignKey("SoftID")] public Soft Soft { get; set; }
        public double Price { get; set; }
        public int LicenseTypeID { get; set; }
        [ForeignKey("LicenseTypeID")] public LicenseType LicenseType { get; set; }
        public int DiscountID { get; set; }
        [ForeignKey("DiscountID")] public Discount Discount { get; set; }

    }
}
