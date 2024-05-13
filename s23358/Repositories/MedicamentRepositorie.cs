using System.Data.SqlClient;
using s23358.Models;

namespace s23358.Repositories;

public class MedicamentRepositorie : IMedicamentRepositorie
{
    private readonly IConfiguration _configuration;

    public MedicamentRepositorie(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<Medicament> GetMedicament(int idMedicament)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdMedicament, Name, Description,Type FROM [Medicament] WHERE IdMedicameny = @IdMedicament";

        var dr = await cmd.ExecuteReaderAsync();
        Medicament? medicament = null;
        while (await dr.ReadAsync())
        {
            medicament = new Medicament
            {
                IdMedicament = (int)dr["IdMedicament"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Type = dr["Type"].ToString()
            };

        }

        return medicament;
    }
}