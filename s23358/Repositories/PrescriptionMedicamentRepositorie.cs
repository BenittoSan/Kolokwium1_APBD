using System.Data.SqlClient;
using s23358.Models;

namespace s23358.Repositories;

public class PrescriptionMedicamentRepositorie : IPrescription_MedicamentRepositorie
{
    private readonly IConfiguration _configuration;

    public PrescriptionMedicamentRepositorie(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
    
    public async Task<Prescription_Medicament> GetPrescription_Medicament(int idMedicament)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdMedicament,IdPrescription,Dose,Details FROM Prescription_Medicament ";

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