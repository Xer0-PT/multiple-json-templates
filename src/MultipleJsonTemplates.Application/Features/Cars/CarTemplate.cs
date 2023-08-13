using System.Text.Json.Serialization;

namespace MultipleJsonTemplates.Application.Features.Cars;

public class CarTemplate
{
    [JsonPropertyName("brand")]
    public string Brand { get; set; } = null!;
    
    [JsonPropertyName("productionDate")]
    public DateTimeOffset ProductionDate { get; set; }
}