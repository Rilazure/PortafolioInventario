using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb
{
    public partial class CrearAlmacenista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PnlRegistro.Visible = false;
            }
        }

        protected void BtnVerPnlRegistro_Click(object sender, EventArgs e)
        {
            PnlRegistro.Visible = true;
            BtnVerPnlRegistro.Visible = false;
        }
    }
}