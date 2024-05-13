using System.ComponentModel.DataAnnotations;

namespace s23358.Models;

public class Doctor
{
    [Required]
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}