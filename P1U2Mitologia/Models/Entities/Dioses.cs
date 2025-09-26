using System;
using System.Collections.Generic;

namespace P1U2Mitologia.Models.Entities;

public partial class Dioses
{
    public int Id { get; set; }

    public string NombreGeneral { get; set; } = null!;

    public string? Genero { get; set; }

    public string? Dominio { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<CivilizacionDios> CivilizacionDios { get; set; } = new List<CivilizacionDios>();
}
