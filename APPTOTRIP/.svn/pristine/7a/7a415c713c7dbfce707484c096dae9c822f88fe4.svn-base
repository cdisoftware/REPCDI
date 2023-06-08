using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data;
using CDI.Comun;

namespace CT.ADMIN.BL
{
    public class clsConexion
    {
        string mstrConnectionStringORACLE;
        string mstrConnectionStringMSSQL;
        string motorBD = "SqlServer";
        List<InParameter> lParametrosEntrada;
        private SqlCommand ComandoSQLMs;
        private OracleCommand ComandoOracle;

        public clsConexion()
        {
            motorBD = Herramienta.TraerConfiguracion("motorBD");

            switch (motorBD)
            {
                case "Oracle":
                    mstrConnectionStringORACLE = Herramienta.traerConectionStringOrcl();
                    ComandoOracle = new OracleCommand
                    {
                        CommandTimeout = 1000
                    };
                    break;
                case "SqlServer":
                    mstrConnectionStringMSSQL = Herramienta.traerConectionStringMs();

                    ComandoSQLMs = new SqlCommand();
                    ComandoSQLMs.CommandTimeout = 5000;
                    break;
            }
        }

        /// <summary>
        /// Tipo de dato de retorno
        /// </summary>
        public enum TipoDato
        {
            Table,
            View,
            DataSet,
            DataReader,
            RecordSet
        }

        /// <summary>
        /// Ejecuta el query, retorna el numero de datos afectados
        /// </summary>
        /// <param name="strSQL">El query a ejecutar</param>
        /// <returns>Numero de datos afectados</returns>
        public int QueryEscalar(string strSQL)
        {
            try
            {
                CDITrace.EscribirLog("Execute QueryEscalar: Query[" + strSQL + "]", CDITrace.Tipo.Log);
                int query = 0;
                switch (motorBD)
                {
                    case "SqlServer":
                        SqlConnection cnConexionSQL = ConectarMS();
                        SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);

                        query = cmComandoSQL.ExecuteNonQuery();
                        cnConexionSQL.Close();
                        cnConexionSQL.Dispose();
                        cmComandoSQL.Dispose();
                        break;
                    case "Oracle":
                        OracleConnection cnConexion = ConectarOrcl();
                        OracleCommand cmComando = new OracleCommand(strSQL, cnConexion);

                        query = cmComando.ExecuteNonQuery();
                        cnConexion.Close();
                        cnConexion.Dispose();
                        cmComando.Dispose();
                        break;
                }

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Query. Error detallado es " + ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta el query y retorna datos en el tipo que se requiera
        /// </summary>
        /// <param name="strSQL">Query a ejecutar</param>
        /// <param name="eTipoDato">Tipo de dato a retornar</param>
        /// <returns>Segun el tipo de dato pedido</returns>
        public object Query(string strSQL, TipoDato eTipoDato)
        {
            try
            {
                CDITrace.EscribirLog("Execute QueryT: Query[" + strSQL + "]", CDITrace.Tipo.Log);
                object query = new object();
                DataSet dtsTemp = new DataSet();
                DataTable dttTemp = new DataTable();
                DataView dtvTemp = new DataView();

                switch (motorBD)
                {
                    case "SqlServer":
                        SqlConnection cnConexionSQL = ConectarMS();
                        SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);
                        SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                        SqlDataReader dtrTempSQL;

                        cmComandoSQL.CommandType = CommandType.Text;
                        dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

                        switch (eTipoDato)
                        {
                            case TipoDato.DataSet:
                                dtaAdaptadorSQL.Fill(dtsTemp, "Temp");
                                query = dtsTemp;
                                break;
                            case TipoDato.Table:
                                dtaAdaptadorSQL.Fill(dttTemp);
                                query = dttTemp;
                                break;
                            case TipoDato.View:
                                dtaAdaptadorSQL.Fill(dttTemp);
                                dttTemp.TableName = "Temp";
                                dtvTemp.Table = dttTemp;
                                query = dtvTemp;
                                break;
                            case TipoDato.RecordSet:
                                dtrTempSQL = cmComandoSQL.ExecuteReader();
                                query = dtrTempSQL;
                                break;
                        }

                        cnConexionSQL.Close();
                        cnConexionSQL.Dispose();
                        cmComandoSQL.Dispose();
                        dtaAdaptadorSQL.Dispose();
                        dtrTempSQL = null;
                        break;
                    case "Oracle":
                        OracleConnection cnConexion = ConectarOrcl();
                        OracleCommand cmComandoORA = new OracleCommand(strSQL, cnConexion);
                        OracleDataAdapter dtaAdaptadorORA = new OracleDataAdapter();
                        OracleDataReader dtrTempORA;

                        cmComandoORA.CommandType = CommandType.Text;
                        dtaAdaptadorORA.SelectCommand = cmComandoORA;

                        switch (eTipoDato)
                        {
                            case TipoDato.DataSet:
                                dtaAdaptadorORA.Fill(dtsTemp, "Temp");
                                query = dtsTemp;
                                break;
                            case TipoDato.Table:
                                dtaAdaptadorORA.Fill(dttTemp);
                                query = dttTemp;
                                break;
                            case TipoDato.View:
                                dtaAdaptadorORA.Fill(dttTemp);
                                dttTemp.TableName = "Temp";
                                dtvTemp.Table = dttTemp;
                                query = dtvTemp;
                                break;
                            case TipoDato.RecordSet:
                                dtrTempORA = cmComandoORA.ExecuteReader();
                                query = dtrTempORA;
                                break;
                        }

                        cnConexion.Close();
                        cnConexion.Dispose();
                        cmComandoORA.Dispose();
                        dtaAdaptadorORA.Dispose();
                        dtrTempORA = null;
                        break;
                }

                dtsTemp.Dispose();
                dttTemp.Dispose();
                dtvTemp.Dispose();

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Query. Error detallado es " + ex.Message);
            }
        }

        /// <summary>
        /// Ejecuta el query y retorna datos en una tabla
        /// </summary>
        /// <param name="strSQL">Query a ejecutar</param>
        /// <returns>Una tabla con los datos</returns>
        public DataTable Query(string strSQL)
        {
            try
            {
                CDITrace.EscribirLog("Execute Query: Query[" + strSQL + "]", CDITrace.Tipo.Log);

                object query = new object();
                DataSet dtsTemp = new DataSet();
                DataTable dttTemp = new DataTable();
                DataView dtvTemp = new DataView();

                switch (motorBD)
                {
                    case "SqlServer":
                        SqlConnection cnConexionSQL = ConectarMS();
                        SqlCommand cmComandoSQL = new SqlCommand(strSQL, cnConexionSQL);
                        SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();

                        cmComandoSQL.CommandType = CommandType.Text;
                        dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

                        dtaAdaptadorSQL.Fill(dttTemp);
                        query = dttTemp;

                        cnConexionSQL.Close();
                        cnConexionSQL.Dispose();
                        cmComandoSQL.Dispose();
                        dtaAdaptadorSQL.Dispose();

                        break;
                    case "Oracle":
                        OracleConnection cnConexion = ConectarOrcl();
                        OracleCommand cmComandoORA = new OracleCommand(strSQL, cnConexion);
                        OracleDataAdapter dtaAdaptadorORA = new OracleDataAdapter();

                        cmComandoORA.CommandType = CommandType.Text;
                        dtaAdaptadorORA.SelectCommand = cmComandoORA;

                        dtaAdaptadorORA.Fill(dttTemp);
                        query = dttTemp;

                        cnConexion.Close();
                        cnConexion.Dispose();
                        cmComandoORA.Dispose();
                        dtaAdaptadorORA.Dispose();
                        break;
                }

                dtsTemp.Dispose();
                dttTemp.Dispose();
                dtvTemp.Dispose();

                return (DataTable)query;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error en el metodo Query. Error detallado es " + ex.Message);
            }
        }

        /// <summary>
        /// Adiciona un parametro al procedimiento almacenado que se va a ejecutar
        /// </summary>
        /// <param name="nombre">nombre del parametro</param>
        /// <param name="valor">Valor que se va a pasar</param>
        public void AdicionarParametrosMS(string nombre, Object valor)
        {
            CDITrace.EscribirLog(nombre + "='" + valor + "'", CDITrace.Tipo.Log);
            if (valor.GetType().Name == "String")
            {
                if (valor.ToString() == "null")
                {
                    valor = DBNull.Value;
                }
            }

            ComandoSQLMs.Parameters.AddWithValue(nombre, valor);
        }

        /// <summary>
        /// Adiciona un parametro al procedimiento almacenado que se va a ejecutar
        /// </summary>
        /// <param name="nombre">nombre del parametro</param>
        /// <param name="valor">Valor que se va a pasar</param>
        public void AdicionarParametrosOutMs(string nombre, Object valor, SqlDbType Tipo)
        {
            CDITrace.EscribirLog(nombre + "='" + valor + "'", CDITrace.Tipo.Log);

            if (valor.GetType().Name == "String")
            {
                if (valor.ToString() == "null")
                {
                    valor = DBNull.Value;
                }
            }

            SqlParameter sqlPm = new SqlParameter(nombre, Tipo);
            sqlPm.Direction = ParameterDirection.Output;
            ComandoSQLMs.Parameters.Add(sqlPm);
        }

        /// <summary>
        /// Adiciona un parametro al procedimiento almacenado que se va a ejecutar
        /// </summary>
        /// <param name="nombre">nombre del parametro</param>
        /// <param name="valor">Valor que se va a pasar</param>
        public void AdicionarParametrosOutOrcl(string nombre, Object valor, SqlDbType Tipo)
        {
            CDITrace.EscribirLog(nombre + "='" + valor + "'", CDITrace.Tipo.Log);

            if (valor.GetType().Name == "String")
            {
                if (valor.ToString() == "null")
                {
                    valor = DBNull.Value;
                }
            }

            SqlParameter sqlPm = new SqlParameter(nombre, Tipo);
            sqlPm.Direction = ParameterDirection.Output;
            ComandoOracle.Parameters.Add(sqlPm);
        }

        /// <summary>
        /// Adiciona un parametro al procedimiento almacenado que se va a ejecutar
        /// </summary>
        /// <param name="nombre">nombre del parametro</param>
        /// <param name="valor">Valor que se va a pasar</param>
        public void AdicionarParametrosOrcl(string nombre, Object valor)
        {
            CDITrace.EscribirLog(nombre + "='" + valor + "'", CDITrace.Tipo.Log);
            if (valor.GetType().Name == "String")
            {
                if (valor.ToString() == "null")
                {
                    valor = DBNull.Value;
                }
            }
            ComandoOracle.Parameters.AddWithValue(nombre, valor);
        }

        /// <summary>
        /// Limpia los parametros
        /// </summary>
        public void limpiarParametrosMs()
        {
            ComandoSQLMs.Parameters.Clear();
        }

        /// <summary>
        /// Limpia los parametros
        /// </summary>
        public void limpiarParametrosOrlc()
        {
            ComandoSQLMs.Parameters.Clear();
        }

        /// <summary>
        /// Abre la conexion de oracle
        /// </summary>
        /// <returns></returns>
        private OracleConnection ConectarOrcl()
        {
            try
            {
                OracleConnection cnConexion = new OracleConnection(mstrConnectionStringORACLE);
                cnConexion.Open();

                return cnConexion;
            }
            catch (Exception ex)
            {
                throw new Exception("ha ocurrido un erro conectadose a la base de datos metodo ConectarOrcl. Error detallado " + ex.Message + " cadena " + mstrConnectionStringORACLE);
            }
        }

        /// <summary>
        /// Abre la conexion con sqlserver
        /// </summary>
        /// <returns></returns>
        private SqlConnection ConectarMS()
        {
            try
            {
                SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                cnConexionSQL.Open();
                return cnConexionSQL;
            }
            catch (Exception ex)
            {
                throw new Exception("ha ocurrido un erro conectadose a la base de datos metodo ConectarMS. Error detallado " + ex.Message + " cadena " + mstrConnectionStringMSSQL);
            }
        }

        /// <summary>
        /// Consuigue los parametros de salidad
        /// </summary>
        /// <param name="parametrosSalida"></param>
        /// <param name="nombreParametro"></param>
        /// <returns></returns>
        public object GetOutParameter(List<OutParameter> parametrosSalida, string nombreParametro)
        {
            OutParameter parametroSalida = parametrosSalida.Find(delegate (OutParameter outParam) { return outParam.nombre == "nombreParametro"; });
            return parametroSalida.valor;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado
        /// </summary>
        /// <param name="nombreEsquema"></param>
        /// <param name="nombrePaquete"></param>
        /// <param name="nombreProcedimiento"></param>
        /// <param name="parametrosEntrada"></param>
        /// <param name="parametrosSalida"></param>
        /// <param name="eTipoDato"></param>
        /// <returns></returns>
        public Object ExecuteProc(string nombreEsquema, string nombrePaquete, string nombreProcedimiento, List<InParameter> parametrosEntrada,
            ref List<OutParameter> parametrosSalida, TipoDato eTipoDato)
        {
            CDITrace.EscribirLog("ExecuteProc: nombreProcedimiento[" + nombreProcedimiento + "]", CDITrace.Tipo.Log);
            EscribirParametros(parametrosEntrada);

            object result = new object();
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    cnConexionSQL.Open();
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    SqlCommand cmComandoSQL = new SqlCommand();
                    cmComandoSQL.Connection = cnConexionSQL;
                    cmComandoSQL.CommandTimeout = 5400;
                    cmComandoSQL.CommandText = nombreProcedimiento;
                    cmComandoSQL.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoSQL.Parameters.Add(param.nombre, param.tipoSqlServer).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        SqlParameter sqlPm = new SqlParameter(param.nombre, param.tipoSqlServer, param.tamano);
                        sqlPm.Direction = ParameterDirection.Output;
                        cmComandoSQL.Parameters.Add(sqlPm);
                    }

                    dtaAdaptadorSQL.SelectCommand = cmComandoSQL;
                    switch (eTipoDato)
                    {
                        case TipoDato.DataReader:
                            SqlDataReader dtrTemp;
                            dtrTemp = cmComandoSQL.ExecuteReader();
                            result = dtrTemp;
                            break;
                        case TipoDato.DataSet:
                            DataSet dtsTemp = new DataSet();
                            dtaAdaptadorSQL.Fill(dtsTemp, "Temp");
                            result = dtsTemp;
                            break;
                        case TipoDato.Table:
                            DataTable dttTemp = new DataTable();
                            dtaAdaptadorSQL.Fill(dttTemp);
                            result = dttTemp;
                            break;
                        case TipoDato.View:
                            DataTable dttTemp2 = new DataTable();
                            dtaAdaptadorSQL.Fill(dttTemp2);
                            DataView dtvTemp = new DataView();
                            dtvTemp.Table = dttTemp2;
                            result = dtvTemp;
                            break;
                    }
                    cnConexionSQL.Close();
                    break;
                case "Oracle":
                    OracleConnection cnConexionOracle = new OracleConnection(mstrConnectionStringORACLE);
                    cnConexionOracle.Open();
                    OracleDataAdapter dtaAdaptadorOracle = new OracleDataAdapter();
                    OracleCommand cmComandoOracle = new OracleCommand();
                    cmComandoOracle.Connection = cnConexionOracle;
                    string textoComando = "";
                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComando += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComando += nombrePaquete + ".";
                    }
                    textoComando += nombreProcedimiento + ".";
                    cmComandoOracle.CommandText = textoComando;
                    cmComandoOracle.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoOracle.Parameters.Add(param.nombre, param.tipoOra).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        OracleParameter opm = new OracleParameter(param.nombre, param.tipoOra, param.tamano);
                        opm.Direction = ParameterDirection.Output;
                        cmComandoOracle.Parameters.Add(opm);
                    }

                    dtaAdaptadorOracle.SelectCommand = cmComandoOracle;
                    switch (eTipoDato)
                    {
                        case TipoDato.DataReader:
                            OracleDataReader dtrTemp;
                            dtrTemp = cmComandoOracle.ExecuteReader();
                            result = dtrTemp;
                            break;
                        case TipoDato.DataSet:
                            DataSet dtsTemp = new DataSet();
                            dtaAdaptadorOracle.Fill(dtsTemp, "Temp");
                            result = dtsTemp;
                            break;
                        case TipoDato.Table:
                            DataTable dttTemp = new DataTable();
                            dtaAdaptadorOracle.Fill(dttTemp);
                            result = dttTemp;
                            break;
                        case TipoDato.View:
                            DataTable dttTemp2 = new DataTable();
                            dtaAdaptadorOracle.Fill(dttTemp2);
                            DataView dtvTemp = new DataView();
                            dtvTemp.Table = dttTemp2;
                            result = dtvTemp;
                            break;
                    }
                    cnConexionOracle.Close();
                    break;
            }
            return result;
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado
        /// </summary>
        /// <param name="nombreEsquema"></param>
        /// <param name="nombrePaquete"></param>
        /// <param name="nombreProcedimiento"></param>
        /// <param name="parametrosEntrada"></param>
        /// <param name="parametrosSalida"></param>
        /// <param name="eTipoDato"></param>
        /// <returns></returns>
        public DataTable ExecuteProc(string nombreEsquema, string nombrePaquete, string nombreProcedimiento)
        {
            CDITrace.EscribirLog("ExecuteProc: nombreProcedimiento[" + nombreProcedimiento + "]", CDITrace.Tipo.Log);

            DataTable result = new DataTable();
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    cnConexionSQL.Open();
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    ComandoSQLMs.Connection = cnConexionSQL;
                    ComandoSQLMs.CommandText = nombreProcedimiento;
                    ComandoSQLMs.CommandType = CommandType.StoredProcedure;

                    dtaAdaptadorSQL.SelectCommand = ComandoSQLMs;
                    dtaAdaptadorSQL.Fill(result);
                    cnConexionSQL.Close();
                    break;
                case "Oracle":
                    OracleConnection cnConexionOracle = new OracleConnection(mstrConnectionStringORACLE);
                    cnConexionOracle.Open();
                    OracleDataAdapter dtaAdaptadorOracle = new OracleDataAdapter();
                    ComandoOracle.Connection = cnConexionOracle;
                    string textoComando = "";

                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComando += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComando += nombrePaquete + ".";
                    }

                    textoComando += nombreProcedimiento + ".";
                    ComandoOracle.CommandText = textoComando;
                    ComandoOracle.CommandType = CommandType.StoredProcedure;

                    dtaAdaptadorOracle.SelectCommand = ComandoOracle;
                    dtaAdaptadorOracle.Fill(result);
                    cnConexionOracle.Close();
                    break;
            }
            return result;
        }


        /// <summary>
        /// Ejecuta un stored procedure
        /// </summary>
        /// <param name="nombreEsquema"></param>
        /// <param name="nombrePaquete"></param>
        /// <param name="nombreProcedimiento"></param>
        /// <param name="parametrosEntrada"></param>
        /// <param name="parametrosSalida"></param>
        /// <returns></returns>
        public Object ExecuteProc(string nombreEsquema, string nombrePaquete, string nombreProcedimiento, List<InParameter> parametrosEntrada, ref List<OutParameter> parametrosSalida)
        {
            CDITrace.EscribirLog("ExecuteProc: nombreProcedimiento[" + nombreProcedimiento + "]", CDITrace.Tipo.Log);
            EscribirParametros(parametrosEntrada);
            DataTable dttTemp = null;
            object result = new object();
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    cnConexionSQL.Open();
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    SqlCommand cmComandoSQL = new SqlCommand();
                    cmComandoSQL.Connection = cnConexionSQL;
                    cmComandoSQL.CommandTimeout = 5400;
                    cmComandoSQL.CommandText = nombreProcedimiento;
                    cmComandoSQL.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoSQL.Parameters.Add(param.nombre, param.tipoSqlServer).Value = param.valor;
                    }

                    foreach (OutParameter param in parametrosSalida)
                    {
                        SqlParameter sqlPm = new SqlParameter(param.nombre, param.tipoSqlServer, param.tamano);
                        sqlPm.Direction = ParameterDirection.Output;
                        cmComandoSQL.Parameters.Add(sqlPm);
                    }

                    dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

                    dttTemp = new DataTable();
                    dtaAdaptadorSQL.Fill(dttTemp);
                    result = dttTemp;

                    cnConexionSQL.Close();
                    break;
                case "Oracle":
                    OracleConnection cnConexionOracle = new OracleConnection(mstrConnectionStringORACLE);
                    cnConexionOracle.Open();
                    OracleDataAdapter dtaAdaptadorOracle = new OracleDataAdapter();
                    OracleCommand cmComandoOracle = new OracleCommand();
                    cmComandoOracle.Connection = cnConexionOracle;
                    string textoComando = "";
                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComando += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComando += nombrePaquete + ".";
                    }
                    textoComando += nombreProcedimiento + ".";
                    cmComandoOracle.CommandText = textoComando;
                    cmComandoOracle.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoOracle.Parameters.Add(param.nombre, param.tipoOra).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        OracleParameter opm = new OracleParameter(param.nombre, param.tipoOra, param.tamano);
                        opm.Direction = ParameterDirection.Output;
                        cmComandoOracle.Parameters.Add(opm);
                    }

                    dtaAdaptadorOracle.SelectCommand = cmComandoOracle;

                    dttTemp = new DataTable();
                    dtaAdaptadorOracle.Fill(dttTemp);
                    result = dttTemp;

                    cnConexionOracle.Close();
                    break;
            }
            return result;
        }

        public DataSet ExecuteProcWS(string nombreEsquema, string nombrePaquete, string nombreProcedimiento, List<InParameter> parametrosEntrada, ref List<OutParameter> parametrosSalida)
        {
            CDITrace.EscribirLog("ExecuteProc: nombreProcedimiento[" + nombreProcedimiento + "]", CDITrace.Tipo.Log);
            EscribirParametros(parametrosEntrada);
            DataSet dttTemp = null;
            object result = new object();
            switch (motorBD)
            {
                case "SqlServer":
                    SqlConnection cnConexionSQL = new SqlConnection(mstrConnectionStringMSSQL);
                    cnConexionSQL.Open();
                    SqlDataAdapter dtaAdaptadorSQL = new SqlDataAdapter();
                    SqlCommand cmComandoSQL = new SqlCommand();
                    cmComandoSQL.Connection = cnConexionSQL;
                    cmComandoSQL.CommandTimeout = 5400;
                    cmComandoSQL.CommandText = nombreProcedimiento;
                    cmComandoSQL.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoSQL.Parameters.Add(param.nombre, param.tipoSqlServer).Value = param.valor;
                    }

                    foreach (OutParameter param in parametrosSalida)
                    {
                        SqlParameter sqlPm = new SqlParameter(param.nombre, param.tipoSqlServer, param.tamano);
                        sqlPm.Direction = ParameterDirection.Output;
                        cmComandoSQL.Parameters.Add(sqlPm);
                    }

                    dtaAdaptadorSQL.SelectCommand = cmComandoSQL;

                    dttTemp = new DataSet();
                    dtaAdaptadorSQL.Fill(dttTemp);
                    result = dttTemp;

                    cnConexionSQL.Close();
                    break;
                case "Oracle":
                    OracleConnection cnConexionOracle = new OracleConnection(mstrConnectionStringORACLE);
                    cnConexionOracle.Open();
                    OracleDataAdapter dtaAdaptadorOracle = new OracleDataAdapter();
                    OracleCommand cmComandoOracle = new OracleCommand();
                    cmComandoOracle.Connection = cnConexionOracle;
                    string textoComando = "";
                    if (!string.IsNullOrEmpty(nombreEsquema))
                    {
                        textoComando += nombreEsquema + ".";
                    }
                    if (!string.IsNullOrEmpty(nombrePaquete))
                    {
                        textoComando += nombrePaquete + ".";
                    }
                    textoComando += nombreProcedimiento + ".";
                    cmComandoOracle.CommandText = textoComando;
                    cmComandoOracle.CommandType = CommandType.StoredProcedure;

                    foreach (InParameter param in parametrosEntrada)
                    {
                        cmComandoOracle.Parameters.Add(param.nombre, param.tipoOra).Value = param.valor;
                    }
                    foreach (OutParameter param in parametrosSalida)
                    {
                        OracleParameter opm = new OracleParameter(param.nombre, param.tipoOra, param.tamano);
                        opm.Direction = ParameterDirection.Output;
                        cmComandoOracle.Parameters.Add(opm);
                    }

                    dtaAdaptadorOracle.SelectCommand = cmComandoOracle;

                    dttTemp = new DataSet();
                    dtaAdaptadorOracle.Fill(dttTemp);
                    result = dttTemp;

                    cnConexionOracle.Close();
                    break;
            }
            return dttTemp;
        }

        /// <summary>
        /// Escribe el parametro en el log
        /// </summary>
        /// <param name="parametrosEntrada">Lista de parametros</param>
        private static void EscribirParametros(List<InParameter> parametrosEntrada)
        {
            foreach (InParameter par in parametrosEntrada)
            {
                CDITrace.EscribirLog("Parametros: Nombre[" + par.nombre + "] Valor[" + par.valor + "]", CDITrace.Tipo.Log);
            }
        }
    }
}
