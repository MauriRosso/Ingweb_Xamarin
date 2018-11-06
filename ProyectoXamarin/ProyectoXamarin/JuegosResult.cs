using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoXamarin
{
    class JuegosResult
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public string Imagen { get; set; }
        public object Eliminado { get; set; }
        public object Categorias { get; set; }
        public List<object> Posts { get; set; }
    }
}
