using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp2184587.Models
{
    public class ReporteCompra
    {
        public String nombreCliente { get; set; }

        public String documentoCliente { get; set; }

        public int? total { get; set; }

        public System.DateTime? fechaCompra { get; set; }

    }
}