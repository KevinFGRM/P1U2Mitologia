
namespace PracticaU2.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CivilizacionesModel> Civilizaciones { get; set; } = null!;
    }
    public class CivilizacionesModel
    {
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
    }
}
