using System;
using System.Data;
using CDI.Comun;
using Ent_BpmNet.Administrador;
using System.Collections.Generic;
using System.Web.Security;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT.ADMIN.BL
{
    public class clsOperacionUsuario
    {

        public Usuario AutenticarUsuario(string usuario, string clave, ref string error)
        {
            CT.ADMIN.BL.clsHerramientas objHerramientas = new clsHerramientas();
            objHerramientas.InsertaLog("entra AutenticarUsuario", "log");
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            parametrosEntrada.Add(new InParameter("@Usuario", usuario, SqlDbType.VarChar, null));
            List<OutParameter> parametrosSalida = new List<OutParameter>();

            try
            {
                DataTable dtUsuario = (DataTable)objCon.ExecuteProc("", "", "pa_Recuperar_Usuario", parametrosEntrada, ref parametrosSalida);
                objHerramientas.InsertaLog("Consulta Usuario", "log");
                if (dtUsuario.Rows.Count > 0)
                {
                    Usuario usr = new Usuario(
                        dtUsuario.Rows[0]["ID_USUARIO"].ToString(),
                        //dtUsuario.Rows[0]["NOMBRES_USUARIO"].ToString(),
                        //dtUsuario.Rows[0]["NUMERO_CELULAR"].ToString(),
                        //dtUsuario.Rows[0]["CODIGO_CELULAR"].ToString(),
                        //dtUsuario.Rows[0]["NUMERO_VERIFICACION"].ToString(),
                        //dtUsuario.Rows[0]["CORREO"].ToString(),
                        //dtUsuario.Rows[0]["USUARIO"].ToString(),
                        dtUsuario.Rows[0]["ESTADO"].ToString(),
                        ""//dtUsuario.Rows[0]["CodPais"].ToString().ToLower()
                        );

                    bool claveCorrecta = false;

                    //Validación de clave encriptada
                    Encriptacion.Operacion opc;
                    opc = Encriptacion.Operacion.Encripta;

                    string claveEnc = dtUsuario.Rows[0]["clave"].ToString();
                    string hashedPassword = Encriptacion.Cifrado(opc, clave);//FormsAuthentication.HashPasswordForStoringInConfigFile(clave, "SHA1");

                    claveCorrecta = hashedPassword.Equals(claveEnc);

                    if (!claveCorrecta)
                    {
                        error = "Clave incorrecta";
                        return null;
                    }

                    //CDITrace.EscribirLog("Autenticación Correcta", CDITrace.Tipo.Log);
                    return usr;
                }
                else
                {
                    error = "Usuario no existe";
                    return null;
                }
            }
            catch (Exception e)
            {
                objHerramientas.InsertaLog("error login: " + e.Message, "error");
                 throw new Exception("Error en AutenticarUsuario  excepción: " + e.Message);
            }
        }

        public Boolean BloquearUsuario(string usuario)
        {
            clsConexion objConexion = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("usuNombr", usuario, SqlDbType.VarChar, null));
                objConexion.ExecuteProc("", "", "BloquearUsuario", parametrosEntrada, ref parametrosSalida);
                return true;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Bloquear Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                return false;
            }
        }

        public DataTable ConsultaCircuitos(string CodIdioma, string idUsuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_usuario", idUsuario, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Consulta_Circuito", parametrosEntrada, ref parametrosSalida);
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
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Consultar_Sitios", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaCategorias(string CodIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Consultar_Categorias", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Categorias Falla excepción: " + e.Message, CDITrace.Tipo.Error);
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
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Consultar_ImagenSitio", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Img_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaImagenesXSitio(string idSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();

            parametrosEntrada.Add(new InParameter("idSitio", idSitio, SqlDbType.VarChar, null));

            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Consultar_ImagenSitio", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_ImagenSitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_audios(string IdCircuito, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("fk_circuito", IdCircuito, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Validacion_Audios", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Validacion_Audios falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

    }
}
