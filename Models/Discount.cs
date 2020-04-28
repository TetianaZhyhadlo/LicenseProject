using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class Discount:IModel
    {
        [Key] public int ID { get; set; }
        public string DiscountName { get; set; }
        public double Percantage { get; set; }
    }
}
