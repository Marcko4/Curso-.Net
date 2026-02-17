using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Categoria:BaseEntity
    {
        public string Nombre { get; set; }
        public ICollection<Producto> Productos { get; set; }

    }
}
