using AutoMapper;
using FlightControl.Api;
using FlightControl.Api.Services;
using FlightControl.Domain.Interfaces;
using FlightControl.Infrastructure;
using FlightControl.Infrastructure.Context;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

var builder = WebApplication.CreateBuilder(args); 
{
    builder.Services.AddInfrastructure()
                    .AddTowerControlServices()
                    .AddFixedCors()
                    .AddHubServices();

    builder.Services.AddSignalR();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


}
var app = builder.Build();

app.MapHub<MyHub>("/Control");

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();