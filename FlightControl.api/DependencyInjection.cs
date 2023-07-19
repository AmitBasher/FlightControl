using FlightControl.Api.Services;

namespace FlightControl.Api;
public static class DependencyInjection {
    public static IServiceCollection AddTowerControlServices(this IServiceCollection services) {
        return services.AddScoped<FlightControlService>()
                       .AddSingleton
                       (serviceprovider => {
                           var scope = serviceprovider.GetRequiredService<IServiceScopeFactory>().CreateScope();
                           var FlightDBService = scope.ServiceProvider.GetRequiredService<FlightControlService>();
                           var hub = scope.ServiceProvider.GetRequiredService<HubService>();
                           return new TowerControlService(FlightDBService);//, hub FlightService,
                       });
    }
    public static IServiceCollection AddHubServices(this IServiceCollection services) {
        return services.AddTransient<MyHub>()
                       .AddScoped<HubService>();
    }
    public static IServiceCollection AddFixedCors(this IServiceCollection services) {
        return services.AddCors(options => {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200", "https://localhost:7137")
                    );//
        });
    }
}
