using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
        #region Conexion Base de datos
        string Conexion = ConfigurationManager.ConnectionStrings["DBZ"].ConnectionString;

        #endregion
        #region Insertar Datos
        public void CrearAlmacenista(string Nombre, int Cedula)
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("insert into Almacenista values @Nombre,@Cedula");
                cx.Open();
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.ExecuteNonQuery();
            }
        }
        public void IngresarArticulo(DateTime FechaIngreso, int Fk_Almacenista)
        {
            using (SqlConnection Cx = new SqlConnection(Conexion))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO IngresoArticulo values @fechaIngreso,@Fk_Almacenista");
                Cx.Open();
                cmd.Parameters.AddWithValue("@fechaIngreso", FechaIngreso);
                cmd.Parameters.AddWithValue("@Fk_Almacenista", Fk_Almacenista);
                cmd.ExecuteNonQuery();
            }
        }
        public void CrearSolicitante(string Nombre, int Cedula)
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
        public DataTable Info()
        {
            using (SqlConnection cx = new SqlConnection(Conexion))
            {
                //SqlCommand cmd = new SqlCommand("select * from Employee", cx);
                //SqlCommand cmd = new SqlCommand("select IdEstado,Estado,IdDispo,Diponibilidad,IdCategoria,Categoria from Estado E join Disponibilidad D on E.IdEstado = D.IdDispo join Categoria C  on E.IdEstado = C.IdCategoria", cx);
                SqlDataAdapter DA = new SqlDataAdapter("select * from Employee", cx);
                DataSet dt = new DataSet();
                DA.Fill(dt);                                
                Cantidad = dt.Tables[0].Rows.Count;
                return dt.Tables[0];
            }
        }

        #endregion
        #region Datos Importantes para los drl Items.Insert(0,"-Seleccione-")

        #endregion
    }
}
