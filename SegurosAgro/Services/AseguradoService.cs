using Microsoft.EntityFrameworkCore;
using SegurosAgro.Models;

namespace SegurosAgro.Services

{
    public interface IAseguradoService
    {

        IEnumerable<Asegurado> ObtenerAsegurado();

        Task<string> GuardarAsegurado(Asegurado NuevoSeguro);
        Task<string> EditarAsegurado(int id, Asegurado NuevoSeguro);

        Task<string> DeleteAsegurado(int id);

    }
    public class AseguradoService: IAseguradoService
    {

        private AgroSegurosContext contex;

        public AseguradoService(AgroSegurosContext context)
        {

            contex = context;
        }

        public IEnumerable<Asegurado> ObtenerAsegurado()
        {

            return contex.Asegurados;




        }

        public async Task<string> GuardarAsegurado(Asegurado NuevoSeguro)
        {


            try
            {

                contex.Asegurados.Add(NuevoSeguro);
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
        public async Task<string> EditarAsegurado(int id, Asegurado NuevoSeguro)
        {

            try
            {

                var Seguro = contex.Asegurados.Find(id);


                if (Seguro != null)
                {

                    Seguro.NombreCliente = NuevoSeguro.NombreCliente;
                    Seguro.Cedula = NuevoSeguro.Cedula;
                    Seguro.Telefono = NuevoSeguro.Telefono;
                    Seguro.Edad = NuevoSeguro.Edad;
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

        public async Task<string> DeleteAsegurado(int id)
        {

            try
            {
                var Seguro = contex.Asegurados.Find(id);

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

