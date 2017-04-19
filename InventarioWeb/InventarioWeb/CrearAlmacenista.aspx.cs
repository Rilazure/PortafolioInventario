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
    public partial class CrearAlmacenista : System.Web.UI.Page
    {
        //Instancion la clase de negocios para traer sus metodos
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ObtenerMenu();
                
                
                //PnlRegistro.Visible = false;
                PnlConsultarAlmacenista.Visible = false;
                lblEx.Visible = false;
            }
        }      
        protected void Registro_Click(object sender, EventArgs e)
        {
            PnlRegistro.Visible = true;
            PnlConsultarAlmacenista.Visible = false;
            
        }
        protected void Consulta_Click(object sender, EventArgs e)
        {
            PnlConsultarAlmacenista.Visible = true;
            PnlRegistro.Visible = false;
        }
        protected void GuardarAlmacenista_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCedula.Text == "" || TxtNombre.Text == "")
                {
                    throw new Exception("Esta mal");
                }
                Cn.CrearAlmcenista(TxtNombre.Text, Convert.ToInt32(TxtCedula.Text));

            }
            catch (Exception ex)
            {
                lblEx.Visible = true;
                lblEx.Text =  ex.Message;
            }
            
        }        
        protected void BtnConsultarAlmacenista_Click(object sender, EventArgs e)
        {
            //Cn.ConsultaAlmacenista(Convert.ToInt32(TxtCedula.Text));
            Gv_DatosAlmacenista.DataSource = Cn.ConsultaAlmacenista(Convert.ToInt32(TxtCedula.Text));
            Gv_DatosAlmacenista.DataBind();
        }
        public void ObtenerMenu()
        {
            Cn.ObtenerMenu();

            DataSet dt = new DataSet();
             dt = Cn.ObtenerMenu();
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