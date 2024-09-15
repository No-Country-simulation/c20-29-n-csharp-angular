using Backend.DTO;
using Backend.Models;
using Backend.Services.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoService _TipoDocumentoService;
        public TipoDocumentoController(ITipoDocumentoService TipoDocumentoService)
        {
            _TipoDocumentoService = TipoDocumentoService;   
        }
        [HttpGet("GetListaTipodocumentos")]
        public async Task<IActionResult> ListarTipodocumentos()
        {
            var data = await _TipoDocumentoService.ListarTipodocumentos();
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpGet("GetTipodocumentoById/{IdTipoDocumento}")]
        public async Task<IActionResult> ObtenerTipodocumentoById(int IdTipoDocumento)
        {
            var data = await _TipoDocumentoService.ObtenerTipodocumentoById(IdTipoDocumento);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpPost("PostTipodocumento")]
        public async Task<IActionResult> RegistrarTipodocumento([FromBody] Tipodocumento tipodocumento)
        {
            var response = await _TipoDocumentoService.RegistrarTipodocumento(tipodocumento);
            return Ok(response);
        }

        [HttpPut("PutTipodocumento")]
        public async Task<IActionResult> ActualizarTipodocumento([FromBody] Tipodocumento tipodocumento)
        {
            var data = await _TipoDocumentoService.ActualizarTipodocumento(tipodocumento);
            var response = RespuestaOperacionDTO.ExitoConDatos(data);
            return Ok(response);
        }

        [HttpDelete("DeleteTipodocumento/{IdTipoDocumento}")]
        public async Task<IActionResult> EliminarTipodocumento(int IdTipoDocumento)
        {
            var response = await _TipoDocumentoService.EliminarTipodocumento(IdTipoDocumento);
            return Ok(response);
        }
    }
}
