using System;
using System.Collections.Generic;

namespace GestionVentaFidelityTools.Models
{
    public partial class TiposProductos
    {
        public TiposProductos()
        {
            Productos = new HashSet<Productos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Productos> Productos { get; set; }
    }
}
