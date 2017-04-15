using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegociosC
{
    public class ClaseNegocios
    {
        CapaConexion Cx = new CapaConexion();
        public DataTable Infos()
        {
            return Cx.Info();
        }
    }
}
