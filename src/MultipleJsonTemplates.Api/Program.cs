using FluentValidation;
using MultipleJsonTemplates.Api.Validators;
using MultipleJsonTemplates.Application.Features.Cars;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CarTemplateCommand).Assembly));
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddValidatorsFromAssemblyContaining<BaseRequestValidator>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();