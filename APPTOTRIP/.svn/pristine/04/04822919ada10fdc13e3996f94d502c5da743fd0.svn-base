using System;
using System.Data;
using CT.ADMIN.BL;
using CDI.Comun;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace CT.ADIM.WEB
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        clsRegistroUsuario objUsuario = new clsRegistroUsuario();
        clsHerramientas objHerramientas = new clsHerramientas();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaInfo();
            }
        }

        protected void btnEditarDatos_Click(object sender, ImageClickEventArgs e)
        {
            var button = (ImageButton)sender;
            DataTable dtUsuario = (DataTable)Session["dtUsuario"];
            string Nombre = button.ValidationGroup;
            if (Nombre == "btnNombres")
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                lblNombre.Visible = false;
                txtNombre.Visible = true;
                txtNombre.Text = dtUsuario.Rows[0]["nombres_usuario"].ToString();
            }

            if (Nombre == "btnApellidos")
            {
                lblApellido.Visible = false;
                txtApellido.Visible = true;
                txtApellido.Text = dtUsuario.Rows[0]["apellidos_usuario"].ToString();
            }

            if (Nombre == "btnTipoId")
            {
                CargarTipoId();
                lblTipoId.Visible = false;
                ddlTipoId.Visible = true;
                ddlTipoId.SelectedValue = dtUsuario.Rows[0]["tipo_documento"].ToString();
            }

            if (Nombre == "btnNumeroId")
            {
                lblNumeroId.Visible = false;
                txtNumeroId.Visible = true;
                txtNumeroId.Text = dtUsuario.Rows[0]["documento_usuario"].ToString();
            }

            if (Nombre == "btnPais")
            {
                CargarPaises();
                lblPais.Visible = false;
                ddlPais.Visible = true;
                ddlPais.SelectedValue = dtUsuario.Rows[0]["id_pais"].ToString();
            }

            if (Nombre == "btnCiudad")
            {
                CargarCiudades(dtUsuario.Rows[0]["id_pais"].ToString());
                lblCiudad.Visible = false;
                ddlCiudad.Visible = true;
                ddlCiudad.SelectedValue = dtUsuario.Rows[0]["id_ciudad"].ToString();
            }

            if (Nombre == "btnNumCert")
            {
                lblNumCert.Visible = false;
                txtNumCert.Visible = true;
                txtNumCert.Text = dtUsuario.Rows[0]["numero_certificado"].ToString();
            }

            if (Nombre == "btnVigCert")
            {
                lblVigCert.Visible = false;
                txtVigCert.Visible = true;
                txtVigCert.Text = dtUsuario.Rows[0]["vigencia_certificado"].ToString();
            }

            if (Nombre == "btnFecNac")
            {
                lblFecNac.Visible = false;
                txtFecNac.Visible = true;
                txtFecNac.Text = dtUsuario.Rows[0]["fecha_nacimiento"].ToString();
            }

            if (Nombre == "btnContrasena")
            {
                lblClave.Visible = false;
                txtClave.Visible = true;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void CargaInfo()
        {
            try
            {
                Encriptacion.Operacion opc;
                opc = Encriptacion.Operacion.Desencripta;
                ImageConverter convertidor = new ImageConverter();


                Usuario Usuario = (Usuario)Session["usuario"];
                string idUsu = Usuario.Id_Usuario;
                DataTable dtUsuario = objUsuario.CargaPerfilUsuario(idUsu);
                Session["dtUsuario"] = dtUsuario;

                System.Text.Encoding enc = System.Text.Encoding.ASCII;

                byte[] ImagenPerfil = (byte[])dtUsuario.Rows[0]["foto_cuenta"];
                string ImgPerfil = enc.GetString(ImagenPerfil);

                byte[] ImagenCertificado = (byte[])dtUsuario.Rows[0]["foto_certificado"];
                string ImgCertificado = enc.GetString(ImagenCertificado);

                imgPrfl.ImageUrl = "data:image/jpg;base64," + ImgPerfil;
                imgCertificado.ImageUrl = "data:image/jpg;base64," + ImgCertificado;
                lblNombre.Text = dtUsuario.Rows[0]["nombres_usuario"].ToString();
                lblApellido.Text = dtUsuario.Rows[0]["apellidos_usuario"].ToString();
                lblTipoId.Text = dtUsuario.Rows[0]["texto_tipo_documento"].ToString();
                lblNumeroId.Text = dtUsuario.Rows[0]["documento_usuario"].ToString();
                lblPais.Text = dtUsuario.Rows[0]["nombre_pais"].ToString();
                lblCiudad.Text = dtUsuario.Rows[0]["nombre_ciudad"].ToString();
                lblNumCert.Text = dtUsuario.Rows[0]["numero_certificado"].ToString();
                lblVigCert.Text = dtUsuario.Rows[0]["vigencia_certificado"].ToString();
                lblFecNac.Text = dtUsuario.Rows[0]["fecha_nacimiento"].ToString();
                lblEmail.Text = dtUsuario.Rows[0]["correo_usuario"].ToString();
                lblClave.Text = "Campo Oculto";
                //Encriptacion.Cifrado(opc, dtUsuario.Rows[0][""].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

        public void CargarCiudades(string idPais)
        {
            DataTable dtCiudades = (DataTable)objHerramientas.CargaCiudades(idPais);
            ddlCiudad.DataSource = dtCiudades;
            ddlCiudad.DataValueField = "id_ciudad";
            ddlCiudad.DataTextField = "ciudad";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, "Ciudad...");
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
                throw ex;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> lstUsuario = new List<string>();
                string Nombres;
                string Apellidos;
                string TipoId;
                string NumeroId;
                string Pais;
                string Ciudad;
                string Certificado;
                string VigenciaCertificado;
                string FechaNacimiento;

                if (txtNombre.Text != "")
                {
                    Nombres = txtNombre.Text;
                    lstUsuario.Add(Nombres);
                }
                else
                {
                    Nombres = lblNombre.Text;
                    lstUsuario.Add(Nombres);
                }

                if (txtApellido.Text != "")
                {
                    Apellidos = txtApellido.Text;
                    lstUsuario.Add(Apellidos);
                }
                else
                {
                    Apellidos = lblApellido.Text;
                    lstUsuario.Add(Apellidos);
                }

                if (ddlTipoId.SelectedIndex > 0)
                {
                    TipoId = ddlTipoId.SelectedValue;
                    lstUsuario.Add(TipoId);
                }
                else
                {
                    TipoId = lblTipoId.Text;
                    lstUsuario.Add(TipoId);
                }

                if (txtNumeroId.Text != "")
                {
                    NumeroId = txtNumeroId.Text;
                    lstUsuario.Add(NumeroId);
                }
                else
                {
                    NumeroId = lblNumeroId.Text;
                    lstUsuario.Add(NumeroId);
                }

                if (ddlPais.SelectedIndex > 0)
                {
                    Pais = ddlPais.SelectedValue;
                    lstUsuario.Add(Pais);
                }
                else
                {
                    Pais = lblPais.Text;
                    lstUsuario.Add(Pais);
                }

                if (ddlCiudad.SelectedIndex > 0)
                {
                    Ciudad = ddlCiudad.SelectedValue;
                    lstUsuario.Add(Ciudad);
                }
                else
                {
                    Ciudad = lblCiudad.Text;
                    lstUsuario.Add(Ciudad);
                }

                if (txtNumCert.Text != "")
                {
                    Certificado = txtNumCert.Text;
                    lstUsuario.Add(Certificado);
                }
                else
                {
                    Certificado = lblNumCert.Text;
                    lstUsuario.Add(Certificado);
                }

                if (txtVigCert.Text != "")
                {
                    VigenciaCertificado = txtVigCert.Text;
                    lstUsuario.Add(VigenciaCertificado);
                }
                else
                {
                    VigenciaCertificado = lblVigCert.Text;
                    lstUsuario.Add(VigenciaCertificado);
                }

                if (txtFecNac.Text != "")
                {
                    FechaNacimiento = txtFecNac.Text;
                    lstUsuario.Add(FechaNacimiento);
                }
                else
                {
                    FechaNacimiento = lblFecNac.Text;
                    lstUsuario.Add(FechaNacimiento);
                }

                objUsuario.ActualizaUsuario(lstUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}