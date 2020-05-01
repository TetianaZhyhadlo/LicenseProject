using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class DeveloperTeam:IModel
    {
        [Key]public int ID { get; set; }
        public string Name { get; set; }
        public string PeopleQuantity { get; set; }
        
        
    }
}
