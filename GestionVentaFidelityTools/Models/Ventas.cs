using System;
using System.Collections.Generic;

namespace GestionVentaFidelityTools.Models
{
    public partial class Ventas
    {
        public Ventas()
        {
            DetallesVentas = new HashSet<DetallesVentas>();
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Importe { get; set; }

        public ICollection<DetallesVentas> DetallesVentas { get; set; }
    }
}
