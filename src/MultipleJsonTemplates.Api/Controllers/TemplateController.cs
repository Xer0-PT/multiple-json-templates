using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultipleJsonTemplates.Api.Contracts;
using MultipleJsonTemplates.Api.Validators;
using MultipleJsonTemplates.Application.Features.Cars;
using MultipleJsonTemplates.Application.Features.Houses;

namespace MultipleJsonTemplates.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TemplateController : Controller
{
    private readonly IMediator _mediator;
    private readonly BaseRequestValidator _validator;

    public TemplateController(IMediator mediator, BaseRequestValidator validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> GetAsync([Required] BaseRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.First().ErrorMessage);
        }
        
        var command = GetCommand(request.TemplateName, request.Content);

        await _mediator.Send(command, cancellationToken);
        
        return Ok();
    }

    private static IRequest GetCommand(string templateName, JsonDocument content)
        => templateName switch
        {
            TemplateNames.CarTemplate => new CarTemplateCommand(content),
            TemplateNames.HouseTemplate => new HouseTemplateCommand(content),
            _ => throw new ArgumentException("Unknown template name", templateName)
        };
}