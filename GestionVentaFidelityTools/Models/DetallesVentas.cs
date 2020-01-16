using System;
using System.Collections.Generic;

namespace GestionVentaFidelityTools.Models
{
    public partial class DetallesVentas
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }

        public Productos IdProductoNavigation { get; set; }
        public Ventas IdVentaNavigation { get; set; }
    }
}
