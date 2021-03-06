﻿using CapaDeDatos;
using Entidades;
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
        public int Columna { get; set; }
        public string mensaje { get; set; }
        public string Valor { get; set; }
        CapaConexion Cx = new CapaConexion();
        #region Metodo Lectura datos        
        //public List<UsuariosE> ListarUsuario()
        //{
        //    return 
        //}


        public DataSet ObtenerMenu(string perfil)
        {
            return Cx.ObtenerMenu(perfil);
        }
        public DataTable Infos()
        {
            return Cx.Info();
        }
        public int DatoColumna()
        {
            Cx.DatoColumna();
            Columna = Cx.Columna;
            return Columna;

        }
        public DataTable ConsultaAlmacenista(int Cedula)
        {
            return Cx.ConsultaAlmacenista(Cedula);
        }
        #endregion
        #region Metodos ingreso datos        
        public string CrearUsuario(string NombreUsuario, string PasswordU, int Cedula, int Fk_Perfil)
        {
            Cx.CrearUsuario(NombreUsuario, PasswordU, Cedula, Fk_Perfil);
            return mensaje = Cx.Mensaje;
        }
        public string VerificarLogin(string Usuario, string PassWordU)
        {
            Cx.VerificarLogin(Usuario, PassWordU);
            return Valor = Cx.Valor;
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
            Cx.CrearPrestamo(fk_Almacenista, fk_Solicitante, fk_IngresoArticulo, fk_Estado, fk_Disponibilidad, fk_Categoria, fechaPrestamo);
        }
        public void ActualizarPrestamo(int IdPrestamo, int fk_Almacenista, int fk_Solicitante, int fk_IngresoArticulo, int fk_Estado, int fk_Disponibilidad, int fk_Categoria, DateTime fechaDevolucion)
        {
            Cx.ActualizarPrestamo(IdPrestamo, fk_Almacenista, fk_Solicitante, fk_IngresoArticulo, fk_Estado, fk_Disponibilidad, fk_Categoria, fechaDevolucion);
        }
        public void AtualizarHistorial(DateTime FechaGestion, string Observaciones, int fk_Prestamo)
        {
            Cx.ActualizarHistorial(FechaGestion, Observaciones, fk_Prestamo);
        }
     
        #endregion
    }
}
