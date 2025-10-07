using LogicaDeNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.EF
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Equipo> equipos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<PagoRecurrente> pagoRecurrentes { get; set; }
        public DbSet<PagoUnico> PagoUnico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoDeGasto> tiposDeGasto { get; set; }

        public ObligatorioContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //optionsBuilder.UseSqlServer(@"SERVER=(localdb)\W180BS45;DATABASE=Obligatorio;Integrated Security=true");
        }
    
    }
}
