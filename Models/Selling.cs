using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class Selling:IModel
    {
        [Key]public int ID { get; set; }
        public int InvoiceNumber { get; set; }
        public string CustomerName { get; set; }//должен быть Foreign key на таблицу Customer
        public string SoftName { get; set; }// должен быть Foreign key на таблицу soft
        public double Price { get; set; }
        public string LicenseType { get; set; }// должен быть Foreign key на таблицу LicenseType
        public string DiscountName { get; set; }// должен быть Foreign key на таблицу Discount
    }
}
