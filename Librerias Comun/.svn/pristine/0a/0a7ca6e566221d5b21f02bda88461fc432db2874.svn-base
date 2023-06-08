using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;

namespace CDI.Common
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
        public static void EscribirLog(MethodBase Nombre, string pMensaje, Exception pEx)
        {
            try
            {
                string sExcep = CrearMensajeError(pEx);

                EscribirLog(Nombre, pMensaje + " " + sExcep ?? "", Tipo.Error);
            }
            catch (Exception e)
            {
                EscribirLog(Nombre, "Ocurrio un error en la escritura de log. " + e.Message + " " + pMensaje + pEx.Message ?? "", Tipo.Error);
            }
        }

        private static string CrearMensajeError(Exception pEx)
        {
            Exception Sub = pEx;
            int cnt = 0;
            StringBuilder Error = new StringBuilder();
            Error.AppendLine("");
            while (Sub != null)
            {
                string TargetSiteInt = Sub.TargetSite?.Name ?? "";
                string MensajeInt = Sub.Message ?? "";
                string FuenteInt = Sub.Source ?? "";

                Error.AppendLine("Metodo Interno: TargetSite " + cnt + ": " + TargetSiteInt + ", Mensaje Interno: " + cnt + ": " + MensajeInt + ", Fuente interna: " + cnt + ": " + FuenteInt);

                Sub = Sub.InnerException;

                cnt++;
            }

            return Error.ToString();
        }


        /// <summary>
        /// Metodo que escribe un txt con un mensaje
        /// </summary>
        /// <param name="Mensaje">Mensaje a escribir</param>
        public static void EscribirLog(MethodBase Nombre, string pMensaje, Tipo pTipo)
        {
            try
            {
                int EscribeLog = 0;

                if (pTipo == Tipo.Error)
                {
                    EscribeLog = 1;
                }
                else if (pTipo == Tipo.Log)
                {
                    EscribeLog = Herramienta.ParseoTexto(Herramienta.TraerConfiguracion("LogRealizar"));
                }

                if (EscribeLog == 1)
                {
                    string BD = Herramienta.TraerConfiguracion("LogsBD");

                    if (BD == "1")
                    {
                        InsertarLogs(pTipo, pMensaje);
                    }
                    else
                    {
                        EscribirDD(Nombre, pMensaje, pTipo);
                    }
                }
            }
            catch (Exception e)
            {
                EscribirDD("ErroresLogs" + DateTime.Now.ToString("ddHH"), "Error ingreso " + pMensaje + ". Ocurrio un error en la escritura de log. " + e, Tipo.Log);
            }
        }

        ///// <summary>
        ///// Metodo que escribe un txt con un mensaje
        ///// </summary>
        ///// <param name="Mensaje">Mensaje a escribir</param>
        //public static void EscribirLog(string pMensaje, Tipo pTipo, string NombreApp)
        //{
        //    int EscribeLog = 0;

        //    if (NombreLog == null || NombreLog == "")
        //    {
        //        NombreLog = Herramienta.TraerConfiguracion("NombLog");
        //    }

        //    string sNombreArc = "";
        //    try
        //    {
        //        if (pTipo == Tipo.Error)
        //        {
        //            EscribeLog = 1;
        //            sNombreArc = NombreLog;
        //        }
        //        else if (pTipo == Tipo.Log)
        //        {
        //            EscribeLog = Herramienta.ParseoTexto(Herramienta.TraerConfiguracion("LogRealizar"));
        //            sNombreArc = NombreLog;
        //        }

        //        sNombreArc += "_" + NombreApp.ToUpper() + "_";
        //        string NombresLog = Herramienta.TraerConfiguracion("LogsActivos");

        //        if (EscribeLog == 1 || NombresLog.IndexOf(NombreApp) != -1)
        //        {
        //            string BD = Herramienta.TraerConfiguracion("LogsBD");

        //            if (BD == "1")
        //            {
        //                InsertarLogs(pTipo, pMensaje);
        //            }
        //            else
        //            {
        //                EscribirDD(pMensaje, pTipo, Nombre);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error ingreso " + pMensaje + ". Ocurrio un error en la escritura de log. ", e);
        //    }
        //}

        #endregion

        #region Metodos auxiliares
        /// <summary>
        /// Escribe los mensajes en el disco duro
        /// </summary>
        /// <param name="pMensaje"></param>
        /// <param name="pTipo"></param>
        /// <param name="sNombreArc"></param>
        private static void EscribirDD(MethodBase Nombre, string pMensaje, Tipo pTipo)
        {
            try
            {
                if (string.IsNullOrEmpty(NombreLog))
                {
                    NombreLog = Herramienta.TraerConfiguracion("NombLog");
                }

                string DirLog = Herramienta.traerUbicacionLogs();
                string fecha = DateTime.Now.ToString("ddMMyyyy");

                if (!(Directory.Exists(DirLog)))
                {
                    Directory.CreateDirectory(DirLog);
                }

                if (!(Directory.Exists(DirLog + "\\" + fecha)))
                {
                    Directory.CreateDirectory(DirLog + "\\" + fecha);
                }

                if (pTipo == Tipo.Error)
                {
                    string sUbicacionE = DirLog + "\\" + fecha + @"\" + "Errores.txt";
                    sUbicacionE = sUbicacionE.Replace("\0", "");
                    using (StreamWriter w2 = new StreamWriter(sUbicacionE, true))
                    {
                        w2.WriteLine("-- " + DateTime.Now.ToString("HHmm") + " --- " + pTipo.ToString() + " --- Metodo: " + Nombre.Name + " --- Clase: " + Nombre.ReflectedType.FullName + " ----");
                        w2.WriteLine(pMensaje);
                        w2.Flush();
                        w2.Close();
                    }
                }

                string NombresLog = Herramienta.TraerConfiguracion("LogsActivos");
                string sUbicacion = DirLog + "\\" + fecha + @"\" + NombreLog;

                if (NombresLog.IndexOf(Nombre.ReflectedType.Name) != -1)
                {
                    sUbicacion += "_" + Nombre.ReflectedType.Name + ".txt";
                }
                else
                {
                    sUbicacion += "_LOGS.txt";
                }

                sUbicacion = sUbicacion.Replace("\0", "");
                sUbicacion = sUbicacion.Replace("+", "");
                using (StreamWriter w = new StreamWriter(sUbicacion, true))
                {
                    w.WriteLine("-- " + DateTime.Now.ToString("HHmm") + " ---- " + pTipo.ToString() + " ----- Metodo: " + Nombre.Name + " ----- Clase: " + Nombre.ReflectedType.FullName + " ------");
                    w.WriteLine(pMensaje);
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error en la escritura de log [" + pMensaje +"] en disco duro. ", e);
            }
        }

        /// <summary>
        /// Escribe los mensajes en el disco duro
        /// </summary>
        /// <param name="pMensaje"></param>
        /// <param name="pTipo"></param>
        /// <param name="sNombreArc"></param>
        private static void EscribirDD(string Nombre, string pMensaje, Tipo pTipo)
        {
            try
            {
                if (string.IsNullOrEmpty(NombreLog))
                {
                    NombreLog = Herramienta.TraerConfiguracion("NombLog");
                }

                string DirLog = Herramienta.traerUbicacionLogs();
                string fecha = DateTime.Now.ToString("ddMMyyyy");

                if (!(Directory.Exists(DirLog)))
                {
                    Directory.CreateDirectory(DirLog);
                }

                if (!(Directory.Exists(DirLog + "\\" + fecha)))
                {
                    Directory.CreateDirectory(DirLog + "\\" + fecha);
                }

                if (pTipo == Tipo.Error)
                {
                    string sUbicacionE = DirLog + "\\" + fecha + @"\" + "Errores.txt";
                    sUbicacionE = sUbicacionE.Replace("\0", "");
                    using (StreamWriter w2 = new StreamWriter(sUbicacionE, true))
                    {
                        w2.WriteLine("-- " + DateTime.Now.ToString("HHmm") + " --- " + pTipo.ToString() + " ----");
                        w2.WriteLine(pMensaje);
                        w2.Flush();
                        w2.Close();
                    }
                }

                string NombresLog = Herramienta.TraerConfiguracion("LogsActivos");
                string sUbicacion = DirLog + "\\" + fecha + @"\" + NombreLog;

                sUbicacion += Nombre + ".txt";

                sUbicacion = sUbicacion.Replace("\0", "");
                sUbicacion = sUbicacion.Replace("+", "");
                using (StreamWriter w = new StreamWriter(sUbicacion, true))
                {
                    w.WriteLine("-- " + DateTime.Now.ToString("HHmm") + " ---- " + pTipo.ToString() + " ------");
                    w.WriteLine(pMensaje);
                    w.Flush();
                    w.Close();
                }
            }
            catch (Exception e)
            {
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
                string strConneccion = Herramienta.traerConectionStringMs(System.Reflection.MethodBase.GetCurrentMethod(), "");

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