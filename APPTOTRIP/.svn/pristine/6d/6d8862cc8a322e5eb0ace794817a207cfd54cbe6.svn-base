using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Text;
using System.Web.UI;
using CT.ADMIN.BL;
using CDI.Comun;
using System.Web;
using System.Web.UI.WebControls;
using TextBox = System.Web.UI.WebControls.TextBox;
using System.Drawing;
using System.Net;

namespace CT.ADIM.WEB.NuIm
{
    public partial class Circuitos : System.Web.UI.Page
    {
        clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
        clsCircuitos objCircuitosInd = new clsCircuitos();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient objWs = new wsATT.AppToTripWSSoapClient();
        //wsATT_PR.AppToTripWSSoapClient objWsPruebas = new wsATT_PR.AppToTripWSSoapClient();
        //wsATT_PR_170.AppToTripWSSoapClient objWs = new wsATT_PR_170.AppToTripWSSoapClient();
        wsPQR.wsPQRSoapClient objPQR = new wsPQR.wsPQRSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if (IsPostBack && fulImagenes.PostedFile != null)
                {
                    if (fulImagenes.PostedFile.FileName.Length > 0)
                    {
                        ViewState["fulBand"] = "1";
                        int Tamanio = fulImagenes.PostedFile.ContentLength;
                        btnGuardarImagen.Enabled = true;
                        string[] Tipo = fulImagenes.PostedFile.ContentType.ToString().Split('/');
                        if (Tamanio < 2000000)
                        {
                            if (Tipo[1].ToString().ToUpper() == "JPG" || Tipo[1].ToString().ToUpper() == "JPEG" || Tipo[1].ToString().ToUpper() == "PNG")
                            {
                                if (!Directory.Exists(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + ViewState["idc"].ToString()))
                                {
                                    Directory.CreateDirectory(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + ViewState["idc"].ToString());
                                }
                                string NombreArchivo = GenerarNombreArchivo();
                                string imgUrlSave = "http://api.apptotrip.com/circ_tur/media/imgusuario/" + ViewState["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                //string imgUrlSave = "http://35.163.51.145/circ_tur/media/imgusuario/" + ViewState["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                string urlImagen = @"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + ViewState["idc"].ToString() + @"\" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.FileName;
                                ViewState["urlImagen"] = urlImagen;
                                ViewState["imgUrlSave"] = imgUrlSave;
                                byte[] ImagenOriginal = new byte[Tamanio];
                                fulImagenes.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
                                Bitmap ImagenOriginalBinaria = new Bitmap(fulImagenes.PostedFile.InputStream);
                                string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                                Image3.ImageUrl = ImagenDataURL64;
                                pnlImg.Visible = true;
                                pnlUpload.Visible = false;
                                ViewState["NomImagen"] = NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                fulImagenes.SaveAs(urlImagen);
                                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalImagenesCirc();", true);

                            }
                            else
                            {
                                lblMensajePU.Text = "Solo se permiten archivos JPG.";
                                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                            }
                        }
                        else
                        {
                            lblMensajePU.Text = "El tamaño de la imágen no debe ser mayor a 4 Megabytes.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                        }
                    }
                }
                if (!IsPostBack)
                {
                    if (ViewState["idc"] == null)
                    {
                        string idCircuito = Request.QueryString["ic"].ToString();
                        ViewState["idc"] = Request.QueryString["ic"];
                        Session["idc"] = Request.QueryString["ic"];
                        CargarInfoCircuito(idCircuito);
                        CargarSitios(idCircuito);
                        if (Request.QueryString["ic"] == "0")
                        {
                            lblTitulo.Text = "NUEVO";
                            imgCircuito.ImageUrl = "../MEDIA/IMG/NoImage.png";
                            lblDuracion.Text = "--";
                            lblEdad.Text = "--";
                            lblRecomendaciones.Text = "--";
                            lblDescripcion.Text = "--";
                            lblEquipamento.Text = "--";
                            lblContexto.Text = "--";
                            hdIdCircuito.Value = "0";
                            btnActivar.Visible = false;
                            btnPreview.Visible = false;
                            btnEliminar.Visible = false;
                        }
                        else
                        {
                            btnActivar.Visible = true;
                            btnPreview.Visible = true;
                            btnEliminar.Visible = true;
                        }

                        try
                        {
                            string Expresion = "id_circuito = " + idCircuito;
                            DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
                            DataRow[] dr = dtCircuitos.Select(Expresion);
                            if (dr[0]["estado_circuito"].ToString() == "3")
                            {

                                btnPreview.Enabled = true;
                                btnPreview.Text = "Ver en Mapa";
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    else
                    {
                        CargarInfoCircuito(ViewState["idc"].ToString());
                        CargarSitios(ViewState["idc"].ToString());
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        #region Botones Editar
        protected void btnEditNombre_Click(object sender, ImageClickEventArgs e)
        {
            txtNombre.Text = lblTitulo.Text;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNombreCirc();", true);
        }

        protected void imgEditEncabezado_Click(object sender, ImageClickEventArgs e)
        {
            string[] veccosto = lblCosto.Text.Split(' ');
            CargarCiudades(hdIdPais.Value);
            ddlCiudad.SelectedValue = hdIdCiudad.Value;
            txtResumen.Text = lblResumen.Text;
            txtPrecio.Text = veccosto[0].ToString();
            ddlMoneda.SelectedValue = veccosto[1].ToString();
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalEncabezadoCirc();", true);
        }

        protected void btnEditDescripcion_Click(object sender, ImageClickEventArgs e)
        {
            txtDescripcion.Text = lblDescripcion.Text;
            txtDescripcion.Wrap = true;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalDescripcionCirc();", true);
        }

        protected void btnEditDetalles_Click(object sender, ImageClickEventArgs e)
        {
            clsCircuito objCircuito = (clsCircuito)Session["clsCircuito"];
            CargarEdad();
            CargaUniMedidaTiempo();
            string[] Duracion;
            if (lblDuracion.Text != "")
            {
                Duracion = lblDuracion.Text.Split(' ');
                txtDuracion.Text = Duracion[0];
                ddlUniTiempo.SelectedValue = Duracion[1];
            }
            ddlEdad.SelectedValue = objCircuito.Edad;
            txtEquipamento.Text = lblEquipamento.Text;
            txtRecomendaciones.Text = lblRecomendaciones.Text;
            txtContexto.Text = lblContexto.Text;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalDetallesCirc();", true);
        }
        #endregion

        #region Nombre
        protected void btnGuardarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ic"] != "0")
                {
                    string Campos = "nombre_circuito";
                    string Datos = txtNombre.Text;
                    objWs.pa_Actualiza_General("circuito", ViewState["idc"].ToString(), Campos, Datos, "es");
                    Usuario usuario = (Usuario)Session["usuario"];
                    DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                    Session["dtCircuitos"] = dtCircuitos;
                    CargarInfoCircuito(ViewState["idc"].ToString());
                }
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    string Campos = "nombre_circuito";
                    string Datos = txtNombre.Text;
                    string idCircuito = objWs.pa_Insert_General("circuito", usuario.Id_Usuario, Campos, Datos, "es");
                    DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                    Session["dtCircuitos"] = dtCircuitos;
                    ViewState["idc"] = idCircuito;
                    Session["idc"] = idCircuito;
                    hdIdCircuito.Value = idCircuito;
                    CargarInfoCircuito(idCircuito);
                    btnPreview.Visible = true;
                    btnActivar.Visible = true;
                    btnEliminar.Visible = true;
                    btnEliminar.Enabled = true;
                    btnPreview.Enabled = false;
                    btnActivar.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Encabezado
        protected void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                string imgUrlSave = ViewState["imgUrlSave"].ToString(); //"http://api.apptotrip.com/circ_tur/media/imgusuario/" + ViewState["NomImagen"].ToString();
                string imgBD = "media/imgusuario/" + ViewState["idc"].ToString() + "/" + ViewState["NomImagen"].ToString();
                string Campos = "imagen|imagen_img";
                string Datos = imgUrlSave + "|" + imgBD;
                objWs.pa_Actualiza_General("circuito", ViewState["idc"].ToString(), Campos, Datos, "es");
                DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                Session["dtCircuitos"] = dtCircuitos;
                CargarInfoCircuito(ViewState["idc"].ToString());
                pnlUpload.Visible = true;
                pnlImg.Visible = false;
                btnGuardarImagen.Enabled = false;
                ViewState["NomImagen"] = null;
                ViewState["fulBand"] = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelarImagen_Click(object sender, EventArgs e)
        {
            pnlImg.Visible = false;
            pnlUpload.Visible = true;
            if (ViewState["NomImagen"] != null && ViewState["fulBand"].ToString() != "0")
            {
                string urlImg = ViewState["urlImagen"].ToString(); //@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + ViewState["NomImagen"].ToString();
                File.Delete(urlImg);
                ViewState["NomImagen"] = null;
                ViewState["fulBand"] = "1";
                btnGuardarImagen.Enabled = false;
            }

        }

        protected void btnGuardarEncabezado_Click(object sender, EventArgs e)
        {
            try
            {
                string Campos = "valor|otra_moneda|fk_ciudad|descripcion_corta_circuito";
                string Datos = txtPrecio.Text + "|" + ddlMoneda.SelectedValue + "|" + ddlCiudad.SelectedValue + "|" + txtResumen.Text;
                objWs.pa_Actualiza_General("circuito", ViewState["idc"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                Session["dtCircuitos"] = dtCircuitos;
                CargarInfoCircuito(ViewState["idc"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Descripcion
        protected void btnGuardarDescripcion_Click(object sender, EventArgs e)
        {
            try
            {
                string Campos = "descripcion_circuito";
                string Datos = txtDescripcion.Text;
                objWs.pa_Actualiza_General("circuito", ViewState["idc"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                Session["dtCircuitos"] = dtCircuitos;
                CargarInfoCircuito(ViewState["idc"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Detalles
        protected void btnGuardarDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string Duracion = txtDuracion.Text + " " + ddlUniTiempo.SelectedValue;
                string Campos = "tiempo_estimado|fk_rango_edad|equipamento|recomendacion|contexto";
                string Datos = Duracion + "|" + ddlEdad.SelectedValue + "|" + txtEquipamento.Text + "|" + txtRecomendaciones.Text + "|" + txtContexto.Text;
                objWs.pa_Actualiza_General("circuito", ViewState["idc"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);
                Session["dtCircuitos"] = dtCircuitos;
                CargarInfoCircuito(ViewState["idc"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos Controles
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?ini=1");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ValidaSesion())
                //{
                string idCircuito = ViewState["idc"].ToString();
                string Expresion = "id_circuito = " + idCircuito;
                DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
                DataRow[] dr = dtCircuitos.Select(Expresion);
                if (dr[0]["estado_circuito"].ToString() == "0" || dr[0]["estado_circuito"].ToString() == "3")
                {
                    bool banImg = true;
                    bool banValGrl = true;
                    StringBuilder Mensaje = new StringBuilder();
                    StringBuilder MensajeImg = new StringBuilder();
                    DataTable dtSitios = ConsultaSitiosXCircuito(idCircuito);
                    foreach (DataRow drs in dtSitios.Rows)
                    {
                        if (drs["contImagenes"].ToString() == "0")
                        {
                            MensajeImg.AppendLine(drs["nombre_sitio"].ToString() + "</br>");
                            banImg = false;
                        }
                    }
                    if (!banImg)
                    {
                        Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                        Mensaje.AppendLine("Cada sitio de este circuito debe tener por lo menos una imágen. </br>");
                        Mensaje.AppendLine("</div>");
                        lblMensajePU.Text = Mensaje.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                    }
                    else
                    {
                        if (dr[0]["imagen"].ToString() == "")
                        {
                            Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                            Mensaje.AppendLine("El circuito debe tener una imágen de referencia. </br>");
                            Mensaje.AppendLine("</div>");
                            lblMensajePU.Text = Mensaje.ToString();
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                            banValGrl = false;
                        }
                        if (dr[0]["ContSitios"].ToString() == "0")
                        {
                            Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                            Mensaje.AppendLine("El circuito debe tener por lo menos un sitio relacionado. </br>");
                            Mensaje.AppendLine("</div>");
                            lblMensajePU.Text = Mensaje.ToString();
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                            banValGrl = false;
                        }

                    }
                    if (banImg && banValGrl)
                    {
                        if (ViewState["estCircuito"].ToString() == "0")
                        {
                            objCircuitosInd.ActualizaEstadoCircuito(idCircuito, "3");
                            Session["dtCircuitos"] = objCircuitos.ConsultaCircuitos("es", Session["idUsuario"].ToString());
                            lblMensajeNot.Text = "Ya puedes ver tu circuito en la app de App To Trip.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);

                        }
                        else if (ViewState["estCircuito"].ToString() == "3")
                        {
                            objCircuitosInd.ActualizaEstadoCircuito(idCircuito, "2");
                            Session["dtCircuitos"] = objCircuitos.ConsultaCircuitos("es", Session["idUsuario"].ToString());
                            objPQR.crearPQRPr(idCircuito, "C");
                            CargarInfoCircuito(ViewState["idc"].ToString());
                            CargarSitios(ViewState["idc"].ToString());
                            lblMensajePU.Text = "Se ha enviado la solicitud de activación.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                        }
                    }
                }
                else
                {
                    lblMensajeNot.Text = "El circuito ya se encuentra publicado o está en revisión.";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);
                }
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                //}


            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                hdIdCircuito.Value = ViewState["idc"].ToString();
                string idCircuito = ViewState["idc"].ToString();
                string Expresion = "id_circuito = " + idCircuito;
                DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
                DataRow[] dr = dtCircuitos.Select(Expresion);
                DataSet validacion = pa_Validacion_Audios(idCircuito, "es");
                string validacion_audios = validacion.Tables[0].Rows[0][0].ToString();

                if (dr[0]["estado_circuito"].ToString() == "0")
                {
                    bool banImg = true;
                    bool banValGrl = true;
                    StringBuilder Mensaje = new StringBuilder();
                    StringBuilder MensajeImg = new StringBuilder();
                    DataTable dtSitios = ConsultaSitiosXCircuito(idCircuito);
                    foreach (DataRow drs in dtSitios.Rows)
                    {
                        if (drs["contImagenes"].ToString() == "0")
                        {
                            MensajeImg.AppendLine(drs["nombre_sitio"].ToString() + "</br>");
                            banImg = false;
                        }
                    }
                    if (!banImg)
                    {
                        Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                        Mensaje.AppendLine("Cada sitio de este circuito debe tener por lo menos una imágen. </br>");
                        Mensaje.AppendLine("</div>");
                        lblMensajePU.Text = Mensaje.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                    }
                    else
                    {
                        if (dr[0]["imagen"].ToString() == "")
                        {
                            Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                            Mensaje.AppendLine("El circuito debe tener una imágen de referencia. </br>");
                            Mensaje.AppendLine("</div>");
                            lblMensajePU.Text = Mensaje.ToString();
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                            banValGrl = false;
                        }
                        if (dr[0]["ContSitios"].ToString() == "0")
                        {
                            Mensaje.AppendLine("<div aling='left'><h6>Circuito Incompleto.</h6> </br>");
                            Mensaje.AppendLine("El circuito debe tener por lo menos un sitio relacionado. </br>");
                            Mensaje.AppendLine("</div>");
                            lblMensajePU.Text = Mensaje.ToString();
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                            banValGrl = false;
                        }

                    }
                    if (banImg && banValGrl)
                    {
                        objCircuitosInd.ActualizaEstadoCircuito(idCircuito, "3");

                        Session["dtCircuitos"] = objCircuitos.ConsultaCircuitos("es", Session["idUsuario"].ToString());
                        lblMensajeNot.Text = "Ya puedes ver tu circuito en la app de App To Trip.";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);
                    }
                }
                else if (dr[0]["estado_circuito"].ToString() == "3" && validacion_audios.Equals("1"))
                {
                    string clave = "cdi.jlge.com.circuitosturisticos";
                    string url = "http://api.apptotrip.com/AppToTripMovile/AppToTripMovile.svc/Movile_Consulta_Recorrido_Circuito/" + idCircuito + "/intranet/" + clave;
                    var json = new WebClient().DownloadString(url);
                    Session["lat"] = "0";
                    Session["Lon"] = json;
                    if (json.Length != 0)
                    {
                        Response.Redirect("../Mapa.aspx", false);
                    }
                    //Response.Redirect("../Mapa.aspx");
                    //Response.Redirect("../Mapa.aspx", false);
                }
                else
                {
                    //lblMensajeNot.Text = "El circuito ya se encuentra publicado o está en revisión.";
                    //ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);
                    lblMensajeNot.Text = "El circuito ya se encuentra publicado o está en revisión.";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);

                }



            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnEditSitios_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataTable dtSitios = ConsultaSitiosXCircuito(Session["idc"].ToString()); ;
                gvSitios.DataSource = dtSitios;
                gvSitios.DataBind();
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalOrdenSitio();", true);
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnGuardarOrden_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
            try
            {
                //if (ValidaSesion())
                //{
                bool val = ValidarOrden();
                if (val == true)
                {
                    lblMensajePU.Text = "Orden Duplicado!";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                }
                else
                {
                    CreaDtOrden();
                    DataTable dtOrden = Session["dtOrden"] as DataTable;
                    foreach (GridViewRow gvr in gvSitios.Rows)
                    {
                        DataRow drOrden = dtOrden.NewRow();
                        string IdSitio = gvSitios.DataKeys[gvr.RowIndex]["id_sitio"].ToString();
                        TextBox txtOrden = (TextBox)gvr.FindControl("txtOrden");
                        string Orden = txtOrden.Text;
                        drOrden["idSitio"] = IdSitio;
                        drOrden["Orden"] = Orden;
                        dtOrden.Rows.Add(drOrden);

                        //objCircuitosInd.ActualizaOrdenSitios(IdSitio, Orden);
                        //ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "cerrarpopup();", false);
                    }
                    dtOrden.DefaultView.Sort = "Orden ASC";
                    dtOrden = dtOrden.DefaultView.ToTable();
                    int i = 1;
                    foreach (DataRow dr in dtOrden.Rows)
                    {
                        string idSitio = dr["idSitio"].ToString();
                        objCircuitosInd.ActualizaOrdenSitios(dr["idSitio"].ToString(), i.ToString());
                        i++;
                    }
                }

                CargarSitios(Session["idc"].ToString());
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                //}
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion

        #region Metodos
        public bool ValidarOrden()
        {
            try
            {
                bool ban = false;
                string Orden;
                string[] arrOrden = new string[100];
                foreach (GridViewRow gvr in gvSitios.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtOrden = (System.Web.UI.WebControls.TextBox)gvSitios.Rows[gvr.RowIndex].FindControl("txtOrden");
                    Orden = txtOrden.Text;
                    if (gvr.RowIndex == 0)
                    {
                        arrOrden[gvr.RowIndex] = Orden;
                    }
                    else
                    {
                        for (int i = 1; i <= gvr.RowIndex; i++)
                        {
                            if (arrOrden[i - 1] == Orden)
                            {
                                ban = true;
                                break;
                            }
                            else
                            {
                                arrOrden[gvr.RowIndex] = Orden;
                            }
                        }
                    }
                }
                return ban;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        public void CreaDtOrden()
        {
            try
            {
                DataTable dtOrden = new DataTable();
                dtOrden.Columns.Add("idSitio");
                DataColumn column;
                column = new DataColumn();
                column.DataType = System.Type.GetType("System.Int32");
                column.ColumnName = "Orden";
                dtOrden.Columns.Add(column);
                //dtOrden.Columns.Add("Orden");

                Session["dtOrden"] = dtOrden;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargarInfoCircuito(string idCircuito)
        {

            if (ViewState["idc"].ToString() == "0")
            {
                btnEditDescripcion.Enabled = false;
                btnEditDetalles.Enabled = false;
                imgEditEncabezado.Enabled = false;
                //  btnEditSitios.Enabled = false;
            }
            else
            {
                hdIdCircuito.Value = "1";
                btnEditDescripcion.Enabled = true;
                btnEditDetalles.Enabled = true;
                imgEditEncabezado.Enabled = true;
                //  btnEditSitios.Enabled = true;
            }
            clsCircuito objCircuito = new clsCircuito();
            string Expresion = "id_circuito = " + idCircuito;
            DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
            DataRow[] dr = dtCircuitos.Select(Expresion);
            CargarPaises();
            if (dr.Length > 0)
            {
                switch (dr[0]["estado_circuito"].ToString())
                {
                    case "0":
                        btnActivar.Enabled = false;
                        btnPreview.Enabled = true;
                        lblEstado.Text = "Editado";
                        break;
                    case "1":
                        btnActivar.Enabled = false;
                        btnPreview.Enabled = false;
                        lblEstado.Text = "Publicado";
                        break;
                    case "2":
                        btnActivar.Enabled = false;
                        btnPreview.Enabled = true;
                        lblEstado.Text = "En validación";
                        break;
                    case "3":
                        btnActivar.Enabled = true;
                        btnPreview.Enabled = false;
                        lblEstado.Text = "Beta";
                        break;
                }
                ViewState["estCircuito"] = dr[0]["estado_circuito"].ToString();
                string[] Valor = dr[0]["valor"].ToString().Split(' ');
                string Costo = Valor[0];
                string Moneda = " Indeterminada";
                if (Valor.Length > 1)
                {
                    Moneda = Valor[1];
                }
                lblTitulo.Text = dr[0]["nombre_circuito"].ToString();
                Session["nc"] = dr[0]["nombre_circuito"].ToString();
                if (dr[0]["descripcion_corta_circuito"].ToString() != "")
                {
                    lblResumen.Text = dr[0]["descripcion_corta_circuito"].ToString();
                }
                else
                {
                    lblResumen.Text = "[Descripción Corta]";
                }
                if (dr[0]["Imagen"].ToString() != "" || File.Exists(dr[0]["imagen_img"].ToString()))
                {
                    imgCircuito.ImageUrl = dr[0]["Imagen"].ToString();
                }
                else
                {
                    imgCircuito.ImageUrl = "../MEDIA/IMG/NoImage.png";
                }
                lblDescripcion.Text = dr[0]["Descripcion_circuito"].ToString();
                lblContexto.Text = dr[0]["contexto"].ToString();
                lblEquipamento.Text = dr[0]["equipamento"].ToString();
                lblDuracion.Text = dr[0]["tiempo_estimado"].ToString();
                lblEdad.Text = dr[0]["rango"].ToString();
                lblRecomendaciones.Text = dr[0]["recomendacion"].ToString();
                lblCosto.Text = Costo + " " + Moneda;
                if (ViewState["banPais"] == null)
                {

                    ddlPais.SelectedValue = dr[0]["id_pais"].ToString();
                }
                else
                {
                    ddlPais.SelectedValue = ViewState["banPais"].ToString();
                }
                ddlMoneda.SelectedValue = dr[0]["otra_moneda"].ToString();
                lblCiudad.Text = dr[0]["ciudad"].ToString() + " (" + dr[0]["nombre_pais"].ToString() + ")";
                hdIdPais.Value = dr[0]["id_pais"].ToString();
                hdIdCiudad.Value = dr[0]["fk_ciudad"].ToString();

                objCircuito.Edad = dr[0]["id_rango_edad"].ToString();
                objCircuito.Id_Circuito = dr[0]["id_circuito"].ToString();
                Session["clsCircuito"] = objCircuito;
            }
        }

        public void CargarCiudades(string id_pais)
        {
            try
            {
                DataTable dtCiudades = (DataTable)objHerramientas.CargaCiudades(id_pais);
                ddlCiudad.DataSource = dtCiudades;
                ddlCiudad.DataValueField = "id_ciudad";
                ddlCiudad.DataTextField = "ciudad";
                ddlCiudad.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
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
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargarSitios(string idCircuito)
        {
            try
            {
                DataTable dtSitios = ConsultaSitiosXCircuito(idCircuito);
                Session["dtSitios"] = dtSitios;
                StringBuilder sbSitios = new StringBuilder();
                sbSitios.AppendLine("<div class='row'>");
                sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6' style='height:250px'>");
                sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                sbSitios.AppendLine("<div class='img-personal circ' style='height:200px; width:200px; border:1px solid #666666; background:url(../MEDIA/IMG/añadir2.png) no-repeat center; background-size: contain' onclick='redirectsitios(0)'>");
                sbSitios.AppendLine("</div>");
                sbSitios.AppendLine("</a>");
                sbSitios.AppendLine("</div>");
                foreach (DataRow dr in dtSitios.Rows)
                {
                    string urlImagen = @"c:\inetpub\wwwroot\circ_tur\MEDIA\IMGUSUARIO\" + dr["imagen_img"].ToString();
                    bool exite = File.Exists(urlImagen);
                    string imagen = dr["imagen"].ToString();
                    sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6' style='height:250px;'>");
                    sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                    if (dr["imagen"].ToString() != "")
                    {
                        sbSitios.AppendLine("<div class='img-personal circ cargando' style='box - shadow: 5px 5px 5px rgba(113, 110, 110, 0.50); width:200px; height:200px; background:url(" + dr["imagen"].ToString() + ") no-repeat; background-size: cover; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>");
                    }
                    else
                    {
                        sbSitios.AppendLine("<div class='img-personal circ cargando' style='box - shadow: 5px 5px 5px rgba(113, 110, 110, 0.50); width:200px; height:200px; background:url(../MEDIA/IMG/NoImage.png) no-repeat; background-size: contain; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>");
                    }
                    sbSitios.AppendLine("</div>");
                    sbSitios.AppendLine("<div class='text-center' style='color:#666666; padding-top:5px; font-family: 'Century Gothic'' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>" + dr["nombre_sitio"].ToString() + "</div>");
                    sbSitios.AppendLine("</a>");
                    sbSitios.AppendLine("</div>");
                }
                sbSitios.AppendLine("</div>");
                string Contenido = sbSitios.ToString();
                cntSitios.InnerHtml = Contenido;
                if (dtSitios.Rows.Count > 0)
                {
                    btnEditSitios.Enabled = true;
                }
                else
                {
                    btnEditSitios.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargaUniMedidaTiempo()
        {
            try
            {
                Usuario usr = (Usuario)Session["usuario"];
                DataTable dtDuracion = objWs.pa_Consulta_Generica("Duracion", "es");
                ddlUniTiempo.DataSource = dtDuracion;
                ddlUniTiempo.DataTextField = "texto";
                ddlUniTiempo.DataValueField = "texto";
                ddlUniTiempo.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void CargarEdad()
        {
            try
            {
                DataTable dtEdad = objHerramientas.CargaRangoEdad();
                ddlEdad.DataSource = dtEdad;
                ddlEdad.DataValueField = "id_rango_edad";
                ddlEdad.DataTextField = "rango";
                ddlEdad.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public DataTable ConsultaSitiosXCircuito(string IdCircuito)
        {
            try
            {
                return objCircuitos.ConsultaSitios("es", IdCircuito);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        public DataSet pa_Validacion_Audios(string IdCircuito, string codigo_idioma)
        {
            try
            {
                return objCircuitos.pa_Consultar_audios(IdCircuito, "es");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        public string GenerarNombreArchivo()
        {
            int longitud = 10;
            Guid miGuid = Guid.NewGuid();
            string Nombre = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            return "IC-" + Nombre;
        }

        #endregion

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCiudades(ddlPais.SelectedValue);
            ViewState["banPais"] = ddlPais.SelectedValue;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalEncabezadoCirc();", true);
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalEliCir();", true);
        }

        protected void btnEliminarCir_Click(object sender, EventArgs e)
        {
            DataTable dtRespuesta = objCircuitosInd.EliminaCircuito(Request.QueryString["ic"].ToString());
            if (dtRespuesta.Rows.Count > 0 && dtRespuesta.Rows[0]["respuesta"].ToString() == "1")
            {
                Response.Redirect("Index.aspx?ini=1");
            }
        }
    }
}