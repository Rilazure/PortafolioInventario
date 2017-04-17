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
            Gv.DataSource = Cn.VerificarLogin(TxtPassword.Text);
            Gv.DataBind();
            int dato = Gv.Rows.Count;
            //Cn.CrearUsuario(TxtNombre.Text, TxtPassword.Text);
            if (dato == 1)
            {
                Response.Redirect("RegistroUsuario/Registro.aspx");
            }
            else
            {
                Response.Write("No");
            }
        }
    }
}
