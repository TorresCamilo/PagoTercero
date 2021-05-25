using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class TerceroService
    {
        private readonly PagoContext context;

        public TerceroService(PagoContext context)
        {
            this.context = context;
        }


        public TerceroResponse GuardarTercero(Tercero tercero){
            try
            {
                var terceroBuscado = context.Terceros.Find(tercero.Identificacion);
                if(terceroBuscado == null){
                    context.Terceros.Add(tercero);
                    context.SaveChanges();
                    return new TerceroResponse(tercero);
                }
                return new TerceroResponse("Error, la identificacion ingresada ya se encuentra registrada");
            }
            catch (System.Exception ex)
            {
                return new TerceroResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public ListaTercerosResponse ConsultarTerceros(){
            try
            {
                var terceros = context.Terceros.ToList();
                return new ListaTercerosResponse(terceros);
            }
            catch (System.Exception ex)
            {
                return new ListaTercerosResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public TerceroResponse BuscarTerceroConPago(string idTercero){
            try
            {
                var terceroBuscado = context.Terceros.Where(t => t.Identificacion == idTercero).Include(t => t.Pagos).FirstOrDefault();
                if(terceroBuscado == null){
                    return new TerceroResponse("Error, la identificacion ingresada no esta registrada");
                }
                return new TerceroResponse(terceroBuscado);
            }
            catch (System.Exception ex)
            {
                return new TerceroResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }
        public TerceroResponse BuscarTerceroPorId(string idTercero){
            try
            {
                var terceroBuscado = context.Terceros.Find(idTercero);
                if(terceroBuscado == null){
                    return new TerceroResponse("Error, la identificacion ingresada no esta registrada");
                }
                return new TerceroResponse(terceroBuscado);
            }
            catch (System.Exception ex)
            {
                return new TerceroResponse("Se ha presentado la siguiente excepcion: "+ex.Message);
            }
        }



  }
    public class TerceroResponse
    {
        public TerceroResponse(Tercero tercero)
        {
            Tercero = tercero;
            Error = false;
        }

        public TerceroResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public Tercero Tercero { get; set; }

    }
    public class ListaTercerosResponse
    {
        public ListaTercerosResponse(List<Tercero> terceros)
        {
            Terceros = terceros;
            Error = false;
        }

        public ListaTercerosResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public List<Tercero> Terceros { get; set; }

    }
}
