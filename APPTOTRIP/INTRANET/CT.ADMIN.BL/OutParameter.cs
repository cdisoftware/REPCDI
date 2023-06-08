using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CT.ADMIN.BL
{
    public class OutParameter
    {
        public string nombre;
        public object valor;
        public SqlDbType tipoSqlServer;
        public OracleType tipoOra;
        public int tamano;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nombre">Nombre del parámetro</param>
        /// <param name="Tipo">Tipo de dato</param>
        /// <param name="Tamano">Opcional, determina el tamaño máximo para las cadenas</param>
        public OutParameter(string Nombre, SqlDbType? TipoSqlServer, OracleType? TipoOra, int Tamano)
        {
            nombre = Nombre;
            tamano = Tamano;
            if (TipoSqlServer != null)
            {
                tipoSqlServer = (SqlDbType)TipoSqlServer;
            }
            else
            {
                if (TipoOra != null)
                {
                    tipoOra = (OracleType)TipoOra;
                }
            }
        }
    }
}
