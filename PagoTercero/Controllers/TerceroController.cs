using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Logica;
using Microsoft.AspNetCore.Mvc;
using PagoTercero.Models;

namespace PagoTercero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController: ControllerBase
    {
        private TerceroService terceroService;

        public TerceroController(PagoContext context)
        {
            this.terceroService = new TerceroService(context);
        }

        [HttpPost]
        public ActionResult<TerceroViewModel> postPago(TerceroInputModel terceroInput){
            var tercero = this.MapearTercero(terceroInput);
            var response = terceroService.GuardarTercero(tercero);
            if(!response.Error){
                var terceroView = new TerceroViewModel(tercero);
                return Ok(terceroView);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet]
        public ActionResult<IEnumerable<TerceroViewModel>> GetTerceros(){
            var response = terceroService.ConsultarTerceros();
            if(!response.Error){
                var terceroView = response.Terceros.Select(t => new TerceroViewModel(t));
                return Ok(terceroView);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet("{id}")]
        public ActionResult<TerceroViewModel> GetTerceroPorId(string id){
            var response = terceroService.BuscarTerceroPorId(id);
            if(!response.Error){
                var terceroView = new TerceroViewModel(response.Tercero);
                return Ok(terceroView);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet("{id}/Pago")]
        public ActionResult<TerceroConPagosViewModel> GetTerceroConPago(string id){
            var response = terceroService.BuscarTerceroConPago(id);
            if(!response.Error){
                var terceroView = new TerceroConPagosViewModel(response.Tercero);
                return Ok(terceroView);
            }
            return BadRequest(response.Mensaje);
        }

        private Tercero MapearTercero(TerceroInputModel terceroInput)
        {
            var tercero = new Tercero(){
                TerceroId = terceroInput.TerceroId,
                Telefono = terceroInput.Telefono,
                Nombre = terceroInput.Nombre
            };
            return tercero;
        }
  }
}