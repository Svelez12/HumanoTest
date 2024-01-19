namespace HumanoTest.Controllers;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Person.Commands;
using HumanoTest.Application.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ISender sender;

    public PersonController(ISender Sender)
    {
        sender = Sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] GetAllPersons getAllPersons)
    {
        ResponseData responseData = await sender.Send(getAllPersons);

        if (!responseData.Success)
        {
            return BadRequest(responseData);
        }

        return Ok(responseData);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreatePerson createPerson)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errors = ModelState });
        }

        ResponseData responseData = await sender.Send(createPerson);

        if (responseData.Success)
        {
            return Ok(responseData); ;
        }

        return BadRequest(responseData);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(DeletePerson deletePerson)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { errors = ModelState });
        }

        ResponseData responseData = await sender.Send(deletePerson);

        if (responseData.Success)
        {
            return Ok(responseData); ;
        }

        return BadRequest(responseData);
    }
}