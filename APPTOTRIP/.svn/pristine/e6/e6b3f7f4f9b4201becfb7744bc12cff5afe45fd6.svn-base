<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sitios.aspx.cs" Inherits="CT.ADIM.WEB.NuIm.Sitios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sitios</title>
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
    <style>
        .btnEliImag {
            visibility: hidden;
        }
    </style>
    <script>
        $("#archivos").fileinput({});
    </script>
    <script>

        $(document).ready(function () {
            $('.cargando').click(function (event) {
                $('#p').show();
            })
        });

        function verImagenes(url, op, urlBd, id) {
            var idImagen = document.getElementById("hdIdImagen");
            idImagen.value = id;
            var btnEliminar = document.getElementById("btnEliminaImagen");
            var img = document.getElementById("verImagen");
            var urlImagen = document.getElementById("hdUrlImagen");
            urlImagen.value = urlBd;
            img.src = url;
            if (op != null) {
                btnEliminar.style.visibility = "visible";
            }
            else {
                btnEliminar.style.visibility = "hidden";
            }
            $('#myModalPrevImg').modal('show');
        }

        function returnIndex() {
            var idCirc = document.getElementById('hdIdCircuito').value;
            window.location.href = 'Circuitos.aspx?ic=' + idCirc;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%">
            <div id="p" style="position: fixed; background-color: white; width: 100%; height: 100%; z-index: 2; top: 1PX; left: 1px; display: none; text-align: center; vertical-align: central;">
                <div style="display: inline-block; padding-top: 15%">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/MEDIA/IMG/spinner2.gif" />
                </div>
            </div>
            <div class="container" style="background-color: #3c6299; height: 55px; width: 100%">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="text-left">
                            <div style="z-index: 10000;">
                                <asp:Image ID="Image1" runat="server" CssClass="circ" ImageUrl="~/MEDIA/IMG/LogoBlancoSombra.png" />
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="text-right">
                            <%--<asp:LinkButton ID="btnAyuda" runat="server" ForeColor="White" Font-Size="14px">Ayuda</asp:LinkButton>
                            <asp:Label ID="lblespacio" runat="server" Text="|||" ForeColor="#3c6299"></asp:Label>--%>
                            <asp:LinkButton ID="btnSalir" runat="server" OnClick="btnSalir_Click" ForeColor="White" Font-Size="14px">Salir</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <div class="container div-center">
                <div class="ads-grid" style="width: 90%">
                    <div style="border-bottom: 1px solid #e5e3db;">
                        <div class="row">
                            <div class="col-sm-12">
                                <div id="divTtlCircuitos" runat="server" class="cargando" style="font-family: 'Century Gothic'; cursor: pointer" onclick="returnIndex();" visible="true">
                                    <h5 style="font-family: 'Century Gothic';">
                                        <asp:Label ID="lblTtlCircuito" runat="server"></asp:Label></h5>
                                </div>
                                <div class="row">
                                    <div style="display: table-cell; padding-left: 5px">
                                        <h5 class="sear-head fer">
                                            <asp:Label ID="lblTitulo" ForeColor="#4470b3" runat="server" Font-Names="Century Gothic"></asp:Label>
                                        </h5>
                                    </div>
                                    <div style="display: table-cell; padding-left: 5px">
                                        <asp:ImageButton ID="btnEditNombre" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditNombre_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="container">
                            <div style="width: 100%; text-align: right">
                                <asp:ImageButton ID="imgEditEncabezado" runat="server" ImageUrl="~/MEDIA/IMG/editar.png" CssClass="cargando" OnClick="imgEditEncabezado_Click" />
                            </div>
                            <ul class="list">
                                <li>
                                    <div style="padding: 12px 10px; background-color: #fff; margin-bottom: 15px;">
                                        <div class="row">
                                            <div class="col-md-3">
                                                <a>
                                                    <div class="featured-ad-left" style="background-color: red; width: 100%; height: 100%" onclick="openModalImagenesSitio()">
                                                        <asp:Image ID="imgSitio" runat="server" Width="100%" Height="100%" />
                                                    </div>
                                                </a>
                                            </div>
                                            <div class="col-md-9" style="background-color: white; padding: 15px">
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
                                                        <asp:Label ID="lblDireccion" runat="server" ForeColor="#4A4949"></asp:Label></span>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <div style="width: 100%; text-align: right">
                                <asp:ImageButton ID="btnEditDescripcion" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditDescripcion_Click" />
                            </div>
                            <div class="all-categories" style="padding: 20px">
                                <h6>Descripción</h6>
                                <span class="num-of-ads" style="padding-left: 15px">
                                    <asp:Label ID="lblDescripcion" runat="server"></asp:Label></span>
                            </div>
                            <div style="width: 100%; text-align: right">
                                <asp:ImageButton ID="btnEditDetalles" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditDetalles_Click" />
                            </div>
                            <div class="all-categories" style="padding: 20px">
                                <h6>Detalles</h6>
                                <ul class="all-cat-list">
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">Telefono</label>
                                        <span class="num-of-ads">
                                            <asp:Label ID="lblTelefono" runat="server" Font-Names="Century Gothic"></asp:Label></span></a></li>
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">Horario</label>
                                        <span class="num-of-ads">
                                            <asp:Label ID="lblHorario" runat="server" Font-Names="Century Gothic" /></span></a></li>
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">Duración</label>
                                        <span class="num-of-ads">
                                            <asp:Label ID="lblDuracion" runat="server" Font-Names="Century Gothic" /></span></a></li>
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">Equipamento</label>
                                        <span class="num-of-ads">
                                            <asp:Label ID="lblEquipamento" runat="server" Text="--" Font-Names="Century Gothic" /></span></a></li>
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">Recomendaciones</label>
                                        <span class="num-of-ads">
                                            <asp:Label ID="lblRecomendaciones" runat="server" Text="--" Font-Names="Century Gothic" /></span></a></li>
                                    <li><a>
                                        <label style="color: #01a185; font-family: 'Century Gothic'">I.R.A</label><span class="num-of-ads">
                                            <asp:Label ID="lblIra" runat="server" Font-Names="Century Gothic" /></span></a></li>
                                </ul>
                            </div>
                            <div style="width: 100%; text-align: right">
                                <asp:ImageButton ID="btnEditarUbicacion" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditarUbicacion_Click" />
                            </div>
                            <div class="all-categories" style="padding: 20px;">
                                <h6>Ubicación</h6>
                                <div class="col-lg-12">
                                    <div style="display: table-cell">
                                        <p style="font-size: 15px; color: #01A185; padding-right: 20px; font-family: 'Century Gothic'">
                                            Latitud:
                                              <asp:Label ID="lblLatitud" runat="server" ForeColor="#666666" Text="--"></asp:Label>
                                        </p>
                                    </div>
                                    <div style="display: table-cell">
                                        <p style="font-size: 15px; color: #01A185; font-family: 'Century Gothic'">
                                            Longitud:
                                            <asp:Label ID="lblLongitud" runat="server" ForeColor="#666666" Text="--"></asp:Label>
                                        </p>
                                    </div>
                                    <div style="display: table-cell">
                                    </div>
                                </div>
                            </div>

                            <div style="width: 100%; text-align: right">
                                <asp:ImageButton ID="btnEditImagenes" runat="server" CssClass="cargando" ImageUrl="~/MEDIA/IMG/editar.png" OnClick="btnEditImagenes_Click" />
                            </div>
                            <div class="all-categories" style="padding: 20px;">
                                <h6>Imágenes</h6>
                                <div id="cntImagenes" class="container" runat="server">
                                    <div class="row text-center text-lg-left">
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="myModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h3 class="modal-title">¡Atención!</h3>
                    </div>
                    <div class="modal-body">
                        <div class="div-center" style="width: 100%; height: 100%;">
                            <div style="display: table; width: 100%; height: 100%;">
                                <div style="display: table-row">
                                    <div style="display: table-cell; padding-left: 20px">
                                        <asp:Label ID="lblMensajePU" CssClass="lblMensajePU" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-PGN-cancelar" Text="Cerrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modales de edición -->
        <%--Nombre--%>
        <div class="modal fade bd-example-modal-lg" id="myModalNombreSitio" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
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

        <%--Encabezado--%>
        <div class="modal fade bd-example-modal-lg" id="myModalEncabezadoSitio" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Encabezado</h3>
                        </div>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <div class="col-lg-1">
                                <div style="display: table-cell">
                                    Precio:
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:DropDownList ID="ddlMoneda" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="USD" Text="USD"></asp:ListItem>
                                    <asp:ListItem Value="EU" Text="EU"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-2">
                                <div style="display: table-cell">
                                    Dirección:
                                </div>
                            </div>
                            <div class="col-lg-5">
                                <asp:TextBox ID="txtDireccion" runat="server" onkeyup="countChars(this);" CssClass="form-control"></asp:TextBox>
                                <p id="charNumDirecSitio" class="lblCountCarc">100 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                Resumen:
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <asp:TextBox ID="txtResumenS" runat="server" TextMode="MultiLine" onkeyup="countCharsDC(this);" CssClass="form-control" Rows="4"></asp:TextBox>
                                <p id="charNumSinopSitio" class="lblCountCarc">200 caracteres permitidos</p>
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
                                <asp:Button ID="btnGuardarEncabezado" runat="server" Text="Guardar" OnClick="btnGuardarEncabezado_Click" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Descripcion--%>
        <div class="modal fade bd-example-modal-lg" id="myModalDescripcionSitio" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Descripción</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtDescripcionS" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
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
                            <asp:Button ID="btnGuardarDescripcion" runat="server" Text="Guardar" OnClick="btnGuardarDescripcion_Click" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Detalles--%>
        <div class="modal fade bd-example-modal-lg" id="myModalDetallesSitio" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
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
                                    Teléfono:
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-2">
                                <div style="display: table-cell; padding-right: 5px">
                                    Duración:
                                </div>
                            </div>
                            <div class="col-sm-2">
                                <asp:TextBox ID="txtDuracion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-sm-3">
                                <asp:DropDownList ID="ddlUniTiempo" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-2">
                                Horario
                            </div>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtHorario" runat="server" CssClass="form-control" onkeyup="countChars(this);"></asp:TextBox>
                                 <p id="charNumHorario" class="lblCountCarc">100 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                I.R.A:
                            <asp:TextBox ID="txtIra" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
                                <p id="charNumIra" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                Equipamento:
                                <asp:TextBox ID="txtEquipamentoS" runat="server" CssClass="form-control" onkeyup="countChars(this);" TextMode="MultiLine" Rows="10"></asp:TextBox>
                                <p id="charNumEquip" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                Recomendaciones:
                                <asp:TextBox ID="txtRecomendacionesS" runat="server" TextMode="MultiLine" onkeyup="countChars(this);" CssClass="form-control" Rows="10"></asp:TextBox>
                                <p id="charNumRecom" class="lblCountCarc">3000 caracteres permitidos</p>
                            </div>
                        </div>
                        <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarDetalles" runat="server" Text="Guardar" OnClick="btnGuardarDetalles_Click" CssClass="btn btn-secondary btn-user btn-block cargando" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Ubicación--%>
        <div class="modal fade bd-example-modal-lg" style="z-index: 100000" id="myModalPrevImg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Imágenes</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="col-sm-12">
                            <div class="div-center" id="prvImg" style="width: 100%; padding-bottom: 20px; background-size: cover">
                                <asp:Image ID="verImagen" runat="server" CssClass="img-fluid rounded d-block m-l-none" />
                            </div>
                        </div>
                        <br />
                        <div class="col-sm-12">
                            <div class="div-center" style="width: 100%; padding-bottom: 20px;">
                                <asp:ImageButton ID="btnEliminaImagen" CssClass="btnEliImag cargando" runat="server" ImageUrl="~/MEDIA/IMG/deleteOpaco.png" OnClick="btnEliminaImagen_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                    </div>
                </div>
                <%--<a class="popup-cerrar" onclick="cerrarpopup();">X</a>--%>
            </div>
        </div>

        <%-- Imagenes--%>
        <div class="modal fade bd-example-modal-lg" id="myModalImagenes" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Imágenes</h3>
                        </div>
                    </div>
                    <div class="modal-body">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100%; padding-bottom: 25px">
                                    <div class="row">
                                        <div class="text-center" style="width: 100%; border: 1px solid rgba(0, 0, 0, 0.2); border-radius: 10px 10px; padding: 5px;">
                                            <asp:Panel ID="pnlImagen" runat="server" Visible="false" CssClass="div-center">
                                                <div class="container div-center">
                                                    <asp:Image ID="Image3" runat="server" CssClass="img-fluid rounded d-block m-l-none" />
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlUpload" runat="server" Visible="true">
                                                <label class="file-upload">
                                                    <asp:FileUpload ID="fulImagenes" runat="server" AllowMultiple="false" onchange="this.form.submit()"></asp:FileUpload>
                                                </label>
                                            </asp:Panel>
                                            <br />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div id="cntEditarImagenes" class="container" runat="server">
                                    </div>
                                </td>
                            </tr>
                        </table>

                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <asp:Button ID="btnCancelarImg" runat="server" class="btn btn-secondary btn-user btn-block" Text="Cancelar" OnClick="btnCancelarImg_Click" />
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarImagen" runat="server" Text="Aceptar" OnClick="btnGuardarImagen_Click" CssClass="btn btn-secondary btn-user btn-block" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%--Orden de imágenes--%>
        <div class="modal" id="myModalOrden">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="row">
                            <h3 class="modal-title">Ordenar Imágenes!</h3>
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
                    </div>
                    <div class="modal-footer div-center">
                        <div style="display: table-cell">
                            <button type="button" class="btn btn-secondary btn-user btn-block" data-dismiss="modal" style="width: 100px">Cerrar</button>
                        </div>
                        <div style="display: table-cell">
                            <asp:Button ID="btnGuardarOrdenIimg" runat="server" Text="Guardar" CssClass="btn btn-secondary btn-user btn-block" Width="100px" Visible="true" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdIdImagen" runat="server" />
        <footer style="background-color: #3c6299; height: 30px; width: 100%">
            <div class="container" style="height: 20px; position: absolute">
                <p class="m-0 text-center text-white">Copyright &copy; C.D.I Software 2018</p>
            </div>
        </footer>

        <asp:HiddenField ID="hdIdCircuito" runat="server" />
        <asp:HiddenField ID="hdUrlImagen" runat="server" />
        <input type="text" id="txtValidaCarac" class="oculto" />
    </form>
</body>
</html>
