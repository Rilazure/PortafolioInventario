using CapaDeDatos;
using CapaNegociosC;
using System;
using System.Collections.Generic;
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
            CapaConexion d = new CapaConexion();
            ClaseNegocios Nego = new ClaseNegocios();
            if (!IsPostBack)
            {
                Gv_Datos.DataSource = Nego.Infos();
                Gv_Datos.DataBind();

                Ddrl_Dato1.DataSource = Nego.Infos();
                Ddrl_Dato1.DataValueField = "Name";
                Ddrl_Dato1.DataTextField = "Name";
                Ddrl_Dato1.DataBind();
                Ddrl_Dato1.Items.Insert(0, "-Seleccione-");
                Drl_Dato2.DataSource = Nego.Infos();
                Drl_Dato2.DataValueField = "LastName";
                Drl_Dato2.DataTextField = "LastName";
                Drl_Dato2.DataBind();

            }                                    
        }
    }
}