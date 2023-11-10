using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegurosAgro.Services;
using SegurosAgro.Models;

namespace SegurosAgro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private ISeguroService SeguroService;
        public SeguroController(ISeguroService SeguroServices) {

            SeguroService = SeguroServices;
        }


       [HttpGet("ObtenerSeguro")]
       public IActionResult obSeguros() {



            return Ok(SeguroService.ObtenerSeguro());
        }

        [HttpPost("GuardarSeguro")]
        public IActionResult GuardarSeguro([FromBody] Seguro  NuevoSeguro )
        {

            SeguroService.GuardarSeguro(NuevoSeguro);

            return Ok();
        }


        [HttpPut("EditarSeguro/{id}")]
        public IActionResult EditSeguro([FromBody] Seguro NuevoSeguro,int id)
        {

            SeguroService.EditarSeguro( id, NuevoSeguro);

            return Ok();
        }

        [HttpDelete("BorrarSeguro/{id}")]
        public IActionResult BorrarSeguro(int id)
        {

            SeguroService.DeleteSeguro(id);

            return Ok();
        }


    }
}
