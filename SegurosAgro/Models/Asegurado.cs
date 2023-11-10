using System;
using System.Collections.Generic;

namespace SegurosAgro.Models
{
    public partial class Asegurado
    {
        public Asegurado()
        {
            AsignaciónSeguros = new HashSet<AsignaciónSeguro>();
        }

        public int IdAsegurado { get; set; }
        public long? Cedula { get; set; }
        public string? NombreCliente { get; set; }
        public int? Edad { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<AsignaciónSeguro> AsignaciónSeguros { get; set; }
    }
}
