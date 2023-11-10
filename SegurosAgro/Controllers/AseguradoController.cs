using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegurosAgro.Models;
using SegurosAgro.Services;

namespace SegurosAgro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradoController : ControllerBase
    {

        private IAseguradoService AseguradoService;

        public AseguradoController(IAseguradoService AseguradoServices) {

            AseguradoService = AseguradoServices;
        }


        [HttpGet("ObtenerAsegurado")]
        public IActionResult obSeguros()
        {



            return Ok(AseguradoService.ObtenerAsegurado());
        }

        [HttpPost("GuardarAsegurado")]
        public IActionResult GuardarSeguro([FromBody] Asegurado NuevoSeguro)
        {

            AseguradoService.GuardarAsegurado(NuevoSeguro);

            return Ok();
        }


        [HttpPut("EditarAsegurado/{id}")]
        public IActionResult EditSeguro([FromBody] Asegurado NuevoSeguro, int id)
        {

            AseguradoService.EditarAsegurado(id, NuevoSeguro);

            return Ok();
        }

        [HttpDelete("BorrarAsegurado/{id}")]
        public IActionResult BorrarSeguro(int id)
        {

            AseguradoService.DeleteAsegurado(id);

            return Ok();
        }


    }                           



}
