namespace HumanoTest.Application.Contracts;

/// <summary>
/// Clase de Respuesta entre el Application y Cliente.
/// </summary>
public class ResponseData
{
    public ResponseData(bool success, object data)
    {
        Success = success;
        Data = data;
    }

    public ResponseData(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public ResponseData(bool success, string message, int dataId)
    {
        Success = success;
        Message = message;
        DataId = dataId;
    }

    public ResponseData()
    {
    }

    public bool Success { get; set; }

    public object Data { get; set; }

    public string Message { get; set; }

    public int DataId { get; set; }
}