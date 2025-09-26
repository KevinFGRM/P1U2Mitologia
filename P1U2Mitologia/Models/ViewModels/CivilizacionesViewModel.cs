namespace PracticaU2.Models.ViewModels
{
    public class CivilizacionesViewModel
    {
        public IEnumerable<CivilizacionModel> Civilizaciones { get; set; } = null!;
    }
    public class CivilizacionModel
    {
        public string Nombre { get; set; } = null!;

        public string Periodo { get; set; } = null!;

        public string? Region { get; set; }

        public string? Capital { get; set; }

        public string? Lengua { get; set; }

        public string? Descripcion { get; set; }
    }
}
