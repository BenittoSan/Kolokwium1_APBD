using s23358.ModelsDTO;

namespace s23358.Repositories;

public interface IPrescriptionDTORepositorie
{
    Task<MedicamentDTO> GetMedicamentDTO(int idMedicament);
}