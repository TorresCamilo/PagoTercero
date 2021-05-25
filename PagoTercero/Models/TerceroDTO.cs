using System.Collections.Generic;
using System.Linq;
using Entity;

namespace PagoTercero.Models
{
    public class TerceroInputModel
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
    }
  public class TerceroViewModel : TerceroInputModel
  {
    public TerceroViewModel(Tercero tercero)
    {
        this.Identificacion = tercero.Identificacion;
        this.Nombre = tercero.Nombre;
        this.Telefono = tercero.Telefono;
    }
  }
  public class TerceroConPagosViewModel: TerceroInputModel
    {
        public List<InformacionPagoViewModel> Pagos { get; set; }
        public TerceroConPagosViewModel(Tercero tercero)
        {
            Identificacion = tercero.Identificacion;
            Nombre = tercero.Nombre;
            Telefono = tercero.Telefono;
            Pagos = tercero.Pagos.Select(p => new InformacionPagoViewModel(p)).ToList();
        }
    }

}