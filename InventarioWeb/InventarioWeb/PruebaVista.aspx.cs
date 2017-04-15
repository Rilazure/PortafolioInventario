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
            ClaseNegocios Nego = new ClaseNegocios();
            if (!IsPostBack)
            {
                Gv_Datos.DataSource = Nego.Infos();
                Gv_Datos.DataBind();
            }                                    
        }
    }
}