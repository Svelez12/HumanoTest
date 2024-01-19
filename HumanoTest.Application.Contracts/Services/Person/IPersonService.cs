namespace HumanoTest.Application.Contracts.IServices.Person;

using HumanoTest.Application.Contracts.IServices.Generic;
using HumanoTest.Application.Models.Person;

public interface IPersonService : IGenericQueryService
{
    /// <summary>
    /// Crear <see cref="Person"/>.
    /// </summary>
    /// <param name="PersonDto"><see cref="PersonCreateDto"/>. </param>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> CreateAsync(PersonCreateDto personCreateDto);


    /// <summary>
    /// 
    /// </summary>
    /// <param name="identityNumberId"></param>
    /// <returns></returns>
    Task<ResponseData> GetByIdentityNumberId(int page, int take, int identityNumberId);
}