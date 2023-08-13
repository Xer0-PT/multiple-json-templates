using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace MultipleJsonTemplates.Api.Contracts;

public record BaseRequest([Required] string TemplateName, [Required] JsonDocument Content);