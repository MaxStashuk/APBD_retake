using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WEB.Models;
using WEB.Models.DTOs;

namespace WEB.Services;

public class MobileService : IMobileService
{
    private string _connectionString;

    public MobileService(String connectionString)
    {
        this._connectionString = connectionString;
    }

    public IEnumerable<GetDto> GetAllNumbers()
    {
        List <GetDto> result = [];
        
        var query = "SELECT n.Id, n.Operator_Id, n.Client_Id, n.Number, o.Name, c.Id, c.Fullname, c.Email, c.City FROM PhoneNumber n JOIN Operator o ON n.Operator_Id = o.ID JOIN Client c ON n.Client_Id = c.ID";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var clientDTO = new ClientDto
                        {
                            id = reader.GetInt32(5),
                            fullName = reader.GetString(6),
                            email = reader.GetString(7),
                            city = reader.GetString(8),
                        };

                        var number = new GetDto
                        {
                            id = reader.GetInt32(0),
                            number = reader.GetString(3),
                            @operator = reader.GetString(4),
                            client = clientDTO,
                        };
                        result.Add(number);
                    }
                }
            }
            finally
            {
                reader.Close();
            }
            return result;
        }
        
        //return NotImplementedException();
    }

    public IEnumerable<PhoneNumber> GetPhoneNumbers()
    {
        List<PhoneNumber> result = [];

        var query = "SELECT * FROM PhoneNumber";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var pn = new PhoneNumber
                        {
                            Id = reader.GetInt32(0),
                            Client_Id = reader.GetInt32(1),
                            Operator_Id = reader.GetInt32(2),
                            Number = reader.GetString(3)
                        };
                        result.Add(pn);
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            return result;
        }
    }

    public IActionResult CreateNumber(CreateDto dto)
    {
        
        string number = dto.mobileNumber;
        if (number[0] != '+' || number[1] != '4' || number[2] != '8')
        {
            return new BadRequestObjectResult("Invalid mobile number");
        }
        
        var checkIfExist = @"SELECT * FROM PhoneNumber WHERE number = @number";
        
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            SqlCommand command = new SqlCommand(checkIfExist, connection);
            command.Parameters.AddWithValue("@number", number);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    return new BadRequestObjectResult("Mobile number already exists");
                }
            }
            finally
            {
                reader.Close();
            }
            
            
            

        }
    }
}