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

namespace CT.ADIM.WEB
{
    public partial class Index : System.Web.UI.Page
    {
        clsCircuitos objCircuitosInd = new clsCircuitos();
        clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsPQR.wsPQRSoapClient objPQR = new wsPQR.wsPQRSoapClient();
        /// <summary>
        /// Producción
        /// </summary>
        wsATT.AppToTripWSSoapClient wsCorProd = new wsATT.AppToTripWSSoapClient();
       /// <summary>
       /// Pruebas
       /// </summary>
        //wsATT_PR.AppToTripWSSoapClient wsCor= new wsATT_PR.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDescripcion.MaxLength = 400;

                if (Session["usuario"] != null)
                {
                    CargaCombos();
                    Usuario usuario = (Usuario)Session["Usuario"];
                    if (Request.QueryString["ini"] != null && Request.QueryString["ini"].ToString() == "1")
                    {
                        CargarCircuitos();
                        CargarPaises();
                        CargarEdades();
                    }
                    else if (Request.QueryString["ic"] != null)
                    {
                        Session["idc"] = Request.QueryString["ic"];
                        RequestCircuito();
                        CargarPaises();
                    }
                    else if (Request.QueryString["is"] != null)
                    {
                        Session["ids"] = Request.QueryString["is"];
                        RequestSitio();
                        CargarEdades();

                    }
                    else
                    {
                        RequestInicial();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
        }

        #region Eventos Botones y Listas
        protected void btnCircuitos_Click(object sender, ImageClickEventArgs e)
        {
            CargarCircuitos();
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (ValidaSesion())
            {
                CargarCircuitos();
                Session["idc"] = null;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
            }
        }

        protected void btnGuardarCircuito_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    if (ViewState["urlImagen"] == null)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalBt();", true);
                    }
                    else
                    {
                        int RangoEdad = 0;

                        if (ddlCategoria.SelectedIndex > 0)
                        {
                            Usuario usuario = (Usuario)Session["Usuario"];
                            if (Session["idc"].ToString() != "0")
                            {
                                string Duracion;
                                if (txtTiempoEstimado.Text != "")
                                {
                                    Duracion = txtTiempoEstimado.Text + " " + ddlUniTiempo.SelectedValue;
                                }
                                else
                                {
                                    Duracion = "";
                                }
                                var resp = wsCorProd.pa_Update_Circuito(Convert.ToInt32(Session["idc"]), txtNombre.Text, txtContexto.Text, txtDescCortaCircuito.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtEquipamentos.Text, Convert.ToInt32(ddlEdad.SelectedValue), Duracion, "es", Convert.ToInt32(ddlCategoria.SelectedValue), ViewState["urlImagen"].ToString(), ViewState["urlImagenBD"].ToString(), Convert.ToInt32(txtCostoCliente.Text), Convert.ToInt32(ddlMoneda.SelectedValue));
                                CargarCircuitos();
                            }
                            else
                            {
                                string Duracion;
                                if (txtTiempoEstimado.Text != "")
                                {
                                    Duracion = txtTiempoEstimado.Text + " " + ddlUniTiempo.SelectedValue;
                                }
                                else
                                {
                                    Duracion = "";
                                }
                                if (ddlEdad.SelectedIndex > 0)
                                {
                                    RangoEdad = Convert.ToInt32(ddlEdad.SelectedValue);
                                }

                                var resp = wsCorProd.pa_Insert_Circuito(txtNombre.Text, txtContexto.Text, txtDescCortaCircuito.Text, txtDescripcion.Text, txtRecomendaciones.Text, txtEquipamentos.Text, RangoEdad, Duracion, "es", Convert.ToInt32(ddlCategoria.SelectedValue), Convert.ToInt32(ddlCiudad.SelectedValue), Convert.ToInt32(usuario.Id_Usuario), ViewState["urlImagen"].ToString(), ViewState["urlImagenBD"].ToString(), Convert.ToInt32(txtCostoCliente.Text), Convert.ToInt32(ddlMoneda.SelectedValue));
                                CargarCircuitos();
                            }
                        }
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

        protected void btnEliminarCircuito_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    lblEliminar.Text = "Está seguro que desea eliminar este circuito?";
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

        protected void btnVolverSitio_Click(object sender, EventArgs e)
        {
            CargaDatosCircuito(Session["idc"].ToString());
            Session["ids"] = null;
        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    if (Session["ve"].ToString() == "s")
                    {
                        EliminarSitio();
                    }

                    if (Session["ve"].ToString() == "c")
                    {
                        EliminarCircuito();
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

        protected void btnVerSitio_Click(object sender, EventArgs e)
        {
            if (ValidaSesion())
            {
                Response.Redirect("Sitio.aspx?idc=" + Session["idc"].ToString() + "&nc=" + Session["ttlCircuito"].ToString());
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
            }
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilUsuario.aspx");
        }

        protected void btnValidaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ValidaUsuario.aspx", true);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnOrdenarSitios_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    lblMensajeOrden.Text = "";
                    DataTable dtSitios = objCircuitos.ConsultaSitios("es", Session["idc"].ToString());
                    gvSitios.DataSource = dtSitios;
                    gvSitios.DataBind();
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalOrden();", true);
                    //ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                    //Response.Redirect("Login.aspx");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void btnGuardarOrden_Click(object sender, EventArgs e)
        {
            // ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
            try
            {
                if (ValidaSesion())
                {
                    bool val = ValidarOrden();
                    if (val == true)
                    {
                        lblMensajeOrden.Text = "Orden Duplicado!";
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
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

                            // objCircuitosInd.ActualizaOrdenSitios(IdSitio, Orden);
                            //   ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "cerrarpopup();", false);
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

        protected void btnImagen_Click(object sender, EventArgs e)
        {
            if (ValidaSesion())
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalBt();", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
            }
        }

        protected void btnGuardarImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    if (fulImagenes.HasFile)
                    {
                        if (Session["idc"].ToString() == "0")
                        {
                           // string urlImagen = "http://akyvoy.com/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                            string urlImagen = "http://35.163.51.145/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                            string urlImgBd = "media/imgusuario/" + fulImagenes.FileName;
                            fulImagenes.SaveAs(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + fulImagenes.FileName);
                            ViewState["urlImagen"] = urlImagen;
                            ViewState["urlImagenBD"] = urlImgBd;
                            lblMensajePU.Text = "Se ha asignado la imágen a tu circuito, debes guardar para aplicar los cambios.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                        }
                        else
                        {
                            //string urlImagen = "http://akyvoy.com/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                             string urlImagen = "http://35.163.51.145/circ_tur/media/imgusuario/" + fulImagenes.FileName;
                            string urlImgBd = "media/imgusuario/" + fulImagenes.FileName;
                            fulImagenes.SaveAs(@"c:\inetpub\wwwroot\circ_tur\media\imgusuario\" + fulImagenes.FileName);
                            ViewState["urlImagen"] = urlImagen;
                            ViewState["urlImagenBD"] = urlImgBd;
                            wsCorProd.pa_Update_Imagen_Circuito(urlImagen, urlImgBd, Convert.ToInt32(Session["idc"].ToString()));
                            lblMensajePU.Text = "Se ha asignado la imágen a tu circuito.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalMsg();", true);
                        }
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

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaSesion())
                {
                    bool banImg = true;
                    bool banValGrl = true;
                    string idCircuito = ViewState["idCircuito"].ToString();
                    string Expresion = "id_circuito = " + idCircuito;
                    StringBuilder Mensaje = new StringBuilder();
                    StringBuilder MensajeImg = new StringBuilder();
                    DataTable dtSitios = ConsultaSitiosXCircuito(idCircuito);
                    DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
                    DataRow[] dr = dtCircuitos.Select(Expresion);
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
                        lblMensajeImg.Text = MensajeImg.ToString();
                        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalImg();", true);
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
                            lblMensajeNot.Text = "Ya puedes ver tu circuito en la app de App To Trip.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);

                        }
                        else if (ViewState["estCircuito"].ToString() == "3")
                        {
                            objCircuitosInd.ActualizaEstadoCircuito(idCircuito, "2");
                            objPQR.crearPQRPr(idCircuito, "C");
                            lblMensajeNot.Text = "Se ha enviado la solicitud de activación.";
                            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalNot();", true);
                        }
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

        protected void ddlEdad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEdad.SelectedIndex > 0)
            {
                txtValidaEdad.Text = "1";
            }
            else
            {
                txtValidaEdad.Text = "";
            }
        }

        protected void ddlCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCiudad.SelectedIndex > 0)
            {
                txtValidaCiudad.Text = "1";
            }
            else
            {
                txtValidaCiudad.Text = "";
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoria.SelectedIndex > 0)
            {
                txtValidaCategoria.Text = "1";
            }
            else
            {
                txtValidaCategoria.Text = "";
            }
        }

        protected void ddlPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlPais.SelectedIndex > 0)
                {
                    txtValidaPais.Text = "1";
                    CargarCiudades(ddlPais.SelectedValue);
                }
                else
                {
                    txtValidaPais.Text = "";
                    ddlCiudad.Items.Clear();
                    ddlCiudad.Items.Insert(0, "Ciudad...");
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion

        #region Metodos Circuitos
        public DataTable ConsultaCircuitos()
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", usuario.Id_Usuario);

                //DataTable dtCircuitos = objCircuitos.ConsultaCircuitos(Session["LNG"].ToString(), usuario.Id_Usuario);
                return dtCircuitos;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
            }
        }

        public void CargaDatosCircuito(string idCircuito)
        {
            try
            {
                CargarPaises();
                CargaCategorias();
                CargarEdades();
                string Expresion = "id_circuito = " + idCircuito;
                DataTable dtCircuitos = (DataTable)Session["dtCircuitos"];
                DataRow[] dr = dtCircuitos.Select(Expresion);
                ViewState["idCircuito"] = idCircuito;

                if (dr.Length > 0)
                {
                    if (dr[0]["estado_circuito"].ToString() == "0")
                    {
                        ViewState["estCircuito"] = dr[0]["estado_circuito"].ToString();
                        btnActivar.Text = "Solicitar Preview";
                    }
                    else if (dr[0]["estado_circuito"].ToString() == "3")
                    {
                        ViewState["estCircuito"] = dr[0]["estado_circuito"].ToString();
                        btnActivar.Text = "Activar";
                    }
                    else
                    {
                        btnActivar.Visible = false;
                    }
                    if (dr[0]["tiempo_estimado"].ToString() != "")
                    {
                        string[] TiempoEstimado = dr[0]["tiempo_estimado"].ToString().Split(' ');
                        string Tiempo = TiempoEstimado[0];
                        string UniTiempo = TiempoEstimado[1];
                        txtTiempoEstimado.Text = Tiempo;
                        ddlUniTiempo.SelectedValue = UniTiempo;
                    }
                    else
                    {
                        txtTiempoEstimado.Text = dr[0]["tiempo_estimado"].ToString();
                    }
                    CargarCiudades(dr[0]["id_pais"].ToString());
                    ddlCiudad.SelectedValue = dr[0]["fk_ciudad"].ToString();
                    txtValidaCiudad.Text = dr[0]["fk_ciudad"].ToString();
                    ddlPais.SelectedValue = dr[0]["id_pais"].ToString();
                    txtValidaPais.Text = dr[0]["id_pais"].ToString();
                    btnVerSitio.Enabled = true;
                    txtNombre.Text = dr[0]["nombre_circuito"].ToString();
                    txtDescripcion.Text = dr[0]["descripcion_circuito"].ToString();
                    txtEquipamentos.Text = dr[0]["Equipamento"].ToString();

                    //txtHorario.Text = dr[0][5].ToString();
                    if (dr[0]["rango"].ToString() != "0")
                    {
                        ddlEdad.SelectedValue = dr[0]["id_rango_edad"].ToString();
                        txtValidaEdad.Text = dr[0]["id_rango_edad"].ToString();
                    }
                    if (dr[0]["otra_moneda"].ToString() != "0")
                    {
                        ddlMoneda.SelectedValue = dr[0]["otra_moneda"].ToString();
                    }
                    txtCostoCliente.Text = dr[0]["valor"].ToString();
                    txtRecomendaciones.Text = dr[0]["Recomendacion"].ToString();
                    ddlCategoria.SelectedValue = dr[0]["fk_categoria"].ToString();
                    txtValidaCategoria.Text = dr[0]["fk_categoria"].ToString();
                    txtDescCortaCircuito.Text = dr[0]["descripcion_corta_circuito"].ToString();
                    txtContexto.Text = dr[0]["contexto"].ToString();

                    lblTituloCircuito.Text = dr[0][1].ToString().ToUpper();
                    Session["ttlCircuito"] = dr[0][1].ToString();
                    ViewState["urlImagen"] = dr[0]["imagen"].ToString();
                    ViewState["urlImagenBD"] = dr[0]["imagen_img"].ToString();
                    btnActivar.Visible = true;
                    btnOrdenarSitios.Visible = true;
                }
                else
                {
                    lblTituloCircuito.Text = "[NUEVO]";
                    btnVerSitio.Visible = false;
                    btnActivar.Visible = false;
                    btnOrdenarSitios.Visible = false;
                }

            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        //Evento de boton nuevo (+) circuito
        public void RequestCircuito()
        {
            try
            {
                //DataTable dtSitios = ConsultaSitiosXCircuito(Session["idc"].ToString());
                //Session["dtSitios"] = dtSitios;
                CargaDatosCircuito(Session["idc"].ToString());
                //CargarSitiosXCircuito(dtSitios);
                //CargaCategorias();
                cntCircuitoDtlle.Visible = true;
                cntBotones.Visible = false;
                cntCircuitos.Visible = false;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void CargarCircuitos()
        {
            try
            {
                string urlImagen;
                divTtlCircuitos.Visible = true;
                cntCircuitoDtlle.Visible = false;
                // cntSitiosXCircuito.Visible = false;
                DataTable dtCircuitos = ConsultaCircuitos();
                Session["dtCircuitos"] = dtCircuitos;
                cntBotones.Visible = false;
                cntCircuitos.Visible = true;
                StringBuilder sbCircuitos = new StringBuilder();
                sbCircuitos.AppendLine("<div class='row text-center text-lg-left'>");
                sbCircuitos.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                // sbCircuitos.AppendLine("<div align=center><h3> Tus Circuitos. </h3></div><br/>");
                sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                sbCircuitos.AppendLine("<div class='img-fluid img-thumbnail cargando' style='height:250px; width:250px; background:url(MEDIA/IMG/Btn_Nuevo.png) no-repeat; background-position-x: center; background-position-y: center; background-color:white' onclick='redirect(0)'></div>");
                sbCircuitos.AppendLine("</a>");
                //sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:250px; width:250px;' onclick='redirect(0)'><div style='width:100%; height:50px; background-color:white;border-radius:10px;display: flex;justify-content: center;align-items: center' align='center'><h4>NUEVO</h4></div></div></a>");
                sbCircuitos.AppendLine("</div>");
                foreach (DataRow dr in dtCircuitos.Rows)
                {
                    urlImagen = dr["imagen"].ToString();
                    sbCircuitos.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6' style='display:table-cell'>");
                    sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'>");
                    sbCircuitos.AppendLine("<div class='img-fluid img-thumbnail cargando' style='height:250px; width:250px; background:url(" + urlImagen + ") no-repeat; background-size: contain; background-position-y:center; background-color:white; display:table-cell; vertical-align:bottom' onclick='redirect(" + dr["id_circuito"].ToString() + ")'>");
                    sbCircuitos.AppendLine("<div style='width:100%; height:25px; padding-top:25px background-color:white;border-radius:10px;display: flex; vertical-align:middle;justify-content: center;align-items: center; display:inline-block; border:1px solid whitesmoke' align='center'>");
                    sbCircuitos.AppendLine("<div style='display:inline-block'><h6>" + dr["nombre_circuito"].ToString().ToUpper() + "</h6></div>");
                    sbCircuitos.AppendLine("</div>");
                    sbCircuitos.AppendLine("</div>");
                    sbCircuitos.AppendLine("</a>");
                    // sbCircuitos.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:250px; width:250px;' onclick='redirect(" + dr["id_circuito"].ToString() + ")'><h4>" + dr["nombre_circuito"].ToString() + "</h4></div></a>");
                    sbCircuitos.AppendLine("</div>");
                }
                sbCircuitos.AppendLine("</div>");
                string Contenido = sbCircuitos.ToString();
                cntCircuitos.InnerHtml = Contenido;
                cntCircuitos.Visible = true;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }

        }

        public void CargaCategorias()
        {
            try
            {
                DataTable dtCategorias = objCircuitos.ConsultaCategorias("es");
                ddlCategoria.DataSource = dtCategorias;
                ddlCategoria.DataValueField = "fk_categoria";
                ddlCategoria.DataTextField = "nombre_categoria";
                ddlCategoria.DataBind();
                ddlCategoria.Items.Insert(0, "Categoria...");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void EliminarCircuito()
        {
            try
            {
                string idCircuito = Session["idc"].ToString().ToString();
                wsCorProd.pa_Delete_Circuito(Convert.ToInt32(idCircuito));
                CargarCircuitos();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion

        #region Metodos Sitios
        public void RequestSitio()
        {
            try
            {
                CargaDatosCircuito(Session["idc"].ToString());
                cntCircuitoDtlle.Visible = true;
                cntBotones.Visible = false;
                cntCircuitos.Visible = false;
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

        public void CargarSitiosXCircuito(DataTable dtSitios)
        {
            try
            {
                Session["dtSitios"] = dtSitios;
                StringBuilder sbSitios = new StringBuilder();
                sbSitios.AppendLine("<div class='row text-center text-lg-left'>");
                sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background-image:url(MEDIA/IMG/Btn_Nuevo.png) no-repeat center' onclick='redirectsitios(0)'></div></a>");
                sbSitios.AppendLine("</div>");
                foreach (DataRow dr in dtSitios.Rows)
                {
                    sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                    sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background-image:url(MEDIA/IMG/Btn_Circuitos.png)' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>" + dr["nombre_sitio"].ToString() + "</div></a>");
                    sbSitios.AppendLine("</div>");
                }
                sbSitios.AppendLine("</div>");
                string Contenido = sbSitios.ToString();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public void EliminarSitio()
        {
            try
            {
                string idSitio = Session["ids"].ToString().ToString();
                //wsCorProdProd.Delete_Sitio(Convert.ToInt32(idSitio));
                RequestCircuito();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }
        #endregion

        #region Metodos Generales
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

        public void DetectaIdioma()
        {
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            string CodIdioma = myCurrentLanguage.Culture.ToString().Substring(0, 2);
            Session["LNG"] = CodIdioma;
        }

        public void RequestInicial()
        {
            DetectaIdioma();
            cntCircuitos.Visible = false;
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
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        protected void CargarEdades()
        {
            try
            {
                DataTable dtEdad = objHerramientas.CargaRangoEdad();
                ddlEdad.DataSource = dtEdad;
                ddlEdad.DataValueField = "id_rango_edad";
                ddlEdad.DataTextField = "rango";
                ddlEdad.DataBind();
                ddlEdad.Items.Insert(0, "Edad...");
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
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

        public void CreaDtImagenes()
        {
            try
            {
                DataTable dtImagenes = new DataTable();

                dtImagenes.Columns.Add("id_imagen");
                dtImagenes.Columns.Add("Nombre");
                dtImagenes.Columns.Add("Orden");
                dtImagenes.Columns.Add("UrlTemp");

                Session["dtImagenes"] = dtImagenes;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
            }
        }

        public DataTable InsRowDtImagenes(string Nombre, string Orden, string UrlTemp)
        {
            try
            {
                DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                DataRow dr = dtImagenes.NewRow();
                dr["id_imagen"] = "-1";
                dr["Nombre"] = Nombre;
                dr["Orden"] = Orden;
                dr["UrlTemp"] = UrlTemp;
                dtImagenes.Rows.Add(dr);

                return dtImagenes;
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalErr();", true);
                throw ex;
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
                ddlCiudad.Items.Insert(0, "Ciudad...");
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
        #endregion












    }
}