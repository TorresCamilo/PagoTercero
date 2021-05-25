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
    public class PagoController: ControllerBase
    {
        private PagoService pagoService;

        public PagoController(PagoContext context)
        {
            this.pagoService = new PagoService(context);
        }
        
        [HttpPost]
        public ActionResult<PagoViewModel> postPago(PagoInputModel pagoInput){
            var pago = this.MapearPago(pagoInput);
            var response = pagoService.GuardarPago(pago);
            if(!response.Error){
                var pagoView = new PagoViewModel(pago);
                return Ok(pagoView);
            }
            return BadRequest(response.Mensaje);
        }
        [HttpGet]
        public ActionResult<IEnumerable<PagoViewModel>> GetPagos(){
            var response = pagoService.ConsultarPagos();
            if(!response.Error){
                var pagosView = response.Pagos.Select(p => new PagoViewModel(p));
                return Ok(pagosView);
            }
            return BadRequest(response.Mensaje);
        }

        private Pago MapearPago(PagoInputModel pagoInput)
        {
            var pago = new Pago(){
                PagoId = pagoInput.PagoId,
                TerceroId = pagoInput.Tercero.Identificacion,
                Fecha = pagoInput.Fecha,
                Valor = pagoInput.Valor,
                PorcentajeIva = pagoInput.PorcentajeIva,
                Tercero = new Tercero(){
                    Identificacion = pagoInput.Tercero.Identificacion,
                    Nombre = pagoInput.Tercero.Nombre,
                    Telefono = pagoInput.Tercero.Telefono
                }
            };
            return pago;
    }
    }
}