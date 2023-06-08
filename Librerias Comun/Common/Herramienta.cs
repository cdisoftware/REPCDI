using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CDI.Common
{
    public class Herramienta
    {
        #region Comun
        //CREACION DE VARIABLES PARA GENERACION DE REPORTES
        public static string ReportPath = "";
        private static string sRutaIni = "";
        private static string sUsuario = "";
        private static string sClave = "";

        private static Herramienta instance = null;
        private static string sBaseDatos;
        private static string sServidor;

        private Herramienta()
        {
            //trae la ruta del archivo de configuracion externo
            RutaConfig = ArchivoConfiguracion();
        }

        /// <summary>
        /// Trae la ruta del archivo de configuracion configurado en el web.config con la key "Archivo_Configuracion"
        /// </summary>
        /// <returns>La ruta</returns>
        public static string ArchivoConfiguracion()
        {
            string ruta = ConfigurationManager.AppSettings["Archivo_Configuracion"];

            if (ruta?.IndexOf(".config") == -1)
            {
                ruta += ".config";
            }

            return ruta;
        }

        public static Herramienta Instanciar()
        {
            if (instance == null)
            {
                instance = new Herramienta();

                string usuario = "";
                string password = "";
                string source = "";
                string instancia = "";

                usuario = TraerConfiguracion("UserBD");
                password = TraerConfiguracion("PasswordBD");
                source = TraerConfiguracion("ServerBD");
                instancia = TraerConfiguracion("InicialBD");

                usuario = usuario.Replace("\0", "");
                password = password.Replace("\0", "");
                source = source.Replace("\0", "");
                instancia = instancia.Replace("\0", "");

                sUsuario = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, usuario);
                sClave = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, password);
                sServidor = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, source);
                sBaseDatos = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, instancia);
            }

            return instance;
        }

        /// <summary>
        /// Ruta y nombre del archivo de configuracion de la app.
        /// <example>C:\Proyecto\Configlog.config</example>
        /// </summary>
        public static string RutaConfig
        {
            set
            {
                sRutaIni = value;
            }
            get
            {
                if (sRutaIni == "")
                {
                    Instanciar();
                }
                return sRutaIni;
            }
        }

        /// <summary>
        /// Usuario de la base de datos
        /// </summary>
        public static string Usuario
        {
            set
            {
                sUsuario = value;
            }
            get
            {
                Instanciar();
                return sUsuario;
            }
        }

        /// <summary>
        /// Clave de la base de datos
        /// </summary>
        public static string Clave
        {
            set
            {

                sClave = value;
            }
            get
            {
                Instanciar();
                return sClave;
            }
        }

        /// <summary>
        /// Convierte una DataTable en un arreglo de JSON
        /// </summary>
        /// <param name="dt">DataTable a convertir</param>
        /// <returns>string con los datos en formato json.</returns>
        public static string TablaToJson(DataTable dtDatos)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            try
            {
                foreach (DataRow dr in dtDatos.Rows)
                {
                    row = new Dictionary<string, object>();

                    foreach (DataColumn col in dr.Table.Columns)
                    {
                        row.Add(col.ColumnName.Trim(), dr[col]);
                    }
                    rows.Add(row);
                }

                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error en la conversion de datos a json. error " + ex.Message);
            }
        }


        /// <summary>
        /// Nombre de la base de datos
        /// </summary>
        public static string BaseDatos
        {
            set
            {

                sBaseDatos = value;
            }
            get
            {
                Instanciar();
                return sBaseDatos;
            }
        }

        /// <summary>
        /// Servidor de la base de datos
        /// </summary>
        public static string Servidor
        {
            set
            {

                sServidor = value;
            }
            get
            {
                Instanciar();
                return sServidor;
            }
        }
        #endregion

        #region Mensajes

        /// <summary>
        /// Genera un mensaje de java script
        /// </summary>
        /// <param name="Mensage">Mensaje a mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void MensageJ(string Mensage, Page pagina)
        {
            string java = "alert('" + Mensage + "');";

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Mostar ventana modal con mensaje al usuario
        /// </summary>
        /// <param name="mensage"></param>
        /// <param name="pagina"></param>
        public static void MensageModal(string mensage, Page pagina)
        {
            string titulo = "Información";

            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append(string.Format("<div id='dialog' title='{0}'>", titulo));
            sbMensaje.Append(mensage);
            sbMensaje.Append("</div>");
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.Append("$(document).ready( function() { ");
            sbMensaje.Append("$('#dialog'.dialog( { modal:true });");
            sbMensaje.Append(" });");
            sbMensaje.Append("</script>");
            Literal ltMensaje = new Literal();
            ltMensaje.Text = sbMensaje.ToString();

            pagina.Controls.Add(ltMensaje);
        }

        /// <summary>
        /// Enumeracion para los tipos de mensajes
        /// </summary>
        public enum TpoMsg
        {
            /// <summary>
            /// Para el mensaje de insercion de datos
            /// </summary>
            Insert,
            /// <summary>
            /// Para el mensaje de actualizacion de datos
            /// </summary>
            Update,
            /// <summary>
            /// Para el mensaje de eliminacion de datos
            /// </summary>
            Delete,
            /// <summary>
            /// Para el mensaje cuando no se pudo insertar
            /// </summary>
            NoInsert,
            /// <summary>
            /// Para el mensaje cuando no se pudo actualizar
            /// </summary>
            NoUpdate,
            /// <summary>
            /// Para el mensaje cuando no se pudo eliminar
            /// </summary>
            NoDelete
        }

        /// <summary>
        /// Agrega un mensaje de error al un ValidationSummary
        /// </summary>
        /// <param name="Mensaje">El mensaje a mostrar</param>
        /// <param name="Grupo">El grupo que pertenece el validationsummary</param>
        /// <param name="page">La pagina</param>
        public static void MensajeErrorPaginas(string Mensaje, string Grupo, Page page)
        {
            CustomValidator valid = new CustomValidator();
            valid.IsValid = false;
            valid.ValidationGroup = Grupo;
            valid.ErrorMessage = Mensaje;
            page.Controls.Add(valid);
        }

        /// <summary>
        /// Enumeracion del tipo de comportamiento del mensaje
        /// </summary>
        public enum Retorno
        {
            /// <summary>
            /// Saca un mensaje de alerta personalizado
            /// </summary>
            alert,
            /// <summary>
            /// Saca un mensaje de error personalizado
            /// </summary>
            error,
            /// <summary>
            /// saca un mensaje de existo de la operacion
            /// </summary>
            success,

            No,

            Yes,

            Cerrar
        }

        /// <summary>
        /// Genera un mensaje personalizado
        /// </summary>
        /// <param name="pMensage">Mensaje a mostrar maximo 100 caracteres</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void Mensage(string pMensage, Page pagina)
        {
            string[] name = SepararARegistro(pagina.Page.Request.Path, 47);
            string pgn = name[name.Length - 1];

            string java = String.Format("alert('{0}');", pMensage);

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Genera nn mensaje de personalizado
        /// </summary>
        /// <param name="Mensage">Tipo de mensaje a mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        /// <param name="rtn">Si tiene retorno a la pagina</param>
        public static void Mensage(TpoMsg Mensage, Page pagina, Retorno rtn)
        {
            string tpo = "0";
            if (Mensage == TpoMsg.Insert)
            {
                tpo = "2";
            }
            else if (Mensage == TpoMsg.Update)
            {
                tpo = "1";
            }
            else if (Mensage == TpoMsg.Delete)
            {
                tpo = "3";
            }

            string pgn = "#";

            string[] name = SepararARegistro(pagina.Page.Request.Path, 47);
            pgn = name[name.Length - 1];

            string java = String.Format("<script language='javascript'>" +
              "EjecutarMsg4('{0}', '{1}', '{2}', '{3}');" +
              "</script>", "M", pgn, rtn.ToString(), tpo);

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Genera un mensaje de personalizado
        /// </summary>
        /// <param name="Mensage">Mensaje a mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        /// <param name="rtn">Si tiene retorno a la pagina o Imagen a Mostrar en el mensaje</param>
        /// <param name="AddParams">Parametros adicionales para la ventana ColorBox</param>
        public static void Mensage(string pMensage, Page pagina, Retorno rtn)
        {
            ///el cuatro es el personalizado
            string tpo = "4";

            string pgn = "#";

            string[] name = SepararARegistro(pagina.Page.Request.Path, 47);
            pgn = name[name.Length - 1];

            string java = String.Format("<script language='javascript'>" +
              "EjecutarMsg4('{0}', '{1}', '{2}', '{3}');" +
              "</script>", pMensage, pgn, rtn.ToString(), tpo);

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Genera Un mensaje de java script
        /// </summary>
        /// <param name="Mensage">Mensaje a mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void Mensage(TpoMsg Mensage, Page pagina)
        {
            string tpo = "0";
            if (Mensage == TpoMsg.Insert)
            {
                tpo = "2";
            }
            else if (Mensage == TpoMsg.Update)
            {
                tpo = "1";
            }
            else if (Mensage == TpoMsg.Delete)
            {
                tpo = "3";
            }

            string pgn = "#";
            string[] name = SepararARegistro(pagina.Page.Request.Path, 47);
            pgn = name[name.Length - 1];

            string java = String.Format("<script language='javascript'>" +
             "EjecutarMsg3('{0}', '{1}', '{2}');" +
             "</script>", "M", pgn, tpo);

            JavaScript(java, pagina);
        }

        #endregion

        #region JavaScript
        /// <summary>
        /// Genera Un mensaje de java script
        /// </summary>
        /// <param name="Mensage">Mensaje a mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void JavaScript(string script, Page pagina)
        {
            string java = "<script language='javascript'>" + script + "</script>";
            Random ornd = new Random(999);
            int Numero = ornd.Next(999, 9999);
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), DateTime.Now.ToLongTimeString() + Numero.ToString(), java);
        }

        /// <summary>
        /// Genera un JavaScript para ocultar un control
        /// </summary>
        /// <param name="Control">Control ha ocultar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void jOcultarControl(Control ctr, Page pagina)
        {
            string java = "Hide('" + ctr.ClientID + "');";

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Genera un JavaScript para mostrar un control
        /// </summary>
        /// <param name="Control">Control ha mostrar</param>
        /// <param name="pagina">El objeto pagina en donde se lanzara el mensage</param>
        public static void jMostrarControl(Control ctr, Page pagina)
        {
            string java = "Show('" + ctr.ClientID + "');";

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Cierra la pagina
        /// </summary>
        /// <param name="pagina">El objeto pagina en donde se cerrara</param>
        public static void Cerrar(Page pagina)
        {
            string java = "close();";

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Cierra la session del aplicativo.
        /// </summary>
        /// <param name="pagina">El objeto pagina en donde se cerrara</param>
        public static void CerrarSession(Page pagina)
        {
            pagina.Response.Redirect("~/CerrarSesion.aspx");
        }

        public static void MostrarVentana(string texto, Page pagina)
        {
            string java = String.Format("makeAlert('{0}','{1}');", "CDI Software Informa", texto);

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Ventana de error con un boton para informar
        /// </summary>
        /// <param name="texto">El texto que se visualizara</param>
        /// <param name="pPage">La pagina donde aparece</param>
        public static void MostrarVentanaError(string texto, Page pagina)
        {
            string java = String.Format("makeAlertErr('{0}','{1}');", "CDI Software Informa", texto);

            JavaScript(java, pagina);
        }

        /// <summary>
        /// Envia un mensaje de confirmacion al cliente
        /// </summary>
        /// <param name="pMensaje">Mensaje a mostrar</param>
        /// <param name="boton">Boton que va tener la confirmacion</param>
        /// <param name="pagina">Instancia de la pagina que contendra el mensaje</param>
        public static void Confirmacion(string pMensaje, System.Web.UI.WebControls.Button boton, Page pagina)
        {
            string strJava = "<script> alert(" + pMensaje + ");</script>";

            System.Text.StringBuilder script = new System.Text.StringBuilder();
            script.Append("<script type= 'text/javascript' language= 'javascript'>");
            script.Append("function MensajeAdvertencia(mensaje){");
            script.Append("if(!window.confirm(mensaje)){");
            script.Append("event.returnValue=false;");
            script.Append("return false;");
            script.Append("}");
            script.Append("else{");
            script.Append("return true;");
            script.Append("}");
            script.Append("}");
            script.Append("</script>");

            JavaScript(strJava, pagina);

            boton.Attributes.Add("onclick", "javascript:MensajeAdvertencia('" + pMensaje + "?');");
        }

        /// <summary>
        /// Envia un mensaje de confirmacion al cliente
        /// </summary>
        /// <param name="pMensaje">Mensaje a mostrar</param>
        /// <param name="boton">Boton que va tener la confirmacion</param>
        /// <param name="pagina">Instancia de la pagina que contendra el mensaje</param>
        public static void Confirmacion(string pMensaje, ImageButton boton, Page pagina)
        {
            string strJava = "<script> alert(" + pMensaje + ");</script>";

            System.Text.StringBuilder script = new System.Text.StringBuilder();
            script.Append("<script type= 'text/javascript' language= 'javascript'>");
            script.Append("function MensajeAdvertencia(mensaje){");
            script.Append("if(!window.confirm(mensaje)){");
            script.Append("event.returnValue=false;");
            script.Append("return false;");
            script.Append("}");
            script.Append("else{");
            script.Append("return true;");
            script.Append("}");
            script.Append("}");
            script.Append("</script>");

            JavaScript(strJava, pagina);

            boton.Attributes.Add("onclick", "javascript:MensajeAdvertencia('" + pMensaje + "?');");
        }
        #endregion

        #region ConexionMS

        /// <summary>
        /// Trae la coneccion de la bd para ADO.Net desde un archivo Config
        /// </summary>
        /// <returns></returns>
        public static string traerConectionStringMs(MethodBase Nombre, string pUsuario)
        {
            string strconection = "";

            try
            {
                if (instance == null)
                {
                    Instanciar();
                }
                string maxpool = TraerConfiguracion("MaxPool");

                if (string.IsNullOrEmpty(pUsuario))
                {
                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "La definicion de la cadena de conexion no trae el usuario Metodo " + Nombre.Name + " Clase: " + Nombre.ReflectedType.FullName, CDITrace.Tipo.Log);
                    pUsuario = Nombre.Name;
                }

                strconection = "data source=" + sServidor + ";initial catalog=" + sBaseDatos +
                ";persist security info=True;user id=" + sUsuario + ";Password=" + sClave + ";Connect Timeout=90; Application Name = " + pUsuario + "; Max Pool Size=" + maxpool + ";Pooling=True;";
            }
            catch (Exception ex)
            {
                throw new Exception(" Ha ocurrido un error en la recuperacion de los valores de configuracion, metodo traerConectionString. Err " + ex + "Datos: data source=" + Servidor + ";initial catalog=" + BaseDatos +
                ";persist security info=True;user id=" + Usuario + ";Password=" + Clave + ";");
            }

            return strconection;
        }

        public static string traerConectionStringMs2()
        {
            string strconection = "";

            try
            {
                if (instance == null)
                {
                    Instanciar();
                }

                strconection = "data source=" + sServidor + ";initial catalog=" + sBaseDatos +
                ";persist security info=True;user id=" + sUsuario + ";Password=" + sClave + ";Connect Timeout=90;";
            }
            catch (Exception ex)
            {
                throw new Exception(" Ha ocurrido un error en la recuperacion de los valores de configuracion, metodo traerConectionString. Err " + ex + "Datos: data source=" + Servidor + ";initial catalog=" + BaseDatos +
                ";persist security info=True;user id=" + Usuario + ";Password=" + Clave + ";");
            }

            return strconection;
        }

        /// <summary>
        /// Trae la cadena de conexión de SQLSERVER para la bd EntityFramework desde un archivo Config
        /// </summary>
        /// <returns></returns>
        public static string traerConectionStringEF()
        {
            string strconection = "";
            try
            {
                if (instance == null)
                {
                    Instanciar();
                }

                strconection = "data source=" + sServidor + ";initial catalog=" + sBaseDatos +
                ";persist security info=True;user id=" + sUsuario + ";Password=" + sClave + ";Connect Timeout=90";
            }
            catch (Exception ex)
            {
                throw new Exception(" Ha ocurrido un error en la recuperacion de los valores de configuracion, metodo traerConectionString. Err " + ex + "Datos: data source=" + Servidor + ";initial catalog=" + BaseDatos +
                ";persist security info=True;user id=" + Usuario + ";Password=" + Clave + ";");
            }

            return strconection;
        }

        /// <summary>
        /// Trae la coneccion de la bd para ORACLE desde un archivo Config
        /// </summary>
        /// <returns></returns>
        public static string traerConectionStringOrcl()
        {
            string strconection = "";
            string puerto = "";

            try
            {
                if (instance == null)
                {
                    Instanciar();
                }

                puerto = TraerConfiguracion("Puerto");

                strconection = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " + sServidor + ")(PORT = " + puerto +
                              ")))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + sBaseDatos + "))); " +
                              "User Id = " + sUsuario + "; Password = " + sClave + ";";


                //CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), strconection, CDITrace.Tipo.Log);
            }
            catch (Exception ex)
            {
                throw new Exception(" Ha ocurrido un error en la recuperacion de los valores de configuracion, metodo traerConectionString. Err " + ex + "Datos: data source=" + Servidor + ";initial catalog=" + BaseDatos +
                ";persist security info=True;user id=" + Usuario + ";");
            }

            return strconection;
        }

        /// <summary>
        /// Trae la coneccion de la bd ALTERNA para ORACLE desde un archivo Config
        /// SOLO CDI Software
        /// </summary>
        /// <returns></returns>
        public static string traerConectionStringOrclAlt()
        {
            string strconection = "";
            string usuario = "";
            string password = "";
            string source = "";
            string instancia = "";
            string puerto = "";

            try
            {
                if (instance == null)
                {
                    Instanciar();
                }

                usuario = TraerConfiguracion("UserBDAlt");
                password = TraerConfiguracion("PasswordBDAlt");
                source = TraerConfiguracion("ServerBDAlt");
                instancia = TraerConfiguracion("InicialBDAlt");
                puerto = TraerConfiguracion("PuertoAlt");

                usuario = usuario.Replace("\0", "");
                password = password.Replace("\0", "");
                source = source.Replace("\0", "");
                instancia = instancia.Replace("\0", "");

                sUsuario = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, usuario);
                sClave = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, password);
                sServidor = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, source);
                sBaseDatos = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, instancia);

                strconection = "Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = " + sServidor + ")(PORT = " + puerto +
                              ")))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = " + sBaseDatos + "))); " +
                              "User Id = " + sUsuario + "; Password = " + sClave + ";";
            }
            catch (Exception ex)
            {
                throw new Exception(" Ha ocurrido un error en la recuperacion de los valores de configuracion, metodo traerConectionString. Err " + ex + "Datos: data source=" + source + ";initial catalog=" + instancia +
                ";persist security info=True;user id=" + usuario + ";Password=" + password + ";");
            }

            return strconection;
        }

        /// <summary>
        /// Trae la ubicacion de los logs en la maquina servidor 
        /// </summary>
        /// <returns></returns>
        public static string traerUbicacionLogs()
        {
            try
            {
                string ubiLogs = TraerConfiguracion("LogPath");

                if (ubiLogs == "")
                {
                    ubiLogs = @"C:\Temp";
                }

                return ubiLogs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trae un parametro del archivo de configuración
        /// </summary>
        /// <param name="key">Parametro a traer</param>
        /// <param name="pUbicacion">Ubicacion del config</param>
        /// <example>C:\\proyectos\\sci.config</example>
        /// <returns>El valor de la key</returns>
        public static string TraerConfiguracion(string key, string pUbicacion)
        {
            string valor = "";

            if (File.Exists(pUbicacion))
            {
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = pUbicacion;

                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                try
                {
                    valor = config.AppSettings.Settings[key].Value;
                }
                catch (Exception ex)
                {
                    CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "No existe la key buscada, [" + key + "] ", ex);
                    return "";
                }
            }
            return valor;
        }

        /// <summary>
        /// Trae un parametro del archivo de configuración
        /// </summary>
        /// <param name="key">Parametro a traer</param>
        /// <returns>El valor de la key</returns>
        public static string TraerConfiguracion(string key)
        {
            if (instance == null)
            {
                Instanciar();
            }

            return TraerConfiguracion(key, RutaConfig);
        }

        #endregion

        #region Redirecciones

        /// <summary>
        /// Lista de los posibles estados para las paginas
        /// </summary>
        public enum Estado
        {
            /// <summary>
            /// Cuando se envia a la pagina para editar
            /// </summary>
            Editar,
            /// <summary>
            /// Cuando se envia a la pagina para insertar
            /// </summary>
            Insertar,
            /// <summary>
            /// Cuando la pagina va a ser de solo consulta
            /// </summary>
            Consulta,
            /// <summary>
            /// Cuando la pagina anterior edito exitosamente
            /// </summary>
            Editado,
            /// <summary>
            /// Cuando la pagina anterior inserto exitosamente
            /// </summary>
            Insertado,
            /// <summary>
            /// Cuando no se necesita enviar nada
            /// </summary>
            Nada,
        }

        /// <summary>
        /// Metodo para llamar paginas
        /// </summary>
        /// <param name="pagina">La pagina actual(This)</param>
        /// <param name="url">La url a la cual se va a enviar</param>
        /// <param name="estado">El estado que con el que se va a enviar la pagina</param>
        public static void redireccion(Page pagina, string url, Estado estado)
        {
            string sUrl = "";

            if (url.IndexOf("?") == -1)
            {
                sUrl = url + "?e=" + estado.ToString();
            }
            else
            {
                sUrl = url + "&e=" + estado.ToString();
            }

            pagina.Response.Redirect(sUrl);
        }

        /// <summary>
        /// Trae las url de la pagina actual
        /// </summary>
        /// <param name="Pagina">la referencia a la pagina</param>
        /// <returns>la url</returns>
        public static string TraerUrl(Page Pagina)
        {
            string url = Pagina.Request.Url.AbsolutePath.Remove(0, 1);

            if (SepararARegistro(url, 47).Length == 2)
            {
                return url;
            }
            else
            {
                return url.Remove(0, url.IndexOf("/") + 1);
            }
        }
        #endregion

        #region Anexos
        /// <summary>
        /// Trae la ubicacion de los anexos en la maquina servidor 
        /// </summary>
        /// <returns></returns>
        public static string traerUbicacionAnexos()
        {
            string ubiLogs = TraerConfiguracion("AnexosPath", RutaConfig);

            if (ubiLogs == "")
            {
                ubiLogs = @"C:\Proyectos\";
            }

            return ubiLogs;
        }

        #endregion

        #region Ejecutar Archivos
        /// <summary> ejecuta archivo .bat
        /// 
        /// </summary>
        /// <param name="nomb">nombre de archivo</param>
        /// <param name="rut">ubicacion</param>
        /// <returns>nombre de archivo si fue ejecutado exitosamente</returns>
        public static string EjecutarArchivo(string nombre, string ruta)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(nombre);
                psi.WorkingDirectory = ruta;
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                Process.Start(psi);

                return nombre;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        #endregion

        #region Controles de listas

        /// <summary>
        /// Inserta el elemento por defecto para el dropdownlist dado ("Seleccione..." valor "-1")
        /// </summary>
        /// <param name="ddl">Dropdown para hacer la inserción</param>
        public static void InsertDefaultValue(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Seleccione...", "-1"));
            //ddl.Items.Insert(1, new ListItem("No Aplica", "-2"));
        }

        /// <summary>
        /// Trae el valor seleccionado en el listcontrol
        /// </summary>
        /// <param name="listControl"></param>
        /// <returns>string -1 si no hay valor o el valor seleccionado</returns>
        public static string TraeValorStringListControl(ListControl listControl)
        {
            string selval = "";

            if (listControl.SelectedValue.Trim() == "")
            {
                selval = "-1";
            }
            else
            {
                selval = listControl.SelectedValue;
            }

            return selval;
        }

        /// <summary>
        /// Carga con los datos especificados el Control de listas especificado y los ordena de acuerdo a la columna que llevará el texto y si se autohabilitará el control de destino
        /// </summary>
        /// <param name="control">El control ha ser llenado</param>
        /// <param name="dv">El nombre de la dataview con los datos de origen</param>
        /// <param name="nombreColumnaValor">El nombre de la columna que asignará el valor a las entradas</param>
        /// <param name="nombreColumnaMostrar">El nombre de la columna que asignará el texto a las entradas</param>
        /// <param name="nombreColumnaOrdenar">Nombre de la columna en la tabla que será usada para el ordenamiento</param>
        public static void cargarControlDListas(ListControl control, DataView dv, string nombreColumnaValor, string nombreColumnaMostrar, string nombreColumnaOrdenar)
        {
            if (dv != null)
            {
                dv.Sort = nombreColumnaOrdenar;
                if (dv.Count > 0)
                {
                    control.DataSource = dv;
                    control.DataTextField = nombreColumnaMostrar;
                    control.DataValueField = nombreColumnaValor;
                    control.DataBind();
                }
                else
                {
                    control.Items.Clear();
                }

                if (control is DropDownList)
                {
                    InsertDefaultValue((DropDownList)control);
                }
            }
        }

        /// <summary>
        /// Carga con los datos especificados el Control de listas especificado y los ordena de acuerdo a la columna que llevará el texto y si se autohabilitará el control de destino
        /// </summary>
        /// <param name="control">El control ha ser llenado</param>
        /// <param name="List">El nombre de la lista con los datos de origen</param>
        /// <param name="nombreColumnaValor">El nombre de la columna que asignará el valor a las entradas</param>
        /// <param name="nombreColumnaMostrar">El nombre de la columna que asignará el texto a las entradas</param>
        public static void cargarControlDListas(ListControl control, IList pList, string nombreColumnaValor, string nombreColumnaMostrar)
        {
            if (pList?.Count > 0)
            {
                control.DataSource = pList;
                control.DataTextField = nombreColumnaMostrar;
                control.DataValueField = nombreColumnaValor;
                control.DataBind();
            }
            else
            {
                control.Items.Clear();
            }

            if (control is DropDownList)
            {
                InsertDefaultValue((DropDownList)control);
            }
        }

        /// <summary>
        /// Carga con los datos especificados el Control de listas especificado y si se autohabilitará el control de destino
        /// </summary>
        /// <param name="control">El control ha ser llenado</param>
        /// <param name="List">El nombre de la Lista con los datos de origen</param>
        public static void cargarControlDListas(ListControl control, IList List)
        {
            if (List.Count > 0)
            {
                control.DataSource = List;
                control.DataBind();
            }
            else
            {
                control.Items.Clear();
            }

            if (control is DropDownList)
            {
                InsertDefaultValue((DropDownList)control);
            }
        }

        /// <summary>
        /// Parsea un control list y devuelve el valor entero equivalente
        /// </summary>
        /// <param name="listControl"></param>
        /// <returns>valor entero equivalente</returns>
        public static Nullable<int> ParseListControl(ListControl listControl)
        {
            int selval = -1;
            if (int.TryParse(listControl.SelectedValue, out selval) && selval >= 0) return selval;
            return null;
        }

        /// <summary>
        /// Trae el valor seleccionado en el listcontrol
        /// </summary>
        /// <param name="listControl"></param>
        /// <returns>-1 si no hay valor o el valor seleccionado</returns>
        public static int TraeValorListControl(ListControl listControl)
        {
            int selval = -1;
            int.TryParse(listControl.SelectedValue, out selval);
            return selval;
        }

        /// <summary>
        /// Ordena los Items de un Control ListBox de la A a la Z, cuando sus items son repetidos y 
        /// su clave o valor es diferente. No retorna valor.
        /// </summary>
        /// <param name="ControlListBox">Control ListBox a ordenar.</param>
        public static void OrdenarItemsListBoxItemsRepetidos(ListBox ControlListBox)
        {
            SortedList sl = new SortedList();
            foreach (ListItem li in ControlListBox.Items)
            {
                sl.Add(li.Text + "." + li.Value, li.Value);
            }
            ControlListBox.Items.Clear();
            foreach (DictionaryEntry key in sl)
            {
                ListItem item = new ListItem();
                string[] texto = SepararARegistro(key.Key.ToString(), 46);
                item.Text = texto[0];
                item.Value = key.Value.ToString();
                ControlListBox.Items.Add(item);
            }
            //ControlListBox.DataSource = sl;
            //ControlListBox.DataValueField = "Value";
            //ControlListBox.DataTextField = "Key";
            //ControlListBox.DataBind();
        }

        /// <summary>
        /// Ordena los Items de un Control ListBox de la A a la Z. No retorna valor.
        /// </summary>
        /// <param name="ControlListBox">Control ListBox a ordenar.</param>
        public static void OrdenarItemsListBoxItems(ListBox ControlListBox)
        {
            SortedList sl = new SortedList();
            foreach (ListItem li in ControlListBox.Items)
            {
                sl.Add(li.Text, li.Value);
            }
            ControlListBox.DataSource = sl;
            ControlListBox.DataValueField = "Value";
            ControlListBox.DataTextField = "Key";
            ControlListBox.DataBind();
        }
        #endregion ListControls

        #region Parceo  

        /// <summary>
        /// Parsea un texto a base 64
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>string en base 64</returns>
        public static string ParseoBase64(string pTxt)
        {
            try
            {
                byte[] bDatos = Encoding.UTF8.GetBytes(pTxt);

                string datos = Convert.ToBase64String(bDatos);

                return datos;
            }
            catch (Exception ex)
            {
                CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParseoBase64]. Detalle: ", ex);
                return null;
            }
        }

        /// <summary>
        /// Parsea un texto a entero
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>Entero con el valor convertido</returns>
        public static int ParseoTexto(object pTxt)
        {
            int ret;
            try
            {
                string txt = pTxt.ToString();
                return int.TryParse(txt, out ret) ? ret : -1;
            }
            catch (Exception ex)
            {
                CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParceoTexto]. Detalle: ", ex);
                return -1;
            }
        }

        /// <summary>
        /// Parsea un texto a entero
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>Entero con el valor convertido o cero si no pudo convertirlo</returns>
        public static int ParseoTextoCero(object pTxt)
        {
            int ret;
            try
            {
                string txt = pTxt.ToString();
                return int.TryParse(txt, out ret) ? ret : 0;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParceoTexto]. Detalle: ", ex);
                return 0;
            }
        }

        /// <summary>
        /// Parsea un texto a entero
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>Entero con el valor convertido</returns>
        public static int? ParseoTextoANull(object pTxt)
        {
            int ret;
            try
            {
                string txt = pTxt.ToString();

                int valor = int.TryParse(txt, out ret) ? ret : -1;

                if (valor != -1)
                {
                    return ret;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParceoTextoANull]. Detalle: ", ex);
                return -1;
            }
        }

        /// <summary>
        /// Parsea un texto a entero
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>Entero con el valor convertido</returns>
        public static float ParseoTextoAFloat(object pTxt)
        {
            float ret;
            try
            {
                string txt = pTxt.ToString();
                return float.TryParse(txt, out ret) ? ret : -1;
            }
            catch (Exception ex)
            {
                CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParseoTextoAFloat]. Detalle: ", ex);
                return -1;
            }
        }

        /// <summary>
        /// Parsea un texto proveniente de un textbox
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>Double con el valor convertido</returns>
        public static double ParseoTextoADouble(string txt)
        {
            double ret;
            return double.TryParse(txt, out ret) ? ret : 0;
        }

        /// <summary>
        /// Parsea un texto a decimal
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>El decimal con el valor convertido</returns>
        public static decimal? ParseoTextoADecimalNull(string txt)
        {
            decimal ret;

            if (decimal.TryParse(txt, out ret))
            {
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Obtener el valor numérico de tipo Short
        /// </summary>
        /// <returns>short: valor numérico o null si el valor no es correcto</returns>
        public static short? ObtenerValorShort(string datoValidar)
        {
            if (!string.IsNullOrEmpty(datoValidar))
            {
                short valor = 0;
                if (short.TryParse(datoValidar, out valor))
                    return valor;

                return null;
            }

            return null;
        }

        /// <summary>
        /// Parsea un texto a decimal
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>El decimal con el valor convertido</returns>
        public static decimal ParseoTextoADecimal(string txt)
        {
            decimal ret;

            if (txt.IndexOf(",") != -1)
            {
                txt = txt.Replace(".", "");
                txt = txt.Replace(",", ".");
            }
            return decimal.TryParse(txt, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out ret) ? ret : -1;
        }

        /// <summary>
        /// Parsea un texto a decimal
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>El decimal con el valor convertido</returns>
        public static decimal? ParseoTextoADecimalCero(object txt)
        {
            decimal ret;

            if (txt != null)
            {
                return decimal.TryParse(txt.ToString(), out ret) ? ret : 0;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Parsea un texto a decimal
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>El decimal con el valor convertido</returns>
        public static decimal ParseoTextoADecimalCero(string txt)
        {
            decimal ret;
            if (txt != null)
            {
                return decimal.TryParse(txt.ToString(), out ret) ? ret : 0;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Parsea un texto a bool
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el bool con el valor convertido o false si tiene algun error</returns>
        public static bool ParseoTextoABool(string txt)
        {
            bool ret;
            return bool.TryParse(txt, out ret) ? ret : false;
        }

        /// <summary>
        /// Parsea un texto a fecha con cultura es-co
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el bool con el valor convertido o la fecha del dia si no se puede convertir</returns>
        public static DateTime ParseoTextoAFechaCulture(string txt)
        {
            DateTime ret;
            System.Globalization.CultureInfo esCo = new System.Globalization.CultureInfo("es-CO");

            DateTime.TryParseExact(txt, "d/M/yyyy", esCo, System.Globalization.DateTimeStyles.None, out ret);


            return ret;
        }

        /// <summary>
        /// Parsea un texto a fecha 
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el bool con el valor convertido o la fecha del dia si no se puede convertir</returns>
        public static DateTime ParseoTextoAFecha(string txt)
        {
            DateTime ret;

            return DateTime.TryParse(txt, out ret) ? ret : DateTime.Now;
        }

        /// <summary>
        /// Parsea un texto de fecha a un string fecha con formato dd/MM/YYYY
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el string con el valor convertido o la fecha del dia si no se puede convertir</returns>
        public static string ParseoTextoAStringFecha(string txt)
        {
            DateTime ret = DateTime.Now;

            DateTime.TryParse(txt, out ret);

            return ret.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Parsea un texto de fecha a un string fecha con formato dd/MM/YYYY
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el string con el valor convertido o empty si no se puede convertir</returns>
        public static string ParseoTextoAStringFechaEmpty(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return txt;
            }
            else
            {
                DateTime ret = DateTime.Now;

                DateTime.TryParse(txt, out ret);

                return ret.ToString("dd/MM/yyyy");
            }
        }

        /// <summary>
        /// Parsea un texto a fecha si viene vacio lo deja null
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>el bool con el valor convertido o la fecha del dia si no se puede convertir</returns>
        public static DateTime? ParseoTextoAFechaNull(string txt)
        {
            DateTime ret;

            if (DateTime.TryParse(txt, out ret))
            {
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Quita los ceros que tenga 
        /// </summary>
        /// <param name="txt">texto de donde se va a estraer</param>
        /// <returns>Entero sin los ceros</returns>
        public static int QuitarCeros(string txt)
        {
            int ret;
            if (txt.StartsWith("0"))
                txt.Replace("0", "");
            return int.TryParse(txt, out ret) ? ret : -1;

        }

        /// <summary>
        /// Convertir una lista en DataTable
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static DataTable aDataTable(List<Dictionary<string, object>> items)
        {
            DataTable result = new DataTable();
            if (items.Count == 0)
                return result;

            var columnNames = items.SelectMany(dict => dict.Keys).Distinct();
            result.Columns.AddRange(columnNames.Select(c => new DataColumn(c)).ToArray());
            foreach (Dictionary<string, object> item in items)
            {
                var row = result.NewRow();
                foreach (var key in item.Keys)
                {
                    row[key] = item[key];
                }

                result.Rows.Add(row);
            }

            return result;
        }
        #endregion

        #region GridView

        /// <summary>
        /// Con este metodo se carga el gridview deseado
        /// </summary>
        /// <param name="gvAcargar">gridview a cargar</param>
        /// <param name="dvCargado">datos para el control</param>
        public static void cargarGridView(GridView gvAcargar, DataView dvCargado)
        {
            gvAcargar.DataSource = dvCargado;
            gvAcargar.DataBind();
        }

        /// <summary>
        /// Con este metodo se carga el gridview deseado
        /// </summary>
        /// <param name="gvAcargar">gridview a cargar</param>
        /// <param name="dvCargado">datos para el control</param>
        public static void cargarGridView(GridView gvAcargar, DataTable dtCargado)
        {
            gvAcargar.DataSource = dtCargado;
            gvAcargar.DataBind();
        }

        /// <summary>
        /// Con este metodo se carga el gridview deseado
        /// </summary>
        /// <param name="gvAcargar">gridview a cargar</param>
        /// <param name="list">datos para el control</param>
        public static void cargarGridView(GridView gvAcargar, IList list)
        {
            gvAcargar.DataSource = list;
            gvAcargar.DataBind();
        }

        /// <summary>
        /// Rutina para recordar los checkbox selecionados cuando se realiza la paginacion del GridView
        /// </summary>
        /// <param name="pItemsList">La lista de los checkbox seleccionados en la acterior paginacion</param>
        /// <param name="pGV">El GridView que se va a recorrer para validar los check </param>
        /// <param name="pColumnaID">La columna que va a contener el valor id que se asociara el la lista</param>
        /// <param name="NombreCombo">El nombre del combobox que se va a revisar</param>
        /// <returns>La lista de los combobox que estan chequeados</returns>
        public static ArrayList RecordarCheckBox(ArrayList pItemsList, GridView pGV, int pColumnaID, string NombreCombo)
        {
            ArrayList IdList = new ArrayList();
            int iIndex = -1;

            foreach (GridViewRow item in pGV.Rows)
            {
                iIndex = ParseoTexto(pGV.DataKeys[item.RowIndex].Values[pColumnaID].ToString());

                bool bResult = ((CheckBox)item.FindControl(NombreCombo)).Checked;

                if (pItemsList != null)
                {
                    IdList = pItemsList;
                }

                if (bResult)
                {
                    if (!IdList.Contains(iIndex))
                    {
                        IdList.Add(iIndex);
                    }
                }
                else
                {
                    IdList.Remove(iIndex);
                }
            }

            return IdList;
        }

        /// <summary>
        /// Carga los CheckBox que antes fueron selccionados cuando se cambia la paginacion
        /// </summary>
        /// <param name="pItemsList">La lista de los checkbox seleccionados en la acterior paginacion</param>
        /// <param name="pGV">El GridView que se va a recorrer para validar los check </param>
        /// <param name="pColumnaID">La columna que va a contener el valor id que se asociara el la lista</param>
        /// <param name="NombreCombo">El nombre del combobox que se va a revisar</param>
        public static void CargarCheckBox(ArrayList pItemsList, GridView pGV, int pColumnaID, string NombreCombo)
        {
            if (pItemsList != null && pItemsList.Count > 0)
            {
                foreach (GridViewRow item in pGV.Rows)
                {
                    int iIndex = ParseoTexto(pGV.DataKeys[item.RowIndex].Values[pColumnaID].ToString());

                    if (pItemsList.Contains(iIndex))
                    {
                        CheckBox myCheckBox = (CheckBox)item.FindControl(NombreCombo);
                        myCheckBox.Checked = true;
                    }
                }
            }
        }

        #endregion

        #region Office

        /// <summary>
        /// Exporta a Excel
        /// </summary>
        /// <param name="DivExportar">Control HTML Div</param>
        /// <param name="NameReport">Nombre del reporte</param>
        public static void ExportarExcel(HtmlControl DivExportar, string NameReport)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            DivExportar.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(DivExportar);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + NameReport + "_" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            HttpContext.Current.Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            page.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// Exporta a Excel
        /// </summary>
        /// <param name="NameReport">Nombre del reporte</param>
        /// <param name="Grid">Control de tipo GridView a exportar</param>
        /// <param name="PathRpt">Ruta</param>
        public static void ExportarExcel(GridView Grid, string NameReport)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            Grid.EnableViewState = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(Grid);
            page.RenderControl(htw);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + NameReport + ".xls");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportarExcel_Prueba(GridView Grid, string NameReport)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            System.Web.UI.Page page = new System.Web.UI.Page();
            HtmlForm form = new HtmlForm();

            Grid.EnableViewState = false;
            Grid.AllowPaging = false;
            Grid.AllowSorting = false;

            // Deshabilitar la validación de eventos, sólo asp.net 2
            page.EnableEventValidation = false;

            // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
            page.DesignerInitialize();

            page.Controls.Add(form);
            form.Controls.Add(Grid);
            page.RenderControl(htw);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + NameReport + ".xls");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = Encoding.Default;
            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Exporta a excel un data table
        /// </summary>
        /// <param name="table">Data table a exportar</param>
        /// <param name="name">Nombre del excel sin extencion</param>
        public static void ExportarExcel(DataTable table, string name)
        {
            HttpContext context = HttpContext.Current;
            context.Response.Clear();
            foreach (DataColumn column in table.Columns)
            {
                context.Response.Write(column.ColumnName + ";");
            }
            context.Response.Write(Environment.NewLine);
            foreach (DataRow row in table.Rows)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
                }
                context.Response.Write(Environment.NewLine);
            }

            context.Response.ContentType = "text/csv";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name + ".xls");
            context.Response.End();
        }

        /// <summary>
        /// Exporta a excel un datatable
        /// </summary>
        /// <param name="source">Datatable a exportar</param>
        /// <param name="strDir">Ruta completa donde se guardara el excel</param>
        public static void ExportExcel(DataTable source, string strDir)
        {

            StreamWriter excelDoc = new StreamWriter(strDir);
            const string startExcelXML = "<xml version version='1.0'>\r\n<Workbook " +
                        "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                        " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                        "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                        "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                        "office:spreadsheet\">\r\n <Styles>\r\n " +
                        "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"BoldColumn\">\r\n<Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n<Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/></Style>\r\n" +
                        "<Style ss:ID=\"StringLiteral\">\r\n <NumberFormat ss:Format=\"@\"/>\r\n </Style>\r\n" +
                        "<Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"#,##0.00\"/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"#,##0\"/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ss:Format=\"dd/mm/yyyy;@\"/>\r\n </Style>\r\n " +
                        "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;

            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
            excelDoc.Write("<Table>");
            excelDoc.Write("<Row>");
            for (int x = 0; x < source.Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(source.Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");
            foreach (DataRow x in source.Rows)
            {
                rowCount++;
                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                "-" +
                                (XMLDate.Month < 10 ? "0" +
                                XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                "-" +
                                (XMLDate.Day < 10 ? "0" +
                                XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                "T" +
                                (XMLDate.Hour < 10 ? "0" +
                                XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                ":" +
                                (XMLDate.Minute < 10 ? "0" +
                                XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                ":" +
                                (XMLDate.Second < 10 ? "0" +
                                XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString().Replace(',', '.'));
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }
            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }

        /// <summary>
        /// Exporta a excel un dataset
        /// </summary>
        /// <param name="source">DataSet a exportar</param>
        /// <param name="strDir">Ruta completa donde se guardara el excel</param>
        public static void ExportExcel(DataSet source, string strDir)
        {

            StreamWriter excelDoc = new StreamWriter(strDir);
            const string startExcelXML = "<xml version version='1.0'>\r\n<Workbook " +
                        "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                        " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                        "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                        "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                        "office:spreadsheet\">\r\n <Styles>\r\n " +
                        "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>\r\n <Protection/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"BoldColumn\">\r\n<Font x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n<Interior ss:Color=\"#D8D8D8\" ss:Pattern=\"Solid\"/></Style>\r\n" +
                        "<Style ss:ID=\"StringLiteral\">\r\n <NumberFormat ss:Format=\"@\"/>\r\n </Style>\r\n" +
                        "<Style ss:ID=\"Decimal\">\r\n <NumberFormat ss:Format=\"#,##0.00\"/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"Integer\">\r\n <NumberFormat ss:Format=\"#,##0\"/>\r\n </Style>\r\n " +
                        "<Style ss:ID=\"DateLiteral\">\r\n <NumberFormat ss:Format=\"dd/mm/yyyy;@\"/>\r\n </Style>\r\n " +
                        "</Styles>\r\n ";
            const string endExcelXML = "</Workbook>";

            int rowCount = 0;
            int sheetCount = 1;

            excelDoc.Write(startExcelXML);
            excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
            excelDoc.Write("<Table>");
            excelDoc.Write("<Row>");
            for (int x = 0; x < source.Tables[0].Columns.Count; x++)
            {
                excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                excelDoc.Write(source.Tables[0].Columns[x].ColumnName);
                excelDoc.Write("</Data></Cell>");
            }
            excelDoc.Write("</Row>");
            foreach (DataRow x in source.Tables[0].Rows)
            {
                rowCount++;
                //if the number of rows is > 64000 create a new page to continue output
                if (rowCount == 64000)
                {
                    rowCount = 0;
                    sheetCount++;
                    excelDoc.Write("</Table>");
                    excelDoc.Write(" </Worksheet>");
                    excelDoc.Write("<Worksheet ss:Name=\"Sheet" + sheetCount + "\">");
                    excelDoc.Write("<Table>");
                }
                excelDoc.Write("<Row>"); //ID=" + rowCount + "
                for (int y = 0; y < source.Tables[0].Columns.Count; y++)
                {
                    System.Type rowType;
                    rowType = x[y].GetType();
                    switch (rowType.ToString())
                    {
                        case "System.String":
                            string XMLstring = x[y].ToString();
                            XMLstring = XMLstring.Trim();
                            XMLstring = XMLstring.Replace("&", "&");
                            XMLstring = XMLstring.Replace(">", ">");
                            XMLstring = XMLstring.Replace("<", "<");
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write(XMLstring);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DateTime":
                            //Excel has a specific Date Format of YYYY-MM-DD followed by  
                            //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                            //The Following Code puts the date stored in XMLDate 
                            //to the format above
                            DateTime XMLDate = (DateTime)x[y];
                            string XMLDatetoString = ""; //Excel Converted Date
                            XMLDatetoString = XMLDate.Year.ToString() +
                                "-" +
                                (XMLDate.Month < 10 ? "0" +
                                XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                "-" +
                                (XMLDate.Day < 10 ? "0" +
                                XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                "T" +
                                (XMLDate.Hour < 10 ? "0" +
                                XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                ":" +
                                (XMLDate.Minute < 10 ? "0" +
                                XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                ":" +
                                (XMLDate.Second < 10 ? "0" +
                                XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                ".000";
                            excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                "<Data ss:Type=\"DateTime\">");
                            excelDoc.Write(XMLDatetoString);
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Boolean":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Int16":
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            excelDoc.Write("<Cell ss:StyleID=\"Integer\"><Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString());
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.Decimal":
                        case "System.Double":
                            excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                "<Data ss:Type=\"Number\">");
                            excelDoc.Write(x[y].ToString().Replace(',', '.'));
                            excelDoc.Write("</Data></Cell>");
                            break;
                        case "System.DBNull":
                            excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                "<Data ss:Type=\"String\">");
                            excelDoc.Write("");
                            excelDoc.Write("</Data></Cell>");
                            break;
                        default:
                            throw (new Exception(rowType.ToString() + " not handled."));
                    }
                }
                excelDoc.Write("</Row>");
            }
            excelDoc.Write("</Table>");
            excelDoc.Write(" </Worksheet>");
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }

        /// <summary>
        /// Esorta un texto a word
        /// </summary>
        /// <param name="Cadena_Imprimir">texto a exportar</param>
        public static void ExportarWord(string[] Cadena_Imprimir)
        {
            int i = 0;
            System.Web.UI.Page pageHtml = new System.Web.UI.Page();
            HtmlForm formHtml = new HtmlForm();
            HtmlHead Head = new HtmlHead();
            pageHtml.EnableViewState = false;



            StringBuilder BuilderReturn = new StringBuilder();
            StringWriter WriterHtlmText = new StringWriter(BuilderReturn);
            HtmlTextWriter WriterExcel = new HtmlTextWriter(WriterHtlmText);
            WriterExcel.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\n<head>\n<title>Correspondencia</title>\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\" />\n<style>\n</style>\n</head>\n<body>\n");

            for (i = 0; i < Cadena_Imprimir.LongLength - 1; i++)
            {
                WriterExcel.Write(Cadena_Imprimir[i].ToString());
                WriterExcel.Write("<br clear=all style='page-break-before:always'>");


            }
            pageHtml.DesignerInitialize();
            pageHtml.RenderControl(WriterExcel);

            pageHtml.Dispose();
            pageHtml = null;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ContentType = "application/vnd.ms-Word";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=Correspondencia.doc");
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.Write(BuilderReturn.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Trae los valores de un excel soporta xlsx
        /// </summary>
        /// <param name="PatchLocalizacion">Lugar donde se encuentra el excel</param>
        /// <returns>Los datos cargados en un dataset</returns>
        public static DataSet TraerDatosExcel(string PatchLocalizacion)
        {
            try
            {
                string mypath = PatchLocalizacion;
                String sConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + mypath + "; Extended Properties='Excel 12.0 Xml;hdr=yes;imex=1'";

                // Crear el objeto de conexión utilizando la cadena de conexión anterior. 
                OleDbConnection objConn = new OleDbConnection(sConnectionString);
                objConn.Open();

                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [BASE$]", objConn);
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

                objAdapter1.SelectCommand = objCmdSelect;
                DataSet objDataset1 = new DataSet();
                objAdapter1.Fill(objDataset1, "XLData");

                objConn.Close();

                return objDataset1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Ayudas
        /// <summary>
        /// Crea una paleta de colores para que el usuario la escoja 
        /// </summary>
        /// <param name="tbl">nombre de la tabla a rellenar con los colores</param>
        public static void creartabla(Table tbl)
        {
            string[] r = { "00", "99", "FF" };
            string[] g = { "00", "99", "FF" };
            string[] b = { "00", "99", "FF" };

            int rb = 0;

            for (int i = 0; i < r.Length; i++)
            {
                TableRow row = new TableRow();

                for (int j = 0; j < g.Length; j++)
                {
                    for (int k = 0; k < b.Length; k++)
                    {
                        // valor de el color
                        string nuevoc = "#" + r[i] + g[j] + b[k];

                        // crea nueva celda 
                        TableCell celda = new TableCell();

                        //crea nuevo radio button
                        rb++;

                        RadioButton escojido = new RadioButton();

                        System.Drawing.ColorConverter color = new System.Drawing.ColorConverter();
                        System.Drawing.Color colores = new System.Drawing.Color();
                        colores = (System.Drawing.Color)color.ConvertFromString(nuevoc);

                        // modifica caracteristocas del radio button
                        escojido.ID = rb.ToString();
                        escojido.BackColor = colores;
                        escojido.GroupName = "1";
                        escojido.BorderColor = colores;
                        escojido.ToolTip = nuevoc;

                        celda.BackColor = colores;
                        celda.Controls.Add(escojido);
                        row.Cells.Add(celda);
                    }
                }
                tbl.Rows.Add(row);
            }
        }

        /// <summary>
        /// Metodo que parte un registro de datos por un valor ancii
        /// </summary>
        /// <param name="valor">string que contiene cierta cantidad de caracteres</param>
        /// <param name="ancii">Valor de ancii por el cual se va a separar. </param>
        /// <returns>un arreglo de valores que contendra por si solo los registros</returns>
        public static string[] SepararARegistro(string valor, int ancii)
        {
            char[] chr = { (char)ancii };
            int valoresVacios = 0;
            string[] substring = valor.Split(chr); //valor.Split(chr35, StringSplitOptions.None);
            foreach (string val in substring)
            {
                if (val == "" || val.Length <= 0)
                {
                    valoresVacios++;
                }
            }

            string[] resultado = new string[(substring.Length - valoresVacios)];
            int cont = 0;
            for (int i = 0; i < substring.Length; i++)
            {

                if (substring[i] != "" && substring[i].Length > 0)
                {
                    resultado[cont] = substring[i];
                    cont++;
                }
            }
            return resultado;
        }

        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW", SetLastError = true,
        CharSet = System.Runtime.InteropServices.CharSet.Unicode, ExactSpelling = true, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnString, int nSize, string lpFilename);

        /// <summary>
        /// Devuelve el valor de una clave de un fichero INI
        /// </summary>
        /// <param name="seccion">La sección de la que se quiere leer</param>
        /// <param name="KeyNombre">Clave</param>
        /// <param name="nombreArch">El fichero INI</param>
        /// <param name="opcional">Valor opcional que devolverá si no se encuentra la clave</param>
        /// <returns>El valor de la cleve de la seccion deseada</returns>
        /// <remarks></remarks>
        public static string ReadStringIni(string seccion, string KeyNombre, string nombreArch, string opcional)
        {
            int ret;
            string sRetVal, resultad;
            resultad = "";
            try
            {
                sRetVal = new string(' ', 1024);

                if (File.Exists(nombreArch))
                {
                    ret = GetPrivateProfileString(seccion, KeyNombre, opcional, sRetVal, sRetVal.Length, nombreArch);

                    foreach (char tmp in sRetVal.ToCharArray())
                    {
                        resultad = resultad + tmp.ToString();
                    }

                    if (ret == 0)
                    {
                        return opcional;
                    }
                    else
                    {
                        return resultad.Trim();
                    }
                }
                else
                {
                    CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "No existe el archivo Ini de configuracion, revise la ubicacion en el web.config", CDI.Common.CDITrace.Tipo.Error);
                    return opcional;
                }
            }
            catch
            {
                return opcional;
            }
        }

        /// <summary>
        /// Filtra un DataView por una igualdad
        /// </summary>
        /// <param name="dv">DataView a filtrar</param>
        /// <param name="columna">El nombre de la columna a filtrar</param>
        /// <param name="valor">El valor por el cual se va a filtrar</param>
        /// <returns>El DataView filtrado</returns>
        public static DataView FiltrarDV(DataView dv, string columna, string valor, ref bool filtrado)
        {
            EnumerableRowCollection<DataRow> dFiltrada = from c in dv.Table.AsEnumerable()
                                                         select c;

            if (valor != "")
            {
                dFiltrada = from c in dFiltrada
                            where c[columna].ToString() == valor
                            select c;

                if (dFiltrada.Count() > 0)
                {
                    DataTable dtFiltro = (DataTable)dFiltrada.CopyToDataTable();

                    filtrado = true;
                    return dtFiltro.DefaultView;
                }
                else
                {
                    filtrado = false;
                    return dv;
                }
            }
            else
            {
                return dv;
            }
        }

        /// <summary>
        /// Tranforma la entrada a sha256
        /// </summary>
        /// <param name="Valor"></param>
        /// <returns></returns>
        public static string GeneraSHA256(string Valor)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(Valor);
                SHA256Managed SHAstring = new SHA256Managed();
                byte[] Sha = SHAstring.ComputeHash(bytes);
                string hashString = string.Empty;
                foreach (byte x in Sha)
                {
                    hashString += String.Format("{0:x2}", x);
                }
                return hashString;
            }
            catch (Exception ex)
            {
                throw new Exception("A ocurrido un error en el metodo clsHerramientas.GeneraSHA, error:", ex);
            }

        }
        #endregion


        #region Correo

        /// <summary>
        /// Envia un correo con la clase de .net
        /// </summary>
        /// <param name="pPara">Para quien va, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pCC">Con copia a, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pAsunto">El asunto del mensaje</param>
        /// <param name="pMensaje">El cuerpo del mensaje</param>
        /// <param name="pAdjunto">Archivo adjuntos</param>
        /// <returns>Verdadero si se envio el correo de loc ontrario falso</returns>
        public static bool EnviarMail(string pPara, string pCC, string pAsunto, string pMensaje, List<System.Net.Mail.Attachment> pAdjunto)
        {
            try
            {
                string ip = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, (TraerConfiguracion("smtpServer")));
                string port = TraerConfiguracion("smtpPort");
                string de = TraerConfiguracion("CorreoFrom");
                string Nombrede = TraerConfiguracion("NombreFrom");
                string autenticacion = TraerConfiguracion("autenticacion");
                string disclaimer = TraerConfiguracion("disclaimer");

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "ip:" + ip + " port:" + port + " de:" + de + " autenticacion:" + autenticacion, CDITrace.Tipo.Log);

                System.Net.Mail.MailAddress add = new System.Net.Mail.MailAddress(de, Nombrede);

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = add;

                string[] sPara = SepararARegistro(pPara, 44);

                foreach (string para in sPara)
                {
                    mail.To.Add(para);
                }

                string[] sCopia = SepararARegistro(pCC, 44);

                foreach (string Copy in sCopia)
                {
                    mail.CC.Add(Copy);
                }

                mail.Subject = pAsunto;
                mail.IsBodyHtml = true;
                pMensaje += "<br />" + disclaimer;
                mail.Body = pMensaje;
                mail.BodyEncoding = Encoding.UTF8;

                if (pAdjunto != null)
                {
                    foreach (System.Net.Mail.Attachment a in pAdjunto)
                    {
                        mail.Attachments.Add(a);
                    }
                }

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ip, int.Parse(port));

                if (autenticacion == "1")
                {
                    string user = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("UserCorreo"));
                    string pass = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("PasswordCorreo"));
                    smtp.Credentials = new System.Net.NetworkCredential(user, pass);
                }

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Listo a enviar pPara:" + pPara + " pCC:" + pCC + " pAsunto:" + pAsunto + " pMensaje:" + pMensaje, CDITrace.Tipo.Log);
                smtp.Send(mail);
                mail.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), " Error en el envio de correos, METODO SendMail ", ex);
                return false;
            }
        }

        /// <summary>
        /// Envia un correo con la clase de .net
        /// </summary>
        /// <param name="pPara">Para quien va, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pCC">Con copia a, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pAsunto">El asunto del mensaje</param>
        /// <param name="pMensaje">El cuerpo del mensaje</param>
        /// <param name="pAdjunto">Archivo adjuntos</param>
        public static bool EnviarMail(string pPara, string pCC, string pAsunto, string pMensaje, List<System.Net.Mail.Attachment> pAdjunto, bool Ssl)
        {
            try
            {
                string ip = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, (TraerConfiguracion("smtpServer")));
                string port = TraerConfiguracion("smtpPort");
                string de = TraerConfiguracion("CorreoFrom");
                string Nombrede = TraerConfiguracion("NombreFrom");
                string autenticacion = TraerConfiguracion("autenticacion");
                string disclaimer = TraerConfiguracion("disclaimer");

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "ip:" + ip + " port:" + port + " de:" + de + " autenticacion:" + autenticacion, CDITrace.Tipo.Log);

                System.Net.Mail.MailAddress add = new System.Net.Mail.MailAddress(de, Nombrede);

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = add;

                string[] sPara = SepararARegistro(pPara, 44);

                foreach (string para in sPara)
                {
                    mail.To.Add(para);
                }

                string[] sCopia = SepararARegistro(pCC, 44);

                foreach (string Copy in sCopia)
                {
                    mail.CC.Add(Copy);
                }

                mail.Subject = pAsunto;
                mail.IsBodyHtml = true;
                pMensaje += "<br />" + disclaimer;
                mail.Body = pMensaje;
                mail.BodyEncoding = Encoding.UTF8;

                if (pAdjunto != null)
                {
                    foreach (System.Net.Mail.Attachment a in pAdjunto)
                    {
                        mail.Attachments.Add(a);
                    }
                }

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ip, int.Parse(port));

                if (autenticacion == "1")
                {
                    string user = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("UserCorreo"));
                    string pass = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("PasswordCorreo"));
                    smtp.EnableSsl = Ssl;
                    smtp.UseDefaultCredentials = false;

                    smtp.Credentials = new System.Net.NetworkCredential(user, pass);
                }

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Listo a enviar pPara:" + pPara + " pCC:" + pCC + " pAsunto:" + pAsunto + " pMensaje:" + pMensaje, CDITrace.Tipo.Log);
                smtp.Send(mail);
                mail.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), " Error en el envio de correos, METODO SendMail. ssl ", ex);
                return false;
            }
        }

        /// <summary>
        /// Envia un correo con la clase de .net
        /// </summary>
        /// <param name="pPara">Para quien va, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pCC">Con copia a, pueden llevar varios destinatarios separados por coma</param>
        /// <param name="pAsunto">El asunto del mensaje</param>
        /// <param name="pMensaje">El cuerpo del mensaje</param>
        /// <param name="pAdjunto">Archivo adjuntos</param>
        public static void EnviarMailPlantilla(string pPara, string pCC, string pAsunto, string pMensaje, List<System.Net.Mail.Attachment> pAdjunto, Page page)
        {
            try
            {
                string ip = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, (TraerConfiguracion("smtpServer")));
                string port = TraerConfiguracion("smtpPort");
                string de = TraerConfiguracion("CorreoFrom");
                string Nombrede = TraerConfiguracion("NombreFrom");
                string autenticacion = TraerConfiguracion("autenticacion");
                string disclaimer = TraerConfiguracion("disclaimer");

                System.Net.Mail.MailAddress add = new System.Net.Mail.MailAddress(de, Nombrede);

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = add;

                string[] sPara = SepararARegistro(pPara, 44);

                foreach (string para in sPara)
                {
                    mail.To.Add(para);
                }

                string[] sCopia = SepararARegistro(pCC, 44);

                foreach (string Copy in sCopia)
                {
                    mail.CC.Add(Copy);
                }

                string urlTemplate = page.Server.MapPath("../Media/HTML/PlantillaAvisos.html");
                StringBuilder Template = new StringBuilder();
                Template.Append(GetHTMLFromAddress(urlTemplate));
                Template.Replace("@Mensaje", pMensaje);
                Template.Replace("@Disclaimer", disclaimer);

                string text = pMensaje + disclaimer;

                AlternateView plainView = AlternateView.CreateAlternateViewFromString(text, Encoding.UTF8, MediaTypeNames.Text.Plain);

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Template.ToString(), null, MediaTypeNames.Text.Html);

                string imagePath = page.Server.MapPath("../Media/img/AvisosBanner.png");
                LinkedResource logo = new LinkedResource(imagePath);
                logo.ContentId = "Banner";
                htmlView.LinkedResources.Add(logo);

                string imagePath2 = page.Server.MapPath("../Media/img/AvisoFirma.png");
                LinkedResource logo2 = new LinkedResource(imagePath2);
                logo2.ContentId = "Firma";
                htmlView.LinkedResources.Add(logo2);

                string imagePath3 = page.Server.MapPath("../Media/img/AvisoFooter.png");
                LinkedResource logo3 = new LinkedResource(imagePath3);
                logo3.ContentId = "Footer";
                htmlView.LinkedResources.Add(logo3);

                mail.AlternateViews.Add(plainView);
                mail.AlternateViews.Add(htmlView);

                mail.Subject = pAsunto;
                mail.IsBodyHtml = true;
                //mail.Body = Template.ToString();
                mail.BodyEncoding = Encoding.UTF8;

                if (pAdjunto != null)
                {
                    foreach (System.Net.Mail.Attachment a in pAdjunto)
                    {
                        mail.Attachments.Add(a);
                    }
                }

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(ip, int.Parse(port));

                if (autenticacion == "1")
                {
                    string user = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("UserCorreo"));
                    string pass = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, TraerConfiguracion("PasswordCorreo"));
                    smtp.Credentials = new System.Net.NetworkCredential(user, pass);
                }

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "pPara:" + pPara + " pCC:" + pCC + " pAsunto:" + pAsunto + " pMensaje:" + pMensaje, CDITrace.Tipo.Log);
                smtp.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(" Error en el envio de correos, METODO SendMail ", ex);
            }
        }

        /// <summary>
        /// Trae el html de una url
        /// </summary>
        /// <param name="Address">La url a traer</param>
        /// <returns>El html</returns>
        private static string GetHTMLFromAddress(string Address)
        {
            System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();
            System.Net.WebClient netWeb = new System.Net.WebClient();
            string lsWeb;
            Byte[] laWeb;

            try
            {
                laWeb = netWeb.DownloadData(Address);
                lsWeb = ASCII.GetString(laWeb);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lsWeb;
        }

        #endregion

        #region Eliminar Caracteres especiales

        /// <summary>
        /// Elimina caracteres especiales, reemplaza ñ por n y ç opr c
        /// </summary>
        /// <param name="cadena">cadena a convertir</param>
        /// <returns></returns>
        public static string EliminaCaracteresEspeciales(string cadena)
        {
            Regex reg;

            reg = new Regex("[àáâãäå]");
            cadena = reg.Replace(cadena, "a");

            reg = new Regex("[ÀÁÂÃÄÅ]");
            cadena = reg.Replace(cadena, "A");

            reg = new Regex("[èéêë]");
            cadena = reg.Replace(cadena, "e");

            reg = new Regex("[ÈÉÊË]");
            cadena = reg.Replace(cadena, "E");

            reg = new Regex("[ìíîï]");
            cadena = reg.Replace(cadena, "i");

            reg = new Regex("[ÌÍÎÏ]");
            cadena = reg.Replace(cadena, "I");

            reg = new Regex("[òóôõö]");
            cadena = reg.Replace(cadena, "o");

            reg = new Regex("[ÒÓÔÕÖ]");
            cadena = reg.Replace(cadena, "O");

            reg = new Regex("[ùúûü]");
            cadena = reg.Replace(cadena, "u");

            reg = new Regex("[ÙÚÛÜ]");
            cadena = reg.Replace(cadena, "U");

            reg = new Regex("[ñ]");
            cadena = reg.Replace(cadena, "n");

            reg = new Regex("[Ñ]");
            cadena = reg.Replace(cadena, "N");

            reg = new Regex("[ç]");
            cadena = reg.Replace(cadena, "c");

            reg = new Regex("[Ç]");
            cadena = reg.Replace(cadena, "C");

            reg = new Regex("[^a-zA-Z0-9]");
            cadena = reg.Replace(cadena, " ");

            return cadena;
        }
        #endregion

        #region Ayudas WEB
        /// <summary>
        /// Retorna el valor de un campo del formulario enviados por post
        /// </summary>
        /// <param name="request">La peticion del servidor Request</param>
        /// <param name="campo">El campo que se desea recuperar</param>
        /// <returns>El valor del campo recuperado o null si no existe</returns>
        public static string ValorForm(HttpRequest request, string campo)
        {
            if (request.Form[campo] != null)
            {
                string valor = request.Form[campo];

                return valor;
            }
            else
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "No se puede recuperar el valor del campo [" + campo + "] pagina[" + request.FilePath + "]", CDITrace.Tipo.Log);
                return null;
            }
        }

        /// <summary>
        /// Retorna el valor de un campo del formulario enviados por querystring
        /// </summary>
        /// <param name="request">La peticion del servidor Request</param>
        /// <param name="campo">El campo que se desea recuperar</param>
        /// <returns>El valor del campo recuperado o null si no existe</returns>
        public static string ValorQuery(HttpRequest request, string campo)
        {
            if (request.QueryString[campo] != null)
            {
                string valor = request.QueryString[campo];

                return valor;
            }
            else
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "No se puede recuperar el valor del querystring [" + campo + "] pagina[" + request.FilePath + "]", CDITrace.Tipo.Log);
                return null;
            }
        }
        #endregion

        #region Utilidades

        public static Boolean ValidarFechaDesdeHasta(String fechaDesde, String fechaHasta)
        {
            Boolean dato = false;
            try
            {
                var fDesde = Convert.ToDateTime(fechaDesde);
                var fHasta = Convert.ToDateTime(fechaDesde);
                if (Convert.ToDateTime(fechaDesde) <= Convert.ToDateTime(fechaHasta))
                    dato = true;
            }
            catch
            {
                //Mostrar mensaje de error
            }
            return dato;
        }

        /// <summary>
        /// Escribe los valores por fila del resultado de una consulta
        /// </summary>
        /// <param name="dt">La datatable a recorrer</param>
        public static void LogValorConsultaSQL(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "LogValorConsultaSQL NombreTabla: " + dt.TableName + " Filas: " + dt.Rows.Count, CDITrace.Tipo.Log);
                    int posicion = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Fila Numero: " + posicion, CDITrace.Tipo.Log);
                        foreach (DataColumn dc in dt.Columns)
                        {
                            string Nombre = dc.ColumnName;

                            string Valor = dr[Nombre].ToString() ?? "";

                            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Columna [" + Nombre + "] Valor: " + Valor, CDITrace.Tipo.Log);
                        }

                        posicion++;
                    }
                }
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "LogValorConsultaSQL Error: ", ex);
            }
        }
        #endregion

    }
}