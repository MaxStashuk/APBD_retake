namespace WEB.Models.DTOs;

public class GetDto
{
    public int id { get; set; }
    public String number { get; set; }
    public String @operator { get; set; }
    public ClientDto client { get; set; }
}

public class ClientDto
{
    public int id { get; set; }
    public String fullName { get; set; }
    public String email { get; set; }
    public String city { get; set; }
}