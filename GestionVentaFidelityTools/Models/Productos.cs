using System;
using System.Collections.Generic;

namespace GestionVentaFidelityTools.Models
{
    public partial class Productos
    {
        public Productos()
        {
            DetallesVentas = new HashSet<DetallesVentas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int IdTipoProducto { get; set; }
        public int? Stock { get; set; }
        public bool Estado { get; set; }

        public TiposProductos IdTipoProductoNavigation { get; set; }
        public ICollection<DetallesVentas> DetallesVentas { get; set; }
    }
}
