﻿using System;
using System.ComponentModel.DataAnnotations;
using MM.CAAM.Gestion.Models.Validaciones;

namespace MM.CAAM.Gestion.DTO.DTOs.Udemy
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}

