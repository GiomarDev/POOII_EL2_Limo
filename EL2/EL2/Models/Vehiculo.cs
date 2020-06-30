using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EL2.Models
{
    public partial class Vehiculo
    {
        [Key]
        public int idVehiculo { get; set; }
        public string Placa { get; set; }
        public int Año { get; set; }
        public string Modelo { get; set; }  
        public int idMarca { get; set; }

    }
}