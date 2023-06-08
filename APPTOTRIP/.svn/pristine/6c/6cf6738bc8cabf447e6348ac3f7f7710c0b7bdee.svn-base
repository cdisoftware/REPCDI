<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Circuitos.aspx.cs" Inherits="CT.ADIM.WEB.NuIm.Circuitos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Circuitos</title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="../MEDIA/JS/jquery.min.js"></script>
    <script src="../MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src="../MEDIA/JS/local.js"></script>

    <link href="../MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/bootstrap-select.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/style.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../MEDIA/CSS/PersonalizadoBPM.css" rel="stylesheet" />
    <script>
        function ajustarTextarea() {
            var scroll_height = $("#txtDescripcion").get(0).scrollHeight;
            $("#txtDescripcion").css('height', scroll_height + 'px');
        }
        $(document).ready(function () {
            $('.cargando').click(function (event) {
                $('#p').show();
            })

            $('.cargando1').click(function (event) {
                $('#p').show();
            })
        });
        function returnIndex() {
            window.location.href = 'Index.aspx?ini=1';
        }

        function returnCircuitos() {
            var idCircuito = document.getElementById('hdIdCircuito').value;
            window.location.href = 'Circuitos.aspx?ic=' + idCircuito;
        }

        function CambiaTamanio(Objetol) {
            Objeto.size = Objeto.textLength;
        }

        function openModalNot() {
            $('#myModalNot').modal('show');
        }

        function openModalImagenesCirc() {
            var pnlimagen = document.getElementsByClassName("pnlimg");
            var pnlupload = document.getElementById("pnlUpload");
            //alert(pnlimagen + pnlupload);
            var idc = document.getElementById("hdIdCircuito").value;
            if (idc == 1) {
                $('#myModalImagenCirc').modal('show');

            }
            pnlimagen.visibility = 'hidden';
            pnlupload.visibility = 'hidden';
        }

    </script>
    <style>
        .txtWrap {
            overflow: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="p" style="position: fixed; background-color: white; width: 100%; height: 100%; z-index: 1000; top: 1PX; left: 1px; display: none; text-align: center; vertical-align: central;">
            <div style="display: inline-block; padding-top: 15%">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/MEDIA/IMG/spinner2.gif" />
            </div>
        </div>
        <div style="width: 100%">

            <div class="container" style="background-color: #3c6299; height: 50px; width: 100%">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="text-left">
                            <div style="z-index: 10000;">
                                <asp:Image ID="Image1" runat="server" CssClass="circ" ImageUrl="~/MEDIA/IMG/LogoBlancoSombra.png" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="text-right" style="font-family: 'Century Gothic'">
                            <%--<asp:LinkButton ID="btnAyuda" runat="server" ForeColor="White" Font-Size="14px">Ayuda</asp:LinkButton>
                            <asp:Label ID="lblespacio" runat="server" Text="|||" ForeColor="#3c6299"></asp:Label>--%>
                            <asp:LinkButton ID="btnSalir" runat="server" OnClick="btnSalir_Click" ForeColor="White" Font-Size="14px">Salir</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container">
                <%-- <div class="col-sm-12 text-xl-right" style="padding-top: 5px">
                    <asp:LinkButton ID="btnVolver" CssClass="btn btn-link" runat="server" OnClick="btnVolver_Click">Volver a Circuitos</asp:LinkButton>
                </div>--%>
                <div class="div-center">
                    <div class="ads-grid" style="width: 90%">
                        <div style="border-bottom: 1px solid #e5e3db;">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div id="divTtlCircuitos" runat="server" class="cargando" style="font-family: 'Century Gothic'; cursor: pointer" onclick="returnIndex();" visible="true">
                                        <h5 style="font-family: 'Century Gothic';">
                                            <asp:Label ID="lblTtlCircuito" runat="server" Text="Mis Circuitos" Font-Names="Century Gothic"></asp:Label></h5>
                                    </div>
                                    <div class="row">
                                        <div style="display: table-cell; padding-left: 5px">
                                            <h5 class="sear-head fer">
                                                <asp:Label ID="lblTitulo" runat="server" ForeColor="#4470b3" Font-Names="Century Gothic"></asp:Label>
                                            </h5>
                                        </div>
                                        <div style="display: table-cell; padding-left: 5px">
                                            <asp:ImageButton ID="btnEditNombre" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditNombre_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdIdPais" runat="server" />
                            <asp:HiddenField ID="hdIdCiudad" runat="server" />
                            <div id="container">
                                <div style="width: 100%; text-align: right">
                                    <asp:ImageButton ID="imgEditEncabezado" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="imgEditEncabezado_Click" />
                                </div>
                                <ul class="list">
                                    <li>
                                        <div style="padding: 12px 10px; margin-bottom: 15px;">
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <a>
                                                        <div class="featured-ad-left" style="background-color: red; width: 100%; height: 100%" onclick="openModalImagenesCirc()" data-backdrop="static" data-keyboard="false">
                                                            <asp:Image ID="imgCircuito" runat="server" Width="100%" Height="100%" />
                                                            <div style="font-size: 12px; font-family: 'Century Gothic'" class="">Clic sobre la imágen para editar.</div>
                                                            <div style="font-size: 14px; font-family: 'Century Gothic'" class="">
                                                                <asp:Label ID="lblTitEstado" runat="server" Text="Estado: " Font-Bold="true"></asp:Label><asp:Label ID="lblEstado" runat="server" Text="--" Font-Bold="false"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </a>
                                                </div>
                                                <div class="col-md-9" style="padding: 15px; font-family: 'Century Gothic'">
                                                    <span class="num-of-ads">
                                                        <asp:Label ID="lblResumen" runat="server" Font-Names="Century Gothic"></asp:Label></span>
                                                    <p style="font-size: 15px; color: #01A185; font-family: 'Century Gothic'">
                                                        Precio:
                                                 <span class="num-of-ads">
                                                     <asp:Label ID="lblCosto" runat="server" ForeColor="#4A4949"></asp:Label></span>
                                                    </p>
                                                    <p style="font-size: 15px; color: #01A185; font-family: 'Century Gothic'">
                                                        Ubicación:
                                                <span class="num-of-ads">
                                                    <asp:Label ID="lblCiudad" runat="server" ForeColor="#4A4949"></asp:Label></span>
                                                    </p>
                                                    <p style="font-size: 15px; color: red">
                                                        <asp:LinkButton ID="btnPreview" CssClass="btn btn-success" runat="server" OnClick="btnPreview_Click">Solicitar Preview</asp:LinkButton>
                                                        <asp:LinkButton ID="btnActivar" CssClass="btn btn-success" runat="server" OnClick="btnActivar_Click">Solicitar Activación</asp:LinkButton>
                                                        <asp:LinkButton ID="btnEliminar" CssClass="btn btn-success" runat="server" OnClick="btnEliminar_Click">Eliminar</asp:LinkButton>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                                <div style="width: 100%; text-align: right">
                                    <asp:ImageButton ID="btnEditDescripcion" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditDescripcion_Click" />
                                </div>
                                <ul class="list">
                                    <li>
                                        <div class="all-categories" style="padding: 20px; border: none">
                                            <h6>Descripción</h6>
                                            <span class="num-of-ads" style="padding-left: 15px">
                                                <asp:Label ID="lblDescripcion" runat="server"></asp:Label></span>
                                        </div>
                                    </li>
                                </ul>
                                <div style="width: 100%; text-align: right">
                                    <asp:ImageButton ID="btnEditDetalles" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditDetalles_Click" />
                                </div>
                                <div class="all-categories" style="padding: 20px; font-family: 'Century Gothic'">
                                    <h6>Detalles</h6>
                                    <ul class="all-cat-list" style="font-family: 'Century Gothic'">
                                        <li><a>
                                            <label style="color: #01a185; font-family: 'Century Gothic'">Duración</label>
                                            <span class="num-of-ads">
                                                <asp:Label ID="lblDuracion" runat="server" Font-Names="Century Gothic" Text="--"></asp:Label></span></a></li>
                                        <li><a>
                                            <label style="color: #01a185; font-family: 'Century Gothic'">Edad</label>
                                            <span class="num-of-ads">
                                                <asp:Label ID="lblEdad" runat="server" Font-Names="Century Gothic" Text="--" /></span></a></li>
                                        <li><a>
                                            <label style="color: #01a185; font-family: 'Century Gothic'">Equipamento </label>
                                            <span class="num-of-ads">
                                                <asp:Label ID="lblEquipamento" runat="server" Font-Names="Century Gothic" Text="--" /></span></a></li>
                                        <li><a>
                                            <label style="color: #01a185; font-family: 'Century Gothic'">Recomendaciones</label><span class="num-of-ads"><asp:Label ID="lblRecomendaciones" runat="server" Font-Names="Century Gothic" /></span></a></li>
                                        <li><a>
                                            <label style="color: #01a185; font-family: 'Century Gothic'">Contexto</label><span class="num-of-ads"><asp:Label ID="lblContexto" runat="server" Font-Names="Century Gothic" /></span></a></li>
                                    </ul>
                                </div>
                                <div style="width: 100%; text-align: right">
                                    <asp:ImageButton ID="btnEditSitios" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditSitios_Click" />
                                </div>
                                <div class="all-categories" style="padding: 20px">
                                    <h6>Sitios</h6>
                                    <div id="cntSitios" class="container" runat="server">
                                        <div class="row text-center text-lg-left">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--otros modales--%>
        <%--Mensajes--%>
        <div class="modal fade" id="myModalMsg">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">¡Atención!</h3>
                    </div>
                    <div class="modal-body">
                        <div class="div-center" style="width: 100%; height: 100%;">
                            <div style="display: table; width: 100%; height: 100%;">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <%--<img src="Media/img/AtencionPeq.png" />--%>
                                    </div>
                                    <div style="display: table-cell; padding-left: 20px">
                                        <asp:Label ID="lblMensajePU" CssClass="lblMensajePU" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" id="btnCerrar" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Validación Eliminar Circuito--%>
        <div class="modal fade" id="myModalEliCirc">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">¡Atención!</h3>
                    </div>
                    <div class="modal-body">
                        <div class="div-center" style="width: 100%; height: 100%;">
                            <div style="display: table; width: 100%; height: 100%;">
                                <div style="display: table-row">
                                    <div style="display: table-cell">
                                        <%--<img src="Media/img/AtencionPeq.png" />--%>
                                    </div>
                                    <div style="display: table-cell; padding-left: 20px">
                                        <asp:Label ID="Label1" CssClass="lblMensajePU" runat="server" Text="Está seguro que desea eliminar este circuito?"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnEliminarCir" runat="server" Text="Aceptar" class="btn btn-success" OnClick="btnEliminarCir_Click" />
                            <button type="button" id="btnCerrar1" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Notificación Activar - Preview--%>
        <div class="modal fade" id="myModalNot" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" data-keyboard="false" data-backdrop="static">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <div class="col-sm-4">
                                <%--<img src="Media/img/AtencionPeq.png" />--%>
                            </div>
                            <div class="col-sm-8 div-center">
                                <h5 class="modal-title" id="exampleModalLongNot">Atención!</h5>
                            </div>
                        </div>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Label ID="lblMensajeNot" runat="server">prueba</asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-secondary" onclick="returnCircuitos();" value="Aceptar" data-dismiss="modal" />
                    </div>
                </div>
            </div>
        </div>

        <%--Orden de sitios--%>
        <div class="modal" id="myModalOrden">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Ordenar Sitios</h3>
                        </div>
                    </div>
                    <div class="modal-body div-center">
                        <div style="display: table-row">
                            <div style="padding-top: 10px">
                                <asp:Label ID="lblMensajeOrden" runat="server" ForeColor="#ff5050" Text=""></asp:Label>
                                <asp:GridView ID="gvSitios" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="table table-striped table-bordered dt-responsive" DataKeyNames="id_sitio,orden">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nombre" DataField="nombre_sitio" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText="Orden" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtOrden" runat="server" Text='<%# Bind("orden") %>' CssClass="form-control form-control-user" Width="50px" Height="20px"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>


                        </div>
                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarOrden" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" OnClick="btnGuardarOrden_Click" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Modales de edición -->
        <%--Nombre--%>
        <div class="modal fade bd-example-modal-lg" id="myModalNombre" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Titulo</h3>
                        </div>
                    </div>
                    <div class="modal-body div-center">
                        <div class="row" style="width: 100%">
                            <div class="col-sm-12" style="padding: 20px">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarNombre" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" OnClick="btnGuardarNombre_Click" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Imagen--%>
        <div class="modal fade bd-example-modal-lg" id="myModalImagenCirc" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Imágen de Referencia</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="text-center" style="width: 100%; border: 1px solid rgba(0, 0, 0, 0.2); border-radius: 10px 10px; padding: 5px;">

                                <asp:Panel ID="pnlImg" runat="server" CssClass="text-center pnlimg">
                                    <div class="container">
                                        <asp:Image ID="Image3" runat="server" CssClass="img-fluid rounded d-block m-l-none" />
                                    </div>
                                </asp:Panel>

                                <asp:Panel ID="pnlUpload" runat="server">
                                    <label class="file-upload">
                                        <asp:FileUpload ID="fulImagenes" runat="server" AllowMultiple="false" onchange="this.form.submit()"></asp:FileUpload>
                                    </label>
                                </asp:Panel>
                                <br />

                            </div>
                        </div>
                    </div>
                    <div class="modal-footer ">
                        <div class="row div-center" style="padding: 10px; width: 100%;">
                            <div class="col-sm-12 div-center">
                                <div style="display: table-cell; padding-right: 5px;">
                                    <asp:Button ID="btnGuardarImagen" runat="server" CssClass="btn btn-secondary btn-user btn-block cargando" Text="Cargar Imágen" Enabled="false" OnClick="btnGuardarImagen_Click" />
                                </div>
                                <div style="display: table-cell; padding-left: 5px;">
                                    <asp:Button ID="btnCancelarImagen" runat="server" CssClass="btn btn-secondary btn-user btn-block cargando" Text="Cancelar" OnClick="btnCancelarImagen_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  
         <%--Encabezado--%>
        <div class="modal fade bd-example-modal-lg" id="myModalEncabezado" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Encabezado</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-2">
                                <div style="display: table-cell">
                                    Costo:
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                Moneda:
                            </div>
                            <div class="col-lg-4">
                                <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="1" Text="USD"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="EU"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2">
                                <div style="display: table-cell">
                                    Pais:
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <div style="display: table-cell">
                                    Ciudad:
                                </div>
                            </div>
                            <div class="col-lg-4">
                                <asp:DropDownList ID="ddlCiudad" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                Resumen:
                                <asp:TextBox ID="txtResumen" runat="server" TextMode="MultiLine" onkeyup="countCharsDC(this);" CssClass="form-control" Rows="3"></asp:TextBox>
                                <p id="charNumSinopCircuito" class="lblCountCarc">200 caracteres permitidos</p>
                            </div>
                        </div>

                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer ">
                        <div class="row div-center" style="padding: 10px; width: 100%;">
                            <div style="display: table-cell; padding-right: 5px;">
                                <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                            </div>
                            <div style="display: table-cell; padding-right: 5px;">
                                <asp:Button ID="btnGuardarEncabezado" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" OnClick="btnGuardarEncabezado_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Descripcion--%>
        <div class="modal fade bd-example-modal-lg" id="myModalDescripcion" tabindex="" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Descripción</h3>
                        </div>
                    </div>
                    <div class="modal-body div-center">
                        <div class="row" style="width: 100%">
                            <div class="col-sm-12" style="padding: 20px">
                                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" CssClass="form-control txtWrap" Rows="10" onkeyup="countChars(this);" onBlur="EditValues(this)"></asp:TextBox>
                                <p id="charNumDesc" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarDescripcion" runat="server" OnClick="btnGuardarDescripcion_Click" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Detalles--%>
        <div class="modal fade bd-example-modal-lg" id="myModalDetalles" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Detalles</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-2">
                                <div style="display: table-cell">
                                    Duración:
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddlUniTiempo" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                <div style="display: table-cell">
                                    Edad:
                                </div>
                            </div>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlEdad" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                Recomendación:
                                <asp:TextBox ID="txtRecomendaciones" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
                                <p id="charNumRecom" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                Equipamento:
                                <asp:TextBox ID="txtEquipamento" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
                                <p id="charNumEquip" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                Contexto:
                                <asp:TextBox ID="txtContexto" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
                                <p id="charNumContextoCircuito" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarDetalles" runat="server" OnClick="btnGuardarDetalles_Click" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <footer style="background-color: #3c6299; height: 30px; width: 100%">
            <div class="container" style="height: 20px; position: absolute">
                <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
            </div>
        </footer>
        <asp:HiddenField ID="hdIdCircuito" runat="server" Value="-1" />
        <asp:HiddenField ID="hdEdit" Value="" runat="server" />
        <input type="text" id="txtValidaCarac" class="oculto" />
    </form>
</body>
</html>
