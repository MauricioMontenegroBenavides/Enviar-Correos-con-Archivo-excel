using SegurosAgro.Models;
using System.Collections.Generic;

namespace SegurosAgro.Services
{

    public interface IAsignacionSeguroService {

       IEnumerable<AsignaciónSeguro> ObtenerAsignacion();
       Task  GuardarAsignacion(AsignaciónSeguro ids);
       IEnumerable<Seguro> ObtenerSeguros(long cedula);

        IEnumerable<Asegurado> ObtenerAseguradosCodigo(string codigo);
     }


    public class AsignacionSeguroService : IAsignacionSeguroService
    {

        private AgroSegurosContext contex;
        public AsignacionSeguroService(AgroSegurosContext conte)
        {
            contex = conte;
        }


        public IEnumerable<AsignaciónSeguro> ObtenerAsignacion() {

            return contex.AsignaciónSeguros;
        }

        public IEnumerable<Seguro> ObtenerSeguros(long cedula)
        {

            var seguros = contex.Asegurados
            .Where(a => a.Cedula == cedula)
            .SelectMany(p => p.AsignaciónSeguros)
            .Select(x=> x.IdSegurosNavigation)
            .ToList(); ;
        
            return seguros;
        }

        public IEnumerable<Asegurado> ObtenerAseguradosCodigo(string codigo)
        {
            var datos = contex.Seguros.Where(s=>s.CodigoSeguro==codigo)
                        .SelectMany(asi=>asi.AsignaciónSeguros)
                        .Select(ase=>ase.IdAseguradoNavigation);
            return datos;
        }


        public async Task GuardarAsignacion(AsignaciónSeguro ids) { 
        
     
            contex.AsignaciónSeguros.Add(ids);
            await contex.SaveChangesAsync();
        }

        

    }
}
