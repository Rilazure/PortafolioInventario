using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegociosC;
using CapaDeDatos;
using System.Web.Security;

namespace InventarioWeb
{
    public partial class Login : System.Web.UI.Page
    {
        
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
               
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Session["Prueba"] = TxtNombre.Text;
            if (FormsAuthentication.Authenticate(TxtNombre.Text, TxtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(TxtNombre.Text, CheckRicar.Checked);
            }
            else
            {
                Mensajes.Text = "Invalido";
            }

            Authenticate(TxtNombre.Text,  TxtPassword.Text);
            if (Mensajes.Text == "")
            {
                Response.Redirect("~/PruebaVista.aspx");
                //Response.Write(ViewState["Prueba"]);
            }
            else
            {
                Response.Write("no");
            }
        }
        public string Authenticate(string nombre,string Pass)
        {
            Cn.VerificarLogin(nombre, Pass);
            return Mensajes.Text =  Cn.mensaje;
        }       
    }
}

