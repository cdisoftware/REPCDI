function openModal() {

    $('#myModal').modal('show');
}

function openModalMsg() {
    $('#myModalMsg').modal('show');
}

function openModalNombreCirc() {
    $('#myModalNombre').modal('show');
}

function openModalNombreSitio() {
    $('#myModalNombreSitio').modal('show');
}

function openModalEncabezadoCirc() {
    $('#myModalEncabezado').modal('show');
}

function openModalEncabezadoSitio() {
    $('#myModalEncabezadoSitio').modal('show');
}

function openModalDescripcionCirc() {
    $('#myModalDescripcion').modal('show');
}

function openModalDescripcionSitio() {
    $('#myModalDescripcionSitio').modal('show');
}

function openModalDetallesCirc() {
    $('#myModalDetalles').modal('show');
}

function openModalDetallesSitio() {
    $('#myModalDetallesSitio').modal('show');
}

function openModalImagenes() {
    $('#myModalImagenes').modal('show');
}



function openModalOrdenSitio() {
    $('#myModalOrden').modal('show');
}

function iniControlFecha(obj) {
    obj.type = "date";
}

function Validar(obj) {
    if (obj.value == '' || obj.selectedIndex == 0) {
        obj.className = 'form-control form-control-obligatorio txt-width';
        if (obj.type == 'date') {
            obj.type = "text";
        }
        obj.placeholder = obj.placeholder + " [Obligatorio]";
    }
    else {
        obj.className = 'form-control txt-width';
    }
}

function ValidarBtnRegistro() {

    var txtNombre = document.getElementById("txtNombre");
    var txtApellido = document.getElementById("txtApellido");
    var ddlTipoId = document.getElementById("ddlTipoId");
    var txtNumeroId = document.getElementById("txtNumeroId");
    var ddlPais = document.getElementById("ddlPais");
    var ddlCiudad = document.getElementById("ddlCiudad");
    var txtFecNac = document.getElementById("txtFecNac");
    //var txtVigCert = document.getElementById("txtVigCert");
    //var txtNumCert = document.getElementById("txtNumCert");
    var txtEmail = document.getElementById("txtEmail");
    var txtClave = document.getElementById("txtClave");
    var txtClaveConf = document.getElementById("txtClaveConf");
    var txtImgCertificado = document.getElementById("txtImgCertificado");


    if (txtNombre != null) {
        if (txtNombre.value == '') {
            txtNombre.type = "text";
            txtNombre.className = 'form-control form-control-obligatorio txt-width';
            txtNombre.placeholder = "Nombres [Obligatorio]";
        }
    }

    if (txtApellido != null) {
        if (txtApellido.value == '') {
            txtApellido.type = "text";
            txtApellido.className = 'form-control form-control-obligatorio  txt-width';
            txtApellido.placeholder = "Apellidos [Obligatorio]";
        }
    }

    if (ddlTipoId != null) {
        if (ddlTipoId.selectedIndex == 0) {
            ddlTipoId.className = 'form-control form-control-obligatorio txt-width';
            // ddlTipoId.placeholder = "Tipo Id [Obligatorio";
        }
    }

    if (txtNumeroId != null) {
        if (txtNumeroId.value == '') {
            txtNumeroId.className = 'form-control form-control-obligatorio txt-width';
            txtNumeroId.placeholder = "Numero Id [Obligatorio]";
        }
    }

    if (ddlPais != null) {
        if (ddlPais.selectedIndex == 0) {
            ddlPais.className = 'form-control form-control-obligatorio txt-width';
            // ddlPais.placeholder = "Numero Id [Obligatorio]";
        }
    }

    if (ddlCiudad != null) {
        if (ddlCiudad.selectedIndex == 0) {
            ddlCiudad.className = 'form-control form-control-obligatorio txt-width';
            //  txtNumeroId.placeholder = "Numero Id [Obligatorio]";
        }
    }

    if (txtFecNac != null) {
        if (txtFecNac.value == '') {
            txtFecNac.type = "text";
            txtFecNac.className = 'form-control form-control-obligatorio txt-width';
            txtFecNac.placeholder = "Fecha Nacimiento [Obligatorio]";
        }
    }

    //if (txtVigCert != null) {
    //    if (txtVigCert.value == '') {
    //        txtVigCert.type = "text";
    //        txtVigCert.className = 'form-control form-control-obligatorio txt-width';
    //        txtVigCert.placeholder = "Vigencia Certificado [Obligatorio]";
    //    }
    //}

    //if (txtNumCert != null) {
    //    if (txtNumCert.value == '') {
    //        txtNumCert.className = 'form-control form-control-obligatorio txt-width';
    //        txtNumCert.placeholder = "Numero Certificado [Obligatorio]";
    //    }
    //}

    if (txtEmail != null) {
        if (txtEmail.value == '') {
            txtEmail.className = 'form-control form-control-obligatorio txt-width';
            txtEmail.placeholder = "Email [Obligatorio]";
        }
    }

    if (txtClave != null) {
        if (txtClave.value == '') {
            txtClave.className = 'form-control form-control-obligatorio txt-width';
            txtClave.placeholder = "Clave [Obligatorio]";
        }
    }

    if (txtClaveConf != null) {
        if (txtClaveConf.value == '') {
            txtClaveConf.className = 'form-control form-control-obligatorio txt-width';
            txtClaveConf.placeholder = "Confirmar Clave [Obligatorio]";
        }
    }

    if (txtImgCertificado != null) {
        if (txtImgCertificado.value == '') {
            //txtImgCertificado.className = 'form-control form-control-obligatorio txt-width';
            var imgCertificado = document.getElementById("lblImgCertificado")
            imgCertificado.style.color = "#ff0000";
            imgCertificado.innerHTML = "Imágen de Certificado [Obligatorio]";
        }
        else {
            var imgCertificado = document.getElementById("lblImgCertificado")
            imgCertificado.style.color = "#999999";
            imgCertificado.innerHTML = "Imágen de Certificado";
        }
    }

}

function verpopup() {
    var div = document.getElementById("divContenedor");
    div.style.visibility = "visible";

    var div1 = document.getElementById("divMensaje");
    div1.style.visibility = "visible";
}

function verpopupMapa() {
    var div = document.getElementById("divContenedor");
    div.style.visibility = "visible";

    var div1 = document.getElementById("divMapa");
    div1.style.visibility = "visible";
}

function cerrarpopup() {
    var div = document.getElementById("divContenedor");
    div.style.visibility = "hidden";

    var div1 = document.getElementById("divMensaje");
    div1.style.visibility = "hidden";
}

function redirect(codcircuito) {
    //window.location.href = 'index.aspx?ic=' + codcircuito;
    window.location.href = 'Circuitos.aspx?ic=' + codcircuito;
}

function redirectsitios(codsitio) {

    var idCirc = document.getElementById("hdIdCircuito").value;
    var lblMensaje = document.getElementById("lblMensajePU");
    if (idCirc != '0') {
        window.location.href = 'Sitios.aspx?is=' + codsitio;
    }
    else {
        //lblMensaje.innerHTML = "Debe guardar el circuito antes de crear un sitio.";
        //openModalMsg();
    }
}

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function soloNumeros(e) {
    var key = window.event ? e.which : e.keyCode;
    if (key < 48 || key > 57) {
        e.preventDefault();
    }
}

$(function () {
    $('.Fechas').datepicker(
        {
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            dayNamesMin: ["Do", "Lu", "Ma", "Mi", "Ju", "Vi", "Sa"],
            nextText: "Sig",
            prevText: "Ant",
            yearRange: '1950:2100'


        });
});

function countChars(obj) {
   
    var maxLength;
    if (obj.name == 'txtHorario' || obj.name == 'txtDireccion')
    {
        maxLength = 100;
    }
    if (obj.name != 'txtHorario' && obj.name != 'txtDireccion')
    {
        maxLength = 3000;
    }
    var strLength = obj.value.length;
    var charRemain = (maxLength - strLength);
    var valValido = '';

    if (charRemain < 0) {
        //Valida Sitio
        if (obj.name == 'txtDescripcionS') {
            document.getElementById("charNumDesc").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtIra') {
            document.getElementById("charNumIra").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtEquipamentoS') {
            document.getElementById("charNumEquip").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtRecomendacionesS') {
            document.getElementById("charNumRecom").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtHorario') {
            document.getElementById("charNumHorario").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtDireccion') {
            document.getElementById("charNumDirecSitio").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        // Valida Circuito
        if (obj.name == 'txtEquipamento') {
            document.getElementById("charNumEquip").innerHTML = '<span style="color: LightCoral;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtRecomendaciones') {
            document.getElementById("charNumRecom").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtDescripcion') {
            document.getElementById("charNumDesc").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        if (obj.name == 'txtContexto') {
            document.getElementById("charNumContextoCircuito").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        obj.value = document.getElementById("txtValidaCarac").value;
    }

    else {
        document.getElementById("txtValidaCarac").value = obj.value;
        //Valida Sitio
        if (obj.name == 'txtDescripcionS') {
            document.getElementById("charNumDesc").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtIra') {
            document.getElementById("charNumIra").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtEquipamentoS') {
            document.getElementById("charNumEquip").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtRecomendacionesS') {
            document.getElementById("charNumRecom").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtHorario') {
            document.getElementById("charNumHorario").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtDireccion') {
            document.getElementById("charNumDirecSitio").innerHTML = charRemain + ' caracteres restantes';
        }
        //Valida Circuito
        if (obj.name == 'txtEquipamento') {
            document.getElementById("charNumEquip").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtRecomendaciones') {
            document.getElementById("charNumRecom").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtDescripcion') {
            document.getElementById("charNumDesc").innerHTML = charRemain + ' caracteres restantes';
        }
        if (obj.name == 'txtContexto') {
            document.getElementById("charNumContextoCircuito").innerHTML = charRemain + ' caracteres restantes';
        }
    }

}

function countCharsDC(obj) {

    var maxLength = 200;
    var strLength = obj.value.length;
    var charRemain = (maxLength - strLength);
    var valValido = '';

    if (charRemain < 0) {
        //Valida Circuito
        if (obj.name == 'txtResumen') {
            document.getElementById("charNumSinopCircuito").innerHTML = '<span style="color: red;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        // Valida Sitio
        if (obj.name == 'txtResumenS') {
            document.getElementById("charNumSinopSitio").innerHTML = '<span style="color: LightCoral;"> Está sobrepasando el limite de ' + maxLength + ' caracteres permitidos.</span>';
        }
        obj.value = document.getElementById("txtValidaCarac").value;
    }

    else {
        document.getElementById("txtValidaCarac").value = obj.value;
        //Valida Circuito
        if (obj.name == 'txtResumen') {
            document.getElementById("charNumSinopCircuito").innerHTML = charRemain + ' caracteres restantes';
        }
        //Valida Sitio
        if (obj.name == 'txtResumenS') {
            document.getElementById("charNumSinopSitio").innerHTML = charRemain + ' caracteres restantes';
        }
    }
}

function EditValues(control) {
    var Editados = document.getElementById("hdEdit").value;
    document.getElementById("hdEdit").value = Editados + " " + control.name
}