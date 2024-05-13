using System.Data.SqlClient;
using s23358.ModelsDTO;

namespace s23358.Repositories;

public class PrescriptionDTORepositorie : IPrescriptionDTORepositorie
{
    private readonly IConfiguration _configuration;

    public PrescriptionDTORepositorie(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<MedicamentDTO> GetMedicamentDTO(int idMedicament)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = $"SELECT med.IdMedicament,med.Name,med.Description,med.Type,prsM.IdPrescription,prsM.Dose,prsM.Details," +
                          $"pr.Date,pr.DueDate,pr.IdPatient,pr.IdDoctor" +
                          $" FROM [Medicament] as med INNER JOIN [Prescription_Medicament] as prsM ON med.IdMedicament=prsM.IdMedicament"+
                          $"INNER JOIN [Prescription] as pr ON prsM.IdPrescription=pr.IdPrescription WHERE med.IdMedicament= @IdMedicament";

        var dr = await cmd.ExecuteReaderAsync();
        MedicamentDTO? medicamentDto = null;

        while (await dr.ReadAsync())
        {
            medicamentDto = new MedicamentDTO
            {
                IdMedicament = (int)dr["med.IdMedicament"],
                Name = dr["med.Name"].ToString(),
                Description = dr["med.Description"].ToString(),
                Type = dr["med.Type"].ToString(),
                IdPrescription = (int)dr["prsM.IdPrescription"],
                Dose = (int)dr["prsM.Dose"],
                Details = dr["prsM.Details"].ToString(),
                Date = (DateTime)dr["pr.Data"],
                DueDate = (DateTime)dr["pr.DueDate"],
                IdPatient = (int)dr["pr.IdPatient"],
                IdDoctor = (int)dr["pr.IdDoctor"]
            };


        }

        return medicamentDto;
    }
}