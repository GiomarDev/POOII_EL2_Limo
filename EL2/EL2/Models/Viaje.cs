using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EL2.Models
{
    public class Viaje
    {
        public int idViaje { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public int VehiculoId { get; set; }
        public int ConductorId { get; set; }
        public DateTime FechaPar { get; set; }
        public DateTime FechaLlega { get; set; }

    }
}