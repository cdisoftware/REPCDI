using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace CT.ADMIN.BL
{
    public class InParameter
    {
        public string nombre;
        public object valor;
        public SqlDbType tipoSqlServer;
        public OracleType tipoOra;
        public InParameter(string Nombre, object Valor, SqlDbType? TipoSqlServer, OracleType? TipoOra)
        {
            nombre = Nombre;
            valor = Valor;
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
