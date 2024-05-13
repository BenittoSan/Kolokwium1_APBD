using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using s23358.ModelsDTO;
using s23358.Services;

namespace s23358.Controllers;

[Route("api/medicaments")]
[ApiController]
public class PrescritionController : ControllerBase
{
    private IPrescriptionServices _prescriptionServices;
    
    public PrescritionController(IPrescriptionServices prescriptionServices)
    {
        _prescriptionServices = prescriptionServices;
    }


    [HttpGet("{id:int}")]
    public IActionResult GetMedicaments(int id)
    {
       var medicament= _prescriptionServices.GetMedicametDto(id);
       return Ok(medicament);
    }
    
    
}