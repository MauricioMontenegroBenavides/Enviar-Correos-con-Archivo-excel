using System;
using System.Collections.Generic;

namespace SegurosAgro.Models
{
    public partial class AsignaciónSeguro
    {
        public int IdAsignación { get; set; }
        public int? IdAsegurado { get; set; }
        public int? IdSeguros { get; set; }

        public virtual Asegurado? IdAseguradoNavigation { get; set; }
        public virtual Seguro? IdSegurosNavigation { get; set; }
    }
}
