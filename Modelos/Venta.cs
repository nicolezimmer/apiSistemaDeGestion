using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOwo.Models
{
    public class Venta
    {
        private long id;
        private string comentarios;
        private long idUsuario;

        public Venta(long id, string comentarios, long idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }

        public long Id { get => id; set => id = value; }
        public string Comentarios { get => comentarios; set => comentarios = value; }
        public long IdUsuario { get => idUsuario; set => idUsuario = value; }
        public override string ToString()
        {
            return $"id usuario: {idUsuario}";
        }
    }
}
