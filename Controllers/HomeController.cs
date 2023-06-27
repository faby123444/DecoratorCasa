using Decorator1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Decorator1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Casa casaLujosa = new CasaLujosa();
            Casa casaNormal = new CasaNormal();
            Casa casaEconomica = new CasaEconomica();

            Casa casaLujosaConDormitorioExtra = new DecoradorDormitorioExtra(casaLujosa);
            Casa casaNormalConBañoExtra = new DecoradorBañoExtra(casaNormal);
            Casa casaLujosaConDormitorioYBañoExtra = new DecoradorBañoExtra(new DecoradorDormitorioExtra(casaLujosa));

            decimal precioCasaLujosa = casaLujosaConDormitorioExtra.ObtenerPrecio();
            decimal precioCasaNormal = casaNormalConBañoExtra.ObtenerPrecio();
            decimal precioCasaEconomica = casaEconomica.ObtenerPrecio();

            CasaViewModel viewModel = new CasaViewModel
            {
                PrecioCasaLujosa = precioCasaLujosa,
                PrecioCasaNormal = precioCasaNormal,
                PrecioCasaEconomica = precioCasaEconomica,

                DescripcionCasaLujosa = casaLujosaConDormitorioExtra.ObtenerDescripcion(),
                DescripcionCasaNormal = casaNormalConBañoExtra.ObtenerDescripcion(),
                DescripcionCasaEconomica = casaEconomica.ObtenerDescripcion()
            };

            return View(viewModel);
        }
    }


}
