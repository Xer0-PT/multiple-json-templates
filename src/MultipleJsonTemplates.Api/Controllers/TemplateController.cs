using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleJsonTemplates.Api.Contracts;
using MultipleJsonTemplates.Application.Features.Cars;
using MultipleJsonTemplates.Application.Features.Houses;

namespace MultipleJsonTemplates.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplateController : Controller
{
    private readonly IMediator _mediator;

    public TemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> GetAsync([Required] BaseRequest request, CancellationToken cancellationToken)
    {
        var command = GetCommand(request.TemplateName, request.Content);

        await _mediator.Send(command, cancellationToken);
        
        return Ok();
    }

    private static IRequest GetCommand(string templateName, JsonDocument content)
        => templateName switch
        {
            nameof(CarTemplate) => new CarTemplateCommand(content),
            nameof(HouseTemplate) => new HouseTemplateCommand(content),
            _ => throw new ArgumentException("Unknown template name", nameof(templateName))
        };
}