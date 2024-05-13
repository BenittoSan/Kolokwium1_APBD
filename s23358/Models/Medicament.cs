using System.ComponentModel.DataAnnotations;

namespace s23358.Models;

public class Medicament
{
   [Required]
    public int IdMedicament { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}