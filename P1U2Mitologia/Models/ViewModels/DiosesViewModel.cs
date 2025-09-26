namespace PracticaU2.Models.ViewModels
{
    public class DiosesViewModel
    {
        public string? CivilizacionSeleccionada { get; set; }
        public IEnumerable<string> NombreCivilizaciones { get; set; } = null!;
        public IEnumerable<DiosModel> Dioses { get; set; } = null!;

    }
    public class DiosModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string NombreCivilizacion { get; set; } = null!;
        public string? Genero { get; set; } 
        public string? Dominio { get; set; }
        public string NombreLocal { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
