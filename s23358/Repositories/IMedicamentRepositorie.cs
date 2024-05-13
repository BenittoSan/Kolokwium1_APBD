using s23358.Models;

namespace s23358.Repositories;

public interface IMedicamentRepositorie
{
  public  Task<Medicament> GetMedicament(int idMedicament);
}