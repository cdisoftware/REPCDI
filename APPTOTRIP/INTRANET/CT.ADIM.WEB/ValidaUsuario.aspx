<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidaUsuario.aspx.cs" Inherits="CT.ADIM.WEB.ValidaUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
    <link href="MEDIA/CSS/all.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <script src="MEDIA/JS/jquery.min.js"></script>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="MEDIA/JS/jquery.easing.min.js"></script>
    <script src="MEDIA/JS/sb-admin-2.min.js"></script>
    <script src="MEDIA/JS/local.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body class="bg-body">
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-gradient-primary fixed-top">
            <div class="container" style="padding-top: 10px">
                <div style="position: fixed; z-index: 10000;">
                    <asp:Image ID="Image1" runat="server" CssClass="circ" ImageUrl="~/MEDIA/IMG/Logo.png" />
                </div>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarResponsive">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <asp:LinkButton ID="btnPerfil" runat="server" CssClass="nav-link" OnClick="btnPerfil_Click" Visible="false">Mi Cuenta</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnAyuda" runat="server" CssClass="nav-link">Ayuda</asp:LinkButton>
                        </li>
                        <li class="nav-item">
                            <asp:LinkButton ID="btnSalir" runat="server" CssClass="nav-link" OnClick="btnSalir_Click">Salir</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <br />
        <br />
        <br />
        <br />
        <div style="width: 100%; height: 100%" align="center">
            <asp:Panel ID="pnlAdmin" runat="server" Visible="true">
                <div align="center">
                    <h4>ADMINISTRACIÓN DE USUARIOS</h4>
                </div>
                <br />
                <asp:GridView ID="gvConfirma" runat="server" CssClass="table" OnRowCommand="gvConfirma_RowCommand" OnRowDataBound="gvConfirma_RowDataBound"
                    DataKeyNames="correo_usuario,estado,id_usuario" AutoGenerateColumns="false" Width="50%">
                    <Columns>
                        <asp:BoundField HeaderText="Usuario" DataField="correo_usuario" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha_nacimiento" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblEstado" runat="server"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkActivar" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <div style="display: table-row">
                    <div class="cell-padd" style="display: table-cell; padding: 5px">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-user btn-block" OnClick="btnGuardar_Click" ValidationGroup="Guardar1" />
                    </div>
                    <div class="cell-padd" style="display: table-cell; padding: 5px">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary btn-user btn-block" />
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
    <footer class="bg-gradient-primary fixed-bottom" style="height: 40px">
        <div class="container" style="height: 20px">
            <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
        </div>
        <!-- /.container -->
    </footer>
</body>
</html>
