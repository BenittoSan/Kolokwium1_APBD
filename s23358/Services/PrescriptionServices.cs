using s23358.ModelsDTO;
using s23358.Repositories;

namespace s23358.Services;

public class PrescriptionServices : IPrescriptionServices
{
    private readonly IPrescriptionDTORepositorie _prescriptionDtoRepositorie;

    public PrescriptionServices(IPrescriptionDTORepositorie prescriptionDtoRepositorie)
    {
        _prescriptionDtoRepositorie = prescriptionDtoRepositorie;
    }
    
    public Task<MedicamentDTO> GetMedicametDto(int idMedicament)
    {
       return _prescriptionDtoRepositorie.GetMedicamentDTO(idMedicament);
    }
}