namespace HumanoTest.Application.Models.BaseModels;

public class BaseDto
{
    /// <summary>
    /// Crear Modelo Base.
    /// </summary>
    public BaseDto()
    {
    }

    /// <summary>
    /// Editar Modelo Base.
    /// </summary>
    /// <param name="id"> Id de Registro. </param>
    public BaseDto(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}