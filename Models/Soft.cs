using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class Soft:IModel
    {
        [Key] public int ID { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
    }
}
