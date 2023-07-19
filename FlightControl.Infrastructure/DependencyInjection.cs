namespace FlightControl.Infrastructure {
    public static class DependencyInjection {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) 
            => services.AddDbService()
                       .AddRepositories();

        private static IServiceCollection AddDbService(this IServiceCollection services) => 
            services.AddDbContext<FlightControlDB>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;DataBase=FlightControlDB;Trusted_Connection=True;MultipleActiveResultSets=true"));
        
        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IFlightsRepository, FlightsRepository>()
                       .AddScoped<IFlightsHistoryRepository, FlightsHistoryRepository>()
                       .AddScoped<IStageRepository, StageRepository>();

    }
}
