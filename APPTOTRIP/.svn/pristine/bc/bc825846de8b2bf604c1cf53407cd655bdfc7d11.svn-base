using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CT.ADIM.WEB
{
    public partial class Mapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ViewState["lat"] = Request.QueryString["lat"].ToString();
                //ViewState["lon"] = Request.QueryString["lon"].ToString
                if(Session["lat"] != null && Session["lon"] != null)
                {
                    ViewState["lat"] = Session["lat"].ToString();
                    ViewState["lon"] = Session["lon"].ToString();
                }
                
                ClientScript.RegisterStartupScript(GetType(), "mostratmensaje", "verCoord(" + Session["lat"].ToString() + "," + Session["lon"].ToString() + ");", true);
                txtLat.Text = ViewState["lat"].ToString();
                txtLon.Text = ViewState["lon"].ToString();
                /**/

            }
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtLat.Text != "" && txtLon.Text != "")
            {
                Response.Redirect("NuIm/Sitios.aspx?lat=" + txtLat.Text + "&lng=" + txtLon.Text);
            }
            else
            {
                Response.Redirect("NuIm/Sitios.aspx?lat=--&lng=--");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuIm/Sitios.aspx?lat=" + ViewState["lat"].ToString() + "&lng=" + ViewState["lon"].ToString());
        }
    }
}