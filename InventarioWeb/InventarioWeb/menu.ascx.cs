using CapaNegociosC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb
{
    public partial class menu : System.Web.UI.UserControl
    {
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LabelPerfil.Text = (string)(Session["Perfil"]).ToString();
                ObtenerMenu();
            }
        }
        public void ObtenerMenu()
        {
            Cn.ObtenerMenu(Convert.ToInt32(LabelPerfil.Text));
            DataSet dt = new DataSet();
            dt = Cn.ObtenerMenu(Convert.ToInt32(LabelPerfil.Text));
            dt.Relations.Add("ChildRows", dt.Tables[0].Columns["Id"], dt.Tables[1].Columns["ParentId"]);
            foreach (DataRow level1Dato in dt.Tables[0].Rows)
            {
                MenuItem item = new MenuItem();
                item.Text = level1Dato["MenuText"].ToString();
                item.NavigateUrl = level1Dato["MenuText"].ToString();
                DataRow[] level2Dato = level1Dato.GetChildRows("ChildRows");
                foreach (DataRow level2Datos in level2Dato)
                {
                    MenuItem childItem = new MenuItem();
                    childItem.Text = level2Datos["MenuText"].ToString();
                    childItem.NavigateUrl = level2Datos["Url"].ToString();
                    item.ChildItems.Add(childItem);
                }
                Menu1.Items.Add(item);
            }
        }        
    }
}
