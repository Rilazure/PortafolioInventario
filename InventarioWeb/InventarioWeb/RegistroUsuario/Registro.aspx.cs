using CapaDeDatos;
using CapaNegociosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.RegistroUsuario
{
    public partial class Registro : System.Web.UI.Page
    {
        CapaConexion cx = new CapaConexion();
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
          CrearUsuario(TxtNombre.Text,TxtPassword.Text,Convert.ToInt32(TxtCedula.Text),Convert.ToInt32(TxtPerfil.Text));
            if (Mensaje.Text == "")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Write("Usuario " + TxtNombre.Text + " Ya existe");
            }
        }
        public string CrearUsuario(string nombre, string Pass,int cedula,int Fk_Perfil)
        {
            Cn.CrearUsuario(nombre, Pass,cedula,Fk_Perfil);
            return Mensaje.Text = Cn.mensaje;
           
        }
    }
}