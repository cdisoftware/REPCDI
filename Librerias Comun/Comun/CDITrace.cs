using System;
using System.Data;
using System.Data.SqlClient;

namespace CDI.Comun
{
    /// <summary>
    /// Escribe en un archivo de texto configurado en la ruta LogPath del archivo de configuracion, si la llave LogRealizar = 1 o siempre si se trata de un error.
    /// </summary>
    public class CDITrace
    {
        #region Logs
        /// <summary>
        /// El tipo de log que escribiremos
        /// </summary>
        public enum Tipo
        {
            /// <summary>
            /// Cuando sucede un error
            /// </summary>
            Error,
            /// <summary>
            /// Cuando se quiere guardar el proceso
            /// </summary>
            Log
        }

        /// <summary>
        /// Metodo que escribe un txt con un mensaje
        /// </summary>
        /// <param name="Mensaje">Mensaje a escribir</param>
        public static void EscribirLog(string pMensaje, Exception pEx)
        {
            try
            {
                string TargetSite = pEx.TargetSite.Name ?? "";
                string Mensaje = pEx.Message ?? "";
                string Fuente = pEx.Source ?? "";

                string sExcep = "TargetSite " + TargetSite + ", Mensaje: " + Mensaje + ", Fuente: " + Fuente;

                if (pEx.InnerException != null)
                {
                    string TargetSiteInt = pEx.InnerException.TargetSite.Name ?? "";
                    string MensajeInt = pEx.InnerException.Message ?? "";
                    string FuenteInt = pEx.InnerException.Source ?? "";

                    sExcep += ", Metodo Interno: " + TargetSiteInt + ", Mensaje Interno: " + MensajeInt + ", Fuente interna: " + FuenteInt;
                }

                EscribirLog(pMensaje + " " + sExcep ?? "", Tipo.Error);
            }
            catch (Exception e)
            {
                EscribirLog("Ocurrio un error en la escritura de log. " + e.Message + " " + pMensaje + pEx.Message ?? "", Tipo.Error);
            }
        }

        /// <summary>
        /// Metodo que escribe un txt con un mensaje
        /// </summary>
        /// <param name="Mensaje">Mensaje a escribir</param>
        public static void EscribirLog(string pMensaje, Exception pEx, string NombreApp)
        {
            try
            {
                string TargetSite = pEx.TargetSite.Name ?? "";
                string Mensaje = pEx.Message ?? "";
                string Fuente = pEx.Source ?? "";

                string sExcep = "TargetSite " + TargetSite + ", Mensaje: " + Mensaje + ", Fuente: " + Fuente;

                if (pEx.InnerException != null)
                {
                    string TargetSiteInt = pEx.InnerException.TargetSite.Name ?? "";
                    string MensajeInt = pEx.InnerException.Message ?? "";
                    string FuenteInt = pEx.InnerException.Source ?? "";

                    sExcep += ", Metodo Interno: " + TargetSiteInt + ", Mensaje Interno: " + MensajeInt + ", Fuente interna: " + FuenteInt;
                }

                EscribirLog(pMensaje + " " + sExcep ?? "", Tipo.Error, NombreApp);
            }
            catch (Exception e)
            {
                EscribirLog("Ocurrio un error en la escritura de log. " + e.Message + " " + pMensaje + pEx.Message ?? "", Tipo.Error);
            }
        }

        /// <summary>
        /// Metodo que escribe un txt con un mensaje
        /// </summary>
        /// <param name="Mensaje">Mensaje a escribir</param>
        public static void EscribirLog(string pMensaje, Tipo pTipo)
        {
            int EscribeLog = 0;

            if (NombreLog == null || NombreLog == "")
            {
                NombreLog = Herramienta.TraerConfiguracion("NombLog");
            }

            string sNombreArc = "";
            try
            {
                if (pTipo == Tipo.Error)
                {
                    EscribeLog = 1;
                    sNombreArc = "LogErrores_" + NombreLog;
                }
                else if (pTipo == Tipo.Log)
                {
                    EscribeLog = Herramienta.ParseoTexto(Herramienta.TraerConfiguracion("LogRealizar"));
                    sNombreArc = "LogFuncional_" + NombreLog;
                }

                string NombresLog = Herramienta.TraerConfiguracion("LogsActivos");

                if (EscribeLog == 1)
                {
                    string BD = Herramienta.TraerConfiguracion("LogsBD");

                    if (BD == "1")
                    {
                        InsertarLogs(pTipo, pMensaje);
                    }
                    else
                    {
                        EscribirDD(pMensaje, pTipo, sNombreArc);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error ingreso " + pMensaje + ". Ocurrio un error en la escritura de log. ", e);
            }
        }

        /// <summary>
        /// Metodo que escribe un txt con un mensaje
        /// </summary>
        /// <param name="Mensaje">Mensaje a escribir</param>
        public static void EscribirLog(string pMensaje, Tipo pTipo, string NombreApp)
        {
            int EscribeLog = 0;

            if (NombreLog == null || NombreLog == "")
            {
                NombreLog = Herramienta.TraerConfiguracion("NombLog");
            }

            string sNombreArc = "";
            try
            {
                if (pTipo == Tipo.Error)
                {
                    EscribeLog = 1;
                    sNombreArc = "LogErrores_" + NombreLog;
                }
                else if (pTipo == Tipo.Log)
                {
                    EscribeLog = Herramienta.ParseoTexto(Herramienta.TraerConfiguracion("LogRealizar"));
                    sNombreArc = "LogFuncional_" + NombreLog;
                }

                sNombreArc += "_" + NombreApp.ToUpper() + "_";
                string NombresLog = Herramienta.TraerConfiguracion("LogsActivos");

                if (EscribeLog == 1 || NombresLog.IndexOf(NombreApp) != -1)
                {
                    string BD = Herramienta.TraerConfiguracion("LogsBD");

                    if (BD == "1")
                    {
                        InsertarLogs(pTipo, pMensaje);
                    }
                    else
                    {
                        EscribirDD(pMensaje, pTipo, sNombreArc);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error ingreso " + pMensaje + ". Ocurrio un error en la escritura de log. ", e);
            }
        }

        #endregion

        #region Metodos auxiliares
        /// <summary>
        /// Escribe los mensajes en el disco duro
        /// </summary>
        /// <param name="pMensaje"></param>
        /// <param name="pTipo"></param>
        /// <param name="sNombreArc"></param>
        private static void EscribirDD(string pMensaje, Tipo pTipo, string sNombreArc)
        {
            System.IO.StreamWriter w = null;
            try
            {

                string DirLog = Herramienta.traerUbicacionLogs();
                string sUbicacion = DirLog + @"\" + sNombreArc + DateTime.Now.ToString("ddMMyy") + ".txt";
                sUbicacion = sUbicacion.Replace("\0", "");

                if (!System.IO.Directory.Exists(DirLog))
                {
                    // Crea la carpeta
                    System.IO.Directory.CreateDirectory(DirLog);
                }

                w = new System.IO.StreamWriter(sUbicacion, true);
                w.WriteLine("--------------------------" + pTipo.ToString() + "-----------------------------");
                w.WriteLine(DateTime.Now.ToString("HHmm") + ": _" + pMensaje);
                w.Flush();
                w.Close();
            }
            catch (Exception e)
            {
                if (w != null)
                {
                    w.Flush();
                    w.Close();
                }

                throw new Exception("Ocurrio un error en la escritura de log en disco duro. ", e);
            }
        }

        /// <summary>
        /// Inserta los log en la base de datos.
        /// </summary>
        /// <param name="TipoLogs">El tipo del log</param>
        /// <param name="Mensaje">El mensaje que se contiene el log</param>
        private static void InsertarLogs(Tipo TipoLogs, string Mensaje)
        {
            try
            {
                EjecutarSQL("INSERT INTO BPMLOGS (FECHA,MENSAJE,TIPO) VALUES  (GETDATE(),'" + Mensaje + "','" + TipoLogs.ToString() + "')");
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo realizar la insercion en la base de datos, excep ", ex);
            }
        }

        /// <summary>
        /// Valida que exista la tabla de los log o si no la crea
        /// </summary>
        /// <returns>True si todo esta ok</returns>
        private static bool ValidarTabla()
        {
            try
            {
                string sValExit = "SELECT COUNT(*)	FROM SYS.OBJECTS O 	WHERE O.TYPE = 'U' AND O.NAME = 'BPMLOGS'";

                DataSet ds = EjecutarSQL(sValExit);

                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    string script = "CREATE TABLE BPMLogs(Id bigint IDENTITY(1,1) NOT NULL,	Fecha datetime NOT NULL, Mensaje nvarchar(max) NOT NULL, Tipo nvarchar(20) NOT NULL, CONSTRAINT PK_BPMLogs PRIMARY KEY CLUSTERED ( Id ASC ))";

                    EjecutarSQL(script);

                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo realizar la validacionTabla en la base de datos, excep ", ex);
            }
        }

        private static DataSet EjecutarSQL(string Sql)
        {
            try
            {
                string strConneccion = Herramienta.traerConectionStringMs();

                SqlConnection connection = new SqlConnection(strConneccion);
                SqlCommand comando = new SqlCommand();
                comando.CommandTimeout = 1000;
                SqlDataAdapter Adaptador = new SqlDataAdapter();
                DataSet dsData = new DataSet();
                comando.CommandText = Sql;
                comando.CommandType = CommandType.Text;
                comando.Connection = connection;
                Adaptador.SelectCommand = comando;
                Adaptador.Fill(dsData, "logs");

                return dsData;
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo realizar la ejecucion del sql en la base de datos, excep ", ex);
            }
        }

        #endregion

        public static string NombreLog { get; set; }
    }
}