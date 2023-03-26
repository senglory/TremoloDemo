using System.Reflection;
using FluentValidation;
using TremoloDemo.Interfaces;
using TremoloDemo.Services;

namespace TremoloDemo.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            //.AddNewtonsoftJson()
            ;
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddHttpClient();
        services.AddTransient<IChartDataSourceService, ChartDataSourceService>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
