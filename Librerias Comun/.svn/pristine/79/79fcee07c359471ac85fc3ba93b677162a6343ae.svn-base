using System;
using System.Data;
using System.Data.SqlClient;

namespace CDI.Comun
{
    public class ConexionMS
    {
        #region Constructor
        public ConexionMS(string strconexion)
        {
            nuevaConexion(strconexion);
        }

        public ConexionMS()
        {

        }
        #endregion

        #region Variables

        private SqlConnection connection = new SqlConnection();
        private SqlCommand comando = new SqlCommand();
        private SqlDataAdapter Adaptador = new SqlDataAdapter();
        private DataSet dsData;

        #endregion

        #region Metodos

        /// <summary>
        /// Realiza la conecion a la bd
        /// </summary>
        /// <param name="strConneccion">la cadena de coneccion</param>
        public void nuevaConexion(string strConneccion)
        {
            try
            {
                connection = new SqlConnection(strConneccion);
                comando = new SqlCommand();
                comando.CommandTimeout = 5000;
            }
            catch (Exception ex)
            {
                throw new Exception("Se presentaron problemas al conectar en el metodo nuevaConexion Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Conecta a la base de datos
        /// </summary>
        public void conectar()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Se presentaron problemas al conectar (" + connection.ConnectionString + ") en el metodo conectar Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Desconecta de la base de datos
        /// </summary>
        public void desconectar()
        {
            connection.Close();
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y me debuelve un data set
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <param name="tabla">nombre de la tabla</param>
        /// <returns>DataSet relleno</returns>
        public DataSet ejecutarStoreProcedure(string procedimiento, string tabla)
        {
            //SqlTransaction Transac = null;
            try
            {
                conectar();
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),procedimiento, NCDITrace.Tipo.Log);

                //Transac = connection.BeginTransaction();
                Adaptador = new SqlDataAdapter();
                dsData = new DataSet();
                comando.CommandText = procedimiento;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = connection;
                //comando.Transaction = Transac;
                Adaptador.SelectCommand = comando;
                Adaptador.Fill(dsData, tabla);
                //Transac.Commit();
                desconectar();
                return dsData;
            }
            catch (Exception ex)
            {
                //if (Transac != null)
                //{
                //    Transac.Rollback();
                //}
                desconectar();
                throw new Exception("Se presentaron problemas al ejecutar su consulta en el metodo ejecutarStoreProcedure Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Ejecuta un procedimiento almacenado y me debuelve un data set
        /// </summary>
        /// <param name="procedimiento">Nombre del procedimiento almacenado</param>
        /// <returns>DataSet relleno</returns>
        public DataSet ejecutarStoreProcedure(string procedimiento)
        {
            try
            {
                conectar();
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),"Entro a: " + procedimiento + " " + DateTime.Now.ToString("ddMMyyhhmm"), CDI.Comun.NCDITrace.Tipo.Log);
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),procedimiento, NCDITrace.Tipo.Log);
                SqlTransaction Transac;
                Transac = connection.BeginTransaction();
                Adaptador = new SqlDataAdapter();
                dsData = new DataSet();
                comando.CommandTimeout = 5400;
                comando.CommandText = procedimiento;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = connection;
                comando.Transaction = Transac;
                Adaptador.SelectCommand = comando;
                Adaptador.Fill(dsData, "tbl");
                Transac.Commit();
                desconectar();
                return dsData;

            }
            catch (Exception ex)
            {
                desconectar();
                throw new Exception("Se presentaron problemas al ejecutar su consulta en el metodo ejecutarStoreProcedure Revise los Valores, err " , ex);
            }
        }

        public DataSet ejecutarStoreProcedureAut(string procedimiento)
        {
            try
            {
                conectar();
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),"Entro a: " + procedimiento + DateTime.Now.ToString("ddMMyyhhmm"), CDI.Comun.NCDITrace.Tipo.Error);
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),procedimiento, NCDITrace.Tipo.Log);
                SqlTransaction Transac;
                Transac = connection.BeginTransaction();
                Adaptador = new SqlDataAdapter();
                dsData = new DataSet();
                comando.CommandTimeout = 5400;
                comando.CommandText = procedimiento;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = connection;
                comando.Transaction = Transac;
                Adaptador.SelectCommand = comando;
                Adaptador.Fill(dsData, "tbl");
                Transac.Commit();
                desconectar();
                return dsData;

            }
            catch (Exception ex)
            {
                desconectar();
                throw new Exception("Se presentaron problemas al ejecutar su consulta en el metodo ejecutarStoreProcedure Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Ejecuta un SQL dirrectamente sobre la base de datos
        /// </summary>
        /// <param name="Sql">SQL a ejecutar</param>
        /// <param name="tabla">nombre de la tabla</param>
        /// <returns>DataSet relleno</returns>
        public DataSet EjecutarSql(string Sql, string tabla)
        {
            try
            {
                conectar();
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),Sql, NCDITrace.Tipo.Log);
                SqlTransaction Transac;
                Transac = connection.BeginTransaction();
                Adaptador = new SqlDataAdapter();
                dsData = new DataSet();
                comando.CommandText = Sql;
                comando.CommandType = CommandType.Text;
                comando.Connection = connection;
                comando.Transaction = Transac;
                Adaptador.SelectCommand = comando;
                Adaptador.Fill(dsData, tabla);
                Transac.Commit();
                desconectar();
                return dsData;
            }
            catch (Exception ex)
            {
                throw new Exception("Se presentaron problemas al ejecutar su consulta en el metodo EjecutarSql Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Ejecuta un scalar que sera utilizado para Insertar, Actualizar o Eliminar
        /// </summary>
        /// <param name="procedimiento">nombre del procedimiento almacenado a ejecutar</param>
        public void ejecutarScalar(string procedimiento)
        {
            try
            {
                conectar();
                NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),procedimiento, NCDITrace.Tipo.Log);
                //SqlTransaction Transac;
                //Transac = connection.BeginTransaction();
                comando.CommandText = procedimiento;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Connection = connection;
                //comando.Transaction = Transac;
                comando.ExecuteScalar();
                //Transac.Commit();
                desconectar();
            }
            catch (Exception ex)
            {
                desconectar();
                throw new Exception("Se presentaron problemas al ejecutar su consulta en el metodo ejecutarScalar Revise los Valores, err " , ex);
            }
        }

        /// <summary>
        /// Adiciona un parametro al procedimiento almacenado que se va a ejecutar
        /// </summary>
        /// <param name="nombre">nombre del parametro</param>
        /// <param name="valor">Valor que se va a pasar</param>
        public void AdicionarParametros(string nombre, Object valor)
        {
            NCDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(),nombre + "= [" + valor + "]", NCDITrace.Tipo.Log);

            if (valor == null)
            {
                valor = DBNull.Value;
            }
            else if (valor.GetType().Name == "String")
            {
                if (valor.ToString() == "null")
                {
                    valor = DBNull.Value;
                }
            }

            comando.Parameters.AddWithValue(nombre, valor);
        }

        /// <summary>
        /// Limpia los parametros
        /// </summary>
        public void limpiarParametros()
        {
            comando.Parameters.Clear();
        }

        #endregion
    }
}
