using Microsoft.AspNetCore.Mvc;
using WEB.Models;
using WEB.Models.DTOs;

namespace WEB.Services;

public interface IMobileService
{
    public IEnumerable<GetDto> GetAllNumbers();
    public IEnumerable<PhoneNumber> GetPhoneNumbers();
    public IActionResult<CreateDto> CreateNumber(CreateDto number);
}