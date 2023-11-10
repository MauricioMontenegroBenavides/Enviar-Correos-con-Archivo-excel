using System;
using System.Collections.Generic;

namespace SegurosAgro.Models
{
    public partial class Seguro
    {
        public Seguro()
        {
            AsignaciónSeguros = new HashSet<AsignaciónSeguro>();
        }

        public int IdSeguros { get; set; }
        public string? NombreSeguro { get; set; }
        public string? CodigoSeguro { get; set; }
        public decimal? SumaAsegurada { get; set; }
        public decimal? Prima { get; set; }

        public virtual ICollection<AsignaciónSeguro> AsignaciónSeguros { get; set; }
    }
}
