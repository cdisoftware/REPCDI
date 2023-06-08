using System;
using System.Data;
using CT.ADMIN.BL;
using CDI.Comun;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Text;

namespace CT.ADIM.WEB
{

    public partial class Registro : System.Web.UI.Page
    {
        clsRegistroUsuario objRegistroUsuario = new clsRegistroUsuario();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient wsAtt = new wsATT.AppToTripWSSoapClient();
        //wsATT_PR.AppToTripWSSoapClient wsAtt = new wsATT_PR.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CargarPaises();
                CargarTipoId();
            }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPais.SelectedIndex > 0)
                {
                    txtPais.Text = "1";
                    DataTable dtCiudades = (DataTable)objHerramientas.CargaCiudades(ddlPais.SelectedValue);
                    ddlCiudad.DataSource = dtCiudades;
                    ddlCiudad.DataValueField = "id_ciudad";
                    ddlCiudad.DataTextField = "ciudad";
                    ddlCiudad.DataBind();
                    ddlCiudad.Items.Insert(0, "Ciudad...");
                }
                else
                {
                    txtPais.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Encriptacion.Operacion opc;
                opc = Encriptacion.Operacion.Encripta;

                string imgPerfilUrl = fulImgPerfil.FileName;
                string imgCert = fulImgCertificado.FileName;
                string ImgPerfil = "";
                string ImgPerfilWeb = "";
                string ImgCertificado = "";
                string ImgCertificadoWeb = "";
                string Nombres = txtNombre.Text;
                string Apellidos = txtApellido.Text;
                string TipoId = ddlTipoId.SelectedValue;
                try
                {
                    TipoId = ddlTipoId.SelectedValue;
                }
                catch (Exception)
                {
                    lblMensajePU.Text = "Seleccione un tipo de identidad!";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                }
                string NumeroId = txtNumeroId.Text;
                string Ciudad = ddlCiudad.SelectedValue;
                try
                {
                    Ciudad = ddlCiudad.SelectedValue;
                }
                catch(Exception) {
                    lblMensajePU.Text = "Seleccione una ciudad!";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                }
                string NumeroCert = txtNumCert.Text;
                //string VigenciaCert = Convert.ToDateTime(txtVigCert.Text).ToString("yyyy/MM/dd");
                //string FechaNac = Convert.ToDateTime(txtFecNac.Text).ToString("yyyy/MM/dd");
                string VigenciaCert = txtVigCert.Text;
                string FechaNac = txtFecNac.Text;
                string Correo = txtEmail.Text;
                string Clave = Encriptacion.Cifrado(opc, txtClave.Text);
                string ConfClave = txtClaveConf.Text;
                if (Session["imgPerfil"] != null)
                {
                    ImgPerfil = Session["imgPerfil"].ToString();
                    ImgPerfilWeb = Session["imgPerfilWeb"].ToString();
                }
                if (Session["imgCertificado"] != null)
                {
                    ImgCertificado = Session["imgCertificado"].ToString();
                    ImgCertificadoWeb = Session["imgCertificadoWeb"].ToString();
                }
                if (Ciudad != null && TipoId!=null) {
                    List<string> lstUsuario = new List<string>();
                    lstUsuario.Add(Nombres);
                    lstUsuario.Add(Apellidos);
                    lstUsuario.Add(TipoId);
                    lstUsuario.Add(NumeroId);
                    lstUsuario.Add(Ciudad);
                    lstUsuario.Add(NumeroCert);
                    lstUsuario.Add(VigenciaCert);
                    lstUsuario.Add(FechaNac);
                    lstUsuario.Add(Correo);
                    lstUsuario.Add(Clave);
                    lstUsuario.Add(ImgPerfil);
                    lstUsuario.Add(ImgCertificado);
                    lstUsuario.Add(ImgPerfilWeb);
                    lstUsuario.Add(ImgCertificadoWeb);
                    lstUsuario.Add("0");

                    DataTable dtRespuesta = objRegistroUsuario.InsertarUsuario(lstUsuario);
                    if (dtRespuesta.Rows[0]["respuesta"].ToString() == "1")
                    {
                        

                        StringBuilder body = new StringBuilder();

                        body.Append("<h3> Estimado(a) " + txtNombre.Text + " " + txtApellido.Text + "</h3></br>");
                        body.Append("<h4>Estas a un paso de convertirte en un nuevo autor de App To Trip</h4></br>");
                        body.Append("<h4>Ingresa en el siguiente link para validar tu correo electrónico</h4></br>");
                        //body.Append("<a href=http://api.apptotrip.com/CIRC_TUR/ValidaUsuarioMail.aspx?iu=" + txtEmail.Text + "&tp=usu> Validar mi e-mail </a>");
                        body.Append("<a href=http://api.apptotrip.com/CIRC_TUR/ValidaUsuarioMail.aspx?iu=" + txtEmail.Text + "&tp=usu> Validar mi e-mail </a>");
                        wsAtt.pa_Send_Mail(txtEmail.Text, "App To Trip - Confirma tu cuenta!", body.ToString());
                        Response.Redirect("Login.aspx?reg=1");
                    }
                    else
                    {
                        lblMensajePU.Text = "El usuario ya existe!";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSubirImgPerfil_Click(object sender, EventArgs e)
        {
            try
            {
                if (fulImgPerfil.HasFile)
                {
                    int tamanio = fulImgPerfil.PostedFile.ContentLength;
                    string Tipo = fulImgPerfil.PostedFile.ContentType;
                    if (tamanio < 4194304)
                    {
                        if (Tipo == "image/png" || Tipo == "image/jpeg")
                        {
                            // string urlImagen = "http://api.apptotrip.com/circ_tur/media/imgusuario/" + fulImgPerfil.FileName;
                            string urlImagen = "http://api.apptotrip.com/circ_tur/media/imgusuario/" + fulImgPerfil.FileName;
                            string urlImgBd = "media/imgusuario/" + fulImgPerfil.FileName;
                            byte[] ImgOrg = new byte[tamanio];
                            fulImgPerfil.PostedFile.InputStream.Read(ImgOrg, 0, tamanio);
                            Bitmap ImgOrgBin = new Bitmap(fulImgPerfil.PostedFile.InputStream);
                            Session["imgPerfil"] = urlImagen;//Convert.ToBase64String(ImgOrg);
                            Session["imgPerfilWeb"] = urlImgBd;
                            string ImgDataIUrlBase64 = "data:image/jpg;base64," + Convert.ToBase64String(ImgOrg);
                            imgPerfil.ImageUrl = ImgDataIUrlBase64;
                            imgPerfil.Visible = true;
                            btnSubirImgPerfil.Visible = false;
                            btnCanImgPerfil.Visible = true;
                        }
                        else
                        {
                            lblMensajePU.Text = "Tipo de archivo inválido!";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                        }
                    }
                    else
                    {
                        lblMensajePU.Text = "La imagen sobrepasa el tamaño permitido (4 Megabytes)!";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                    }
                }
                else
                {
                    lblMensajePU.Text = "Debe seleccionar una imágen!";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                }

            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSubirImgCert_Click(object sender, EventArgs e)
        {
            try
            {
                if (fulImgCertificado.HasFile)
                {
                    //txtImgCertificado.Text = "1";
                    int tamanio = fulImgCertificado.PostedFile.ContentLength;
                    string Tipo = fulImgCertificado.PostedFile.ContentType;
                    if (tamanio < 4194304)
                    {
                        if (Tipo == "image/png" || Tipo == "image/jpeg")
                        {
                            //string urlImagen = "http://api.apptotrip.com/circ_tur/media/imgusuario/" + fulImgCertificado.FileName;
                            string urlImagen = "http://api.apptotrip.com/circ_tur/media/imgusuario/" + fulImgCertificado.FileName;
                            string urlImgBd = "media/imgusuario/" + fulImgCertificado.FileName;
                            byte[] ImgOrg = new byte[tamanio];
                            fulImgCertificado.PostedFile.InputStream.Read(ImgOrg, 0, tamanio);
                            Bitmap ImgOrgBin = new Bitmap(fulImgCertificado.PostedFile.InputStream);
                            Session["imgCertificado"] = urlImagen;//Convert.ToBase64String(ImgOrg);
                            Session["imgCertificadoWeb"] = urlImgBd;
                            string ImgDataIUrlBase64 = "data:image/jpg;base64," + Convert.ToBase64String(ImgOrg);
                            imgCrt.ImageUrl = ImgDataIUrlBase64;
                            imgCrt.Visible = true;
                            btnSubirImgCert.Visible = false;
                            btnCanImgCert.Visible = true;
                        }
                        else
                        {
                            lblMensajePU.Text = "Tipo de archivo inválido!";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                        }
                    }
                    else
                    {
                        lblMensajePU.Text = "La imágen sobrepasa el tamaño permitido (4 Megabytes)!";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "OpenModal();", true);
                    }
                }
                else
                {
                    //txtImgCertificado.Text = "";
                    lblMensajePU.Text = "Debe seleccionar una imágen!";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                }
            }
            catch (Exception ex)
            {
            }

        }

        protected void CargarPaises()
        {
            try
            {
                DataTable dtPaises = objHerramientas.CargaPaises();
                ddlPais.DataSource = dtPaises;
                ddlPais.DataValueField = "id_pais";
                ddlPais.DataTextField = "nombre_pais";
                ddlPais.DataBind();
                ddlPais.Items.Insert(0, "Pais...");
            }
            catch (Exception ex)
            {
            }
        }

        protected void CargarTipoId()
        {
            try
            {
                DataTable dtTipoId = objHerramientas.CargaTipoId();
                ddlTipoId.DataSource = dtTipoId;
                ddlTipoId.DataValueField = "valor";
                ddlTipoId.DataTextField = "texto";
                ddlTipoId.DataBind();
                ddlTipoId.Items.Insert(0, "Tipo Id...");
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCiudad.SelectedIndex > 0)
            {
                txtCiudad.Text = "1";
            }
            else
            {
                txtCiudad.Text = "";
            }
        }

        protected void ddlTipoId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoId.SelectedIndex > 0)
            {
                txtTipoId.Text = "1";
            }
            else
            {
                txtTipoId.Text = "";
            }
        }

        protected void btnCanImgCert_Click(object sender, EventArgs e)
        {
            imgCrt.Visible = false;
            //txtImgCertificado.Text = "";
            btnCanImgCert.Visible = false;
            btnSubirImgCert.Visible = true;
        }

        protected void btnCanImgPerfil_Click(object sender, EventArgs e)
        {
            imgPerfil.Visible = false;
            //txtImgCertificado.Text = "";
            btnCanImgPerfil.Visible = false;
            btnSubirImgPerfil.Visible = true;
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}