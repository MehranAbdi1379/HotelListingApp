using HotelListingApp.Configurations;
using HotelListingApp.Data;
using HotelListingApp.iRepository;
using HotelListingApp.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        // Add services to the container.
        builder.Services.AddDbContext<DataBaseContext>(
            option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"))
            );

        builder.Services.AddAutoMapper(typeof(MapperInitilizer));

        builder.Services.AddCors(o =>
        {
            o.AddPolicy("AllowAll", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console().WriteTo.File(
            path: "c:\\hotellistings\\logs\\log-.txt",
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{level:u3}] {Message:lj}{NewLine}{Exception}",
            rollingInterval: RollingInterval.Day,
            restrictedToMinimumLevel: LogEventLevel.Information));

        builder.Services.AddControllers().AddNewtonsoftJson()

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapControllers();

        try
        {
            Log.Information("Application Is Starting");
            app.Run();
        }
        catch (Exception ex)
        {

            Log.Fatal(ex, "Application Failed To Start");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}