using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EL2.Models;
using EL2.ADO;

namespace EL2.Controllers
{
    public class VehiculoController : Controller
    {
        MarcaADO adoMarca = new MarcaADO();
        VehiculoADO adoVehiculo = new VehiculoADO();


        public ActionResult ListarVehiculo()
        {
            List<Vehiculo> lista = adoVehiculo.Listar();

            return View(lista);
        }



        public ActionResult RegistrarVehiculo()
        {
            ViewBag.Marca = adoMarca.Listar();
            return View(new Vehiculo());
        }

        [HttpPost]
        public ActionResult RegistrarVehiculo(Vehiculo v)
        {
            int resultado = adoVehiculo.Insertar(v);
            return RedirectToAction("ListarVehiculo");
        }

        public ActionResult EliminarVehiculo(int id)
        {
            int resultado = adoVehiculo.Eliminar(id);
            return RedirectToAction("ListarVehiculo");
        }

        public ActionResult VerVehiculo(int id)
        {
            Vehiculo c = adoVehiculo.Obtener(id);
            return View(c);

        }

        //Get : Negocio/EditarCliente
        public ActionResult EditarVehiculo(int id)
        {
            Vehiculo c = adoVehiculo.Obtener(id);
            ViewBag.Marca = adoMarca.Listar();
            return View(c);
        }

        [HttpPost]
        public ActionResult EditarVehiculo(Vehiculo v)
        {
            int resultado = adoVehiculo.Actualizar(v);
            return RedirectToAction("ListarVehiculo");

        }
    }
}