using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseProject.Models
{
    public class DeveloperTeam:IModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PeopleQuantity { get; set; }
    }
}
