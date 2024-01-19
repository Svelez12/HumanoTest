namespace HumanoTest.Application.Person.Queries;

using HumanoTest.Application.Contracts;
using HumanoTest.Application.Models.BaseModels;
using MediatR;

public class GetAllPersons : PaginationDto, IRequest<ResponseData>
{
    public GetAllPersons()
    {
    }

    public GetAllPersons(int page, int take, string identityNumber) : base(page, take)
    {
        IdentityNumber = identityNumber;
    }

    public string IdentityNumber { get; set; } = string.Empty;
}