﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class Usuarios
{
    [Key]
    public int IdUsuario { get; set; }

    public string Nombre { get; set; }

    public string CorreoElectronico { get; set; } 

    public string Contraseña { get; set; }

    public string Perfil { get; set; }

    public DateTime? FechaRegistro { get; set; }
}