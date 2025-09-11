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
       public DbSet<TipoDeGasto> tipos  { get; set; }

        public ObligatorioContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //optionsBuilder.UseSqlServer(@"SERVER=(localdb)\W180BS45;DATABASE=Obligatorio;Integrated Security=true");
        }
    
    }
}
