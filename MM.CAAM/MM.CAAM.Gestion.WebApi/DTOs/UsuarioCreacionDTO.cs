﻿using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.WebApi.DTOs
{
    public class UsuarioCreacionDTO                                                          //DTOs y AUTOMAPPER
    {
            [Required(ErrorMessage = "El campo {0} es requerido")]
            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Nombre { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string ApellidoPaterno { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string ApellidoMaterno { get; set; }

            public int RolId { get; set; }

            [DataType(DataType.EmailAddress)]
            [StringLength(60, ErrorMessage = "Máximo {1} caracteres.")]
            [Display(Name = "Correo Electrónico")]
            public string Correo { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Telefono { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Password { get; set; }

            [StringLength(25, ErrorMessage = "Máximo {1} caracteres.")]
            [Display(Name = "Usuario")]
            public string NombrePerfil { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime FechaNacimiento { get; set; }
            public int GeneroId { get; set; }
            public bool Activo { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string PerfilNombreArchivo { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Profesion { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Calle { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Numero { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Colonia { get; set; }

            [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string CP { get; set; }

            [StringLength(maximumLength: 120, ErrorMessage = "El campo {0} no debe de tener más de {1} carácteres")]
            public string Municipio { get; set; }
            public string Latitud { get; set; }
            public string Longitud { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime FechaActualizacion { get; set; }
            public DateTime FechaAcceso { get; set; }
            public string BearerToken { get; set; }
    }
}
