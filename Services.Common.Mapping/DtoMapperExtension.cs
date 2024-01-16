namespace Services.Common.Mapping;

using System.Text.Json;

public static class DtoMapperExtension
{
    public static T MapTo<T>(this object value)
    {
        return JsonSerializer.Deserialize<T>(
            JsonSerializer.Serialize(value)
        );
    }
}