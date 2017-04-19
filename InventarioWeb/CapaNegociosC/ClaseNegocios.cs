using CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegociosC
{
    public class ClaseNegocios
    {
        
        public string mensaje { get; set; }
        CapaConexion Cx = new CapaConexion();
        #region Metodo Lectura datos        
        public DataSet ObtenerMenu()
        {
            
            return Cx.ObtenerMenu();
        }
        public DataTable Infos()
        {
            return Cx.Info();
        }
        public DataTable ConsultaAlmacenista(int Cedula)
        {
            return Cx.ConsultaAlmacenista(Cedula);
        }
        #endregion
        #region Metodos ingreso datos        
        public string CrearUsuario(string NombreUsuario,string PasswordU)
        {
            Cx.CrearUsuario(NombreUsuario, PasswordU);
            return  mensaje = Cx.Mensaje;
        }
        public string VerificarLogin( string Usuario, string PassWordU)
        {
             Cx.VerificarLogin(Usuario, PassWordU);
            return mensaje = Cx.Mensaje;
        }


        public void CrearAlmcenista(string Nombre, int Cedula)
        {
            Cx.CrearAlmacenista(Nombre, Cedula);
        }
        public void IngresarArticulos(DateTime FechaIngreso, int Fk_Almacenista, string NombreA)
        {
            Cx.IngresarArticulo(FechaIngreso, Fk_Almacenista, NombreA);
        }
        public void CrearPersonaSolicitante(string Nombre, int Cedula)
        {
            Cx.CrearPersonaSolicitante(Nombre, Cedula);
        }
        public void CrearPrestamo(int fk_Almacenista, int fk_Solicitante, int fk_IngresoArticulo, int fk_Estado, int fk_Disponibilidad, int fk_Categoria, DateTime fechaPrestamo)
        {
            Cx.CrearPrestamo(fk_Almacenista, fk_Solicitante, fk_IngresoArticulo, fk_Estado, fk_Disponibilidad, fk_Categoria,fechaPrestamo);
        }
        public void ActualizarPrestamo(int IdPrestamo, int fk_Almacenista, int fk_Solicitante, int fk_IngresoArticulo, int fk_Estado, int fk_Disponibilidad, int fk_Categoria, DateTime fechaDevolucion)
        {
            Cx.ActualizarPrestamo(IdPrestamo,fk_Almacenista,fk_Solicitante,fk_IngresoArticulo,fk_Estado,fk_Disponibilidad,fk_Categoria,fechaDevolucion);
        }
        public void AtualizarHistorial(DateTime FechaGestion, string Observaciones, int fk_Prestamo)
        {
            Cx.ActualizarHistorial(FechaGestion, Observaciones, fk_Prestamo);
        }
        #endregion       
    }
}
