using System;
using System.Data;
using CDI.Comun;
using System.Collections.Generic;

namespace CT.ADMIN.BL
{
    public class clsCircuitos
    {
        public DataTable ConsultaCircuitos(string CodIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Circuitos_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaSitios(string CodIdioma, string IdCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("IdCircuito", IdCircuito, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Sitios_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaCategorias()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Categorias_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaImagenes(string idSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();

            parametrosEntrada.Add(new InParameter("idSitio", idSitio, SqlDbType.VarChar, null));

            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Img_Sitios_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Img_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaOrdenSitios(string idSitio, string Orden)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("idSitio", idSitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Orden", Orden, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Actualizar_OrdenSitio", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public void EliminaImagenSitio(string idImagen)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("idImagen", idImagen, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Eliminar_ImagenSitio", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaEstadoCircuito(string idCircuito, string Estado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito_actualizar", idCircuito, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("estado", Estado, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Actualiza_Estado_Circuito", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable EliminaCircuito(string idCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", idCircuito, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Delete_Circuito", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
    }
}
