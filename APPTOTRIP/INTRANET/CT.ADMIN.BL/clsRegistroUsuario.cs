using System;
using System.Data;
using CDI.Comun;
using System.Collections.Generic;

namespace CT.ADMIN.BL
{
    public class clsRegistroUsuario
    {
        public DataTable InsertarUsuario(List<string> lstUsuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@nombres_usuario", lstUsuario[0], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@apellidos_usuario", lstUsuario[1], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@tipo_documento", lstUsuario[2], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@documento_usuario", lstUsuario[3], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@ciudad", lstUsuario[4], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@numero_certificado", lstUsuario[5], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@vigencia_certificado", lstUsuario[6], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@fecha_nacimiento", lstUsuario[7], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@correo_usuario", lstUsuario[8], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@clave", lstUsuario[9], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_cuenta", lstUsuario[10], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_cuenta_web", lstUsuario[12], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_certificado", lstUsuario[11], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_certificado_web", lstUsuario[13], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@estado", lstUsuario[14], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@perfil", "2", SqlDbType.VarChar, null));
                DataTable dtUsuario = (DataTable)objCon.ExecuteProc("", "", "pa_Inserta_Usuario", parametrosEntrada, ref parametrosSalida);
                return dtUsuario;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaPerfilUsuario(string idUsuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@IdUsuario", idUsuario, SqlDbType.VarChar, null));
                object dtCiudades = objCon.ExecuteProc("", "", "pa_Consultar_Usuario", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtCiudades;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaUsuario(List<string> lstUsuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@nombres_usuario", lstUsuario[0], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@apellidos_usuario", lstUsuario[1], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@tipo_documento", lstUsuario[2], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@documento_usuario", lstUsuario[3], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@ciudad", lstUsuario[4], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@numero_certificado", lstUsuario[5], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@vigencia_certificado", lstUsuario[6], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@fecha_nacimiento", lstUsuario[7], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@correo_usuario", lstUsuario[8], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@clave", lstUsuario[9], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_cuenta", lstUsuario[10], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@foto_certificado", lstUsuario[11], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@estado", lstUsuario[12], SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@perfil", "2", SqlDbType.VarChar, null));
                DataTable dtUsuario = (DataTable)objCon.ExecuteProc("", "", "pa_Inserta_Usuario", parametrosEntrada, ref parametrosSalida);
                return dtUsuario;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaUsuariosActivar()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                object dtUsuarios = objCon.ExecuteProc("", "", "pa_Consultar_Usuario_Activacion", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtUsuarios;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Usuario_Activacion Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaUsuarioActivar(string idUsuario = null, string Estado = null, string CorreoUsuario = null)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@Id_Usuario", idUsuario, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@Estado", Estado, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@correo_usuario", CorreoUsuario, SqlDbType.VarChar, null));
                object dtCiudades = objCon.ExecuteProc("", "", "pa_Actualizar_Usuario_Activacion", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtCiudades;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
    }
}
