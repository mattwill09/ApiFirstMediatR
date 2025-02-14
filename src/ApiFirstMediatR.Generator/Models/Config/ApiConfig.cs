namespace ApiFirstMediatR.Generator.Models.Config;

internal sealed class ApiConfig
{
    public required SerializationLibrary SerializationLibrary { get; init; }
    public required string RequestBodyName { get; init; }
    public required string Namespace { get; set; }
    public string DtoNamespace => $"{Namespace}.Dtos";
    public string RequestNamespace => $"{Namespace}.Requests";
    public string ControllerNamespace => $"{Namespace}.Controllers";
}