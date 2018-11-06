using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin
{
    class PostsResult
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Autor { get; set; }
        public int Puntaje { get; set; }
        public int IdEstado { get; set; }
        public object Eliminado { get; set; }
        public string Descripcion { get; set; }
        public int IdJuego { get; set; }
        public object AspNetUsers { get; set; }
        public List<Comentarios> Comentarios { get; set; }
        public object Estados { get; set; }
        public object Juegos { get; set; }
        public List<object> PostDenunciados { get; set; }
        public List<object> Votos { get; set; }
        public List<object> Tags { get; set; }

        public static implicit operator List<object>(PostsResult v)
        {
            throw new NotImplementedException();
        }
    }
}
