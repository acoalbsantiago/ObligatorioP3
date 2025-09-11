using LogicaDeNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.EF
{
    public class ObligatorioContext : DbContext
    {
       public DbSet<TipoDeGasto> tipos  { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb; DATABASE=Obligatorio; Integrated Security = true");
        }
    
    }
}
