using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using CT.ADMIN.BL;


namespace CT.ADIM.WEB
{
    public partial class Login : System.Web.UI.Page
    {
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient wsAtt = new wsATT.AppToTripWSSoapClient();
        //wsATT_PR.AppToTripWSSoapClient wsAtt = new wsATT_PR.AppToTripWSSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            EliminarCookies();
            if (Request.QueryString["pass"] != null)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalRecPass();", true);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["reg"] != null && Request.QueryString["reg"].ToString() == "1")
                {
                    lblResultadoLogin.Text = "Su cuenta ha sido creada!\n" + "Para continuar debe seguir las instrucciones enviadas a su correo electrónico.";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                }
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "cerrarpopup();", true);
            }

        }

        protected void botonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // objHerramientas.InsertaLog("entra login", "log");
                clsOperacionUsuario objOperacionUsuario = new clsOperacionUsuario();
                string error = "";
                Usuario usr = objOperacionUsuario.AutenticarUsuario(txtUsuario.Text, txtClave.Text, ref error);
                if (usr == null)
                {
                    lblMensajeError.Text = "Datos incorrectos!";
                    lblResultadoLogin.Text = error;
                    //ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                    if (ViewState["contar"] == null)
                    {
                        ViewState["validar"] = txtUsuario.Text;
                        ViewState["contar"] = 1;
                    }
                    else
                    {
                        if ((Convert.ToInt32(ViewState["contar"])) < 3)
                        {
                            if (ViewState["validar"].ToString() == txtUsuario.Text)
                            {
                                ViewState["contar"] = Convert.ToInt32(ViewState["contar"]) + 1;
                            }
                            else
                            {
                                ViewState["contar"] = 1;
                                ViewState["validar"] = txtUsuario.Text;
                            }
                        }
                    }
                    if ((Convert.ToInt32(ViewState["contar"])) == 3)
                    {
                        objOperacionUsuario.BloquearUsuario(txtUsuario.Text);
                        ViewState["contar"] = null;
                    }
                }
                else if ((usr.Estado == "2"))
                {
                    lblMensajeError.Text = "Su cuenta no ha sido activada!";
                }
                else if ((usr.Estado == "0"))
                {
                    lblMensajeError.Text = "Su correo electrónico no ha sido validado!";
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "cerrarpopup();", true);
                    Session["usuario"] = usr;
                    // Session["NombreUsuario"] = usr.Nombre_Usuario;
                    Response.Redirect("NuIm/Index.aspx?ini=1", false);
                }
            }
            catch (Exception ex)
            {
                objHerramientas.InsertaLog("error: " + ex.Message, "error");
            }
        }

        protected void btnRecuperaPass_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder body = new StringBuilder();
                body.Append("Con el siguiente link podrás adquirir tu nueva contraseña.");
                body.Append("<br />");
                body.Append("<a href=http://akyvoy.com/CIRC_TUR/RecuperaContrasena.aspx?mail=" + txtMail.Text + "> Recuperar mi contraseña </a>");

                EnvioCorreo(txtMail.Text, body.ToString());
                lblMensajeRec.Text = "Se ha enviado un correo a " + txtMail.Text + " con el enlace para recuperar tu contraseña.";
                btnRecuperaPass.Visible = false;
                txtMail.Visible = false;
                //ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalRecPass();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EnvioCorreo(string Mail, string body)
        {

            wsAtt.pa_Send_Mail(Mail, "App To Trip - Recuperar Contraseña!", body.ToString());
            //MailMessage email = new MailMessage();
            ////email.To.Add(new MailAddress("natica.det@gmail.com"));
            //email.To.Add(new MailAddress(Mail));
            //email.From = new MailAddress("apptotrip@gmail.com");
            //email.Subject = "App To Trip - Descrube el mundo a tu manera";
            //email.Body = body;
            //email.IsBodyHtml = true;
            //email.Priority = MailPriority.Normal;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "http://gmail.com";
            //smtp.Port = 2525;
            ////smtp.EnableSsl = false;
            //smtp.UseDefaultCredentials = false;
            ////smtp.Credentials = new NetworkCredential("info@aldeacocina.com.co", "CarBusHo0966");
            //smtp = new SmtpClient("smtp.gmail.com", 587)
            //{
            //    Credentials = new NetworkCredential("apptotrip@gmail.com", "CALLE147$"),
            //    EnableSsl = true
            //};

            //string output = null;

            //try
            //{
            //    smtp.Send(email);
            //    email.Dispose();
            //    output = "Corre electrónico fue enviado satisfactoriamente.";
            //}
            //catch (Exception ex)
            //{
            //    output = "Error enviando correo electrónico: " + ex.Message;
            //}
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void EliminarCookies()
        {
            try
            {
                if (Request.Cookies["UserSettings"] != null)
                {
                    HttpCookie myCookie = new HttpCookie("UserSettings");
                    myCookie.Expires = DateTime.Now.AddDays(-1d);
                    Response.Cookies.Add(myCookie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}