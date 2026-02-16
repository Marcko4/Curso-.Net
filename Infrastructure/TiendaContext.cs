using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <Producto> Productos { get; set; }
        public DbSet <Marca> Marcas { get; set; }
        public DbSet <Categoria> Categorias { get; set; }


    }
}
