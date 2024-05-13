using s23358.Models;

namespace s23358.Repositories;

public interface IPrescription_MedicamentRepositorie
{
    Task<Prescription_Medicament> GetPrescription_Medicament(int idMedicament);
}