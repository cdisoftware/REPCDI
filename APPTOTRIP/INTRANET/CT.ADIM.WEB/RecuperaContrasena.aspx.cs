using System;
using CDI.Comun;
using CT.ADMIN.BL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CT.ADIM.WEB
{
    public partial class RecuperaContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ViewState["mail"] = Request.QueryString["mail"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == txtRepPassword.Text)
                {
                    clsHerramientas objHerramientas = new clsHerramientas();
                    string Email = ViewState["mail"].ToString();
                    if (txtPassword.Text == txtRepPassword.Text)
                    {
                        Encriptacion.Operacion opc;
                        opc = Encriptacion.Operacion.Encripta;
                        string Clave = Encriptacion.Cifrado(opc, txtPassword.Text);
                        objHerramientas.ActualizaPassword(Email, Clave);
                        lblMensaje.Text = "La contraseña ha sido modificada correctamente.";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                        ViewState["valida"] = true;
                    }
                }
                else
                {
                    lblMensaje.Text = "Los campos no coinciden, intentalo nuevamente.";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                    ViewState["valida"] = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRecuperaPass_Click(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(ViewState["valida"]))
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}