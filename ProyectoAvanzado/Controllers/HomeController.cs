using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoAvanzado.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nuestra Política de Calidad está orientada a la satisfacción de mejorar continuamente nuestros servicios de salud, estimular su desarrollo integral a través de la capacitación permanente y los beneficios personales, mantener la rentabilidad y el posicionamiento de la empresa, constituyendo una opción segura, honesta y eficiente.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Calle Eligio Ayala 1383 y Paí Perez// Asunción - Paraguay // Central Telefónica (021) 248 9000.";

            return View();
        }
    }
}