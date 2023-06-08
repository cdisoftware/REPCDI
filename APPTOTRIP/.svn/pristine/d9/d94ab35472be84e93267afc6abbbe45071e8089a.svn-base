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

namespace CT.ADIM.WEB.NuIm
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
        wsATT.AppToTripWSSoapClient wsCorTurProd = new wsATT.AppToTripWSSoapClient();
        /// <summary>
        /// Pruebas
        /// </summary>
        //wsATT_PR.AppToTripWSSoapClient wsCorTur = new wsATT_PR.AppToTripWSSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["Usuario"];
                    if (Request.QueryString["ini"] != null && Request.QueryString["ini"].ToString() == "1")
                    {
                        CargarCircuitosNI();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "openModalLogin();", true);
                }
            }
        }

        #region Eventos Botones y Listas

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

        #endregion

        #region Metodos Circuitos

        public void CargarCircuitosNI()
        {
            string urlImagen;
            StringBuilder sbCircuitos = new StringBuilder();
            DataTable dtCircuitos = ConsultaCircuitos();
            Session["dtCircuitos"] = dtCircuitos;
            sbCircuitos.AppendLine("<div id='container'>");
            sbCircuitos.AppendLine("<ul class='list'>");
            sbCircuitos.AppendLine("<a href='#' onclick='redirect(0)' class='cargando'>");
            sbCircuitos.AppendLine("<li>");
            sbCircuitos.AppendLine("<img src='../MEDIA/IMG/NoImage.png' title='' alt='' />");
            sbCircuitos.AppendLine("<section class='list-left'>");
            sbCircuitos.AppendLine("<h5 class='title' style='font-family:Century Gothic'>NUEVO</h5>");
            sbCircuitos.AppendLine("<p class='catpath' style='font-family:Century Gothic'>Descripción Corta</p>");
            sbCircuitos.AppendLine("</section>");
            sbCircuitos.AppendLine("<section class='list-right'>");
            sbCircuitos.AppendLine("<span class='adprice'> 0.0 --</span>");
            sbCircuitos.AppendLine("</section>");
            sbCircuitos.AppendLine("<div class='clearfix'></div>");
            sbCircuitos.AppendLine("</li>");
            sbCircuitos.AppendLine("</a>");
            sbCircuitos.AppendLine("<div class='row'>");
            sbCircuitos.AppendLine("<div class='col-sm-12'>");
            sbCircuitos.AppendLine("</div>");
            sbCircuitos.AppendLine("</div>");
            foreach (DataRow dr in dtCircuitos.Rows)
            {
                urlImagen = dr["imagen"].ToString();
                //sbCircuitos.AppendLine("<div data-toggle='collapse' data-target='#" + dr["id_circuito"].ToString() + dr["nombre_circuito"].ToString().Replace(" ", "") + "'>"
                // + "<h2>Fundamento Legal</h2>"
                // + "</div>");
              //  sbCircuitos.AppendLine("<div id='" + dr["id_circuito"].ToString() + dr["nombre_circuito"].ToString().Replace(" ", "") + "' class='collapse'");
                sbCircuitos.AppendLine("<a href='#' class='cargando' onclick='redirect(" + dr["id_circuito"].ToString() + ")'>");
                sbCircuitos.AppendLine("<li>");
                if (urlImagen != "")
                {
                    sbCircuitos.AppendLine("<img src='" + urlImagen + "' title='' alt='' onclick='redirect(" + dr["id_circuito"].ToString() + ")' />");
                }
                else
                {
                    sbCircuitos.AppendLine("<img src='../MEDIA/IMG/NoImage.png' title='' alt='' onclick='redirect(" + dr["id_circuito"].ToString() + ")' />");
                }
                sbCircuitos.AppendLine("<section class='list-left'>");
                sbCircuitos.AppendLine("<h5 class='title' style='font-family:Century Gothic'>" + dr["nombre_circuito"].ToString().ToUpper() + "</h5>");
                //sbCircuitos.AppendLine("<span class='adprice'>$" + dr["valor"].ToString() + "</span>");
                sbCircuitos.AppendLine("<p class='catpath' style='font-family:Century Gothic'>" + dr["descripcion_corta_circuito"].ToString() + "</p>");
                sbCircuitos.AppendLine("</section>");
                sbCircuitos.AppendLine("<section class='list-right'>");
                sbCircuitos.AppendLine("<span class='adprice'>" + dr["valor"].ToString() + "</span>");
                //sbCircuitos.AppendLine("<span class='cityname'>City name</span>");
                sbCircuitos.AppendLine("</section>");
                sbCircuitos.AppendLine("<div class='clearfix'></div>");
                sbCircuitos.AppendLine("</li>");
                sbCircuitos.AppendLine("</a>");
               // sbCircuitos.AppendLine("</div>");
            }
            sbCircuitos.AppendLine("</ul>");
            sbCircuitos.AppendLine("</div>");
            string Contenido = sbCircuitos.ToString();
            cntCircuitos.InnerHtml = Contenido;
            cntCircuitos.Visible = true;
        }

        public DataTable ConsultaCircuitos()
        {
            try
            {
                Usuario usuario = (Usuario)Session["usuario"];
                Session["idUsuario"] = usuario.Id_Usuario;
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

        #endregion
    }
}