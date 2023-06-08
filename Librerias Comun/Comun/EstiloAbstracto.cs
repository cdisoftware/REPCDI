using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDI.Comun
{
    public abstract class EstiloAbstracto : System.Web.UI.Page
    {
        #region Abstracta

        /// <summary>
        /// Carga todos los datos referenciales en los dropdownlist, 
        /// radiobuttonlist y checkboxlist del form, 
        /// este metodo organiza todo lo que se ejecuta al iniciar la pagina
        /// </summary>
        public abstract void CargaObjetosIniciales();

        /// <summary>
        /// Carga de los Objetos de Negocio
        /// </summary>
        public abstract void CargaObjetosNegocios();

        /// <summary>
        /// Cargar Grilla
        /// </summary>
        public abstract void CargaGrillas();

        /// <summary>
        /// Permite habilitar el contenido de la pagina de acuerdo a cada perfil
        /// </summary>
        public abstract void ValidarPerfil();

        /// <summary>
        /// Permite validar si la session sigue activa.
        /// </summary>
        public abstract void ValidarSession();

        /// <summary>
        /// Inicializa los controles de usuario
        /// </summary>
        public abstract void CargarControles();

        #endregion
    }
}
