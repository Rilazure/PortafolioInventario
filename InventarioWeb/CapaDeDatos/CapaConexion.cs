using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CapaDeDatos
{
    public class CapaConexion
    {
        #region Propiedades de la clase        
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Fk_Almacenista { get; set; }
        public int Fk_Solicitante { get; set; }
        public int Fk_IngresoArticulo { get; set; }
        public int Fk_Estado { get; set; }
        public int Fk_Disponibilidad { get; set; }
        public int Fk_Categoria { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Llenar { get; set; }
        public int Cantidad { get; set; }
        public int Retorna { get; set; }
        public string Mensaje { get; set; }
        public string Referencia { get; set; }
        public int Valor { get; set; }
        #endregion
        #region Conexion Base de datos
        string Conexion = ConfigurationManager.ConnectionStrings["DBZ"].ConnectionString;

        #endregion
        #region Insertar Datos
        //Este metodo es para el Login seguridad.
        public string CrearUsuario(string Nombre, string PasswordU,int Cedula,int Fk_Perfil)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpNewUsers", cx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //SqlDataAdapter da = new SqlDataAdapter("Select * from Login where @NombreUsuario", NombreUsuario);
                    string PasswordEncriptado = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordU, "SHA1");
                    cx.Open();
                    cmd.Parameters.AddWithValue("@Nombre", Nombre);
                    cmd.Parameters.AddWithValue("@PassWordU", PasswordEncriptado);
                    cmd.Parameters.AddWithValue("@Cedula", Cedula);
                    cmd.Parameters.AddWithValue("@Fk_Perfil", Fk_Perfil);
                    cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                    Retorna = (int)cmd.ExecuteScalar();
                    cmd.ExecuteNonQuery();
                    if (Retorna == -1)
                    {
                        return Mensaje = "Ya existe";
                    }
                    else
                    {
                        return Mensaje = "";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //aqui creo q puedo hacer poliformismo o sobre carga de metodos
        public int VerificarLogin(string usuario, string PasswordU)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("SpLoginIngreso", cx);
                cmd.CommandType = CommandType.StoredProcedure;
                string PasswordEncriptado = FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordU, "SHA1");
                cx.Open();
                cmd.Parameters.AddWithValue("@PassWordU", PasswordEncriptado);
                cmd.Parameters.AddWithValue("@Nombre", usuario);
                Valor = (int)cmd.ExecuteScalar();
                if (Valor !=0 )
                {
                  
                    return Valor;
                }
                else
                {
                    return Valor = 0;
                }

                
                
                
            }
        }
        public void CrearAlmacenista(string Nombre, int Cedula)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("insert into Almacenista values (@Nombre,@Cedula,@FechaCreacion)", cx);
                cx.Open();
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
        public void IngresarArticulo(DateTime FechaIngreso, int Fk_Almacenista, string NombreA)
        {
            using (SqlConnection Cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO IngresoArticulo values @fechaIngreso,@Fk_Almacenista,@NombreA,@Referencia");
                Cx.Open();
                cmd.Parameters.AddWithValue("@fechaIngreso", FechaIngreso);
                cmd.Parameters.AddWithValue("@Fk_Almacenista", Fk_Almacenista);
                cmd.Parameters.AddWithValue("@NombreA", NombreA);
                cmd.Parameters.AddWithValue("@Referencia", Referencia);
                cmd.ExecuteNonQuery();
            }
        }
        public void CrearPersonaSolicitante(string Nombre, int Cedula)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Solicitante VALUES @Nombre,@Cedula");
                cx.Open();
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.ExecuteNonQuery();
            }
        }
        public void CrearPrestamo(int fk_Almacenista, int fk_Solicitante, int fk_IngresoArticulo, int fk_Estado, int fk_Disponibilidad, int fk_Categoria, DateTime fechaPrestamo)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("Insert into Prestamo (Fk_Almacenista,Fk_Solicitante,Fk_IngresoArticulo,Fk_Estado,Fk_Disponibilidad,Fk_Categoria,FechaPrestamo) values @Fk_Almacenista,@Fk_Solicitante,@Fk_IngresoArticulo,@Fk_Estado,@Fk_Disponibilidad,@Fk_Categoria,@FechaPrestamo");
                cx.Open();
                cmd.Parameters.AddWithValue("@Fk_Almacenista", fk_Almacenista);
                cmd.Parameters.AddWithValue("@Fk_Solicitante", fk_Solicitante);
                cmd.Parameters.AddWithValue("@Fk_IngresoArticulo", fk_IngresoArticulo);
                cmd.Parameters.AddWithValue("@Fk_Estado", fk_Estado);
                cmd.Parameters.AddWithValue("@Fk_Disponibilidad", fk_Disponibilidad);
                cmd.Parameters.AddWithValue("@Fk_Categoria", fk_Categoria);
                cmd.Parameters.AddWithValue("@FechaPrestamo", fechaPrestamo);
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarPrestamo(int IdPrestamo, int fk_Almacenista, int fk_Solicitante, int fk_IngresoArticulo, int fk_Estado, int fk_Disponibilidad, int fk_Categoria, DateTime fechaDevolucion)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("Update Prestamo set Fk_Estado = @Fk_Estado,Fk_Disponibilidad = @Fk_Disponibilidad,fechaDevolucion = @fechaDevolucion where IdPrestamo = @IdPrestamo ");
                cx.Open();
                cmd.Parameters.AddWithValue("@Fk_Estado", fk_Estado);
                // aqui es importante camviar el la diponbilidad directamente para que quede disponible automaticamente en vez del parametro quemo el dato
                // debo actualizar la cantidad cada vez q presto y cada vez q devuelvo
                cmd.Parameters.AddWithValue("@Fk_Disponibilidad", fk_Disponibilidad);
                cmd.Parameters.AddWithValue("@FechaDevolucion", fechaDevolucion);
                cmd.Parameters.AddWithValue("@IdPrestamo", IdPrestamo);
                cmd.ExecuteNonQuery();
            }
        }
        public void ActualizarHistorial(DateTime FechaGestion, string Observaciones, int fk_Prestamo)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("Insert into HistorialArticulo values @FechaGestion,@Observaciones,@Fk_Prestamo");
                cx.Open();
                cmd.Parameters.AddWithValue("@FechaGestion", FechaGestion);
                cmd.Parameters.AddWithValue("@Observaciones", Observaciones);
                cmd.Parameters.AddWithValue("@Fk_Prestamo", fk_Prestamo);
            }
        }
        #endregion
        #region Obtener Datos
        // aqui devo consultar articulos disponibles
        //Consultar Disponibilidad esto lo puedo hacer con un Join para traer los datos en un datatable y solo mostrar posteriormente con una clave 
        //Categoria
        //Estado
        //Almacenista
        //Disponibilidad aqui es mas un si y un no
        //Solicitante
        //Consultar historial 
        //Prestamo este se hace por medio del Id que se ha generado 
        //Estos datos son para llenar DropDownList
        public DataSet ObtenerMenu(int perfil)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("spObtenerMenu", cx);
                cmd.CommandType = CommandType.StoredProcedure;
                cx.Open();
                cmd.Parameters.AddWithValue("@Fk_Perfil", perfil);
                cmd.ExecuteNonQuery();

                    SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                Da.Fill(dt);
               
                return dt;

            }
        }
        public DataTable Info()
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                //COn esta consulta puedo llenar los drl    
                SqlDataAdapter DA = new SqlDataAdapter("select IdEstado,Estado,IdDispo,Diponibilidad,IdCategoria,Categoria from Estado E join Disponibilidad D on E.IdEstado = D.IdDispo join Categoria C  on E.IdEstado = C.IdCategoria", cx);
                DataSet dt = new DataSet();
                DA.Fill(dt);
                Cantidad = dt.Tables[0].Rows.Count;
                return dt.Tables[0];
            }
        }
        //Este metodo servira para el ddl cuando necesite el nombre del almacenista
        public DataTable ConsultaAlmacenista(int Cedula)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("select Nombre,Cedula,FechaCreacion as [Fecha de Ingreso] from  Almacenista where Cedula = @Cedula", cx);
                cx.Open();
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.ExecuteNonQuery();
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
                Da.Fill(dt);
                return dt.Tables[0];
            }
        }
        #endregion
        #region Datos Importantes para los drl Items.Insert(0,"-Seleccione-")
        #endregion
    }
}
