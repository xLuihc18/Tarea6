namespace CinestarApp.Models
{
    public class Entidades
    {
        public class Pelicula
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string FechaEstreno { get; set; }
            public string Director { get; set; }
            public string Sinopsis { get; set; }
            public string Link { get; set; }
            public string Geneross { get; set; } 
            public string FechaEstrenoss { get; set; } 
        }

        public class Cine
        {
            public int Id { get; set; }
            public string RazonSocial { get; set; }
            public int Salas { get; set; }
            public string Direccion { get; set; }
            public string Telefonos { get; set; }
            public string Ciudad { get; set; } 
            public string Distrito { get; set; } 
            public string Formatoss { get; set; } 
        }

        public class CineTarifa
        {
            public string DiasSemana { get; set; }
            public string Precio { get; set; } 
        }

        public class Ubicacion
        {
            public int Id { get; set; }
            public string Detalle { get; set; }
        }
    }
}
