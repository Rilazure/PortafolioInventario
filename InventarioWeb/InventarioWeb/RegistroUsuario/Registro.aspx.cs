﻿using CapaNegociosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventarioWeb.RegistroUsuario
{
    public partial class Registro : System.Web.UI.Page
    {
        ClaseNegocios Cn = new ClaseNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            Cn.CrearUsuario(TxtNombre.Text, TxtPassword.Text);
        }
    }
}