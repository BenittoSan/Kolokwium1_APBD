using s23358.Models;

namespace s23358.Repositories;

public interface IPrescriptionRepositorie
{
    Task<Prescription_Medicament> GetPrescription(int id);
}