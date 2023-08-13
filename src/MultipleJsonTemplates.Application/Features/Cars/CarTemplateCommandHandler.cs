using System.Text.Json;
using MediatR;

namespace MultipleJsonTemplates.Application.Features.Cars;

public record CarTemplateCommand(JsonDocument Content) : IRequest;

public class CarTemplateCommandHandler : IRequestHandler<CarTemplateCommand>
{
    public Task Handle(CarTemplateCommand request, CancellationToken cancellationToken)
    {
        var content = request.Content.Deserialize<CarTemplate>();

        if (content is null)
        {
            throw new ArgumentNullException(nameof(CarTemplate));
        }
        
        Console.WriteLine(content.Brand);
        Console.WriteLine(content.ProductionDate);
        
        return Task.CompletedTask;
    }
}