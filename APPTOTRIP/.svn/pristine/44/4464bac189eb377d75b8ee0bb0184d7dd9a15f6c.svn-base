<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CT.ADIM.WEB.NuIm.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ATT - Bienvenido</title>
    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
       <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js "></script>
    <script src="../MEDIA/JS/jquery.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src="../MEDIA/JS/bootstrap.bundle.min.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <script src="../MEDIA/JS/local.js"></script>
    <link href="../MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <%--<link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />--%>
    <link href="../MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="../MEDIA/CSS/style.css" rel="stylesheet" />
    <link href="~/Media/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Media/css/PersonalizadoBPM.css" rel="stylesheet" />

    <style>
        .form-control-obligatorio {
            color: #ff0000;
            background-color: #fff;
            border-color: #ff7676;
            outline: 0;
        }

        .div-center {
            align-items: center;
            display: flex;
            justify-content: center
        }
    </style>

    <script>

        $(document).ready(function () {
            $('.cargando').click(function (event) {
                $('#p').show();
            })
        });

        function openModalBt() {
            $('#myModal').modal('show');
        }

        function openModalMsg() {
            $('#myModalMsg').modal('show');
        }

        function openModalImg() {
            $('#myModalImg').modal('show');
        }

        function openModalErr() {
            $('#myModalErr').modal('show');
        }

        function openModalNot() {
            $('#myModalNot').modal('show');
        }
        function fileupload(file) {
            if (file != null) {
                file = file.split('\\');
                var nombreArchivo = file[file.length - 1];
                document.getElementById("txtNombreArchivo").value = nombreArchivo;
                document.getElementById("divDescImagen").style.visibility = "visible";
            }
        }

        $(function () {
            $("#dialogimg").dialog({
                autoOpen: false,
                show: {
                    effect: "blind",
                    duration: 1000
                },
                hide: {
                    effect: "explode",
                    duration: 1000
                }
            });

            $(".lblNombreCls").hover(function () {
                $("#dialogimg").dialog("open");
            });
        });

        function valObl(control) {
            if (control.value != '') {
                control.className = 'valTrue';
            }
            else {
                control.className = 'valFalse'
            }

        }

        function Validar(obj) {
            //alert('hola');
            //if (control = 'ddlCiudad') {
            //    if (obj.value = 'Ciudad...') {
            //        obj.className = 'form-control form-control-obligatorio';
            //        ValidatorEnable(document.getElementById("RequiredFieldValidator2"), true);
            //    }
            //}
            //else {
            if (obj.value == '') {
                if (control = 'txtNombre') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator1"), true);
                }

                if (control = 'txtDescCortaCircuito') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator5"), true);
                }
                if (control = 'txtDescripcion') {
                    obj.className = 'form-control form-control-obligatorio';
                    ValidatorEnable(document.getElementById("RequiredFieldValidator6"), true);
                }

            }
            else {
                obj.className = 'form-control';
            }
            //}

        }

        function openModalOrden() {
            $('#myModalOrden').modal('show');
        }

        function openModalLogin() {
            $('#myModalLogin').modal('show');
        }
    </script>

    <style>
        .validar {
            /*background-color: #ff4081;*/
            border-color: #ff4081;
        }

        .oculto {
            visibility: hidden;
        }

        .modalBackground {
            filter: alpha(opacity=50);
            opacity: 0.5;
            background-color: rgb(6, 6, 6);
        }

        .modalPnl {
            display: block;
            width: 30%;
            height: 30%;
            background-color: White;
            border-width: 1px;
            border-color: #333;
            border-style: solid;
            padding: 10px;
            border-radius: 15px;
            overflow-x: hidden;
            overflow-y: hidden;
        }

        .txt-hidden {
            visibility: hidden;
        }

        .form {
            text-align: center
        }

        .td {
            text-align: left;
        }
        /*.valFalse {
            border:1px solid lightcoral;
        }

        .valTrue {
            border: 1px solid lightcoral;
        }*/
    </style>

</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="p" style="position: fixed; background-color: white; width: 100%; height: 100%; z-index: 2; top: 1PX; left: 1px; display: none; text-align: center; vertical-align: central;">
            <div style="display: inline-block; padding-top: 15%">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/MEDIA/IMG/spinner2.gif" />
            </div>
        </div>
        <div class="container" style="width: 100%; height: 100%">
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
                        <div class="text-right">
                           <%-- <asp:LinkButton ID="btnAyuda" runat="server" ForeColor="White" Font-Size="14px">Ayuda</asp:LinkButton>
                            <asp:Label ID="lblespacio" runat="server" Text="|||" ForeColor="#3c6299"></asp:Label>--%>
                            <asp:LinkButton ID="btnSalir" runat="server" OnClick="btnSalir_Click" ForeColor="White" Font-Size="14px">Salir</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div id="divTtlCircuitos" class="container" runat="server" style="font-family: 'Century Gothic'" visible="true">
                <h5>Tus Circuitos.</h5>
                <span class="num-of-ads">Espacio para crear todos los circuitos que desees y modificar los que creaste anteriormente, ten en cuenta que el exito de tus recorridos depende de la 
            calidad de la información con que los describas.</span>
            </div>
            <br />

            <div id="cntCircuitos" class="container" runat="server">
                <div class="row text-center text-lg-left">
                </div>
            </div>

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

            <div class="modal fade" id="myModalErr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <%--<img src="Media/img/AtencionPeq.png" />--%>
                                </div>
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongError">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h6>ATENCIÓN!.</h6>
                                    <br />
                                    <asp:Label ID="lblError" runat="server" Text="Este servicio esta en mantenimiento, disculpe la molestia."></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModalLogin" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" data-keyboard="false" data-backdrop="static">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <div class="row">
                                <div class="col-sm-4">
                                    <%--<img src="Media/img/AtencionPeq.png" />--%>
                                </div>
                                <div class="col-sm-8 div-center">
                                    <h5 class="modal-title" id="exampleModalLongLogin">Atención!</h5>
                                </div>
                            </div>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h6>Tu sesión ha expirado!.</h6>
                                    <br />
                                    Serás redireccionado a la página de ingreso.
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <%--<button type="button" class="btn btn-secondary" data-dismiss="modal"><a href="Login.aspx"></a>Aceptar</button>--%>
                            <input type="button" class="btn btn-secondary" onclick="location.href = '../Login.aspx';" value="Aceptar" />
                        </div>
                    </div>
                </div>
            </div>

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
                            <input type="button" class="btn btn-secondary" onclick="location.href = 'Index.aspx?ini=1';" value="Aceptar" />
                        </div>
                    </div>
                </div>
            </div>
            <%-- <footer>
                <p>Company © W3docs. All rights reserved.</p>
            </footer>--%>
        </div>

    </form>

</body>
</html>
