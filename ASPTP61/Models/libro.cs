

namespace ASPTP61.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> Paginas { get; set; }
        public string Edicion { get; set; }
        public string Editorial { get; set; }
        public string CiudadyPais { get; set; }
        public Nullable<System.DateTime> FechaDeEdicion { get; set; }

        public string NombreCompleto { get { return Titulo + " " + Autor + " " + Paginas + " " + Editorial + " "; }}
    }
    
}
