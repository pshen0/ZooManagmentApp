using ZooManagmentApp.Application;
using ZooManagmentApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


ConfigureServices(builder.Services);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    
    services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
    services.AddSingleton<IEnclosureRepository, InMemoryEnclosureRepository>();
    services.AddSingleton<IFeedingScheduleRepository, InMemoryFeedingScheduleRepository>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

void ConfigureMiddleware(WebApplication app)
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseRouting();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}
