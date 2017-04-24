using CapaDeDatos;
using CapaNegociosC;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;



namespace InventarioWeb
{
    public partial class CrearAlmacenista : System.Web.UI.Page
    {
        //Instancion la clase de negocios para traer sus metodos
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            CapaConexion Cx = new CapaConexion();
            Gv_DatosAlmacenista.DataSource = Cx.ListarUsuario();
            int sesion = Convert.ToInt32(Session["Perfil"]);
            if (sesion != 2)
            {
                var rol = ConfigurationManager.AppSettings["Administrador"];
                Label1.Text = rol;
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                PnlRegistro.Visible = false;
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
                lblEx.Text = ex.Message;
            }
        }
        protected void BtnConsultarAlmacenista_Click(object sender, EventArgs e)
        {
            //Cn.ConsultaAlmacenista(Convert.ToInt32(TxtCedula.Text));
            Gv_DatosAlmacenista.DataSource = Cn.ConsultaAlmacenista(Convert.ToInt32(TxtCedula.Text));
            Gv_DatosAlmacenista.DataBind();
        }

        protected void BtnLista_Click(object sender, EventArgs e)
        {
           Gv_DatosAlmacenista.DataSource = MostrarDatos().FirstOrDefault(x => x.Nombre == Label1.Text);
            Gv_DatosAlmacenista.DataBind();
            
            //var dato = Cx.ListarUsuario().OrderByDescending(x => x.IdUsuarios);

            //foreach (UsuariosE da in dato)
            //{
            //    Label1.Text = "ok  " + da.Perfil.IndexOf(da.Perfil, 0);
            //}


            //foreach (UsuariosE listas in Cx.ListarUsuario())
            //{
            //    Response.Write(listas.Perfil);
            //}
        }
        public IEnumerable<UsuariosE> MostrarDatos()
        {
            CapaConexion Cx = new CapaConexion();
             return Cx.ListarUsuario().ToList();            
        }
    }
}