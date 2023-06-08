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
    public partial class Sitios : System.Web.UI.Page
    {
        clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
        clsHerramientas objHerramientas = new clsHerramientas();
        wsATT.AppToTripWSSoapClient wsCorTur = new wsATT.AppToTripWSSoapClient();
        wsATT.AppToTripWSSoapClient wsCorTurProd = new wsATT.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        public void CargarSitiosXCircuito()
        {
            try
            {
                DataTable dtSitios = ConsultaSitiosXCircuito(Session["idc"].ToString());
                lblTtlCircuitoSitio.Text = Session["nc"].ToString();
                Session["dtSitios"] = dtSitios;
                StringBuilder sbSitios = new StringBuilder();
                sbSitios.AppendLine("<div class='row text-center text-lg-left'>");
                sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background:url(MEDIA/IMG/Btn_Nuevo.png) no-repeat center' onclick='redirectsitios(0)'></div></a>");
                sbSitios.AppendLine("</div>");
                foreach (DataRow dr in dtSitios.Rows)
                {
                    sbSitios.AppendLine("<div class='col-lg-3 col-md-4 col-xs-6'>");
                    sbSitios.AppendLine("<a href='#' class='d-block mb-4 h-100'><div class='img-fluid img-thumbnail' style='height:150px; width:250px; background-image:url(MEDIA/IMG/Btn_Circuitos.png)' onclick='redirectsitios(" + dr["id_sitio"].ToString() + ")'>" + dr["nombre_sitio"].ToString() + "</div></a>");
                    sbSitios.AppendLine("</div>");
                }
                sbSitios.AppendLine("</div>");
                string Contenido = sbSitios.ToString();
                cntSitiosXCircuito.InnerHtml = Contenido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConsultaSitiosXCircuito(string IdCircuito)
        {
            try
            {
                return objCircuitos.ConsultaSitios(Session["LNG"].ToString(), IdCircuito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RequestSitio()
        {
            CargaDatosSitio(Session["ids"].ToString());
        }

        public void CargaFormMapa()
        {
            try
            {
                pnlDetalleSitios.Visible = true;
                pnlListaSitios.Visible = false;
                string lat = Request.QueryString["lat"].ToString();
                string lng = Request.QueryString["lng"].ToString();
                if (Session["ids"].ToString() != "0")
                {
                    CargaDatosSitio(Session["ids"].ToString());
                    txtLongSitio.Text = lng;
                    txtLatSitio.Text = lat;
                }
                else
                {
                    lblTtlCircuitoNuevo.Text = Session["nc"].ToString();
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
                    txtLongSitio.Text = lng;
                    txtLatSitio.Text = lat;
                }
                Session["lstForm"] = null;
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
                //CargaPaises();
                pnlDetalleSitios.Visible = true;
                pnlListaSitios.Visible = false;
                string Expresion = "id_sitio = " + idSitio;
                DataTable dtSitios = (DataTable)Session["dtSitios"];
                DataRow[] dr = dtSitios.Select(Expresion);
                lblTtlCircuitoNuevo.Text = Session["nc"].ToString();
                if (dr.Length > 0)
                {
                    lblTtlSitioDtll.Text = dr[0]["nombre_sitio"].ToString();
                    txtNombreSitio.Text = dr[0]["nombre_sitio"].ToString();
                    txtLatSitio.Text = dr[0]["latitud"].ToString();
                    txtLongSitio.Text = dr[0]["longitud"].ToString();
                    txtIDireccionSitio.Text = dr[0]["direccion"].ToString();
                    txtTelefonoSitio.Text = dr[0]["telefono"].ToString();
                    txtCostoSitio.Text = dr[0]["costo"].ToString();
                    //txtPaisSitio.Text = dr[0]["pais"].ToString();
                    //txtEdadSitio.Text = dr[0]["edad"].ToString();
                    txtHorarioSitio.Text = dr[0]["horario"].ToString();
                    //txtCiudadSitio.Text = dr[0]["Ciudad"].ToString();
                    txtRecomendacionesSitio.Text = dr[0]["Recomendacion"].ToString();
                    txtEquipamentoSitio.Text = dr[0]["Equipamento"].ToString();
                    txtTiempoSitio.Text = dr[0]["Tiempo_Estimado"].ToString();
                    txtDescripcionSitio.Text = dr[0]["Descripcion_sitio"].ToString();
                    txtIra.Text = dr[0]["Indicaciones"].ToString();
                }
                else
                {
                    lblTtlSitioDtll.Text = "[Nuevo]";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnGuardarSitio_Click(object sender, EventArgs e)
        {
            if (Session["ids"].ToString() != "0")
            {
                string idc = Session["idc"].ToString();
                string ids = Session["ids"].ToString();
                string lng = Session["LNG"].ToString();
                string respuesta = wsCorTurProd.pa_Update_Sitio(Convert.ToInt32(Session["ids"].ToString()), txtLatSitio.Text, txtLongSitio.Text, txtIDireccionSitio.Text, txtCostoSitio.Text, txtNombreSitio.Text, txtDescripcionSitio.Text, txtEquipamentoSitio.Text, txtRecomendacionesSitio.Text, txtIra.Text, Session["LNG"].ToString(), txtHorarioSitio.Text, txtTiempoSitio.Text, txtTelefonoSitio.Text, Convert.ToInt32(Session["idc"].ToString()), 0);
                CargarSitiosXCircuito();
                pnlDetalleSitios.Visible = false;
                pnlListaSitios.Visible = true;
            }
            else
            {
                string idc = Session["idc"].ToString();
                string respuesta = wsCorTurProd.pa_Insert_Sitio(txtLatSitio.Text, txtLongSitio.Text, txtIDireccionSitio.Text, txtCostoSitio.Text, txtNombreSitio.Text, txtDescripcionSitio.Text, txtEquipamentoSitio.Text, txtRecomendacionesSitio.Text, txtIra.Text, Session["LNG"].ToString(), txtHorarioSitio.Text, txtTiempoSitio.Text, txtTelefonoSitio.Text, Convert.ToInt32(Session["idc"].ToString()), 0);
                CargarSitiosXCircuito();
                pnlDetalleSitios.Visible = false;
                pnlListaSitios.Visible = true;
            }
        }

        protected void btnVolverSitio_Click(object sender, EventArgs e)
        {
            CargarSitiosXCircuito();
            pnlDetalleSitios.Visible = false;
            pnlListaSitios.Visible = true;
        }

        protected void btnVerSitio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?ini=1");
        }

        //protected void btnSubirImagen_Click(object sender, EventArgs e)
        //{
        //    if (fulImagenes.HasFile)
        //    {
        //        string ids = Session["ids"].ToString();
        //        string idc = Session["idc"].ToString();
        //        int gvRows = gvImagenes.Rows.Count;
        //        if (gvRows < 5)
        //        {
        //            lblMensajeImg.Visible = false;
        //            DataTable dtImagenes = new DataTable();
        //            int Orden;
        //            if (Session["Orden"] != null)
        //            {
        //                Orden = Convert.ToInt32(Session["Orden"]) + 1;
        //                Session["Orden"] = Orden;
        //            }
        //            else
        //            {
        //                Orden = 1;
        //                Session["Orden"] = Orden;
        //            }
        //            if (Session["dtImagenes"] != null)
        //            {
        //                dtImagenes = (DataTable)Session["dtImagenes"];
        //            }
        //            else
        //            {
        //                CreaDtImagenes();
        //                dtImagenes = (DataTable)Session["dtImagenes"];
        //            }

        //            lblMensajeImg.Visible = false;
        //            string Raiz = Herramienta.TraerConfiguracion("documentLocationTMP");
        //            string Ruta = Raiz + @"TEMPORAL\" + idc + @"\" + ids;
        //            if (!Directory.Exists(Ruta))
        //            {
        //                Directory.CreateDirectory(Ruta);
        //            }
        //            if (!File.Exists(Ruta + @"\" + txtNombreArchivo.Text))
        //            {
        //                fulImagenes.SaveAs(Ruta + @"\" + txtNombreArchivo.Text);
        //                InsRowDtImagenes(txtNombreArchivo.Text, (dtImagenes.Rows.Count + 1).ToString(), Ruta + @"\" + txtNombreArchivo.Text);
        //                gvImagenes.DataSource = dtImagenes;
        //                gvImagenes.DataBind();
        //                if (dtImagenes.Rows.Count > 0)
        //                {
        //                    lblMensajeImg.Visible = false;
        //                    btnGuardarImagenes.Visible = true;
        //                }
        //            }
        //            else
        //            {
        //                lblMensajeImg.Text = "Imágen duplicada";
        //                lblMensajeImg.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            lblMensajeImg.Visible = true;
        //            lblMensajeImg.Text = "Solo se permiten 5 imagenes por sitio.";
        //        }

        //        ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verpopup();", true);
        //    }
        //}

        protected void btnSubirImagen_Click(object sender, EventArgs e)
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
                            lblMensajeImg.Visible = false;
                            byte[] ImgOrg = new byte[tamanio];
                            fulImagenes.PostedFile.InputStream.Read(ImgOrg, 0, tamanio);
                            Bitmap ImgOrgBin = new Bitmap(fulImagenes.PostedFile.InputStream);
                            InsRowDtImagenes(txtNombreArchivo.Text, (dtImagenes.Rows.Count + 1).ToString(), Convert.ToBase64String(ImgOrg));
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

        public void CreaDtImagenes()
        {
            try
            {
                DataTable dtImagenes = new DataTable();

                dtImagenes.Columns.Add("id_imagen_sitio");
                dtImagenes.Columns.Add("Nombre");
                dtImagenes.Columns.Add("Orden");
                dtImagenes.Columns.Add("UrlTemp");
                dtImagenes.Columns.Add("imagen_img");

                Session["dtImagenes"] = dtImagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable InsRowDtImagenes(string Nombre, string Orden, string UrlTemp)
        {
            try
            {
                DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                DataRow dr = dtImagenes.NewRow();
                byte[] imagen_img = null;
                dr["id_imagen_sitio"] = "-1";
                dr["Nombre"] = Nombre;
                dr["Orden"] = Orden;
                dr["UrlTemp"] = UrlTemp;
                dr["imagen_img"] = imagen_img;
                dtImagenes.Rows.Add(dr);

                return dtImagenes;
            }
            catch (Exception ex)
            {
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
                throw ex;
            }
        }

        protected void gvImagenes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Eliminar")
                {
                    DataTable dtImagenes = (DataTable)Session["dtImagenes"];
                    DataRow dr = dtImagenes.Rows[Convert.ToInt32(e.CommandArgument)];
                    File.Delete(gvImagenes.DataKeys[Convert.ToInt32(e.CommandArgument)]["UrlTemp"].ToString());
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
                throw ex;
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
                throw ex;
            }
        }

        //public void GuardarImagenes()
        //{
        //    try
        //    {
        //        string ids = Session["ids"].ToString();
        //        string idc = Session["idc"].ToString();
        //        string Raiz = Herramienta.TraerConfiguracion("documentLocation");
        //        string Ruta = Raiz + idc + @"\" + ids;
        //        if (!Directory.Exists(Ruta))
        //        {
        //            Directory.CreateDirectory(Ruta);
        //        }
        //        foreach (GridViewRow gvr in gvImagenes.Rows)
        //        {
        //            string IdImagen = gvImagenes.DataKeys[gvr.RowIndex]["id_imagen_sitio"].ToString();
        //            string urlImagen = gvImagenes.DataKeys[gvr.RowIndex]["UrlTemp"].ToString();
        //            string Nombre = gvImagenes.DataKeys[gvr.RowIndex]["Nombre"].ToString();
        //            string Orden = gvImagenes.DataKeys[gvr.RowIndex]["Orden"].ToString();
        //            if (IdImagen == "-1")
        //            {
        //                File.Copy(urlImagen, Ruta + @"\" + Nombre);
        //                DataTable respuesta = wsCorTurProd.pa_Insert_ImagenSitio(Ruta + @"\" + Nombre, Convert.ToInt32(Orden), Convert.ToInt32(ids));
        //            }
        //            else
        //            {
        //                wsCorTurProd.pa_Update_ImagenSitio(IdImagen, Convert.ToInt32(Orden), Convert.ToInt32(ids));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void GuardarImagenes()
        {
            try
            {
                string ids = Session["ids"].ToString();
                string idc = Session["idc"].ToString();
                foreach (GridViewRow gvr in gvImagenes.Rows)
                {
                    string IdImagen = gvImagenes.DataKeys[gvr.RowIndex]["id_imagen_sitio"].ToString();
                    string urlImagen = gvImagenes.DataKeys[gvr.RowIndex]["UrlTemp"].ToString();
                    string Nombre = gvImagenes.DataKeys[gvr.RowIndex]["Nombre"].ToString();
                    string Orden = gvImagenes.DataKeys[gvr.RowIndex]["Orden"].ToString();

                    if (IdImagen == "-1")
                    {
                        objHerramientas.GuardaImagen(urlImagen, Orden, Session["ids"].ToString());
                        //DataTable respuesta = wsCorTurProd.pa_Insert_ImagenSitio(Nombre, Convert.ToInt32(Orden), Convert.ToInt32(ids));
                    }
                    else
                    {
                        //wsCorTurProd.pa_Update_ImagenSitio(IdImagen, Convert.ToInt32(Orden), Convert.ToInt32(ids));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }

        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                wsCorTur.pa_Delete_Sitio(Convert.ToInt32(Session["ids"]));
                CargarSitiosXCircuito();
                pnlDetalleSitios.Visible = false;
                pnlListaSitios.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnImagenesSitio_Click(object sender, ImageClickEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminarSitio_Click(object sender, EventArgs e)
        {
            try
            {
                lblEliminar.Text = "Está seguro que desea eliminar este sitio?";
                Session["ve"] = "c";
                mpeUsuario.Show();


            }
            catch (Exception ex)
            {

            }
        }

        protected void gvImagenes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string idImagen = gvImagenes.DataKeys[e.Row.RowIndex]["id_imagen_sitio"].ToString();
                if (idImagen == "-1")
                {
                    System.Text.Encoding enc = System.Text.Encoding.ASCII;
                    string ImagenPerfil = gvImagenes.DataKeys[e.Row.RowIndex]["UrlTemp"].ToString();
                    //string ImgPerfil = enc.GetString(ImagenPerfil);
                    System.Web.UI.WebControls.Image imgPrevia = (Image)e.Row.FindControl("imgPrevia");
                    imgPrevia.ImageUrl = "data:image/jpg;base64," + ImagenPerfil;
                }
                else
                {
                    System.Text.Encoding enc = System.Text.Encoding.ASCII;
                    byte[] ImagenPerfil = (byte[])gvImagenes.DataKeys[e.Row.RowIndex]["imagen_img"];
                    string ImgPerfil = enc.GetString(ImagenPerfil);
                    System.Web.UI.WebControls.Image imgPrevia = (Image)e.Row.FindControl("imgPrevia");
                    imgPrevia.ImageUrl = "data:image/jpg;base64," + ImgPerfil;
                }
            }
        }

        protected void btnVerMapa_Click(object sender, EventArgs e)
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
            Session["lstForm"] = lstFormulario;
            ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "irMapa();", true);
        }
    }
}