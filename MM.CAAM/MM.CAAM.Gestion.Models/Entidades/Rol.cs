﻿namespace MM.CAAM.Gestion.Models.Entidades
{
    public class Rol                               //UNO A MUCHOS [Usuario muchas Consultas][Libro muchos Comentarios]
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        
    }
}