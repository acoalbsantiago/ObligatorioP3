using AccesoADatos.EF;
using AccesoADatos.Repositorios;
using LogicaDeAplicacion.CasosDeUso.TipoDeGasto;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<DbContext, ObligatorioContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiDB"))
            );

        Console.WriteLine($"Entorno actual: {builder.Environment.EnvironmentName}");
        Console.WriteLine($"Connection string: {builder.Configuration.GetConnectionString("MiDB")}");


        // Add services to the container.
        builder.Services.AddControllersWithViews();


        //Repositorios DI
        builder.Services.AddScoped<ITipoDeGastoRepository, TipoDeGastoRepository>();


        //casosDeUso DI
        builder.Services.AddScoped<IObtenerTipoDeGasto, ObtenerTipoDeGastoCU>();
        builder.Services.AddScoped<IAgregarTipoDeGasto, AgregarTipoDeGasto>();
        

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
