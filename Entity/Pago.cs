using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Pago
    {
        public string PagoId { get; set; }
        public DateTime Fecha { get; set; }
        
        [Column(TypeName = "decimal(15,2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal PorcentajeIva { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Iva { get => Valor*PorcentajeIva/100; set {} }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Total { get => Valor+Iva; set {} }

        public string TerceroId { get; set; }
        public Tercero Tercero { get; set; }
    }
}