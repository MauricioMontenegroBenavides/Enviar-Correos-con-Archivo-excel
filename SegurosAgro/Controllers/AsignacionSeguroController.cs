using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegurosAgro.Models;
using SegurosAgro.Services;
using System.Text.RegularExpressions;

namespace SegurosAgro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignacionSeguroController : ControllerBase
    {

        private IAsignacionSeguroService asignacion;
        public AsignacionSeguroController(IAsignacionSeguroService asignaciones) {

            asignacion = asignaciones;
        }

        [HttpGet("ObtenerAsignacion")]
        public IActionResult Get()
        {

            return Ok(asignacion.ObtenerAsignacion());
        }

        [HttpGet("ObtenerSeguros/{cedula}")]
        public IActionResult GetCedula(long cedula)
        {

            return Ok(asignacion.ObtenerSeguros(cedula));
        }


        [HttpGet("ObtenerAsegurados/{codigo}")]
        public IActionResult GetCodigo(String codigo)
        {

            return Ok(asignacion.ObtenerAseguradosCodigo(codigo));
        }

        [HttpPost("GuaradarAsignacion")]
        public IActionResult Guardar([FromBody] AsignaciónSeguro NuevaAsignacion) {


            asignacion.GuardarAsignacion(NuevaAsignacion);

            return Ok();
        }

        [HttpPost("c")]
        public IActionResult CambiosGit([FromBody] AsignaciónSeguro NuevaAsignacion)
        {


            

            return Ok();
        }


    }


}
