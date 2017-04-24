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
            Authenticate(TxtNombre.Text,  TxtPassword.Text);
            if (Cn.Valor != "no")
            {
                FormsAuthentication.RedirectFromLoginPage
                  (TxtNombre.Text, false);
                Session.Add("Perfil", Cn.Valor);


                //Response.Redirect("~/Default.aspx");
                //Response.Write(ViewState["Prueba"]);
                //Response.Write((string)(Session["Perfil"]));
            }
            else
            {
                Response.Write("No");
            }
        }
        public string Authenticate(string nombre,string Pass)
        {
            Cn.VerificarLogin(nombre, Pass);
            return  Cn.Valor;
        }       
    }
}

