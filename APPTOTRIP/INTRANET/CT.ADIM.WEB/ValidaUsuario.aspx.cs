using System;
using System.Data;
using CT.ADMIN.BL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CT.ADIM.WEB
{
    public partial class ValidaUsuario : System.Web.UI.Page
    {
        clsRegistroUsuario objRegUsuarios = new clsRegistroUsuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlAdmin.Visible = true;
                DataTable dtUsuarios = objRegUsuarios.CargaUsuariosActivar();
                gvConfirma.DataSource = dtUsuarios;
                gvConfirma.DataBind();
            }
        }

        protected void gvConfirma_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvConfirma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado = gvConfirma.DataKeys[e.Row.RowIndex]["estado"].ToString();
                Label lblEstado = e.Row.FindControl("lblEstado") as Label;
                CheckBox chkActivar = e.Row.FindControl("chkActivar") as CheckBox;
                if (estado == "0")
                {
                    lblEstado.Text = "Sin Validar";
                    chkActivar.Visible = false;
                }
                else if (estado == "2")
                {
                    lblEstado.Text = "Pendiente Aprobación";
                    chkActivar.Visible = true;
                }
                else if (estado == "1")
                {
                    lblEstado.Text = "Activo";
                    chkActivar.Visible = true;
                    chkActivar.Checked = true;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("PerfilUsuario.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvr in gvConfirma.Rows)
                {
                    int index = gvr.RowIndex;
                    CheckBox chkEstado = gvr.FindControl("chkActivar") as CheckBox;
                    string IdUsuario = gvConfirma.DataKeys[index]["id_usuario"].ToString();
                    string Estado = gvConfirma.DataKeys[index]["estado"].ToString();
                    int EstadoAct;
                    if (Estado != "0")
                    {
                        if (chkEstado.Checked)
                        {
                            EstadoAct = 1;
                        }
                        else
                        {
                            EstadoAct = 2;
                        }
                        objRegUsuarios.ActualizaUsuarioActivar(IdUsuario, EstadoAct.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}