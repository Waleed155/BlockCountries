
using BlockCountries.Models;
using BlockCountries.Repository.BlockCountryRepository;
using BlockCountries.Repository.Logs;
using BlockCountries.Service.BlockedCountry;
using BlockCountries.Service.IpService;
using BlockCountries.Service.LogService;

namespace BlockCountries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(new HttpClient());
            builder.Services.AddHttpContextAccessor();
          builder.Services.AddMemoryCache();

            builder.Services.AddHostedService<TemporalBackGroundService>();

            builder.Services.AddSingleton<IlogRepository, LogRepository>();
            builder.Services.AddScoped<IlogService,LogService>();
            builder.Services.AddSingleton<IBlockCountryRepository, BlockCountryRepository>();
            builder.Services.AddScoped<IBlockedCountryService, BlockedCountryService>();
            builder.Services.AddTransient <IIPService, IpService>();
             


            var app = builder.Build();
            app.UseForwardedHeaders();

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
        }
    }
}
