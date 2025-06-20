namespace WEB.Models.DTOs;

public class CreateDto
{
    public string @operator { get; set; }
    public string mobileNumber { get; set; }
    public ClientCreateDto client { get; set; }
}

public class ClientCreateDto
{
    public String fullName { get; set; }
    public String email { get; set; }
    public String city { get; set; }
}