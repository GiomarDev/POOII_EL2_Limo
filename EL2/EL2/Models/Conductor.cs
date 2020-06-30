using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EL2.Models
{
    public class Conductor
    {
        public int idConductor { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Brevete { get; set; }
        public string Telefono { get; set; }
        public int Estado { get; set; }
        public int idTipoDocumento { get; set; }
    }
}