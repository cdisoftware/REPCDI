using System;
using System.Data;
using CT.ADMIN.BL;
using CDI.Comun;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Drawing;
using Image = System.Web.UI.WebControls.Image;

namespace CT.ADIM.WEB.NuIm
{
    public partial class Sitios : System.Web.UI.Page
    {
        clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
        clsCircuitos objDatosCircuitos = new clsCircuitos();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient objWs = new wsATT.AppToTripWSSoapClient();
        //wsATT_PR.AppToTripWSSoapClient objWsPruebas = new wsATT_PR.AppToTripWSSoapClient();
        //wsATT_PR_170.AppToTripWSSoapClient objWs = new wsATT_PR_170.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                if (IsPostBack && fulImagenes.PostedFile != null)
                {
                    if (fulImagenes.PostedFile.FileName.Length > 0)
                    {
                        ViewState["fulBand"] = "1";
                        DataTable dtImagenes = (DataTable)ViewState["dtImagenes"];
                        if (dtImagenes.Rows.Count < 5)
                        {
                            int Tamanio = fulImagenes.PostedFile.ContentLength;
                            string[] Tipo = fulImagenes.PostedFile.ContentType.ToString().Split('/');
                            if (Tamanio < 1000000)
                            {
                                if (Tipo[1].ToString().ToUpper() == "JPG" || Tipo[1].ToString().ToUpper() == "JPEG" || Tipo[1].ToString().ToUpper() == "PNG")
                                {
                                    if (!Directory.Exists(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + Session["idc"].ToString()))
                                    {
                                        Directory.CreateDirectory(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + Session["idc"].ToString());
                                    }
                                    string NombreArchivo = GenerarNombreArchivo();
                                    string imgUrlSave = "http://34.215.136.170/circ_tur/media/imgusuario/" + Session["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                    //string imgUrlSave = "http://35.163.51.145/circ_tur/media/imgusuario/" + Session["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                    string urlImagen = @"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + Session["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.FileName;
                                    ViewState["urlImangen"] = urlImagen;
                                    ViewState["imgUrlSave"] = imgUrlSave;

                                    byte[] ImagenOriginal = new byte[Tamanio];
                                    fulImagenes.PostedFile.InputStream.Read(ImagenOriginal, 0, Tamanio);
                                    Bitmap ImagenOriginalBinaria = new Bitmap(fulImagenes.PostedFile.InputStream);
                                    string ImagenDataURL64 = "data:image/jpg;base64," + Convert.ToBase64String(ImagenOriginal);
                                    Image3.ImageUrl = ImagenDataURL64;
                                    pnlImagen.Visible = true;
                                    pnlUpload.Visible = false;
                                    ViewState["NomImagen"] = Session["idc"].ToString() + "/" + NombreArchivo + "." + Tipo[1].ToString();//fulImagenes.PostedFile.FileName;
                                    fulImagenes.SaveAs(urlImagen);
                                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalImagenes();", true);
                                }
                                else
                                {
                                    lblMensajePU.Text = "Solo se permiten archivos JPG, JPEG y PNG";
                                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                                }
                            }
                            else
                            {
                                lblMensajePU.Text = "El tamaño de la imágen no debe ser mayor a 1 Megabytes.";
                                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);
                            }
                        }
                        else
                        {
                            lblMensajePU.Text = "Solo se permiten 5 imágenes por sitio.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModal();", true);

                        }
                    }
                }
                if (!IsPostBack)
                {
                    try
                    {
                        if (Session["usuario"] != null)
                        {
                            if (Request.QueryString["lat"] != null && Request.QueryString["lng"] != null)
                            {
                                hdIdCircuito.Value = Session["idc"].ToString();
                                lblLatitud.Text = Request.QueryString["lat"].ToString();
                                lblLongitud.Text = Request.QueryString["lng"].ToString();
                                GuardarUbicacion(Request.QueryString["lng"].ToString(), Request.QueryString["lat"].ToString());
                                DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                                Session["dtSitios"] = dtSitios;
                                CargaDatosSitio(Session["is"].ToString());
                            }
                            else
                            {
                                hdIdCircuito.Value = Session["idc"].ToString();
                                Session["is"] = Request.QueryString["is"].ToString();
                                CargaDatosSitio(Request.QueryString["is"].ToString());
                            }
                        }
                        else
                        {
                            Response.Redirect("/Login.aspx");
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        public void GuardarUbicacion(string Longitud, string Latitud)
        {
            try
            {
                string Campos = "longitud|latitud";
                string Datos = Longitud + "|" + Latitud;
                objWs.pa_Actualiza_General("sitio", Session["is"].ToString(), Campos, Datos, "es");
                //Usuario usuario = (Usuario)Session["usuario"];
                //DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                //Session["dtSitios"] = dtSitios;
                //CargaDatosSitio(Session["is"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CargaUniMedidaTiempo()
        {
            try
            {
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

        public void CargaDatosSitio(string idSitio)
        {
            try
            {
                if (idSitio == "0")
                {
                    imgSitio.ImageUrl = "../MEDIA/IMG/NoImage.png";
                    lblTitulo.Text = "NUEVO";
                    lblCosto.Text = "--";
                    lblDescripcion.Text = "--";
                    lblDireccion.Text = "--";
                    lblDuracion.Text = "--";
                    lblEquipamento.Text = "--";
                    lblHorario.Text = "--";
                    lblIra.Text = "--";
                    lblLatitud.Text = "--";
                    lblLongitud.Text = "--";
                    lblRecomendaciones.Text = "--";
                    lblResumen.Text = "--";
                    lblTelefono.Text = "--";
                    imgEditEncabezado.Enabled = false;
                    btnEditarUbicacion.Enabled = false;
                    btnEditDescripcion.Enabled = false;
                    btnEditDetalles.Enabled = false;
                    btnEditImagenes.Enabled = false;
                }
                else
                {
                    imgEditEncabezado.Enabled = true;
                    btnEditarUbicacion.Enabled = true;
                    btnEditDescripcion.Enabled = true;
                    btnEditDetalles.Enabled = true;
                    btnEditImagenes.Enabled = true;
                }
                string Expresion = "id_sitio = " + idSitio;
                DataTable dtSitios = (DataTable)Session["dtSitios"];
                DataRow[] dr = dtSitios.Select(Expresion);

                lblTtlCircuito.Text = Session["nc"].ToString().ToUpper();
                if (dr.Length > 0)
                {
                    if (dr[0]["imagen"].ToString() != "" || File.Exists(dr[0]["imagen"].ToString()))
                    {
                        imgSitio.ImageUrl = dr[0]["imagen"].ToString();
                    }
                    else
                    {
                        imgSitio.ImageUrl = "../MEDIA/IMG/NoImage.png";
                    }

                    if (dr[0]["tiempo_estimado"].ToString() != "")
                    {
                        string[] TiempoEstimado = dr[0]["tiempo_estimado"].ToString().Split(' ');
                        if (TiempoEstimado.Length > 1)
                        {
                            string Tiempo = TiempoEstimado[0];
                            string UniTiempo = TiempoEstimado[1];
                            ddlUniTiempo.SelectedValue = UniTiempo;
                            lblDuracion.Text = Tiempo + " " + UniTiempo;
                        }
                        else
                        {
                            string Tiempo = TiempoEstimado[0];
                            ddlUniTiempo.SelectedIndex = 0;
                            lblDuracion.Text = Tiempo;
                        }
                    }

                    if (dr[0]["costo"].ToString() != "")
                    {
                        string[] Costo = dr[0]["costo"].ToString().Split(' ');
                        if (Costo.Length > 1)
                        {
                            string Valor = Costo[0];
                            string Moneda = Costo[1];
                            lblCosto.Text = Valor + " " + Moneda;
                        }
                        else
                        {
                            string Valor = Costo[0];
                            lblCosto.Text = Valor;
                        }
                    }

                    lblTitulo.Text = dr[0]["nombre_sitio"].ToString().ToUpper();
                    lblLatitud.Text = dr[0]["latitud"].ToString();
                    lblLongitud.Text = dr[0]["longitud"].ToString();
                    lblDireccion.Text = dr[0]["direccion"].ToString();
                    lblTelefono.Text = dr[0]["telefono"].ToString();

                    //txtPaisSitio.Text = dr[0]["pais"].ToString();
                    //txtEdadSitio.Text = dr[0]["edad"].ToString();
                    lblHorario.Text = dr[0]["horario"].ToString();
                    //txtCiudadSitio.Text = dr[0]["Ciudad"].ToString();
                    lblRecomendaciones.Text = dr[0]["Recomendacion"].ToString();
                    lblEquipamento.Text = dr[0]["Equipamento"].ToString();

                    lblDescripcion.Text = dr[0]["Descripcion_sitio"].ToString();
                    lblIra.Text = dr[0]["Indicaciones"].ToString();
                    if (dr[0]["descripcion_corta_sitio"].ToString() != "")
                    {
                        lblResumen.Text = dr[0]["descripcion_corta_sitio"].ToString();
                    }
                    else
                    {
                        lblResumen.Text = "[Descripción Corta]";
                    }
                    CargarImagenes(idSitio, false);
                }
                else
                {
                    //lblTtlSitioDtll.Text = "[Nuevo]";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargarImagenes(string idSitio, bool Editar)
        {
            try
            {
                DataTable dtImagenes = objCircuitos.ConsultaImagenesXSitio(Session["is"].ToString());
                ViewState["dtImagenes"] = dtImagenes;
                StringBuilder sbSitios = new StringBuilder();
                sbSitios.AppendLine("<div class='row'>");
                foreach (DataRow dr in dtImagenes.Rows)
                {
                    string[] imgURL = dr["urlbd"].ToString().Split('|');
                    sbSitios.AppendLine("<div class='col-sm-2'>");
                    sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                    if (!Editar)
                    {
                        sbSitios.AppendLine("<div class='img-personal circ' style='box - shadow: 5px 5px 5px rgba(113, 110, 110, 0.50); width:100px; height:100px; background:url(" + imgURL[0] + ") no-repeat; background-size: cover; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='verImagenes(\"" + imgURL[0] + "\")'>");
                    }
                    else
                    {
                        sbSitios.AppendLine("<div class='img-personal circ' style='box - shadow: 5px 5px 5px rgba(113, 110, 110, 0.50); width:100px; height:85px; background:url(" + imgURL[0] + ") no-repeat; background-size: cover; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='verImagenes(\"" + imgURL[0] + "\",2,\"" + dr["UrlTemp"].ToString() + "\"," + imgURL[1] + ")'>");
                    }
                    sbSitios.AppendLine("</div>");
                    sbSitios.AppendLine("</a>");
                    sbSitios.AppendLine("</div>");
                }
                sbSitios.AppendLine("</div>");
                string Contenido = sbSitios.ToString();
                if (!Editar)
                {
                    cntImagenes.InnerHtml = Contenido;
                }
                else
                {
                    cntEditarImagenes.InnerHtml = Contenido;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEditarUbicacion_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (lblLatitud.Text != "" && lblLongitud.Text != "")
                {
                    Session["lat"] = lblLatitud.Text;
                    Session["Lon"] = lblLongitud.Text;
                    Response.Redirect("../Mapa.aspx");
                    //Response.Redirect("../Mapa.aspx?lat=" + lblLatitud.Text + "&lon=" + lblLongitud.Text);
                }
                else
                {
                    Session["lat"] = "0";
                    Session["Lon"] = "0";
                    Response.Redirect("../Mapa.aspx");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEditImagenes_Click(object sender, ImageClickEventArgs e)
        {
            pnlImagen.Visible = false;
            pnlUpload.Visible = true;
            CargarImagenes(Session["is"].ToString(), true);
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalImagenes();", true);
        }

        protected void btnEditNombre_Click(object sender, ImageClickEventArgs e)
        {
            txtNombre.Text = lblTitulo.Text;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNombreSitio();", true);
        }

        protected void imgEditEncabezado_Click(object sender, ImageClickEventArgs e)
        {
            txtResumenS.Text = lblResumen.Text;
            txtPrecio.Text = lblCosto.Text;
            txtDireccion.Text = lblDireccion.Text;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalEncabezadoSitio();", true);
        }

        protected void btnEditDescripcion_Click(object sender, ImageClickEventArgs e)
        {
            txtDescripcionS.Text = lblDescripcion.Text;
            txtDescripcionS.Wrap = true;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalDescripcionSitio();", true);
        }

        protected void btnEditDetalles_Click(object sender, ImageClickEventArgs e)
        {
            CargaUniMedidaTiempo();
            txtTelefono.Text = lblTelefono.Text;
            txtHorario.Text = lblHorario.Text;
            string[] Duracion;
            if (lblDuracion.Text != "" && lblDuracion.Text != "--")
            {
                Duracion = lblDuracion.Text.Split(' ');
                txtDuracion.Text = Duracion[0];
                ddlUniTiempo.SelectedValue = Duracion[1];
            }
            txtEquipamentoS.Text = lblEquipamento.Text;
            txtRecomendacionesS.Text = lblRecomendaciones.Text;
            txtIra.Text = lblIra.Text;
            //txtContexto.Text = lblContexto.Text;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalDetallesSitio();", true);
        }

        protected void btnGuardarNombre_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["is"].ToString() != "0")
                {
                    string Campos = "nombre_sitio";
                    string Datos = txtNombre.Text;
                    objWs.pa_Actualiza_General("sitio", Session["is"].ToString(), Campos, Datos, "es");
                    Usuario usuario = (Usuario)Session["usuario"];
                    DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                    Session["dtSitios"] = dtSitios;
                    CargaDatosSitio(Session["is"].ToString());
                }
                else
                {
                    DataTable dtSitiosOld = (DataTable)Session["dtSitios"];
                    int Orden = 1;
                    if (dtSitiosOld.Rows.Count > 0)
                    {
                        List<int> levels = dtSitiosOld.AsEnumerable().Select(al => al.Field<int>("orden")).Distinct().ToList();
                        Orden = levels.Max() + 1;
                    }
                    Usuario usuario = (Usuario)Session["usuario"];
                    string Campos = "nombre_sitio";
                    string Datos = txtNombre.Text;
                    string idCirc = Session["idc"].ToString();
                    string idSitio = objWs.pa_Insert_General("sitio", Session["idc"].ToString(), Campos, Datos, "es");
                    Campos = "orden";
                    Datos = Orden.ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio, Campos, Datos, "es");
                    DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                    Session["dtSitios"] = dtSitios;
                    Session["is"] = idSitio;
                    CargaDatosSitio(idSitio);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarEncabezado_Click(object sender, EventArgs e)
        {
            try
            {
                string Campos = "costo|direccion|descripcion_corta_sitio";
                string Datos = txtPrecio.Text + " " + ddlMoneda.SelectedValue + "|" + txtDireccion.Text + "|" + txtResumenS.Text;
                objWs.pa_Actualiza_General("sitio", Session["is"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                Session["dtSitios"] = dtSitios;
                CargaDatosSitio(Session["is"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarDescripcion_Click(object sender, EventArgs e)
        {
            try
            {
                string Campos = "descripcion_sitio";
                string Datos = txtDescripcionS.Text;
                objWs.pa_Actualiza_General("sitio", Session["is"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                Session["dtSitios"] = dtSitios;
                CargaDatosSitio(Session["is"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                string Campos = "telefono|horario|tiempo_estimado|equipamento|recomendacion|indicaciones";
                string Datos = txtTelefono.Text + "|" + txtHorario.Text + "|" + txtDuracion.Text + " " + ddlUniTiempo.Text + "|" + txtEquipamentoS.Text + "|" + txtRecomendacionesS.Text + "|" + txtIra.Text;
                objWs.pa_Actualiza_General("sitio", Session["is"].ToString(), Campos, Datos, "es");
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                Session["dtSitios"] = dtSitios;
                CargaDatosSitio(Session["is"].ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["fulBand"].ToString() != "0")
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    string imgUrlSave = ViewState["imgUrlSave"].ToString(); //"http://34.215.136.170/circ_tur/media/imgusuario/" + ViewState["NomImagen"].ToString();
                    string imgBD = "media/imgusuario/" + ViewState["NomImagen"].ToString();
                    int Orden = 1;
                    DataTable dtImagenes = (DataTable)ViewState["dtImagenes"];
                    if (dtImagenes.Rows.Count > 0)
                    {
                        List<int> levels = dtImagenes.AsEnumerable().Select(al => al.Field<int>("orden")).Distinct().ToList();
                        Orden = levels.Max() + 1;
                    }
                    string Campos = "fk_sitio|imagen|imagen_img|orden";
                    string Datos = Session["is"].ToString() + "|" + imgUrlSave + "|" + imgBD + "|" + Orden.ToString();
                    objWs.pa_Insert_General("imagen_sitio", Session["is"].ToString(), Campos, Datos, "es");
                    DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                    Session["dtSitios"] = dtSitios;
                    CargaDatosSitio(Session["is"].ToString());
                    pnlImagen.Visible = false;
                    pnlUpload.Visible = true;
                    ViewState["fulBand"] = "0";
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnEliminaImagen_Click(object sender, ImageClickEventArgs e)
        {
            string urlImg = @"c:\inetpub\wwwroot\circ_tur\" + hdUrlImagen.Value.ToString().Replace("/", @"\");
            File.Delete(urlImg);
            objDatosCircuitos.EliminaImagenSitio(hdIdImagen.Value);
            DataTable dtImagenes = objCircuitos.ConsultaImagenesXSitio(Session["is"].ToString());
            int i = 1;
            foreach (DataRow dr in dtImagenes.Rows)
            {
                string Campos = "orden";
                string Datos = i.ToString();
                objWs.pa_Actualiza_General("imagen_sitio", dr["id_imagen_sitio"].ToString(), Campos, Datos, "es");
                i = i + 1;
            }
            DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
            Session["dtSitios"] = dtSitios;
            CargaDatosSitio(Session["is"].ToString());
        }

        protected void btnCancelarImg_Click(object sender, EventArgs e)
        {
            if (ViewState["NomImagen"] != null && ViewState["fulBand"].ToString() != "0")
            {
                string urlImg = ViewState["urlImangen"].ToString();//@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + ViewState["NomImagen"].ToString();
                File.Delete(urlImg);
            }
            ViewState["NomImagen"] = null;
            ViewState["fulBand"] = "1";
            pnlImagen.Visible = false;
            pnlUpload.Visible = true;
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

        protected void btnModificarOrdenImg_Click(object sender, EventArgs e)
        {

        }

        public string GenerarNombreArchivo()
        {
            int longitud = 10;
            Guid miGuid = Guid.NewGuid();
            string Nombre = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            return "IS-" + Nombre;
        }
    }
}