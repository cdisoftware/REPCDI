using System;
using System.Data;
using CT.ADMIN.BL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CT.ADIM.WEB
{
    public partial class ValidaUsuarioMail : System.Web.UI.Page
    {
        wsPQR.wsPQRSoapClient objPQR = new wsPQR.wsPQRSoapClient();
        clsRegistroUsuario objRegistroUsuario = new clsRegistroUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["iu"] != null)
                {
                    string usuario = Request.QueryString["iu"].ToString();
                    objRegistroUsuario.ActualizaUsuarioActivar(Estado: "2", CorreoUsuario: usuario);
                    objPQR.crearPQR(usuario, "U");
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}