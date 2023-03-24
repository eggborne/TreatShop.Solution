using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TreatShop.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    
    [Required(ErrorMessage = "Please add a flavor name!")]
    public string Name { get; set; }

    public List<FlavorTreat> JoinEntities { get; }
  }
}