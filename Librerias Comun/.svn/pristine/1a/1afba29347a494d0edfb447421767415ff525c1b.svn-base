using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Data;
using System.Configuration;
using System.IO;

namespace CDI.Common
{
    /// <summary>
    /// Clase para traer datos del active directory
    /// </summary>
    public class ActiveDirectory
    {
        public ActiveDirectory()
        {

        }

        /// <summary>
        /// metodo para validar el usuario
        /// </summary>
        /// <param name="clave">Clave del usuario</param>
        /// <param name="usuario">Nombre del usuario</param>
        /// <returns>un booleano</returns>
        public bool ValidacionUsuario(string clave, string usuario)
        {
            bool aceptaClave = true;
            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ingreso a ValidacionUsuario: Usuario: " + usuario, CDITrace.Tipo.Log);
            string adPath = Herramienta.TraerConfiguracion("PathLDAP"); ;
            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Path: " + adPath, CDITrace.Tipo.Log);
            try
            {
                //usuario = TraerConfiguracion("UsuarioLDAP", ubicacion);
                //clave = TraerConfiguracion("ClaveLDAP", ubicacion);
                string domain = Herramienta.TraerConfiguracion("DominioLDAP");
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Dominio: " + domain, CDITrace.Tipo.Log);
                string domainAndusuario = domain + @"\" + usuario;
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Dominio y Usuario: " + domainAndusuario, CDITrace.Tipo.Log);

                DirectoryEntry entry = new DirectoryEntry(adPath, domainAndusuario, clave);
                try
                {
                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Directorio Activo: NativeObject", CDITrace.Tipo.Log);
                    // Bind to the native AdsObject to force authentication.
                    object obj = entry.NativeObject;
                    return aceptaClave;
                }
                catch (Exception e)
                {
                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en ValidacionUsuario contra el directorio activo. " + e.Message, CDITrace.Tipo.Log);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en ValidacionUsuario directorio activo" , ex);
            }
        }

        /// <summary>
        /// metodo para validar el usuario, con autenticacion segura
        /// </summary>
        /// <param name="clave">Clave del usuario ldap</param>
        /// <param name="usuario">Nombre del usuario ldap</param>
        /// <param name="UsuarioBusqueda">Usuario que se va a buscar puede ser el mismo que autentica</param>
        /// <returns>un booleano</returns>
        public bool ValidacionUsuario(string clave, string usuario, string UsuarioBusqueda)
        {
            string ldap = Herramienta.TraerConfiguracion("DominioLDAP"); ;
            string strSearchAD = "";

            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ingreso a ValidacionUsuario: Usuario: " + usuario + " UsuarioBusqueda: " + UsuarioBusqueda, CDITrace.Tipo.Log);

            strSearchAD += "(sAMAccountName=" + UsuarioBusqueda + ")";

            DirectoryEntry adEntry = new DirectoryEntry(ldap, usuario, clave, AuthenticationTypes.Secure);

            DirectorySearcher adSearch = new DirectorySearcher(adEntry);

            adSearch.Filter = "(&(objectClass=user)" + strSearchAD + ")";
            SearchResultCollection objResultados;

            try
            {
                objResultados = adSearch.FindAll();
                return true;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en ValidacionUsuario 2 contra el directorio activo. " + e.Message, CDITrace.Tipo.Log);

                return false;
            }
        }

        #region Definir Variables
        private SearchResultCollection results = null;
        private DataTable dt = new DataTable();
        private string adPath = "LDAP://cdi/DC=cdi,DC=com,DC=co";
        private char[] Bus = { '@' };
        private string[] S_usu;
        #endregion

        /// <summary>
        /// metodo que devuelve los valores del usuario del active directory
        /// </summary>
        /// <param name="Nombre">Nombre del usuario</param>
        /// <returns>Una tabla con la informacion del usuario</returns>
        public DataTable Buscar_Nombre(string Nombre)
        {
            string usuario = "";
            string clave = "";

            usuario = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("UsuarioLDAP"));
            clave = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("ClaveLDAP"));

            dt.Columns.Add("Nombre");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Apellidos");
            dt.Columns.Add("Nombres");
            dt.Columns.Add("Mail");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Oficina");

            string domain = Herramienta.TraerConfiguracion("DominioLDAP");
            string domainAndusuario = domain + @"\" + usuario;
            DirectoryEntry entry = new DirectoryEntry(adPath, usuario/*domainAndUsername*/, clave);

            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = "(&(objectClass=user)(anr=" + Nombre + "*))";
            try
            {
                results = mySearcher.FindAll();
                foreach (SearchResult searchResult in results)
                {
                    DataRow dr = dt.NewRow();
                    try
                    {
                        dr["Nombre"] = searchResult.Properties["displayName"][0].ToString();
                        dr["Usuario"] = searchResult.Properties["userprincipalname"][0].ToString();
                        dr["Apellidos"] = searchResult.Properties["sn"][0].ToString();
                        dr["Nombres"] = searchResult.Properties["givenname"][0].ToString();
                        dr["Descripcion"] = "";// searchResult.Properties["description"][0].ToString();
                        dr["Oficina"] = searchResult.Properties["physicaldeliveryofficename"][0].ToString();
                        dr["Mail"] = searchResult.Properties["mail"][0].ToString();
                    }
                    catch
                    {
                        if (dr["Nombre"] == null)
                            dr["Nombre"] = "No tiene nombre de dominio.";
                        if (dr["Usuario"] == null)
                            dr["Usuario"] = "NA";
                        if (dr["Apellidos"] == null)
                            dr["Apellidos"] = "NA";
                        if (dr["Nombres"] == null)
                            dr["Nombres"] = "NA";
                        if (dr["Mail"] == null)
                            dr["Mail"] = "NA";
                        if (dr["Descripcion"] == null)
                            dr["Descripcion"] = "NA";
                        if (dr["Oficina"] == null)
                            dr["Oficina"] = "NA";
                    }

                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un inconveniente en el metodo Buscar_Nombre del directorio activo. err " , ex);
            }

        }

        /// <summary>
        /// extrae un archivo
        /// </summary>
        /// <param name="Usu">Nombre del usuario</param>
        /// <returns>retorna el usuario</returns>
        private string Extraer_Usuario(string Usu)
        {
            S_usu = Usu.Split(Bus);
            return S_usu[0];
        }
    }
}
