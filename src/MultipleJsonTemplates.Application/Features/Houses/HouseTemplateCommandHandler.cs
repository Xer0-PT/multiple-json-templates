using System.Text.Json;
using MediatR;

namespace MultipleJsonTemplates.Application.Features.Houses;

public record HouseTemplateCommand(JsonDocument Content) : IRequest;


public class HouseTemplateCommandHandler : IRequestHandler<HouseTemplateCommand>
{
    public Task Handle(HouseTemplateCommand request, CancellationToken cancellationToken)
    {
        var content = request.Content.Deserialize<HouseTemplate>();

        if (content is null)
        {
            throw new ArgumentNullException(nameof(HouseTemplate));
        }
        
        Console.WriteLine(content.NumberOfDoors);
        Console.WriteLine(content.NumberOfWindows);
        
        return Task.CompletedTask;
    }
}