using System.Web.Services.Protocols;

namespace CDI.Comun
{
    /// <summary>
    /// Clase que se encarga de contener las credenciales de autenticacion: Usuario y Clave
    /// </summary>
    public class Autenticacion : SoapHeader
    {
        private string sUserPass;
        private string sUserID;

        /// <summary>
        /// Lee o escribe la clave del usuario
        /// </summary>
        public string UsuarioClave
        {
            get
            {
                return sUserPass;
            }
            set
            {
                sUserPass = value;
            }
        }

        /// <summary>
        /// Lee o escribe el ID del usuario
        /// </summary>
        public string UsuarioID
        {
            get
            {
                return sUserID;
            }
            set
            {
                sUserID = value;
            }
        }

    }//end class
}