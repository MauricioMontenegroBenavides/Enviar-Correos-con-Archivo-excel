using Microsoft.EntityFrameworkCore;
using SegurosAgro.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace SegurosAgro.Services
{
   
    public interface ISeguroService {

        IEnumerable<Seguro> ObtenerSeguro();

        Task<string> GuardarSeguro(Seguro NuevoSeguro);
        Task<string> EditarSeguro(int id, Seguro NuevoSeguro);

        Task<string> DeleteSeguro(int id);
    
    }
    public class SeguroService : ISeguroService
    {
        private AgroSegurosContext contex;

        public SeguroService(AgroSegurosContext context) {

            contex = context;
        }

       public  IEnumerable<Seguro> ObtenerSeguro() {

            return contex.Seguros;




       }

       public async Task<string> GuardarSeguro(Seguro NuevoSeguro) {


            try
            {

                contex.Seguros.Add(NuevoSeguro);
                await contex.SaveChangesAsync();
                return "OK";

            }
            catch (DbUpdateException ex)
            {
                // Captura la excepción de Entity Framework Core y devuelve el mensaje de error.
                return ex.Message;

            }
            catch (Exception ex)
            {
                // Si hay otras excepciones que no sean DbUpdateException, también puedes manejarlas aquí
                return $"Error inesperado: {ex.Message}";
            }


        }
        public async Task<string>  EditarSeguro(int id, Seguro NuevoSeguro) {

            try
            {

                var Seguro = contex.Seguros.Find(id);
               

                if (Seguro!=null) {

                    Seguro.NombreSeguro= NuevoSeguro.NombreSeguro  ;
                    Seguro.CodigoSeguro= NuevoSeguro.CodigoSeguro;
                    Seguro.SumaAsegurada = NuevoSeguro.SumaAsegurada;
                    Seguro.Prima= NuevoSeguro.Prima;
                    await contex.SaveChangesAsync();
                   
                }

                return "ok";

            }
            catch (DbUpdateException ex)
            {
                // Captura la excepción de Entity Framework Core y devuelve el mensaje de error.
                return ex.Message;

            }
            catch (Exception ex)
            {
                // Si hay otras excepciones que no sean DbUpdateException, también puedes manejarlas aquí
                return $"Error inesperado: {ex.Message}";
            }



        }

        public async Task<string> DeleteSeguro(int id) {

            try
            {
                var Seguro = contex.Seguros.Find(id);

                if (Seguro != null)
                {

                    contex.Remove(Seguro);
                    await contex.SaveChangesAsync();

                }

                return "ok";

            }
            catch (DbUpdateException ex)
            {
                // Captura la excepción de Entity Framework Core y devuelve el mensaje de error.
                return ex.Message;

            }
            catch (Exception ex)
            {
                // Si hay otras excepciones que no sean DbUpdateException, también puedes manejarlas aquí
                return $"Error inesperado: {ex.Message}";
            }



        }

    }
}
