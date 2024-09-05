using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string Perfil { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }
}
