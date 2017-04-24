using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public  class UsuariosE
    {
        public int IdUsuarios { get; set; }
        public string  Nombre { get; set; }
        public int Cedula { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Fk_Perfil { get; set; }
        public string PasswordU { get; set; }
        public string Perfil { get; set; }
    }
}
