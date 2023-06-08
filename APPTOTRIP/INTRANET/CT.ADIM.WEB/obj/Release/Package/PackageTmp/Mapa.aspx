<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mapa.aspx.cs" Inherits="CT.ADIM.WEB.Mapa" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Maps</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.6/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.2.1/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <script src=" https://unpkg.com/popper.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
    <script src="MEDIA/JS/bootstrap.bundle.min.js"></script>  
    <script src="MEDIA/JS/local.js"></script>
    <link href="MEDIA/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/portfolio-item.css" rel="stylesheet" />
    <link href="MEDIA/CSS/thumbnail-gallery.css" rel="stylesheet" />
    <link href="MEDIA/CSS/sb-admin-2.min.css" rel="stylesheet" />
    <link href="MEDIA/CSS/local.css" rel="stylesheet" />
    <link href="~/Media/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="~/Media/css/PersonalizadoBPM.css" rel="stylesheet" />
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"></script>
    <style>

        .slidecontainer {
 width: 100%;
}

.progres {
 -webkit-appearance: none;
 width: 60%;
 height: 15px;
 border-radius: 5px;
 background: #d3d3d3;
 outline: none;
 opacity: 0.7;
 -webkit-transition: .2s;
 transition: opacity .2s;
}

.progres:hover {
 opacity: 1;
}

.progres::-webkit-slider-thumb {
 -webkit-appearance: none;
 appearance: none;
 width: 25px;
 height: 25px;
 border-radius: 50%;
 background: #17a2b8;
 cursor: pointer;
}

.progres::-moz-range-thumb {
 width: 25px;
 height: 25px;
 border-radius: 50%;
 background: #4CAF50;
 cursor: pointer;
}

        #map {
            height: 100%;
        }
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

       

        #description {
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
        }

        #infowindow-content .title {
            font-weight: bold;
        }

        #infowindow-content {
            display: none;
        }

        #map #infowindow-content {
            display: inline;
        }

        .pac-card {
            margin: 10px 10px 10px 10px;
            border-radius: 2px 0 0 2px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
            outline: none;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
            background-color: #fff;
            font-family: Roboto;
        }

        #pac-container {
            padding-bottom: 12px;
            margin-right: 12px;
        }

        .pac-controls {
            display: inline-block;
            padding: 5px 11px;
        }

            .pac-controls label {
                font-family: Roboto;
                font-size: 13px;
                font-weight: 300;
            }

        #pac-input {
            background-color: #fff;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            text-overflow: ellipsis;
            width: 400px;
            margin: 10px;
        }

            #pac-input:focus {
                border-color: #4d90fe;
            }

        #title {
            color: #fff;
            background-color: #4d90fe;
            font-size: 25px;
            font-weight: 500;
            padding: 6px 12px;
        }

        #target {
            width: 345px;
        }
        #div_info {
            background-color: #fff;
        }
        #info {
            background-color: #fff;            
            float:right;
            height:100%;
            width:30%;
            overflow:auto;
            display:none;
            border-left:1px solid #108fc7;
        }
        #nombreC, #contexto, #nombreS, #imagenS, #descripC, #descripL, #ira {  
            padding:8px;
            
        }
        .imageng{
            padding:0px;
        }
        .collapsible {          
          cursor: pointer;
          padding: 8px;
          width: 100%;
          height:auto;
          border: none;
          text-align: left;
          outline: none;
          font-size: 15px;
        }
        .active, .collapsible:hover {
          background-color: #ccc;
        }
        .content {
          padding:10px;
          display: none;
          overflow: hidden;
          width:100%;
        }
        #audio{
            float:right;
        }
        .slider{
            width:100%;   
            overflow:hidden;
        }
        .slider ul{
            width:500%;
            padding:0px;    
            display:flex;   
            animation: cambio 20s infinite alternate;
        }
        .slider li{
            width:100%;
            list-style:none;
        }

        .slider img{
            width:100%;
            height: 250px;  
        }

        @keyframes cambio {
            0% {margin-left:0}
            20% {margin-left:0}

            20% {margin-left:-100%}
            40% {margin-left:-100%}

            40% {margin-left:-200%}
            60% {margin-left:-200%}

            60% {margin-left:-300%}
            80% {margin-left:-300%}

            80% {margin-left:-400%}
            100% {margin-left:-400%}
        }
        #porcentaje{
            float:right;
        }
        #duracion_ct,#duracion_dc,#duracion_dl,#duracion_ira{
            width:85%;
        }


/*/#duracion {width:100px;border:1px solid #808080;height:20px;margin:2px;}
#duracion,
#botones {padding:1px;float:left;}
#duracion span {width:1px;background-color:#bfbfbf;height:20px;position:absolute;}
#botones {margin-left:5px;}
#botones button {font-size:1em;width:30px;}
*/
    </style>
    <script>
        function verCoord(lat, lon) {
            var vlat = document.getElementById("hdlat");
            var vlon = document.getElementById("hdlon");
            vlat.value = lat;
            vlon.value = lon;
            if (lat == 0 && lon != 0) {
                var obj = JSON.parse(lon);
                document.getElementById("obj").value = lon;
                vlat.value = obj[0].latitud;
                vlon.value = obj[0].longitud;
                document.getElementById("form1").style.display = "none";

            }
            //alert(lat + ' ' + lon);
        }

        var interval;
        var duracion = 0;
        var audio;
        var progressss;
        var click = true;
        var du;
        var icon;
        function Play(id, du_e) {
            audio = document.getElementById(id);
            //icon = document.getElementsByClassName('fa','fa-play');
            du = du_e;
            audio.ondurationchange = function () {
                duracion = audio.duration;
            }
            if (audio.paused) {
                $(".playicon").removeClass("fa fa-play");
                $(".playicon").addClass("fa fa-pause");
                audio.play();
                interval = setInterval(mostrarDuracion, 100);
            }
            else if (audio.play) {
                audio.pause();
                $(".playicon").removeClass("fa fa-pause");
                $(".playicon").addClass("fa fa-play");
                clearInterval(interval);
            }
            //document.getElementById("audio").style.display = "none";
        }


        function Reiniciar(id) {
            // nos posicionamos al inicio de la cancion
            audio.currentTime = 0;
            if (audio.paused) {
                duracion = 0;
                progressss.value = 0;
                //audio.play();
                //interval=setInterval(mostrarDuracion,100);
            }

        }
        function Stop(id) {
            // nos posicionamos al inicio de la cancion
            $(".playicon").removeClass("fa fa-pause");
            $(".playicon").addClass("fa fa-play");
            audio.pause();
            audio.currentTime = 0;
            duracion = 0;
            progressss.value = 0;

        }

        function mostrarDuracion() {
            duracion = audio.duration;
            progressss = document.getElementById("barraprogres_" + du);
            progressss.max = duracion;
            progressss.onchange = function () {
                //alert('hey');
                if (!click) {
                    audio.currentTime = progressss.value;
                    click = true;
                }
            }
            progressss.oninput = function () {
                click = false;
            }


            if (duracion > 0) {
                porcentaje = audio.currentTime * 100 / duracion;
                if (click) {
                    progressss.value = audio.currentTime;
                }
                document.getElementById("duracion_" + du).getElementsByTagName("span")[0].style.width = porcentaje + "px";
                document.getElementById("duracion_" + du).getElementsByTagName("h1")[0].innerHTML = parseInt(porcentaje) + "%";
            } else {
                document.getElementById("duracion_" + du).getElementsByTagName("span")[0].style.width = 0 + "px";
                document.getElementById("duracion_" + du).getElementsByTagName("h1")[0].innerHTML = parseInt(0) + "%";
            }
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdlat" runat="server" />
        <asp:HiddenField ID="hdlon" runat="server" />
        <asp:HiddenField ID="obj" runat="server" />  
        <div class="container" style="width: 70%; padding: 10px">
            <div class="row" style="background-color: white; border: 1px solid #999999; border-radius: 10px 10px">
                <div class="col-sm-1">Latitud:</div>
                <div class="col-sm-3">
                    <asp:TextBox ID="txtLat" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                </div>
                <div class="col-sm-1">Longitud:</div>
                <div class="col-sm-3">                                                                                                                                                                                                                                                                                                                                                                                                                              
                    <asp:TextBox ID="txtLon" runat="server" CssClass="form-control" ReadOnly="false"></asp:TextBox>
                </div>
                <div class="col-sm-3">
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-primary" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
        <div style="width: 100%; height: 100%">
        </div>        
    </form>
    <div id="div_info"></div>     
    <div id="audiosdl"></div> 
    <div id="audiosdc"></div> 
    <div id="audiosira"></div> 
    <div id="audiosct"></div> 
    <input id="pac-input" class="form-control" type="text" placeholder="Buscar Ciudad" style="direction: ltr; overflow: hidden; text-align: center; height: 40px; display: table-cell; vertical-align: middle; position: relative; color: rgb(86, 86, 86); font-family: Roboto, Arial, sans-serif; user-select: none; font-size: 18px; background-color: rgb(255, 255, 255); padding: 0px 17px; border-bottom-right-radius: 2px; border-top-right-radius: 2px; background-clip: padding-box; box-shadow: rgba(0, 0, 0, 0.3) 0px 1px 4px -1px; min-width: 62px; border-left: 0px;" />
    <div id="info"> 
        <button type="button" class="collapsible"><h1 id="nombre_circuito"></h1></button>
        <div class="content">
            <div class="slider">
                <ul id="lista_img"></ul>
            </div>
            <h1 >Contexto</h1>
            <h1 id="ct"></h1>
            <p id="contexto_circuito"></p>
        </div>
        <div id="nombreS">
                <h1 id="nombre_sitio">Plaza de Bolivar</h1>
        </div>           
        <div id="imagenS">
                <h1 id="imagen_sitio"></h1>
        </div>   
        <div id="descripC">
                <h1 >Descripcion Corta</h1>
                <h1 id="imgdesc"></h1>
                <p id="descripc_sitio"></p>
        </div>   
        <div id="descripL">
                <h1 >Descripcion Larga</h1>
                <h1 id="imgdes"></h1>
                <p id="descripl_sitio"></p>
        </div>
        <div id="ira">
                <h1>Indicaciones (IRA)</h1>
                <h1 id="irah"></h1>
                <p id="irap"></p>
        </div>  
    </div> 
    <div id="map">        
    </div>

    
    
    <!--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_BcdT_heUpoSU7iFbndqI_rxmMbFsHAA&callback=initMap" async defer></script>-->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyD_BcdT_heUpoSU7iFbndqI_rxmMbFsHAA&libraries=places&callback=initMap" async defer></script>  
    <script>
        var markerp;

        function initMap() {

            var myLatLng = { lat: 4.709319, lng: -74.076472 };

            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 17,
                center: myLatLng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
            var infowindow = new google.maps.InfoWindow;
            var vvlat = document.getElementById("hdlat");
            var vvlon = document.getElementById("hdlon");
            var vlat = parseFloat(vvlat.value);//cargue estas variables con los valores
            var vlon = parseFloat(vvlon.value);//cargue estas variables con los valores
            if (isNaN(vlat) || isNaN(vlon)) {
                map.addListener('click', function (e) {
                    placeMarkerAndPanTo(e.latLng, map);
                    document.getElementById("info").style.display = 'none'
                    /*Detener Audio*/
                });
                vlat = 0;
                vlon = 0;
                // Try HTML5 geolocation.
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {

                        map.setCenter(new google.maps.LatLng(position.coords.latitude, position.coords.longitude));
                        markerp = new google.maps.Marker({
                            map: map,
                            draggable: true,
                            animation: google.maps.Animation.DROP,
                            position: { lat: position.coords.latitude, lng: position.coords.longitude }
                        });

                        markerp.addListener('click', toggleBounce);

                    });
                }
                else {
                    map.addListener('click', function (e) {
                        placeMarkerAndPanTo(e.latLng, map);
                        document.getElementById("info").style.display = 'none'
                        /*Detener Audio*/
                    });
                    alert('Busca tu lugar de origen');
                }
            }
            else if (document.getElementById("obj").value != 0) {
                document.getElementById("pac-input").style.display = 'none';
                map.addListener('click', function (e) {
                    infowindow.close();
                    document.getElementById("info").style.display = 'none'
                    /*Detener Audio*/
                });

                var objE = JSON.parse(utf8_decode(document.getElementById("obj").value));
                var marker, i;
                var coll = document.getElementsByClassName("collapsible");
                var i;
                for (i = 0; i < coll.length; i++) {
                    coll[i].addEventListener("click", function () {
                        this.classList.toggle("active");
                        var content = this.nextElementSibling;
                        if (content.style.display === "block") {
                            content.style.display = "none";
                        } else {
                            content.style.display = "block";
                        }
                    });
                }
                var image = {
                    url: 'https://images.vexels.com/media/users/3/141915/isolated/lists/fa18fbc911311b5371870c880fa5f75a-pin-de-ubicacion.png',
                    scaledSize: new google.maps.Size(50, 60),
                    origin: new google.maps.Point(-1, -5),

                };

                var verticesLinea = [];
                try {
                    document.getElementById("lista_img").innerHTML += "<li><img src='" + objE[0].imagen + "' alt=''></li><li><img src='" + objE[1].imagen + "' alt=''></li><li><img src='" + objE[2].imagen + "' alt=''></li><li><img src='" + objE[3].imagen + "' alt=''></li><li><img src='" + objE[4].imagen + "' alt=''></li>";
                }
                catch (error) {
                    console.error(error);
                }
                for (i = 0; i < objE.length; i++) {
                    //console.log(objE[i].nombre_sitio);
                    var num = objE[i].orden;
                    var orden = num.toString();
                    document.getElementById("audiosdl").innerHTML +=
                        "<audio id='" + objE[i].id_sitio + "dl'><source src='http://api.apptotrip.com/produccion_audios/sitio_" + objE[i].id_sitio + "_descripcion_sitio_es.mp3' type='audio/mpeg' /></audio>";
                    /*audiosdc*/
                    document.getElementById("audiosdc").innerHTML +=
                        "<audio id='" + objE[i].id_sitio + "dc'><source src='http://api.apptotrip.com/produccion_audios/sitio_" + objE[i].id_sitio + "_descripcion_corta_sitio_es.mp3' type='audio/mpeg' /></audio>";
                    /*audiosira*/
                    document.getElementById("audiosira").innerHTML +=
                        "<audio id='" + objE[i].id_sitio + "ira'><source src='http://api.apptotrip.com/produccion_audios/sitio_" + objE[i].id_sitio + "_indicaciones_es.mp3' type='audio/mpeg' /></audio>";
                    /*audiosct*/
                    document.getElementById("audiosct").innerHTML +=
                        "<audio id='" + objE[i].id_sitio + "ct'><source src='http://api.apptotrip.com/produccion_audios/circuito_" + objE[i].id_circuito + "_contexto_es.mp3' type='audio/mpeg' /></audio>";

                    marker = new google.maps.Marker(
                        {
                            position: new google.maps.LatLng(objE[i].latitud, objE[i].longitud),
                            map: map,
                            label: orden,
                            icon: image,
                        }
                    );
                    var latitudes = parseFloat(objE[i].latitud);
                    var longitudes = parseFloat(objE[i].longitud);
                    verticesLinea[i] = ({ lat: latitudes, lng: longitudes });
                    google.maps.event.addListener(marker, 'click', (function (marker, i) {
                        return function () {
                            infowindow.setContent('<div><h1 class="imageng"><center>' + objE[i].nombre_sitio.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ") + '</center></h1><img class="imageng" width="150px" height="100px" src="' + objE[i].imagen + '"/></img></div><br><p>' + objE[i].descripcion_corta_sitio + '</p>');
                            infowindow.open(map, marker);
                            infowindow.setOptions({ maxWidth: 200 });
                            document.getElementById("barra")
                            document.getElementById("info").style.display = 'block';
                            document.getElementById("nombre_circuito").innerHTML = objE[i].nombre_circuito.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ");
                            document.getElementById("contexto_circuito").innerHTML = objE[i].contexto.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ");
                            document.getElementById("ct").innerHTML = "<div id='botones'><div id='duracion_ct'><span></span><button class='btn btn-outline-info' id='iniciar' onclick=Play('" + objE[i].id_sitio + "ct','ct')><i class='fa fa-play playicon'></i></button><button class='btn btn-outline-info' id='reanudar' onclick=Reiniciar('" + objE[i].id_sitio + "ct')><i class='fa fa-fast-backward'></i></button><button class='btn btn-outline-info' id='stop' onclick=Stop('" + objE[i].id_sitio + "ct')><i class='fa fa-stop'></i></button>    <input class='progres text-info' id='barraprogres_ct' type='range' min='0' max='" + duracion + "' step='0.01'><h1 id='porcentaje'></h1></div></div>";
                            document.getElementById("nombre_sitio").innerHTML = objE[i].nombre_sitio.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ") + " (" + objE[i].orden + ")";
                            document.getElementById("imagen_sitio").innerHTML = "<img id='pruebaimg' width='350px' height='200px' src='" + objE[i].imagen + "'/>";
                            document.getElementById("imgdesc").innerHTML = "<div id='botones'><div id='duracion_dc'><span></span><button class='btn btn-outline-info' id='iniciar' onclick=Play('" + objE[i].id_sitio + "dc','dc')><i class='fa fa-play playicon'></i></button><button class='btn btn-outline-info' id='reanudar' onclick=Reiniciar('" + objE[i].id_sitio + "dc')><i class='fa fa-fast-backward'></i></button><button class='btn btn-outline-info' id='stop' onclick=Stop('" + objE[i].id_sitio + "dc')><i class='fa fa-stop'></i></button>    <input class='progres text-info' id='barraprogres_dc' type='range' min='0' max='" + duracion + "' step='0.01'><h1 id='porcentaje'></h1></div></div>";
                            document.getElementById("descripc_sitio").innerHTML = objE[i].descripcion_corta_sitio.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ");
                            document.getElementById("imgdes").innerHTML = "<div id='botones'><div id='duracion_dl'><span></span><button class='btn btn-outline-info' id='iniciar' onclick=Play('" + objE[i].id_sitio + "dl','dl')><i class='fa fa-play playicon'></i></button><button class='btn btn-outline-info' id='reanudar' onclick=Reiniciar('" + objE[i].id_sitio + "dl')><i class='fa fa-fast-backward'></i></button><button class='btn btn-outline-info' id='stop' onclick=Stop('" + objE[i].id_sitio + "dl')><i class='fa fa-stop'></i></button>    <input class='progres text-info' id='barraprogres_dl' type='range' min='0' max='" + duracion + "' step='0.01'><h1 id='porcentaje'></h1></div></div>";
                            document.getElementById("descripl_sitio").innerHTML = objE[i].descripcion_sitio.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ");
                            document.getElementById("irah").innerHTML = "<div id='botones'><div id='duracion_ira'><span></span><button class='btn btn-outline-info' id='iniciar' onclick=Play('" + objE[i].id_sitio + "ira','ira')><i class='fa fa-play playicon'></i></button><button class='btn btn-outline-info' id='reanudar' onclick=Reiniciar('" + objE[i].id_sitio + "ira')><i class='fa fa-fast-backward'></i></button><button class='btn btn-outline-info' id='stop' onclick=Stop('" + objE[i].id_sitio + "ira')><i class='fa fa-stop'></i></button>    <input class='progres text-info' id='barraprogres_ira' type='range' min='0' max='" + duracion + "' step='0.01'><h1 id='porcentaje'></h1></div></div>";
                            document.getElementById("irap").innerHTML = objE[i].ira.replace("⬜", "-").replace("⬓", "''").replace("⬝", "''").replace("⬹", " ");


                        }

                    })(marker, i));
                    google.maps.event.addListener(infowindow, 'closeclick', function () {
                        document.getElementById("info").style.display = 'none';
                        progressss2 = document.getElementById("barraprogres_dc");
                        progressss2.value = 0;
                    });

                }
                var tour = new google.maps.Polyline({
                    path: verticesLinea,
                    map: map,
                    strokeColor: "#108fc7",
                    strokeOpacity: 0.6,
                    strokeWeight: 3
                });
                var centro = objE.length / 2;
                var centro2 = Math.floor(centro);

                map.setCenter(new google.maps.LatLng(objE[centro2].latitud, objE[centro2].longitud));
            }
            else {
                map.addListener('click', function (e) {
                    placeMarkerAndPanTo(e.latLng, map);
                    document.getElementById("info").style.display = 'none'
                    /*Detener Audio*/
                });
                markerp = new google.maps.Marker({
                    map: map,
                    draggable: true,
                    animation: google.maps.Animation.DROP,
                    position: { lat: vlat, lng: vlon },
                });
                markerp.addListener('click', toggleBounce);
                map.setCenter(new google.maps.LatLng(vlat, vlon));
            }

            // Create the search box and link it to the UI element.
            var input = document.getElementById('pac-input');
            var searchBox = new google.maps.places.SearchBox(input);
            map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

            // Bias the SearchBox results towards current map's viewport.
            map.addListener('bounds_changed', function () {
                searchBox.setBounds(map.getBounds());
            });

            var markers = [];
            // Listen for the event fired when the user selects a prediction and retrieve
            // more details for that place.
            searchBox.addListener('places_changed', function () {
                var places = searchBox.getPlaces();

                if (places.length == 0) {
                    return;
                }

                // Clear out the old markers.
                markers.forEach(function (marker) {
                    marker.setMap(null);
                });
                markers = [];

                // For each place, get the icon, name and location.
                var bounds = new google.maps.LatLngBounds();
                places.forEach(function (place) {
                    if (!place.geometry) {
                        console.log("Returned place contains no geometry");
                        return;
                    }
                    marker.setMap(null);
                    markerp = new google.maps.Marker({
                        map: map,
                        draggable: true,
                        animation: google.maps.Animation.DROP,
                        title: place.name,
                        position: place.geometry.location
                    });
                    markerp.addListener('click', toggleBounce);


                    if (place.geometry.viewport) {
                        // Only geocodes have viewport.
                        bounds.union(place.geometry.viewport);
                    } else {
                        bounds.extend(place.geometry.location);
                    }
                });
                map.fitBounds(bounds);
            });



        }

        function handleLocationError(browserHasGeolocation, infoWindow, pos) {
            infoWindow.setPosition(pos);
            infoWindow.setContent(browserHasGeolocation ?
                'Error: The Geolocation service failed.' :
                'Error: Your browser doesn\'t support geolocation.');
            infoWindow.open(map);
        }



        function toggleBounce() {

            markerp.setAnimation(google.maps.Animation.BOUNCE);

            var txtLat = document.getElementById("txtLat");
            var txtLon = document.getElementById("txtLon");
            txtLat.value = markerp.getPosition().lat();
            txtLon.value = markerp.getPosition().lng();
            // window.location = 'NuIm/Sitios.aspx?lat=' + marker.getPosition().lat() + "&lng=" + marker.getPosition().lng();
            //alert("posision " + markerp.getPosition().lat());

        }
        function placeMarkerAndPanTo(latLng, map) {
            markerp.setMap(null);
            markerp = new google.maps.Marker({
                map: map,
                draggable: true,
                animation: google.maps.Animation.DROP,
                position: latLng
            });
            markerp.addListener('click', toggleBounce);
            map.panTo(latLng);
        }

    </script>
    <script>
        function utf8_decode(strData) {

            var tmpArr = []
            var i = 0
            var c1 = 0
            var seqlen = 0

            strData += ''

            while (i < strData.length) {
                c1 = strData.charCodeAt(i) & 0xFF
                seqlen = 0

                if (c1 <= 0xBF) {
                    c1 = (c1 & 0x7F)
                    seqlen = 1
                } else if (c1 <= 0xDF) {
                    c1 = (c1 & 0x1F)
                    seqlen = 2
                } else if (c1 <= 0xEF) {
                    c1 = (c1 & 0x0F)
                    seqlen = 3
                } else {
                    c1 = (c1 & 0x07)
                    seqlen = 4
                }

                for (var ai = 1; ai < seqlen; ++ai) {
                    c1 = ((c1 << 0x06) | (strData.charCodeAt(ai + i) & 0x3F))
                }

                if (seqlen === 4) {
                    c1 -= 0x10000
                    tmpArr.push(String.fromCharCode(0xD800 | ((c1 >> 10) & 0x3FF)))
                    tmpArr.push(String.fromCharCode(0xDC00 | (c1 & 0x3FF)))
                } else {
                    tmpArr.push(String.fromCharCode(c1))
                }

                i += seqlen
            }

            return tmpArr.join('')
        }
    </script>
</body>
    
</html>
