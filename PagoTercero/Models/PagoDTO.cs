using System;
using Entity;

namespace PagoTercero.Models
{
    public class PagoInputModel
    {
        public string PagoId { get; set; }
        public TerceroInputModel Tercero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
    }
    public class PagoViewModel
    {
        public string PagoId { get; set; }
        public TerceroViewModel Tercero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; } 
        
        public PagoViewModel(Pago pago)
        {
            this.PagoId = pago.PagoId;
            this.Valor = pago.Valor;
            this.Fecha = pago.Fecha;
            this.Tercero = new TerceroViewModel(pago.Tercero);
            this.PorcentajeIva = pago.PorcentajeIva;
            this.Iva = pago.Iva;
            this.Total = pago.Total;
        }
    }
    public class InformacionPagoViewModel
    {
        public string PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }
        public InformacionPagoViewModel(Pago pago)
        {
            PagoId = pago.PagoId;
            Valor = pago.Valor;
            Fecha = pago.Fecha;
            PorcentajeIva = pago.PorcentajeIva;
            Iva = pago.Iva;
            Total = pago.Total;
        }
    }
}