using CapaDeDatos;
using CapaNegociosC;
using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb
{
    public partial class PruebaVista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            CapaConexion Cx = new CapaConexion();
            var Usuario =  Cx.ListarUsuario();
            Response.Write(Usuario);

            foreach (var U in Usuario  )
            {
                if (U.Fk_Perfil != (Convert.ToInt32(Session["Perfil"])))
                {
                    var Rol = ConfigurationManager.AppSettings["UsuarioIncorrecto"];
                    Response.Redirect(Rol);
                }
            }


            //if (Perfil.usuarios != PerfilRol)
            //{
            //    var rol = ConfigurationManager.AppSettings["Usuario"];
            //    Response.Redirect(rol);

            //}


            if (Convert.ToInt32(Session["Perfil"]) != 2)
            {
                var rol = ConfigurationManager.AppSettings["Usuario"];
                Response.Redirect(rol);
            }

                ClaseNegocios Nego = new ClaseNegocios();
            if (!IsPostBack)
            {




                Gv_Datos.DataSource = Nego.Infos();
                Gv_Datos.DataBind();

                Ddrl_Dato1.DataSource = Nego.Infos();
                Ddrl_Dato1.DataValueField = "Estado";
                Ddrl_Dato1.DataTextField = "Estado";
                Ddrl_Dato1.DataBind();
                Ddrl_Dato1.Items.Insert(0, "-Seleccione-");
                Drl_Dato2.DataSource = Nego.Infos();
                Drl_Dato2.DataValueField = "Categoria";
                Drl_Dato2.DataTextField = "Categoria";
                Drl_Dato2.DataBind();
                Drl_Dato2.Items.Insert(0, "------");

            }                                    
        }
    }
}