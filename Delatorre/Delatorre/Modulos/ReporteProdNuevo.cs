using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delatorre.Modulos
{
    public class ReporteProdNuevo
    {
        public object id { get; set; }
        public object nombre { get; set; }
        public object fecha { get; set; }
        public object cantidad { get; set; }
        public object descuentos { get; set; }
        public object garantia { get; set; }
    }

    public class SucursalReporte
    {
        public object sucursal { get; set; }
    }


}
