using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P1U2Mitologia.Models.Entities;
using PracticaU2.Models.ViewModels;

namespace PracticaU2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var context = new MitologiaMexicanaContext();
            //Mostrar 3 Civilizaciones al azar
            IndexViewModel vm = null!;

            vm = new IndexViewModel
            {
                Civilizaciones = context.Civilizaciones
                .OrderBy(c => EF.Functions.Random())
                .Take(3)
                .Select(c => new CivilizacionesModel
                {
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion ?? "Sin descripción"
                })
            };

            return View(vm);
        }
        public IActionResult Civilizaciones()
        {
            MitologiaMexicanaContext context = new();
            CivilizacionesViewModel vm = new();
            vm.Civilizaciones = context.Civilizaciones.OrderBy(c => c.Nombre)
                .Select(c => new CivilizacionModel
                {
                    Nombre = c.Nombre,
                    Periodo = (c.PeriodoInicio < 0 ? $"{Math.Abs((decimal)c.PeriodoInicio).ToString("0")} A.C." : $"{c.PeriodoInicio} D.C.") +
                        " - " +
                        (c.PeriodoFin < 0 ? $"{Math.Abs((decimal)c.PeriodoFin).ToString("0")} A.C." : $"{c.PeriodoFin} D.C."),
                    Region = c.Region,
                    Capital = c.Capital,
                    Lengua = c.Lengua,
                    Descripcion = c.Descripcion ?? "Sin descripción"
                });
            return View(vm);
        }
        public IActionResult Dioses(string id) // Nombre de la civilizacion
        {
            MitologiaMexicanaContext context = new();
            DiosesViewModel vm = new();

            vm.CivilizacionSeleccionada = id ?? context.Civilizaciones.Select(x => x.Nombre).First();
            
            vm.NombreCivilizaciones = context.Civilizaciones
                .Select(c => c.Nombre);

            vm.Dioses = context.CivilizacionDios
                .Include(d => d.IdCivilizacionNavigation).Include(d => d.IdDiosNavigation)
                .Where(x=>x.IdCivilizacionNavigation.Nombre == vm.CivilizacionSeleccionada)
                .Select(d => new DiosModel
                {
                    Id = d.Id,
                    Nombre = d.IdDiosNavigation.NombreGeneral,
                    NombreCivilizacion = d.IdCivilizacionNavigation.Nombre,
                    Genero = d.IdDiosNavigation.Genero,
                    Dominio = d.IdDiosNavigation.Dominio,
                    NombreLocal = d.NombreLocal,
                    Descripcion = d.IdDiosNavigation.Descripcion ?? "Sin descripción"
                });
            return View(vm);
        }
    }
}
