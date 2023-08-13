namespace MultipleJsonTemplates.Api.Contracts;

public static class TemplateNames
{
    public const string CarTemplate = "CarTemplate";
    public const string HouseTemplate = "HouseTemplate";

    public static readonly List<string> ValidTemplateNames = new() { CarTemplate, HouseTemplate };
}