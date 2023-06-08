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

namespace CT.ADIM.WEB
{
    public partial class Sitio : System.Web.UI.Page
    {
        clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
        clsCircuitos objDatosCircuitos = new clsCircuitos();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient wsCorProd = new wsATT.AppToTripWSSoapClient();
        //wsATT_PR.AppToTripWSSoapClient wsCorTur = new wsATT_PR.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMapa();", true);
            if (!IsPostBack)
            {
                try
                {
                    if (Session["usuario"] != null)
                    {
                        CargaCombos();
                        if (Request.QueryString["nc"] != null)
                        {
                            Session["nc"] = Request.QueryString["nc"];
                            Session["idc"] = Request.QueryString["idc"];
                        }

                        if (Request.QueryString["is"] != null || Session["ids"] != null)
                        {
                            if (Request.QueryString["is"] != null)
                            {
                                Session["ids"] = Request.QueryString["is"];
                            }
                            if (Session["ids"].ToString() != "0")
                            {
                                btnImagenesSitio.Enabled = true;
                            }
                            else
                            {
                                btnImagenesSitio.Enabled = false;
                            }
                            if (Session["lstForm"] != null)
                            {
                                CargaFormMapa();
                            }
                            else
                            {
                                RequestSitio();
                            }

                        }
                        else
                        {
                            CargarSitiosXCircuito();
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                }
            }
        }

        #region Botones y listas
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnGuardarSitio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    if (Session["ids"].ToString() != "0")
                    {
                        string Titulo, Direccion, Telefono, Horario, Costo, Duracion, Latitud, Longitud, Equipamento, Recomendacion, IRA, Sinopsis, Descripcion;
                        string Cambios = hdEdit.Value;
                        //if (txtNombreSitio.Text != "" && Cambios.Contains("txtNombreSitio"))
                        //{
                        Titulo = txtNombreSitio.Text;
                        //}
                        //else
                        //{
                        //    Titulo = "";
                        //}

                        //if (txtIDireccionSitio.Text != "" && Cambios.Contains("txtIDireccionSitio"))
                        //{
                        Direccion = txtIDireccionSitio.Text;
                        //}
                        //else
                        //{
                        //    Direccion = "";
                        //}

                        //if (txtTelefonoSitio.Text != "" && Cambios.Contains("txtTelefonoSitio"))
                        //{
                        Telefono = txtTelefonoSitio.Text;
                        //}
                        //else
                        //{
                        //    Telefono = "";
                        //}

                        //if (txtHorarioSitio.Text != "" && Cambios.Contains("txtHorarioSitio"))
                        //{
                        Horario = txtHorarioSitio.Text;
                        //}
                        //else
                        //{
                        //    Horario = "";
                        //}

                        //if (txtCostoSitio.Text != "" && Cambios.Contains("txtCostoSitio"))
                        //{
                        if (txtCostoSitio.Text != "")
                        {
                            Costo = txtCostoSitio.Text + " " + ddlMoneda.SelectedItem;
                        }
                        else
                        {
                            Costo = "";
                        }

                        //}
                        //else
                        //{
                        //    Costo = "";
                        //}

                        //if (txtTiempoSitio.Text != "" && Cambios.Contains("txtTiempoSitio"))
                        //{
                        if (txtTiempoSitio.Text != "")
                        {
                            Duracion = txtTiempoSitio.Text + " " + ddlUniTiempo.SelectedValue;
                        }
                        else
                        {
                            Duracion = "";
                        }
                        //}
                        //else
                        //{
                        //    Duracion = "";
                        //}

                        Latitud = txtLatSitio.Text;
                        Longitud = txtLongSitio.Text;

                        //if (txtEquipamentoSitio.Text != "" && Cambios.Contains("txtEquipamentoSitio"))
                        //{
                        Equipamento = txtEquipamentoSitio.Text;
                        //}
                        //else
                        //{
                        //    Equipamento = "";
                        //}

                        //if (txtRecomendacionesSitio.Text != "" && Cambios.Contains("txtRecomendacionesSitio"))
                        //{
                        Recomendacion = txtRecomendacionesSitio.Text;
                        //}
                        //else
                        //{
                        //    Recomendacion = "";
                        //}

                        //if (txtIra.Text != "" && Cambios.Contains("txtIra"))
                        //{
                        IRA = txtIra.Text;
                        //}
                        //else
                        //{
                        //    IRA = "";
                        //}

                        //if (txtDescCortaSitio.Text != "" && Cambios.Contains("txtDescCortaSitio"))
                        //{
                        Sinopsis = txtDescCortaSitio.Text;
                        //}
                        //else
                        //{
                        //    Sinopsis = "";
                        //}

                        //if (txtDescripcionSitio.Text != "" && Cambios.Contains("txtDescripcionSitio"))
                        //{
                        Descripcion = txtDescripcionSitio.Text;
                        //}
                        //else
                        //{
                        //    Descripcion = "";
                        //}
                        string idc = Session["idc"].ToString();
                        string ids = Session["ids"].ToString();
                        // string lng = Session["LNG"].ToString();
                        string respuesta = wsCorProd.pa_Update_Sitio(Convert.ToInt32(Session["ids"].ToString()), Latitud, Longitud, Sinopsis, Direccion, Costo, Titulo, Descripcion, Equipamento, Recomendacion, IRA, "es", Horario, Duracion, Telefono, Convert.ToInt32(Session["idc"].ToString()), 0);
                        CargarSitiosXCircuito();
                        pnlDetalleSitios.Visible = false;
                        pnlListaSitios.Visible = true;
                    }
                    else
                    {
                        string Costo;
                        string Duracion;
                        if (txtCostoSitio.Text != "")
                        {
                            Costo = txtCostoSitio.Text + " " + ddlMoneda.SelectedItem;
                        }
                        else
                        {
                            Costo = "";
                        }
                        if (txtTiempoSitio.Text != "")
                        {
                            Duracion = txtTiempoSitio.Text + " " + ddlUniTiempo.SelectedValue;
                        }
                        else
                        {
                            Duracion = "";
                        }
                        string idc = Session["idc"].ToString();
                        string respuesta = wsCorProd.pa_Insert_Sitio(txtLatSitio.Text, txtLongSitio.Text, txtIDireccionSitio.Text, Costo, txtNombreSitio.Text, txtDescCortaSitio.Text, txtDescripcionSitio.Text, txtEquipamentoSitio.Text, txtRecomendacionesSitio.Text, txtIra.Text, "es", txtHorarioSitio.Text, Duracion, txtTelefonoSitio.Text, Convert.ToInt32(Session["idc"].ToString()), 0);
                        CargarSitiosXCircuito();
                        pnlDetalleSitios.Visible = false;
                        pnlListaSitios.Visible = true;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnVolverSitio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    CargarSitiosXCircuito();
                    pnlDetalleSitios.Visible = false;
                    pnlListaSitios.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnVerSitio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    Session["ids"] = null;
                    Response.Redirect("Index.aspx?ini=1");
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    if (fulImagenes.HasFile)
                    {
                        string ids = Session["ids"].ToString();
                        string idc = Session["idc"].ToString();
                        int gvRows = gvImagenes.Rows.Count;
                        if (gvRows < 5)
                        {
                            lblMensajeImg.Visible = false;
                            DataTable dtImagenes = new DataTable();
                            int Orden;
                            if (Session["Orden"] != null)
                            {
                                Orden = Convert.ToInt32(Session["Orden"]) + 1;
                                Session["Orden"] = Orden;
                            }
                            else
                            {
                                Orden = 1;
                                Session["Orden"] = Orden;
                            }
                            if (Session["dtImagenes"] != null)
                            {
                                dtImagenes = (DataTable)Session["dtImagenes"];
                            }
                            else
                            {
                                CreaDtImagenes();
                                dtImagenes = (DataTable)Session["dtImagenes"];
                            }

                            lblMensajeImg.Visible = false;
                            int tamanio = fulImagenes.PostedFile.ContentLength;
                            string Tipo = fulImagenes.PostedFile.ContentType;
                            if (tamanio < 4194304)
                            {
                                if (Tipo == "image/png" || Tipo == "image/jpeg")
                                {
                                    //Imagen en byte[]
                                    /*byte[] ImgOrg = new byte[tamanio];
                                    fulImagenes.PostedFile.InputStream.Read(ImgOrg, 0, tamanio);
                                    Bitmap ImgOrgBin = new Bitmap(fulImagenes.PostedFile.InputStream);*/
                                    //
                                    lblMensajeImg.Visible = false;
                                    string urlImagen = @"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + fulImagenes.FileName;
                                    fulImagenes.SaveAs(urlImagen);
                                    string urlImgBd = "media/imgusuario/" + fulImagenes.FileName;
                                     //string urlAPP = "http://akyvoy.com/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                                    string urlAPP = "http://35.163.51.145/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                                    InsRowDtImagenes(txtNombreArchivo.Text, (dtImagenes.Rows.Count + 1).ToString(), urlImagen, urlImgBd);
                                    DataTable respuesta = wsCorProd.pa_Insert_ImagenSitio(urlAPP, urlImgBd, Convert.ToInt32(Orden), Convert.ToInt32(ids));
                                    dtImagenes = objCircuitos.ConsultaImagenesXSitio(Session["ids"].ToString());
                                    gvImagenes.DataSource = dtImagenes;
                                    gvImagenes.DataBind();
                                }
                                else
                                {
                                    lblMensajeImg.Visible = true;
                                    lblMensajeImg.Text = "Tipo de archivo inválido";
                                }
                            }
                            else
                            {
                                lblMensajeImg.Visible = true;
                                lblMensajeImg.Text = "La imágen sobrepasa el tamaño permitido (4 Megabytes)";
                            }
                            if (dtImagenes.Rows.Count > 0)
                            {
                                lblMensajeImg.Visible = false;
                                btnGuardarImagenes.Visible = true;
                            }
                        }
                        else
                        {
                            lblMensajeImg.Visible = true;
                            lblMensajeImg.Text = "Solo se permiten 5 imagenes por sitio.";
                        }

                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    DataTable dtRespuesta = wsCorProd.pa_Delete_Sitio(Convert.ToInt32(Session["ids"]));
                    string respuesta = dtRespuesta.Rows[0]["respuesta"].ToString();

                    CargarSitiosXCircuito();
                    pnlDetalleSitios.Visible = false;
                    pnlListaSitios.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnImagenesSitio_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    pnlImagenes.Visible = true;
                    if (Session["ids"].ToString() != null && Session["ids"].ToString() != "0")
                    {
                        DataTable dtImagenesExiste = objCircuitos.ConsultaImagenes(Session["ids"].ToString());
                        DataTable dtImagenes = new DataTable();
                        dtImagenes.Rows.Clear();
                        dtImagenes = (DataTable)Session["dtImagenes"];
                        dtImagenes = dtImagenesExiste.Copy();

                        if (dtImagenes.Rows.Count > 0)
                        {
                            Session["dtImagenes"] = dtImagenes;
                        }
                        else
                        {
                            btnGuardarImagenes.Visible = false;
                        }
                        if (Session["dtImagenes"] != null)
                        {
                            gvImagenes.DataSource = dtImagenes;
                            gvImagenes.DataBind();
                            lblMensajeImg.Visible = false;
                        }
                        else
                        {
                            lblMensajeImg.Visible = true;
                            btnGuardarImagenes.Visible = false;
                        }

                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnEliminarSitio_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    lblEliminar.Text = "Está seguro que desea eliminar este sitio?";
                    Session["ve"] = "c";
                    mpeUsuario.Show();
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnVerMapa_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    List<string> lstFormulario = new List<string>();
                    lstFormulario.Add(txtNombreSitio.Text);
                    lstFormulario.Add(txtIDireccionSitio.Text);
                    lstFormulario.Add(txtTelefonoSitio.Text);
                    lstFormulario.Add(txtCostoSitio.Text);
                    lstFormulario.Add(txtTiempoSitio.Text);
                    lstFormulario.Add(txtHorarioSitio.Text);
                    lstFormulario.Add(txtEquipamentoSitio.Text);
                    lstFormulario.Add(txtRecomendacionesSitio.Text);
                    lstFormulario.Add(txtDescripcionSitio.Text);
                    lstFormulario.Add(txtIra.Text);
                    lstFormulario.Add(txtDescCortaSitio.Text);
                    lstFormulario.Add(ddlMoneda.SelectedValue);
                    lstFormulario.Add(ddlUniTiempo.SelectedValue);
                    Session["lstForm"] = lstFormulario;
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "irMapa();", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnVolver1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    CargarSitiosXCircuito();
                    pnlDetalleSitios.Visible = false;
                    pnlListaSitios.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion

        #region Motodos generales
        public void CargarSitiosXCircuito()
        {
            try
            {
                DataTable dtSitios = ConsultaSitiosXCircuito(Session["idc"].ToString());
                lblTtlCircuitoSitio.Text = Session["nc"].ToString().ToUpper();
                Session["dtSitios"] = dtSitios;
                StringBuilder sbSitios = new StringBuilder();
                //sbSitios.AppendLine("<div class='row text-center text-lg-left'>");
                //sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                //sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background:url(MEDIA/IMG/Btn_Nuevo.png) no-repeat center' onclick='redirectsitios(0)'></div></a>");
                //sbSitios.AppendLine("</div>");
                sbSitios.AppendLine("<div class='row text-center text-lg-left'>");
                sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                // sbCircuitos.AppendLine("<div align=center><h3> Tus Circuitos. </h3></div><br/>");
                sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                sbSitios.AppendLine("<div class='img-fluid img-thumbnail cargando' style='height:250px; width:250px; background:url(MEDIA/IMG/Btn_Nuevo.png) no-repeat; background-position-x: center; background-position-y: center; background-color:white' onclick='redirectsitios(0)'></div>");
                sbSitios.AppendLine("</a>");
                //sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:250px; width:250px;' onclick='redirect(0)'><div style='width:100%; height:50px; background-color:white;border-radius:10px;display: flex;justify-content: center;align-items: center' align='center'><h4>NUEVO</h4></div></div></a>");
                sbSitios.AppendLine("</div>");
                foreach (DataRow dr in dtSitios.Rows)
                {
                    sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6' style='display:table-cell'>");
                    sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                    sbSitios.AppendLine("<div class='img-fluid img-thumbnail cargando' style='height:250px; width:250px; background:url(MEDIA/IMG/PlantillaATT.png) no-repeat; background-size: contain; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>");
                    sbSitios.AppendLine("<div style='width:100%; height:25px; padding-top:25px background-color:white;border-radius:10px;display: flex; vertical-align:middle;justify-content: center;align-items: center; display:inline-block; border:1px solid whitesmoke' align='center'>");
                    sbSitios.AppendLine("<div style='display:inline-block'><h6>" + dr["nombre_sitio"].ToString().ToUpper() + "</h6></div>");
                    sbSitios.AppendLine("</div>");
                    sbSitios.AppendLine("</div>");
                    sbSitios.AppendLine("</a>");
                    // sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:250px; width:250px;' onclick='redirect(" + dr["id_circuito"].ToString() + ")'><h4>" + dr["nombre_circuito"].ToString() + "</h4></div></a>");
                    sbSitios.AppendLine("</div>");
                    //sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                    //sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background-image:url(MEDIA/IMG/Btn_Circuitos.png)' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>" + dr["nombre_sitio"].ToString() + "</div></a>");
                    //sbSitios.AppendLine("</div>");
                }
                sbSitios.AppendLine("</div>");
                string Contenido = sbSitios.ToString();
                cntSitiosXCircuito.InnerHtml = Contenido;
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
                //return objCircuitos.ConsultaSitios(Session["LNG"].ToString(), IdCircuito);
                return objCircuitos.ConsultaSitios("es", IdCircuito);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        public void RequestSitio()
        {
            try
            {
                CargaDatosSitio(Session["ids"].ToString());
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargaFormMapa()
        {
            try
            {
                pnlDetalleSitios.Visible = true;
                pnlListaSitios.Visible = false;
                string lat = "";
                string lng = "";
                if (Request.QueryString["lat"] != null && Request.QueryString["lng"] != null)
                {
                    lat = Request.QueryString["lat"].ToString();
                    lng = Request.QueryString["lng"].ToString();
                }
                if (Session["ids"].ToString() != "0")
                {
                    List<string> lstForm = (List<string>)Session["lstForm"];
                    CargaDatosSitio(Session["ids"].ToString());
                    txtLongSitio.Text = lng;
                    txtLatSitio.Text = lat;
                    txtNombreSitio.Text = lstForm[0];
                    txtIDireccionSitio.Text = lstForm[1];
                    txtTelefonoSitio.Text = lstForm[2];
                    txtCostoSitio.Text = lstForm[3];
                    txtTiempoSitio.Text = lstForm[4];
                    txtHorarioSitio.Text = lstForm[5];
                    txtEquipamentoSitio.Text = lstForm[6];
                    txtRecomendacionesSitio.Text = lstForm[7];
                    txtDescripcionSitio.Text = lstForm[8];
                    txtIra.Text = lstForm[9];
                    txtDescCortaSitio.Text = lstForm[10];
                    ddlMoneda.SelectedValue = lstForm[11];
                    ddlUniTiempo.SelectedValue = lstForm[12];
                }
                else
                {
                    lblTtlCircuitoNuevo.Text = Session["nc"].ToString().ToUpper();
                    lblTtlSitioDtll.Text = "[Nuevo]";
                    List<string> lstForm = (List<string>)Session["lstForm"];
                    txtNombreSitio.Text = lstForm[0];
                    txtIDireccionSitio.Text = lstForm[1];
                    txtTelefonoSitio.Text = lstForm[2];
                    txtCostoSitio.Text = lstForm[3];
                    txtTiempoSitio.Text = lstForm[4];
                    txtHorarioSitio.Text = lstForm[5];
                    txtEquipamentoSitio.Text = lstForm[6];
                    txtRecomendacionesSitio.Text = lstForm[7];
                    txtDescripcionSitio.Text = lstForm[8];
                    txtIra.Text = lstForm[9];
                    txtDescCortaSitio.Text = lstForm[10];
                    ddlMoneda.SelectedValue = lstForm[11];
                    ddlUniTiempo.SelectedValue = lstForm[12];
                    txtLongSitio.Text = lng;
                    txtLatSitio.Text = lat;
                }
                Session["lstForm"] = null;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargaCombos()
        {
            try
            {
                DataTable dtDuracion = wsCorProd.pa_Consulta_Generica("Duracion", "es");
                ddlUniTiempo.DataSource = dtDuracion;
                ddlUniTiempo.DataTextField = "texto";
                ddlUniTiempo.DataValueField = "texto";
                ddlUniTiempo.DataBind();

                DataTable dtMoneda = wsCorProd.pa_Consulta_Generica_Moneda("Moneda");
                ddlMoneda.DataSource = dtMoneda;
                ddlMoneda.DataTextField = "texto";
                ddlMoneda.DataValueField = "valor";
                ddlMoneda.DataBind();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargaDatosSitio(string idSitio)
        {
            try
            {
                //CargaPaises();
                pnlDetalleSitios.Visible = true;
                pnlListaSitios.Visible = false;
                string Expresion = "id_sitio = " + idSitio;
                DataTable dtSitios = (DataTable)Session["dtSitios"];
                DataRow[] dr = dtSitios.Select(Expresion);
                lblTtlCircuitoNuevo.Text = Session["nc"].ToString().ToUpper();
                if (dr.Length > 0)
                {
                    if (dr[0]["tiempo_estimado"].ToString() != "")
                    {
                        string[] TiempoEstimado = dr[0]["tiempo_estimado"].ToString().Split(' ');
                        string Tiempo = TiempoEstimado[0];
                        string UniTiempo = TiempoEstimado[1];
                        if (UniTiempo != "")
                        {
                            ddlUniTiempo.SelectedValue = UniTiempo;
                        }
                        txtTiempoSitio.Text = Tiempo;
                    }

                    if (dr[0]["costo"].ToString() != "")
                    {
                        string[] Costo = dr[0]["costo"].ToString().Split(' ');
                        string Valor = Costo[0];
                        string Moneda = Costo[1];
                        if (Moneda != "")
                        {
                            ddlMoneda.SelectedValue = Moneda;
                        }

                        txtCostoSitio.Text = Valor;
                    }

                    lblTtlSitioDtll.Text = dr[0]["nombre_sitio"].ToString().ToUpper();
                    txtNombreSitio.Text = dr[0]["nombre_sitio"].ToString();
                    txtLatSitio.Text = dr[0]["latitud"].ToString();
                    txtLongSitio.Text = dr[0]["longitud"].ToString();
                    txtIDireccionSitio.Text = dr[0]["direccion"].ToString();
                    txtTelefonoSitio.Text = dr[0]["telefono"].ToString();

                    //txtPaisSitio.Text = dr[0]["pais"].ToString();
                    //txtEdadSitio.Text = dr[0]["edad"].ToString();
                    txtHorarioSitio.Text = dr[0]["horario"].ToString();
                    //txtCiudadSitio.Text = dr[0]["Ciudad"].ToString();
                    txtRecomendacionesSitio.Text = dr[0]["Recomendacion"].ToString();
                    txtEquipamentoSitio.Text = dr[0]["Equipamento"].ToString();

                    txtDescripcionSitio.Text = dr[0]["Descripcion_sitio"].ToString();
                    txtIra.Text = dr[0]["Indicaciones"].ToString();
                    txtDescCortaSitio.Text = dr[0]["descripcion_corta_sitio"].ToString();
                }
                else
                {
                    lblTtlSitioDtll.Text = "[Nuevo]";
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CreaDtImagenes()
        {
            try
            {
                DataTable dtImagenes = new DataTable();

                dtImagenes.Columns.Add("id_imagen_sitio");
                dtImagenes.Columns.Add("Nombre");
                dtImagenes.Columns.Add("Orden");
                dtImagenes.Columns.Add("UrlTemp");
                dtImagenes.Columns.Add("urlBD");

                Session["dtImagenes"] = dtImagenes;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void GuardarImagenes()
        {
            try
            {
                string ids = Session["ids"].ToString();
                string idc = Session["idc"].ToString();
                foreach (GridViewRow gvr in gvImagenes.Rows)
                {
                    TextBox txtOrden = gvr.FindControl("txtOrden") as TextBox;
                    string IdImagen = gvImagenes.DataKeys[gvr.RowIndex]["id_imagen_sitio"].ToString();
                    string urlImagen = gvImagenes.DataKeys[gvr.RowIndex]["UrlTemp"].ToString();
                    string Nombre = gvImagenes.DataKeys[gvr.RowIndex]["Nombre"].ToString();
                    string Orden = gvImagenes.DataKeys[gvr.RowIndex]["Orden"].ToString();
                    DataTable respuesta = wsCorProd.pa_Update_ImagenSitio(IdImagen, Convert.ToInt32(txtOrden.Text), Convert.ToInt32(ids));
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public bool ValidarOrden()
        {
            try
            {
                bool ban = false;
                string Orden;
                string[] arrOrden = new string[5];
                foreach (GridViewRow gvr in gvImagenes.Rows)
                {
                    System.Web.UI.WebControls.TextBox txtOrden = (System.Web.UI.WebControls.TextBox)gvImagenes.Rows[gvr.RowIndex].FindControl("txtOrden");
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

        public void CargaImagenBD(string url)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidaSesion()
        {
            if (Session["Usuario"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region Otros Eventos
        public DataTable InsRowDtImagenes(string Nombre, string Orden, string UrlTemp, string urlBD)
        {
            try
            {
                DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                DataRow dr = dtImagenes.NewRow();
                dr["id_imagen_sitio"] = "-1";
                dr["Nombre"] = Nombre;
                dr["Orden"] = Orden;
                dr["UrlTemp"] = UrlTemp;
                dr["urlBD"] = urlBD;
                dtImagenes.Rows.Add(dr);

                return dtImagenes;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        protected void rbPerfil_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrSelectedRow in gvImagenes.Rows)
                {
                    ((System.Web.UI.WebControls.RadioButton)gvrSelectedRow.FindControl("rbPerfil")).Checked = false;
                }
                System.Web.UI.WebControls.RadioButton rbButton = (System.Web.UI.WebControls.RadioButton)sender;
                GridViewRow gvRow = (GridViewRow)rbButton.NamingContainer;
                ((System.Web.UI.WebControls.RadioButton)gvRow.FindControl("rbPerfil")).Checked = true;
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Eliminar")
                {
                    string idImagen = gvImagenes.DataKeys[Convert.ToInt32(e.CommandArgument)]["id_imagen_sitio"].ToString();
                    string urlImagenBD = gvImagenes.DataKeys[Convert.ToInt32(e.CommandArgument)]["UrlTemp"].ToString();
                    string urlImagenFormato;
                    if (urlImagenBD.Contains(@"c:\"))
                    {
                        urlImagenFormato = urlImagenBD;

                    }
                    else
                    {
                        urlImagenFormato = @"c:\inetpub\wwwroot\circ_tur\" + urlImagenBD.Replace("/", @"\");
                    }
                    objDatosCircuitos.EliminaImagenSitio(idImagen);
                    File.Delete(urlImagenFormato);
                    DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                    DataRow dr = dtImagenes.Rows[Convert.ToInt32(e.CommandArgument)];
                    dtImagenes.Rows.Remove(dr);
                    if (dtImagenes.Rows.Count == 0)
                    {
                        lblMensajeImg.Visible = true;
                        btnGuardarImagenes.Visible = false;
                        gvImagenes.DataSource = dtImagenes;
                        gvImagenes.DataBind();
                    }
                    else
                    {
                        int i = 0;
                        foreach (DataRow drn in dtImagenes.Rows)
                        {
                            dtImagenes.Rows[i]["Orden"] = (i + 1).ToString();
                            i++;
                        }
                        Session["dtImagenes"] = dtImagenes;
                        gvImagenes.DataSource = dtImagenes;
                        gvImagenes.DataBind();
                    }
                    Session["dtImagenes"] = dtImagenes;
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                }
                if (e.CommandName == "Ver")
                {
                    string UrlTemp = gvImagenes.DataKeys[Convert.ToInt32(e.CommandArgument)]["UrlTemp"].ToString();

                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnGuardarImagenes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                if (ValidarOrden() == false)
                {
                    lblMensajeImg.Visible = false;
                    dtImagenes.Rows.Clear();
                    gvImagenes.DataSource = dtImagenes;
                    Session["dtImagenes"] = dtImagenes;
                    GuardarImagenes();
                }
                else
                {
                    lblMensajeImg.Visible = true;
                    lblMensajeImg.Text = "ERROR! Orden repetido.";
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                    //Session["dtImagenes"] = null;
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void gvImagenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string idImagen = gvImagenes.DataKeys[e.Row.RowIndex]["id_imagen_sitio"].ToString();
                    if (idImagen == "-1")
                    {
                        System.Text.Encoding enc = System.Text.Encoding.ASCII;
                        string ImagenPerfil = gvImagenes.DataKeys[e.Row.RowIndex]["urlBD"].ToString();
                        System.Web.UI.WebControls.Image imgPrevia = (Image)e.Row.FindControl("imgPrevia");
                        imgPrevia.ImageUrl = ImagenPerfil;
                    }
                    else
                    {
                        string ImagenPerfil = gvImagenes.DataKeys[e.Row.RowIndex]["UrlTemp"].ToString();
                        System.Web.UI.WebControls.Image imgPrevia = (Image)e.Row.FindControl("imgPrevia");
                        imgPrevia.ImageUrl = ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion





    }
}