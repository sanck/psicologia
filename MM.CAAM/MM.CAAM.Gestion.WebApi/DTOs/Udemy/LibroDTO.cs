﻿using System;
using MM.CAAM.Gestion.WebApi.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace MM.CAAM.Gestion.WebApi.DTOs.Udemy
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        //public List<ComentarioDTO> Comentarios { get; set; }
    }
}

