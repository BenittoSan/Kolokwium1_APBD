using System.Data.SqlClient;
using s23358.Models;

namespace s23358.Repositories;

public class PrescriptionRepositorie: IPrescriptionRepositorie
{
    private readonly IConfiguration _configuration;

    public PrescriptionRepositorie(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<Prescription_Medicament> GetPrescription(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdPrescription,Data,DueDate,IdPatient,IdDoctor";

        var dr = await cmd.ExecuteReaderAsync();
        Prescription_Medicament prescriptionMedicament = null;
        while (await dr.ReadAsync())
        {
            prescriptionMedicament = new Prescription_Medicament()
            {
                IdMedicament = (int)dr["IdMedicament"],
                IdPrescription = (int)dr["IdPrescription"],
                Dose = (int)dr["Dose"],
                Details = dr["Details"].ToString()

            };
            
        }
        return prescriptionMedicament;
    }
}