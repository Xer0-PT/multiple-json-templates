using System.Text.Json.Serialization;

namespace MultipleJsonTemplates.Application.Features.Houses;

public class HouseTemplate
{
    [JsonPropertyName("numberOfWindows")]
    public int NumberOfWindows { get; set; }
    
    [JsonPropertyName("numberOfDoors")]
    public int NumberOfDoors { get; set; }
}