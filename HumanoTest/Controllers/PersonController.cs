namespace HumanoTest.Controllers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Contracts.IServices.Person;
using HumanoTest.Application.Models.Person;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService personService;
    private readonly ILogger<PersonController> _logger;

    public PersonController(IPersonService PersonService, ILogger<PersonController> logger)
    {
        personService = PersonService;
        _logger = logger;

    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int page = 1, int take = 10, int identificatioNumberId= 0)
    {
        ResponseData responseData = new();

        if (identificatioNumberId > 0)
        {
            responseData = await personService.GetByIdentityNumberId(page, take, identificatioNumberId);
        }
        else
        {
            responseData = await personService.GetAllAsync(page, take);
        }


        if (!responseData.Success)
        {
            return BadRequest(responseData);
        }

        return Ok(responseData);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PersonCreateDto personCreateDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errors = ModelState });
        }

        ResponseData responseData = await personService.CreateAsync(personCreateDto);

        if (!responseData.Success)
        {
            return BadRequest(responseData);
        }

        return Ok(responseData);
    }



}