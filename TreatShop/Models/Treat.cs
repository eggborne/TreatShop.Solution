using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Treat
    {
        public int TreatId { get; set; }

        [Required(ErrorMessage = "Please add a Treat name!")]
        public string Name { get; set; }
        
        public List<FlavorTreat> JoinEntities { get;}
    }
}