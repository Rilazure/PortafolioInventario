using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegociosC;
using CapaDeDatos;

namespace InventarioWeb
{
    public partial class Login : System.Web.UI.Page
    {
        CapaConexion cx = new CapaConexion();
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            VerificarLogin(TxtNombre.Text, TxtPassword.Text);
            if (Mensajes.Text == "")
            {
                Response.Write("si");
            }
            else
            {
                Response.Write("no");
            }
        }
        public string VerificarLogin(string nombre,string Pass)
        {
            Cn.VerificarLogin(nombre, Pass);
            return Mensajes.Text =  Cn.mensaje;
        }       
    }
}

