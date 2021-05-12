using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PagoService
    {
        private readonly PagoContext context;

        public PagoService(PagoContext context)
        {
            this.context = context;
        }

        public PagoResponse GuardarPago(Pago pago){
            try
            {
                var terceroBuscado = context.Terceros.Find(pago.Tercero.TerceroId);
                if(terceroBuscado == null)
                    context.Terceros.Add(pago.Tercero);
                else
                    pago.Tercero = terceroBuscado;//Tracking
                
                context.Pagos.Add(pago);
                context.SaveChanges();
                return new PagoResponse(pago);
            }
            catch (System.Exception ex)
            {
                return new PagoResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public ListaPagosResponse ConsultarPagos(){
            try
            {
                var pagos = context.Pagos.Include(p => p.Tercero).ToList();
                return new ListaPagosResponse(pagos);
            }
            catch (System.Exception ex)
            {
                return new ListaPagosResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public PagoResponse BuscarPagoPorId(string id){
            try
            {
                var pagoBuscado = context.Pagos.Find(id);
                if(pagoBuscado == null)
                    return new PagoResponse("Error, no existe un apgo registrado con ese id");
                
                return new PagoResponse(pagoBuscado);
            }
            catch (System.Exception ex)
            {
                return new PagoResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public PagoResponse BuscarPagoConTerceroPorId(string idPago){
            try
            {
                var pagoBuscado = context.Pagos.Where(p => p.PagoId == idPago).Include(p => p.Tercero).FirstOrDefault();
                if(pagoBuscado == null)
                    return new PagoResponse("Error, no existe un apgo registrado con ese id");
                return new PagoResponse(pagoBuscado);
            }
            catch (System.Exception ex)
            {
                return new PagoResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }

    }
    public class PagoResponse{
        public PagoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public PagoResponse(Pago pago)
        {
            Pago = pago;
            Error = false;
        }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Pago Pago { get; set; }
    }
    public class ListaPagosResponse{
        public ListaPagosResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
        public ListaPagosResponse(List<Pago> pagos)
        {
            Pagos = pagos;
            Error = false;
        }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}