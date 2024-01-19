namespace HumanoTest.Application.Contracts.IServices.Generic;

public interface IGenericQueryService
{
    /// <summary>
    /// Obtener todos los registros.
    /// </summary>
    /// <returns> <see cref="ResponseData"/> </returns>
    Task<ResponseData> GetAllAsync(int page, int take);
}