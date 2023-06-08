using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using CDI.Comun;
using CT.ADMIN.BL;
using Ent_BpmNet.Administrador;


namespace CT.ADMIN.WS
{
    /// <summary>
    /// Descripción breve de AppToTripWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AppToTripWS : System.Web.Services.WebService
    {
        Metodos metodos;
        [WebMethod]
        public DataTable pa_Actualizar_Usuario(string IdUsuario, string Nombres, string Apellidos, string TipoDocumento, string DocumentoUsuario, int Ciudad, string FechaNacimiento, string NumeroCertificado, string VigenciaCertificado)
        {
            metodos = new Metodos();
            return metodos.pa_Actualizar_Usuario(IdUsuario, Nombres, Apellidos, TipoDocumento, DocumentoUsuario, Ciudad, FechaNacimiento, NumeroCertificado, VigenciaCertificado).Tables["Table"]; ;
        }

        [WebMethod]
        public DataTable pa_Consulta_Circuito(string CodIdioma,int fk_usuario)
        {
            metodos = new Metodos();
            return metodos.pa_Consulta_Circuito(CodIdioma, fk_usuario).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_Categorias(string CodIdioma)
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_Categorias(CodIdioma).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_Ciudades(string CodPais)
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_Ciudades(CodPais).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_ImagenSitio(int IdSitio)
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_ImagenSitio(IdSitio).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_Paises()
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_Paises().Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_Sitios(string CodIdioma, string IdCircuito)
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_Sitios(CodIdioma, IdCircuito).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_TipoId()
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_TipoId().Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consultar_Usuario(int IdUsuario)
        {
            metodos = new Metodos();
            return metodos.pa_Consultar_Usuario(IdUsuario).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Delete_Circuito(int id_circuito)
        {
            metodos = new Metodos();
            return metodos.pa_Delete_Circuito(id_circuito).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Delete_Imagenes(int id_imagen)
        {
            metodos = new Metodos();
            return metodos.pa_Delete_Imagenes(id_imagen).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Delete_Sitio(int Id_Sitio)
        {
            metodos = new Metodos();
            return metodos.pa_Delete_Sitio(Id_Sitio).Tables["Table"];
        }

        [WebMethod]
        public string pa_Insert_Circuito(string nombre, string contexto, string descripcion_corta, string descripcion, string recomendaciones, string equipamento, int fk_rango_edad, string tiempo_estimado, string codigo_idioma, int fk_categoria, int fk_ciudad, int fk_usuario, string imagen, string imagen_img, int valor, int otra_moneda)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_Circuito(nombre, contexto, descripcion_corta, descripcion, recomendaciones, equipamento, fk_rango_edad, tiempo_estimado, codigo_idioma, fk_categoria, fk_ciudad, fk_usuario,imagen,imagen_img,valor,otra_moneda);
        }


        [WebMethod]
        public DataTable pa_Insert_ImagenSitio(string imagen, string imagen_img, int orden, int fk_sitio)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_ImagenSitio(imagen, imagen_img, orden, fk_sitio).Tables["Table"];
        }

        [WebMethod]
        public string pa_Insert_Sitio(string latitud, string longitud, string direccion, string costo, string nombre, String descripcion_corta, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, string horario, string tiempo_estimado, string telefono_sitio, int fk_circuito, int orden)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_Sitio(latitud, longitud, direccion, costo, nombre, descripcion_corta, descripcion, equipamento,
            recomendaciones, ira, codigo_idioma, horario, tiempo_estimado, telefono_sitio, fk_circuito, orden);
        }


        [WebMethod]
        public DataTable pa_Inserta_Usuario(string nombres_usuario, string apellido_usuario, string tipo_documento, string documento_usuario,
            string correo_usuario, string fecha_nacimiento, int ciudad, string clave, string foto_cuenta, int perfil, string numero_certificado, string vigencia_certificado, string foto_certificado, int estado)
        {
            metodos = new Metodos();
            return metodos.pa_Inserta_Usuario(nombres_usuario, apellido_usuario, tipo_documento, documento_usuario,
                   correo_usuario, fecha_nacimiento, ciudad, clave, foto_cuenta, perfil, numero_certificado, vigencia_certificado, foto_certificado, estado).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Recuperar_Usuario(string Usuario)
        {
            metodos = new Metodos();
            return metodos.pa_Recuperar_Usuario(Usuario).Tables["Table"];
        }

        [WebMethod]
        public string pa_Update_Circuito(int id_circuito, string nombre, string contexto, string descripcion_corta, string descripcion, string recomendaciones, string equipamento, int fk_rango_edad, string tiempo_estimado, string codigo_idioma, int fk_categoria, string imagen, string imagen_img, int valor, int otra_moneda)
        {
            metodos = new Metodos();
            return metodos.pa_Update_Circuito(id_circuito,nombre,contexto, descripcion_corta, descripcion, recomendaciones, equipamento, fk_rango_edad, tiempo_estimado, codigo_idioma, fk_categoria, imagen, imagen_img,valor,otra_moneda);
        }
        
        [WebMethod]
        public DataTable pa_Update_ImagenSitio(string imagen, int orden, int fk_sitio)
        {
            metodos = new Metodos();
            return metodos.pa_Update_ImagenSitio(imagen, orden, fk_sitio).Tables["Table"];
        }

        [WebMethod]
        public string pa_Update_Sitio(int id_sitio, string latitud, string longitud, String descripcion_corta, string direccion, string costo, string nombre, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, string horario, string tiempo_estimado, string telefono_sitio, int fk_circuito, int orden)
        {
            metodos = new Metodos();
            return metodos.pa_Update_Sitio(id_sitio,latitud, longitud, direccion, costo, nombre, descripcion_corta, descripcion, equipamento,
            recomendaciones, ira, codigo_idioma, horario, tiempo_estimado, telefono_sitio, fk_circuito, orden);
        }


        [WebMethod]
        public string pa_Send_Mail(string Correo, string Asunto, string Mensaje)
        {
            metodos = new Metodos();
            return metodos.pa_Send_Mail(Correo, Asunto,Mensaje);
        }

        [WebMethod]
        public string pa_Traducir(string text, string Entrada, string Salida)
        {
            metodos = new Metodos();
            return metodos.pa_Traducir(text, Entrada, Salida);
        }

        /*
            Creado by: Juan Moreno
        */
        [WebMethod]
        public string pa_Insert_Categoriar(string nombre_categoria, string codigo_idioma)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_Categoria(nombre_categoria,codigo_idioma);
        }

        [WebMethod]
        public string pa_Validacion_Estado(int id_usuario)
        {
            metodos = new Metodos();
            return metodos.pa_Validacion_Estado(id_usuario);
        }

        [WebMethod]
        public string pa_Insert_Tduracion(string tabla, string codigo_idioma, string texto)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_Tduracion(tabla, codigo_idioma, texto);
        }

        [WebMethod]
        public DataTable pa_Consulta_Generica(string tabla, string codigo_idioma)
        {
            metodos = new Metodos();
            return metodos.pa_Consulta_Generica(tabla, codigo_idioma).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Consulta_Generica_Moneda(string tabla)
        {
            metodos = new Metodos();
            return metodos.pa_Consulta_Generica_Moneda(tabla).Tables["Table"];
        }

        [WebMethod]
        public DataTable pa_Update_Imagen_Circuito(string imagen, string imagen_img, int id_circuito)
        {
            metodos = new Metodos();
            return metodos.pa_Update_Imagen_Circuito(imagen, imagen_img, id_circuito).Tables["Table"];
        }

        [WebMethod]
        public string pa_Update_Circuito_2(int fk_categoria, int valor, int otra_moneda, int fk_rango_edad, int id_circuito, string nombre = null, string contexto = null, string descripcion_corta = null, string descripcion = null, string recomendaciones = null, string equipamento = null, string tiempo_estimado = null, string codigo_idioma = null, string imagen= null, string imagen_img = null)
        {
            metodos = new Metodos();
            return metodos.pa_Update_Circuito_2(fk_categoria, valor, otra_moneda, fk_rango_edad, id_circuito, nombre, contexto, descripcion_corta, descripcion, recomendaciones, equipamento, tiempo_estimado, codigo_idioma, imagen, imagen_img);
        }

        [WebMethod]
        public string pa_Update_Sitio_2(int fk_circuito, int orden, int id_sitio, string latitud = null, string longitud = null, string direccion = null, string costo = null, string nombre = null, string descripcion_corta = null, string descripcion = null, string equipamento = null,
            string recomendaciones = null, string ira = null, string codigo_idioma = null, string horario = null, string tiempo_estimado = null, string telefono_sitio = null)
        {
            metodos = new Metodos();
            return metodos.pa_Update_Sitio_2(fk_circuito, orden, id_sitio, latitud, longitud, direccion, costo, nombre, descripcion_corta, descripcion, equipamento, recomendaciones, ira, codigo_idioma, horario, tiempo_estimado, telefono_sitio);
        }
        
        [WebMethod]
        public string GeneraStream(string tabla, string clave, string campo, string cadena, string codigo_idioma)
        {
            metodos = new Metodos();
            return metodos.GeneraStream(tabla,clave,campo,cadena, codigo_idioma);
        }

        [WebMethod]
        public string pa_Actualiza_General(string tabla, string clave, string campo, string valor, string codigo_idioma)
        {
            metodos = new Metodos();
            return metodos.pa_Actualiza_General(tabla,clave,campo,valor, codigo_idioma);
        }

        [WebMethod]
        public string pa_Insert_General(string tabla, string clave, string campo, string valor, string codigo_idioma)
        {
            metodos = new Metodos();
            return metodos.pa_Insert_General(tabla, clave, campo, valor, codigo_idioma);
        }
        
        [WebMethod]
        public string generastream_programado(string tabla)
        {
            metodos = new Metodos();
            return metodos.generastream_programado(tabla);
        }
        [WebMethod]
        public string validar_traduce()
        {
            metodos = new Metodos();
            return metodos.validar_traduce();
        }
        [WebMethod]
        public string validar_stream()
        {
            metodos = new Metodos();
            return metodos.validar_stream();
        }
    }

}