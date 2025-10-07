using AccesoADatos.EF;
using AccesoADatos.Repositorios;
using LogicaDeAplicacion.CasosDeUso.Pago;
using LogicaDeAplicacion.CasosDeUso.TipoDeGasto;
using LogicaDeAplicacion.CasosDeUso.Usuario;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddSession();

        builder.Services.AddDbContext<DbContext, ObligatorioContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("MiDB"))
            );

        Console.WriteLine($"Entorno actual: {builder.Environment.EnvironmentName}");
        Console.WriteLine($"Connection string: {builder.Configuration.GetConnectionString("MiDB")}");


        //Repositorios DI
        builder.Services.AddScoped<ITipoDeGastoRepository, TipoDeGastoRepository>();
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        builder.Services.AddScoped<IPagoRepository, PagoRepository>();

        //casosDeUso DI 
        //tipoDeGasto
        builder.Services.AddScoped<IObtenerTipoDeGasto, ObtenerTipoDeGastoCU>();
        builder.Services.AddScoped<IAgregarTipoDeGasto, AgregarTipoDeGastoCU>();
        builder.Services.AddScoped<IEliminarTipoDeGasto, EliminarTipoDeGastoCU>();
        builder.Services.AddScoped<IObtenerTipoDeGastoPorId, ObtenerTipoDeGastoPorIdCU>();
        builder.Services.AddScoped<IEditarTipoDeGasto, EditarTipoDeGastoCU>();
        //usuario
        builder.Services.AddScoped<ILogin, LoginCU>();
        builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
        //pago
        builder.Services.AddScoped<IAgregarPago, AgregarPagoCU>();
        builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();

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
        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Pago}/{action=Create}/{id?}");

        app.Run();
    }
}
