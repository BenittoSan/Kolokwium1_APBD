using s23358.ModelsDTO;

namespace s23358.Services;

public interface IPrescriptionServices
{
    Task<MedicamentDTO> GetMedicametDto(int idMedicament);
}