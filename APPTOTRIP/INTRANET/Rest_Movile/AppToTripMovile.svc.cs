using CDI.Comun;
using CT.ADMIN.BL;
using Geocoding.Google;
using Geocoding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml.XPath;
using System.Web.UI;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.Services.Description;
using static CDI.Comun.Herramienta;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.Web.UI.WebControls.WebParts;
using System.Net.Http.Headers;


/*
    Modificado by:Jhonny Guarnizo 14/02/2020
*/

namespace Rest_Movile
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AppToTripMovile
    {

        //Metodos metodos;
        //MetodosMovile metodosMovile = new MetodosMovile();
        //variables globales

        string NombreSitio = null;
        string ResultadoConcat = null;
        string NameCity = null;
        string NameCountry = null;
        string NumberDay = null;


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Ciudades/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Ciudades(string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consultar_Ciudades().Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Macros/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Macros(string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consultar_Macros().Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Macro_Detalle/{nombre_macro}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Macro_Detalle(String nombre_macro, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Macro_Detalle(nombre_macro, codigo_idioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Circuitos_Macro/{codigo_idioma}/{token_persona}/{ids}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Circuitos_Macro(string codigo_idioma, string token_persona, string ids, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consulta_Circuito_Macro(codigo_idioma, token_persona, ids).Tables["Table"];

                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Ciudades_Cp/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Ciudades_Cp(String token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consultar_Ciudades_Cp(token_persona).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Categoria/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Categoria(string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consulta_Categoria(codigo_idioma).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Insert_Persona/{nombres_persona}/{apellidos_persona}/{correo_persona}/{celular_persona}/{token_persona}/{fecha_nacimiento}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Insert_Persona(string nombres_persona, string apellidos_persona, string correo_persona,
            string celular_persona, string token_persona, string fecha_nacimiento, string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Insert_Persona(nombres_persona, apellidos_persona, correo_persona, celular_persona, token_persona, fecha_nacimiento).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Calificacion_Circuito/{token_persona}/{fk_circuito}/{calificacion_circuito}/{comentario_circuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Calificacion_Circuito(string token_persona, string fk_circuito,
     string calificacion_circuito, string comentario_circuito, string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {

                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Calificacion_Circuito(token_persona, Convert.ToInt32(fk_circuito), Convert.ToInt32(calificacion_circuito), comentario_circuito), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;


            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Calificacion_Sitio/{token_persona}/{fk_sitio}/{valor}/{comentario}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Calificacion_Sitio(string token_persona, string fk_sitio,
        string valor, string comentario, string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {

                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Calificacion_Sitio(token_persona, Convert.ToInt32(fk_sitio), Convert.ToInt32(valor), comentario), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Calificacion_Usuario/{fk_persona}/{fk_usuario}/{calificacion_usuario}/{comentario_usuario}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Calificacion_Usuario(string fk_persona, string fk_usuario, string calificacion_usuario,
           string comentario_usuario, string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Calificacion_Usuario(Convert.ToInt32(fk_persona), Convert.ToInt32(fk_usuario), Convert.ToInt32(calificacion_usuario), comentario_usuario).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Personas/{correo_persona}/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Personas(string correo_persona, string token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Persona(correo_persona, token_persona), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;


            }
            else
            {
                return "{resultado:Error token cliente}";

            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Circuitos/{ciudad}/{codigo_idioma}/{pais}/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Circuitos(string ciudad, string codigo_idioma, string pais, string token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consulta_Circuitos(ciudad, codigo_idioma, pais, token_persona).Tables["Table"];

                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }


        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir/{text}/{Entrada}/{Salida}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Traducir(string text, string Entrada, string Salida, string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {

                MetodosMovile metodosMovile = new MetodosMovile();
                string a = metodosMovile.mv_Traducir(text, Entrada, Salida);
                return a;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traduccion_Circuitos/{fk_circuito}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Traduccion_Circuitos(string fk_circuito, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Traduccion_Circuito(Convert.ToInt32(fk_circuito), codigo_idioma).Tables["Table"];

                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }


        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traduccion_Sitios/{fk_sitio}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Traduccion_Sitios(string fk_sitio, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Traduccion_Sitio(Convert.ToInt32(fk_sitio), codigo_idioma).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }


        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Circuito_Info/{id_circuito}/{codigo_idioma}/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Circuito_Info(string id_circuito, string codigo_idioma, string token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Circuito_Info(Convert.ToInt32(id_circuito), codigo_idioma, token_persona), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }


        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Recorrido_Circuito/{fk_circuito}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Recorrido_Circuito(string fk_circuito, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Consulta_Recorrido_Circuito(Convert.ToInt32(fk_circuito), codigo_idioma).Tables["Table"];

                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Sitio_Info/{id_sitio}/{codigo_idioma}/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Sitio_Info(string id_sitio, string codigo_idioma, string token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Sitio_Info(Convert.ToInt32(id_sitio), codigo_idioma, token_persona), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Web/{id_sitio}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Web(string id_sitio, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Web(Convert.ToInt32(id_sitio), codigo_idioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Comprar_Circuito/{persona_token}/{fk_circuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Comprar_Circuito(string persona_token, string fk_circuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Comprar_Circuito(persona_token, Convert.ToInt32(fk_circuito)), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Asignar_Circuito/{persona_token}/{fk_circuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Asignar_Circuito(string persona_token, string fk_circuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Asignacion_Circuito(persona_token, Convert.ToInt32(fk_circuito)), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Circuitos_Persona/{persona_token}/{fk_circuito}/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Circuitos_Persona(string persona_token, string fk_circuito, string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Circuitos_Persona(persona_token, Convert.ToInt32(fk_circuito), codigo_idioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Finalizar_Circuito/{persona_token}/{fk_circuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Finalizar_Circuito(string persona_token, string fk_circuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Finalizar_Circuito(Convert.ToInt32(fk_circuito), persona_token), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Finalizar_Sitio/{persona_token}/{id_sitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Finalizar_Sitio(string persona_token, string id_sitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Finalizar_Sitio(Convert.ToInt32(id_sitio), persona_token), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";

            }

        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Registro_FCM/{token_persona}/{token_FCM}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Registro_FCM(string token_persona, string token_FCM, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Token_FCM(token_persona, @token_FCM).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }
        [OperationContract]
        [WebGet(UriTemplate = "Movile_Notificacion/{codigo_idioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Notificacion(string codigo_idioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Consulta_Msm_Admin(codigo_idioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Respuesta_Encuesta/{id_encuesta}/{token_persona}/{respuesta}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Respuesta_Encuesta(string id_encuesta, string token_persona, string respuesta, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                dataTable = metodosMovile.mv_Respuesta_Encuesta(id_encuesta, token_persona, respuesta).Tables["Table"];
                string json = JsonConvert.SerializeObject(dataTable, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Actualiza_persona/{correo_persona}/{token_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Actualiza_persona(string correo_persona, string token_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_Actualiza_persona(correo_persona, token_persona), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }



        [OperationContract]
        [WebGet(UriTemplate = "Movile_consulta_persona_Recuperar/{correo_persona}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_consulta_persona_Recuperar(string correo_persona, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.mv_consulta_persona_Recuperar(correo_persona), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_valida_Idioma/{idCircuito}/{CodIdioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_valida_Idioma(string idCircuito,string CodIdioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.au_Validar_Traduccion_Circuito(idCircuito,CodIdioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_valida_Idioma_Sitio/{IdSitio}/{CodIdioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_valida_Idioma_sitio(string IdSitio, string CodIdioma, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                MetodosMovile metodosMovile = new MetodosMovile();
                string json = JsonConvert.SerializeObject(metodosMovile.au_Validar_Traduccion_Sitio(IdSitio, CodIdioma), Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
            }
            else
            {
                return "{resultado:Error token cliente}";
            }

        }

        // GENERACION DE CIRCUITOS AUTOMATICOS 


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Crear_Circuitos/{nameCity}/{nameCountry}/{parEntrada}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string GeneraCircuito(string nameCity, string nameCountry, string parEntrada, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();

            if (TokenApi == Desencripta)
            {
                try
                {

                    
                    string NameCity = nameCity;
                    string NameCountry = nameCountry;
                    string NumberDay = parEntrada;
                    int numeroDia = int.Parse(parEntrada);
                    
                    try
                    {
                        string Resultado = String.Format("{0} {1}, {2}", NameCity, NameCountry, NumberDay);
                        ResultadoConcat = $"{NameCity} {NameCountry}, {NumberDay}";

                        

                        NombreSitio = ResultadoConcat;
                        string[] SinDay = NombreSitio.Split(',');
                        string nombreciudad = SinDay[0];
                        DataTable dtPreguntas = metodosMovile.au_Consulta_Circuito(NombreSitio);

                        string PreguntaDos = dtPreguntas.Rows[0]["Pregunta_Circuito"].ToString().Replace("rplcnombresitio", NombreSitio);


                        string PreguntaCircuito = PreguntaDos.Replace("rplcnombresitio", ResultadoConcat);
                        DataTable UbicacionCircuito = metodosMovile.ConsultaNombreCiudad(nameCity, nameCountry);

                            string idCiudad = UbicacionCircuito.Rows[0]["id_ciudad"].ToString();
                            string idPais = UbicacionCircuito.Rows[0]["id_pais"].ToString();
                            string Respuesta = ConsumeGpt(PreguntaCircuito);
                        

                        if (Respuesta != null || Respuesta.Length > 0)
                        {
                            string latitudCapa = string.Empty;
                            string longitudCapa = string.Empty;
                            string img = buscarImagen(nombreciudad);
                            string NumDias = SinDay[1]+" día";
                            if (NumDias != "1")
                            {
                                NumDias = SinDay[1] + " días";
                            }
                            Coordenadas getCoordenada = BuscarCoordenadas(NameCity, NameCountry);
                            if (getCoordenada != null)
                            {
                                latitudCapa = getCoordenada.Latitud;
                                longitudCapa = getCoordenada.Longitud;
                            }
                                int estadoCircuito = 1;
                                DataTable dtCircuito = ConvertirCadenaTablaCircuito(Respuesta);
                                string idCircuito = InsertaCircuitos(nombreciudad, dtCircuito, img, NumDias, idCiudad, estadoCircuito ,longitudCapa, latitudCapa);

                                CircuitoReturn response = new CircuitoReturn();
                                response.IdCircuito = idCircuito;
                                response.NombreSitio = nombreciudad;
                                response.Mensaje = nombreciudad;
                                response.Img = img;
                                response.numDia = numeroDia;
                                //nombreciudad + " está actualmente en proceso."
                                string json = JsonConvert.SerializeObject(response, Formatting.None);
                                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                            
                            return json;
                            
                        }
                        else
                        {   
                            
                            return "{resultado:Ha ocurrido un error con la creación del circuito al realizar la peticion con GPT}";
                        }
                    }
                    catch (Exception ex)
                    {
                        return ex.Message; 
                     
                    }


                }
                catch (Exception ex)
                {
                    return ex.Message;
            
                }


            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        public DataTable ConvertirCadenaTablaCircuito(string inputText)
        {
            
            string[] rows = inputText.Split('|');

            DataTable dtValores = new DataTable();
          
            if (dtValores.Columns.Count == 0)
            {
                dtValores.Columns.Add("Coordenada");
                dtValores.Columns.Add("Descripción Jocosa Extendida");
                dtValores.Columns.Add("Descripción Corta");
                dtValores.Columns.Add("Contexto");
                dtValores.Columns.Add("Equipamiento");
                dtValores.Columns.Add("Recomendaciones");

            }

            DataRow dataRow = dtValores.NewRow();
            
            for (int i = 0; i < rows.Length; i++)
            {
                if (i < dtValores.Columns.Count)
                {
                    dataRow[i] = rows[i].Trim();
                }
            }
      
            dtValores.Rows.Add(dataRow);

            return dtValores;
        }

        public string InsertaCircuitos(string NombreCircuito, DataTable dtCircuito, string img, string Duracion, string idCiudad, int estadoCircuito ,string longitudCapa, string latitudCapa)
        {
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();


            string CamposNombre = "nombre_circuito";
            string DatosNombre = NombreCircuito;
            string idCircuito = objWs.pa_Insert_General("circuito", "108", CamposNombre, DatosNombre, "es");

            string CamposDescripcion = "descripcion_circuito";
            string DatosDescripcion = dtCircuito.Rows[0]["Descripción Jocosa Extendida"].ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposDescripcion, DatosDescripcion, "es");

            string CamposContexto = "contexto";
            string DatosContexto = dtCircuito.Rows[0]["Contexto"].ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposContexto, DatosContexto, "es");

            string CamposResumen = "descripcion_corta_circuito";
            string DatosResumen = dtCircuito.Rows[0]["Descripción Corta"].ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposResumen, DatosResumen, "es");

            string CamposEquipamento = "equipamento";
            string DatosEquipamento = dtCircuito.Rows[0]["Equipamiento"].ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposEquipamento, DatosEquipamento, "es");


            string CamposRecomendaciones = "recomendacion";
            string DatosRecomendaciones = dtCircuito.Rows[0]["Recomendaciones"].ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposRecomendaciones, DatosRecomendaciones, "es");

            string CamposLongitud = "Longitud_Capa";
            //string DatosLongitud = dtCircuito.Rows[0]["Coordenada"].ToString();
            string DatosLongitud = longitudCapa;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposLongitud, DatosLongitud, "es");

            string CamposLatitud = "Latitud_Capa";
            //string DatosLatitud = dtCircuito.Rows[0]["Coordenada"].ToString();
            string DatosLatitud= latitudCapa;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposLatitud, DatosLatitud, "es");

            string CamposImagen = "imagen";
            string DatosImagen = img;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposImagen, DatosImagen, "es");

            string CamposDuracion = "tiempo_estimado";
            string DatosDuracion = Duracion;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposDuracion, DatosDuracion, "es");

            string CamposFkCiudad = "fk_ciudad";
            string DatosFkCiudad = idCiudad;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposFkCiudad, DatosFkCiudad, "es");

            string CamposEstadoC = "estado_circuito";
            string DatosEstadoC = estadoCircuito.ToString();
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposEstadoC, DatosEstadoC, "es");


           

            return idCircuito;
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuito(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                string[] idiomas = { "en", "fr", "it", "ja", "pt", "ru", "tr", "de" };

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

               
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();

                    foreach (string idiomaDestino in idiomas)
                    {
                       
                        string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", idiomaDestino);
                        string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", idiomaDestino);
                        string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", idiomaDestino);
                        string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", idiomaDestino);
                        string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", idiomaDestino);
                        string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", idiomaDestino);

                        string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                     
                        InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, idiomaDestino, "nombre_circuito");
                        InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, idiomaDestino, "descripcion_circuito");
                        InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, idiomaDestino, "descripcion_corta_circuito");
                        InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, idiomaDestino, "contexto");
                        InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, idiomaDestino, "equipamento");
                        InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, idiomaDestino, "recomendacion");


                    }

                }
               
                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de "+ nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;
              
            }
            else
            {
              
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Generar_Audios_Circuitos/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string GenerarAudios(string idCircuito, string TokenApi) {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {
                try
                {
                    
                    string[] idiomasDestino = { "de", "en", "es", "fr", "it", "ja", "pt", "ru", "tr" };

                    DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

                  
                    if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                    {
                        DataRow idiomaRow = dataSet.Tables[0].Rows[0]; 
                        for (int i = 0; i <idiomasDestino.Length; i++) 
                        {
                            DataRow dataRow = dataSet.Tables[0].Rows[i];
                            string nombreCircuito = dataRow["nombre_circuito"].ToString();
                            string descripcionCircuito = dataRow["descripcion_circuito"].ToString();
                            string descripcionCortaCircuito = dataRow["descripcion_corta_circuito"].ToString();
                            string contextoCircuito = dataRow["contexto"].ToString();
                            string equipamentoCircuito = dataRow["equipamento"].ToString();
                            string recomendacionCircuito = dataRow["recomendacion"].ToString();

                            string idiomaDestino = idiomasDestino[i]; 
                            GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuito, idiomaDestino);
                            GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuito, idiomaDestino);
                            GeneraAudio("circuito", idCircuito, "contexto", contextoCircuito, idiomaDestino);
                            GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuito, idiomaDestino);
                            GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuito, idiomaDestino);
                        }
                    }
                   
                    DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                    string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                    TraduccionReturn response = new TraduccionReturn();
                    response.IdCircuito = idCircuito;
                    response.Mensaje = "Audios de " + nombreCircuitoEncontrado;

                    
                    string json = JsonConvert.SerializeObject(response, Formatting.None);
                    byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                    Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                    return json;
                }
                catch(Exception e) 
                {
                    return e.Message;
                }
            } 
            else
            {
               
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_Destino/{IdCircuito}/{codIdioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaDestino(string idCircuito,string codIdioma ,string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();

                    
                        
                        string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", codIdioma);
                        string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", codIdioma);
                        string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", codIdioma);
                        string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", codIdioma);
                        string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", codIdioma);
                        string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", codIdioma);

                        string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                        
                        InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, codIdioma, "nombre_circuito");
                        InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, codIdioma, "descripcion_circuito");
                        InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, codIdioma, "descripcion_corta_circuito");
                        InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, codIdioma, "contexto");
                        InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, codIdioma, "equipamento");
                        InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, codIdioma, "recomendacion");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, codIdioma);
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, codIdioma);
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, codIdioma);
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, codIdioma);
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, codIdioma);

                }

                
                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_FR/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaFR(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

                
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();
                    string campoRango = "Todas las edades";


                   
                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "fr");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "fr");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "fr");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "fr");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "fr");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "fr");
                    string campoRangoCircuitoTraducido = metodosMovile.pa_Traducir("Todas las edades", "es", "fr");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "fr");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string CampoRangosCircuitoTraducida = campoRangoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    
                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "fr", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "fr", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "fr", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "fr", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "fr", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "fr", "recomendacion");
                    //InsertaTraduccion("1", idCircuito, CampoRangosCircuitoTraducida, "fr", "rango");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "fr", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "fr");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "fr");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "fr");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "fr");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "fr");
                    //GeneraAudio("circuito", idCircuito, "rango", CampoRangosCircuitoTraducida, "fr");

                }

                
                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_EN/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaEN(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

            
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();
                   
                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "en");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "en");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "en");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "en");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "en");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "en");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "en");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");


                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "en", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "en", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "en", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "en", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "en", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "en", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "en", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "en");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "en");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "en");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "en");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "en");

                }

               
                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_IT/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaIT(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);
 
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();
                   

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "it");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "it");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "it");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "it");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "it");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "it");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "it");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "it", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "it", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "it", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "it", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "it", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "it", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "en", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "it");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "it");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "it");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "it");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "it");

                }

                
                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_JA/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaJA(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);

              
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                 
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "ja");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "ja");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "ja");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "ja");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "ja");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "ja");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "ja");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "ja", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "ja", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "ja", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "ja", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "ja", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "ja", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "ja", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "ja");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "ja");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "ja");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "ja");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "ja");

                }

                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_PT/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaPT(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "pt");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "pt");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "pt");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "pt");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "pt");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "pt");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "pt");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "pt", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "pt", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "pt", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "pt", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "pt", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "pt", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "pt", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "pt");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "pt");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "pt");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "pt");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "pt");

                }

                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_RU/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaRU(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "ru");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "ru");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "ru");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "ru");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "ru");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "ru");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "ru");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "ru", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "ru", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "ru", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "ru", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "ru", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "ru", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "ru", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "ru");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "ru");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "ru");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "ru");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "ru");

                }

                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_TR/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaTR(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();
     

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "tr");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "tr");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "tr");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "tr");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "tr");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "tr");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "tr");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "tr", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "tr", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "tr", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "tr", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "tr", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "tr", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "tr", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "tr");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "tr");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "tr");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "tr");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "tr");

                }

                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Circuitos_Idioma_DE/{IdCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposCircuitoIdiomaDE(string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_CircuitoXId(idCircuito);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreCircuito = row["nombre_circuito"].ToString();
                    string descripcionCircuito = row["descripcion_circuito"].ToString();
                    string descripcionCortaCircuito = row["descripcion_corta_circuito"].ToString();
                    string contextoCircuito = row["contexto"].ToString();
                    string equipamentoCircuito = row["equipamento"].ToString();
                    string recomendacionCircuito = row["recomendacion"].ToString();
                    string tiempoEstimadoCircuito = row["tiempo_estimado"].ToString();

                    string nombreCircuitoTraducido = metodosMovile.pa_Traducir(nombreCircuito, "es", "de");
                    string descripcionCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCircuito, "es", "de");
                    string descripcionCortaCircuitoTraducida = metodosMovile.pa_Traducir(descripcionCortaCircuito, "es", "de");
                    string contextoCircuitoTraducido = metodosMovile.pa_Traducir(contextoCircuito, "es", "de");
                    string equipamentoCircuitoTraducido = metodosMovile.pa_Traducir(equipamentoCircuito, "es", "de");
                    string recomendacionCircuitoATraducida = metodosMovile.pa_Traducir(recomendacionCircuito, "es", "de");
                    string campoTiempoCircuitoTraducido = metodosMovile.pa_Traducir(tiempoEstimadoCircuito, "es", "de");

                    string DescCircuitoTraducida = descripcionCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaCircuitoTraducida = descripcionCortaCircuitoTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string ContextCircuitoTraducida = contextoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoCircuitoTraducida = equipamentoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionCircuitoTraducida = recomendacionCircuitoATraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string campoTiempoEstimadoCircuitoTraducido = campoTiempoCircuitoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    InsertaTraduccion("1", idCircuito, nombreCircuitoTraducido, "de", "nombre_circuito");
                    InsertaTraduccion("1", idCircuito, DescCircuitoTraducida, "de", "descripcion_circuito");
                    InsertaTraduccion("1", idCircuito, DescCortaCircuitoTraducida, "de", "descripcion_corta_circuito");
                    InsertaTraduccion("1", idCircuito, ContextCircuitoTraducida, "de", "contexto");
                    InsertaTraduccion("1", idCircuito, equipamentoCircuitoTraducida, "de", "equipamento");
                    InsertaTraduccion("1", idCircuito, recomendacionCircuitoTraducida, "de", "recomendacion");
                    InsertaTraduccion("1", idCircuito, campoTiempoEstimadoCircuitoTraducido, "tr", "tiempo_estimado");

                    GeneraAudio("circuito", idCircuito, "descripcion_circuito", descripcionCircuitoTraducida, "de");
                    GeneraAudio("circuito", idCircuito, "descripcion_corta_circuito", descripcionCortaCircuitoTraducida, "de");
                    GeneraAudio("circuito", idCircuito, "contexto", contextoCircuitoTraducido, "de");
                    GeneraAudio("circuito", idCircuito, "equipamento", equipamentoCircuitoTraducido, "de");
                    GeneraAudio("circuito", idCircuito, "recomendacion", recomendacionCircuitoATraducida, "de");

                }

                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                TraduccionReturn response = new TraduccionReturn();
                response.IdCircuito = idCircuito;
                response.Mensaje = "Traduccion de " + nombreCircuitoEncontrado;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Generar_Nombre_Sitios/{nombreSitio}/{IdCircuito}/{NumeroDias}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string ConsultaSitios(string nombreSitio, string idCircuito,string NumeroDias ,string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();
            if (TokenApi == Desencripta)
            {
                try
                {
                    string NombreLugar = nombreSitio;
                    string[] partes = NombreLugar.Split(' ');
                    string primerLugar = string.Join(" ", partes.Take(partes.Length - 1));
                    //int OrdenImagenSitio = 1;
                    int Orden = 1;
                    int maxLugares = 5;
                    string primerLugarName = primerLugar.ToLower();
                    string NombreLugarName = NombreLugar.ToLower();
                    var ResponseGooglePlaces = BuscarLugaresDestacados(primerLugar);
                    List<string> Lugares = new List<string>();
                    if (int.TryParse(NumeroDias, out int numDias))
                    {                       
                        if (numDias == 1)
                        {
                            maxLugares = 5;
                        }
                        else if (numDias == 2)
                        {
                            maxLugares = 8;
                        }
                        else if (numDias == 3)
                        {
                            maxLugares = 10;
                        }
                        else if (numDias == 4)
                        {
                            maxLugares = 13;
                        }
                        else if (numDias == 5)
                        {
                            maxLugares = 16;
                        }
                        else if (numDias == 6)
                        {
                            maxLugares = 18;
                        }
                        else if (numDias == 7)
                        {
                            maxLugares = 20;
                        }
                    

                    foreach (string lugar in ResponseGooglePlaces)
                        {
                            string lugarLower = lugar.ToLower();

                            if (!lugarLower.Contains(primerLugarName) && !lugarLower.Contains(NombreLugarName))
                            {
                                if (!Lugares.Contains(lugar, StringComparer.OrdinalIgnoreCase))
                                {
                                    Lugares.Add(lugar);

                                    if (Lugares.Count >= maxLugares)
                                    {
                                        break; 
                                    }
                                }
                            }
                        }
                    }

                    string[] SitesNames = Lugares.ToArray();

                    string primerIdSitio = null;
                    string primerNombre = null;

                    foreach (string sitio in SitesNames)
                    {

                        Coordenadas Coordenada = BuscarCoordenadas(sitio, nombreSitio);
                        if (Coordenada != null)
                        {
                            string latitud = Coordenada.Latitud.Replace(",", ".");
                            string longitud = Coordenada.Longitud.Replace(",", ".");

                            string CamposNombre = "nombre_sitio";
                            string DatosNombre = sitio;
                            string idSitio = objWs.pa_Insert_General("sitio", idCircuito.ToString(), CamposNombre, DatosNombre, "es");

                            string CamposOrden = "orden";
                            string DatosOrden = Orden.ToString();
                            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposOrden, DatosOrden, "es");
                            Orden++;

                            string CamposLatitud = "latitud";
                            string DatosLatitud = latitud;
                            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLatitud, DatosLatitud, "es");

                            string CamposLongitud = "longitud";
                            string DatosLongitud = longitud;
                            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLongitud, DatosLongitud, "es");

                            if (primerIdSitio == null && primerNombre == null)
                            {
                                primerNombre = sitio;
                                primerIdSitio = idSitio;

                            }

                        }
                    }


                    //return primerIdSitio;
                    ConsultaSitiosReturn response = new ConsultaSitiosReturn();
                    response.Mensaje = nombreSitio;
                    response.PrimerNombre = primerNombre;
                    response.PrimerIdSitio = primerIdSitio;
                    response.idCircuito = idCircuito;
                    response.cantidad = SitesNames.Count();
                    

                    //return response;
                    string json = JsonConvert.SerializeObject(response, Formatting.None);
                    byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                    Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                    return json;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                  
                }
            }
            else
            {
                
                return "{resultado:Error token cliente}";
               
            }
        }
     

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Generar_Info_Sitios/{sitio}/{nombreciudad}/{idSitio}/{idCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string GeneraInfoSitio(string sitio, string nombreciudad, string idSitio,string idCircuito ,string TokenApi)
        {

            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();
            if (TokenApi == Desencripta)
            {
             

                try
                {
                    
                    DataTable dtPreguntasSitio = metodosMovile.au_Consulta_Sitio(nombreciudad);
                    string PreguntaSitios = dtPreguntasSitio.Rows[0]["Pregunta_Sitio"].ToString();
                    int OrdenImagenSitio = 1;

                   // string PreguntaDescSitio = "Ponte en el papel de un buen GUIA DE TURISMO HACIENDO REFERENCIA EN ESTE ORDEN A EN EL PRIMER PARRAFO DESCRIPCION JOCOSA EXTENDIDA, SEGUNDO PARRAFO DESCRIPCION CORTA , TERCER PARRAFO EQUIPAMIENTO, CUARTO PARRAFO RECOMENDACIONES Y QUINTO PARRAFO INDICACIONES COMO EN EL SIGUIENTE EJEMPLO: " +

                   //    "1- El Viaducto de Pereira es una impresionante estructura vial que atraviesa la ciudad. Con su diseño arquitectónico único y sus vistas panorámicas, es un punto de referencia emblemático el Viaducto de Pereira es una impresionante estructura vial que atraviesa la ciudad.Con su diseño arquitectónico único y sus vistas panorámicas, es un punto de referencia emblemático que ofrece diversas actividades y atracciones para los visitantes,el Viaducto de Pereira ofrece impresionantes vistas de la ciudad y sus alrededores.|" +
                   //    "2- Bienvenido al  rplcsitio y disfruta.(NO MAS DE 150 CARACTERES)|" +
                   //    "3- Cámara fotográfica, protector solar, calzado cómodo.|" +
                   //    "4- Disfruta de la vista panorámica y captura fotos increíbles.|" +
                   //    "5- El viaducto se encuentra en el centro de la ciudad de Pereira, conectando diferentes sectores y facilitando el tránsito entre ellos.| " +
                   // "QUIERO OBTENER  ESPECIFICACIONES COMO LAS DEL EJEMPLO PERO CON EL CONTENIDO Y CARACTERISTICAS DEL SITIO QUE HE PEDIDO: rplcsitio de rplcnombresitios" +
                   //" TIENE QUE TENER ESA MISMA ESTRUCTURA DEL SITIO QUE PEDÍ, CADA PARRAFO DEBE TERMINAR CON | NO USES SALTOS DE LINEAS, EN EL PARRAFO 2 NO EXCEDAS LOS 150 CARACTERES";

                    string PreguntaDescSitio = PreguntaSitios.Replace("rplcsitio", sitio).Replace("rplcnombresitios",nombreciudad);
                    string RespuestaDesSitio = ConsumeGpt(PreguntaDescSitio);
                    DataTable dtInfoSitio = ConvertirCadenaTablaSitio(RespuestaDesSitio);
                    //string idSitio = InsertaSitio(idCircuito, sitio, Orden, dtInfoSitio, latitud, longitud);

                    string CamposDescripcion = "descripcion_sitio";
                    string DatosDescripcion = dtInfoSitio.Rows[0]["descripcion"].ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposDescripcion, DatosDescripcion, "es");

                    string CamposDescripcionCorta = "descripcion_corta_sitio";
                    string DatosDescripcionCorta = dtInfoSitio.Rows[0]["descripcion_corta_sitio"].ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposDescripcionCorta, DatosDescripcionCorta, "es");

                    string CamposEquipamento = "equipamento";
                    string DatosEquipamento = dtInfoSitio.Rows[0]["equipamento"].ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposEquipamento, DatosEquipamento, "es");

                    string CamposRecomendacion = "recomendacion";
                    string DatosRecomendacion = dtInfoSitio.Rows[0]["recomendaciones"].ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposRecomendacion, DatosRecomendacion, "es");

                    string CamposIndicaciones = "indicaciones";
                    string DatosIndicaciones = dtInfoSitio.Rows[0]["indicaciones"].ToString();
                    objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposIndicaciones, DatosIndicaciones, "es");

                    string respuestaImagen = buscarImagen(sitio);
                    metodosMovile.InsertarImagenSitio(respuestaImagen, respuestaImagen, OrdenImagenSitio, idSitio);
                    OrdenImagenSitio++;



                    TraduccionReturnSitio response = new TraduccionReturnSitio();
                    response.IdSitio = idSitio;
                    response.Mensaje = sitio;
                    response.IdCircuito = idCircuito;
                    
                    response.Img = respuestaImagen;
                    //response.NextIdSitio = siguienteIdSitio;
                    //response.NextNombreSitio = nombreSitioEncontrado;
                    //response.NombreCircuito = nombreCircuitoEncontrado;

                    string json = JsonConvert.SerializeObject(response, Formatting.None);
                    byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                    Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                    return json;

                }
                catch (Exception ex)
                {
                    
                    return ex.Message;
                    //return "{resultado:Error 2}";
                }
            }
            else
            {
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio/{IdSitio}/{idCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitio(string idSitio,string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {
                
                string[] idiomas = { "en", "fr", "it", "ja", "pt", "ru", "tr", "de" };

                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

               
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreSitio= row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();

                    foreach (string idiomaDestino in idiomas)
                    {
                        string DatosnombreSitio = metodosMovile.pa_Traducir(nombreSitio, "es", idiomaDestino);
                        string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", idiomaDestino);
                        string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", idiomaDestino);
                        string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", idiomaDestino);
                        string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", idiomaDestino);
                        string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", idiomaDestino);

                        string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                       
                        InsertaTraduccion("2", idSitio, DatosnombreSitio, idiomaDestino, "nombre_sitio");
                        InsertaTraduccion("2", idSitio, descSitioTraducida, idiomaDestino, "descripcion_sitio");
                        InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, idiomaDestino, "descripcion_corta_sitio");
                        InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, idiomaDestino, "equipamento");
                        InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, idiomaDestino, "recomendacion");
                        InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, idiomaDestino, "indicaciones");


                    }


                }

                TraduccionReturnSitio response = new TraduccionReturnSitio();
                response.IdSitio = idSitio;
                response.Mensaje = "Traduciendo información de los sitios";
                response.IdCircuito = idCircuito;
                
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);
                return json;

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }


        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_Destino/{IdSitio}/{idCircuito}/{codIdioma}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaDestino(string idSitio, string idCircuito,string codIdioma ,string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {
                
                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);
                
                
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();

                    
                        string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", codIdioma);
                        string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", codIdioma);
                        string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", codIdioma);
                        string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", codIdioma);
                        string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", codIdioma);
                        string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", codIdioma);

                        string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                        string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                        
                        InsertaTraduccion("2", idSitio, DatosnombreSitio, codIdioma, "nombre_sitio");
                        InsertaTraduccion("2", idSitio, descSitioTraducida, codIdioma, "descripcion_sitio");
                        InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, codIdioma, "descripcion_corta_sitio");
                        InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, codIdioma, "equipamento");
                        InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, codIdioma, "recomendacion");
                        InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, codIdioma, "indicaciones");

                        GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, codIdioma);
                        GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, codIdioma);
                        GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, codIdioma);
                        GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, codIdioma);
                        GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, codIdioma);
                }
                DataRow rowNombre = dataSet.Tables[0].Rows[2];
                string nombreDelSitio = rowNombre["nombre_sitio"].ToString();

                string nombreSitioEncontrado = string.Empty;
                string siguienteIdSitio = string.Empty;
                DataSet ds = metodosMovile.pa_Consulta_SiguienteIdSitio_Value(idCircuito);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Columns.Contains("id_sitio"))
                    {
                        siguienteIdSitio = ds.Tables[0].Rows[0]["id_sitio"].ToString();
                    }
                    else if (ds.Tables[0].Columns.Contains("colum1"))
                    {
                        siguienteIdSitio = ds.Tables[0].Rows[0]["colum1"].ToString();
                    }
                }
                else
                {
                    siguienteIdSitio = "0";
                }
                

                DataSet nombreSitio = metodosMovile.pa_Consulta_Nombre_SitioXId(siguienteIdSitio);
                
                if (nombreSitio.Tables.Count > 0 && nombreSitio.Tables[0].Rows.Count > 2)
                {
                    if (nombreSitio.Tables[0].Rows[2]["nombre_sitio"] != DBNull.Value)
                    {
                        nombreSitioEncontrado = nombreSitio.Tables[0].Rows[2]["nombre_sitio"].ToString();
                    }
                    else
                    {

                        nombreSitioEncontrado = "Nombre de Sitio No Encontrado";
                    }
                }
                else
                {

                    nombreSitioEncontrado = "Nombre de Sitio No Encontrado";
                }


                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                messageReturn response = new messageReturn();
                response.NextIdSitio = siguienteIdSitio;
                response.NextNombreSitio = nombreSitioEncontrado;
                response.NombreCircuito = nombreCircuitoEncontrado;
                response.idCircuito = idCircuito;
                response.Message =  nombreDelSitio;


                
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_FR/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaFR(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                
                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

                
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "fr");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "fr");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "fr");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "fr");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "fr");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "fr");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    
                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "fr", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "fr", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "fr", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "fr", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "fr", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "fr", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "fr");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "fr");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "fr");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "fr");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "fr");
                }

                messageReturn response = new messageReturn();
               
                response.Message = "Creando audios "; 


                
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
       

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_EN/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaEN(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

               
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "en");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "en");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "en");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "en");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "en");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "en");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                  
                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "en", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "en", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "en", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "en", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "en", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "en", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "en");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "en");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "en");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "en");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "en");
                }

                messageReturn response = new messageReturn();
               
                response.Message = "Creando audios";


                //return response;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
           

            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_IT/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaIT(string idSitio,  string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                

                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

               
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "it");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "it");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "it");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "it");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "it");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "it");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                 
                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "it", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "it", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "it", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "it", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "it", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "it", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "it");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "it");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "it");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "it");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "it");
                }

                messageReturn response = new messageReturn();
            
                response.Message = "Creando audios";


                
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
          

            }
            else
            {
               
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_JA/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaJA(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

                
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "ja");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "ja");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "ja");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "ja");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "ja");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "ja");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                 
                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "ja", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "ja", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "ja", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "ja", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "ja", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "ja", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "ja");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "ja");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "ja");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "ja");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "ja");
                }

                messageReturn response = new messageReturn();
              
                response.Message = "Creando audios";


               
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
         

            }
            else
            {
               
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_PT/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaPT(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);

               
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                   
                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "pt");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "pt");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "pt");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "pt");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "pt");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "pt");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");

                    
                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "pt", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "pt", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "pt", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "pt", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "pt", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "pt", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "pt");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "pt");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "pt");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "pt");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "pt");
                }

                messageReturn response = new messageReturn();
               
                response.Message = "Creando audios"; 


                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
       
            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_RU/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaRU(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "ru");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "ru");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "ru");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "ru");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "ru");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "ru");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");


                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "ru", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "ru", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "ru", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "ru", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "ru", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "ru", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "ru");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "ru");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "ru");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "ru");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "ru");
                }

                messageReturn response = new messageReturn();
             
                response.Message = "Creando audios"; 


                //return response;
                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;

            }
            else
            {

                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_TR/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaTR(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "tr");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "tr");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "tr");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "tr");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "tr");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "tr");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");


                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "tr", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "tr", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "tr", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "tr", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "tr", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "tr", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "tr");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "tr");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "tr");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "tr");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "tr");
                }
           

                messageReturn response = new messageReturn();
              
                response.Message = "Creando audios"; 


                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;

            }
            else
            {

                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Traducir_Campos_Sitio_Idioma_DE/{IdSitio}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string TraducirCamposSitioIdiomaDE(string idSitio, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {


                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {

                    DataRow row = dataSet.Tables[0].Rows[2];
                    string nombreDeSitio = row["nombre_sitio"].ToString();
                    string descripcionSitio = row["descripcion_sitio"].ToString();
                    string descripcionCortaSitio = row["descripcion_corta_sitio"].ToString();
                    string equipamentoSitio = row["equipamento"].ToString();
                    string recomendacionSitio = row["recomendacion"].ToString();
                    string IndicacionesSitio = row["indicaciones"].ToString();


                    string DatosnombreSitio = metodosMovile.pa_Traducir(nombreDeSitio, "es", "de");
                    string DatosDescripcionTraducida = metodosMovile.pa_Traducir(descripcionSitio, "es", "de");
                    string DatosDescripcionCortaTraducida = metodosMovile.pa_Traducir(descripcionCortaSitio, "es", "de");
                    string DatosEquipamentoTraducido = metodosMovile.pa_Traducir(equipamentoSitio, "es", "de");
                    string DatosRecomendacionTraducida = metodosMovile.pa_Traducir(recomendacionSitio, "es", "de");
                    string DatosIndicacionesTraducida = metodosMovile.pa_Traducir(IndicacionesSitio, "es", "de");

                    string descSitioTraducida = DatosDescripcionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string DescCortaSitioTraducida = DatosDescripcionCortaTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string equipamentoSitioTraducida = DatosEquipamentoTraducido.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string recomendacionesSitioTraducida = DatosRecomendacionTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");
                    string IndicacionesSitioTraducida = DatosIndicacionesTraducida.Replace("with", "[with]").Replace("of", "[of]").Replace("'", "");


                    InsertaTraduccion("2", idSitio, DatosnombreSitio, "de", "nombre_sitio");
                    InsertaTraduccion("2", idSitio, descSitioTraducida, "de", "descripcion_sitio");
                    InsertaTraduccion("2", idSitio, DescCortaSitioTraducida, "de", "descripcion_corta_sitio");
                    InsertaTraduccion("2", idSitio, equipamentoSitioTraducida, "de", "equipamento");
                    InsertaTraduccion("2", idSitio, recomendacionesSitioTraducida, "de", "recomendacion");
                    InsertaTraduccion("2", idSitio, IndicacionesSitioTraducida, "de", "indicaciones");

                    GeneraAudio("sitio", idSitio, "descripcion_sitio", DatosDescripcionTraducida, "de");
                    GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", DatosDescripcionCortaTraducida, "de");
                    GeneraAudio("sitio", idSitio, "equipamento", DatosEquipamentoTraducido, "de");
                    GeneraAudio("sitio", idSitio, "recomendacion", DatosRecomendacionTraducida, "de");
                    GeneraAudio("sitio", idSitio, "indicaciones", DatosIndicacionesTraducida, "de");
                }
            

                messageReturn response = new messageReturn();
            
                response.Message = "Creando audios";


                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;

            }
            else
            {

                return "{resultado:Error token cliente}";
            }
        }

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Generar_Audios_Sitios/{idSitio}/{idCircuito}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string GenerarAudiosSitios(string idSitio, string idCircuito, string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {

                string[] idiomas = { "de", "en", "es", "fr", "it", "ja", "pt", "ru", "tr" };

                DataSet dataSet = metodosMovile.pa_Consulta_SitioIdiomaXId(idSitio);


                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count >= 3)
                {
                    DataRow row = dataSet.Tables[0].Rows[0];
                    for (int i = 0; i < idiomas.Length; i++)
                    {
                        DataRow datarow = dataSet.Tables[0].Rows[i];
                      
                        string descripcionSitio = datarow["descripcion_sitio"].ToString();
                        string descripcionCortaSitio = datarow["descripcion_corta_sitio"].ToString();
                        string equipamentoSitio = datarow["equipamento"].ToString();
                        string recomendacionSitio = datarow["recomendacion"].ToString();
                        string IndicacionesSitio = datarow["indicaciones"].ToString();

                     
                        string idioma = idiomas[i];
                        
                        GeneraAudio("sitio", idSitio, "descripcion_sitio", descripcionSitio, idioma);
                        GeneraAudio("sitio", idSitio, "descripcion_corta_sitio", descripcionCortaSitio, idioma);
                        GeneraAudio("sitio", idSitio, "equipamento", equipamentoSitio, idioma);
                        GeneraAudio("sitio", idSitio, "recomendacion", recomendacionSitio, idioma);
                        GeneraAudio("sitio", idSitio, "indicaciones", IndicacionesSitio, idioma);
                       
                    }
                }
                string nombreSitioEncontrado = string.Empty;
                string siguienteIdSitio = string.Empty;
                DataSet ds = metodosMovile.pa_Consulta_SiguienteIdSitio_Value(idCircuito);
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Columns.Contains("id_sitio"))
                    {
                        siguienteIdSitio = ds.Tables[0].Rows[0]["id_sitio"].ToString();
                    }
                    else if (ds.Tables[0].Columns.Contains("colum1"))
                    {
                        siguienteIdSitio = ds.Tables[0].Rows[0]["colum1"].ToString();
                    }
                }
                else
                {
                    siguienteIdSitio = "0";
                }
               

                DataSet nombreSitio = metodosMovile.pa_Consulta_Nombre_SitioXId(siguienteIdSitio);
                
                if (nombreSitio.Tables.Count > 0 && nombreSitio.Tables[0].Rows.Count > 2)
                {
                    if (nombreSitio.Tables[0].Rows[2]["nombre_sitio"] != DBNull.Value)
                    {
                        nombreSitioEncontrado = nombreSitio.Tables[0].Rows[2]["nombre_sitio"].ToString();
                    }
                    else
                    {

                        nombreSitioEncontrado = "Nombre de Sitio No Encontrado";
                    }
                }
                else
                {

                    nombreSitioEncontrado = "Nombre de Sitio No Encontrado";
                }


                DataSet nombreCiudad = metodosMovile.pa_Consulta_Nombre_CircuitoXId(idCircuito);
                string nombreCircuitoEncontrado = nombreCiudad.Tables[0].Rows[2]["nombre_circuito"].ToString();

                messageReturn response = new messageReturn();
                response.NextIdSitio = siguienteIdSitio;
                response.NextNombreSitio = nombreSitioEncontrado;
                response.NombreCircuito = nombreCircuitoEncontrado;
                response.idCircuito = idCircuito;
                response.Message = "Creando audios de "+nombreSitioEncontrado;


                string json = JsonConvert.SerializeObject(response, Formatting.None);
                byte[] encodedBytes = Encoding.UTF8.GetBytes(json);
                Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

                return json;
            }
            else
            {
                
                return "{resultado:Error token cliente}";
            }
        }

      
        public DataTable ConvertirCadenaTablaSitio(string inputText)
        {
            
            string[] rows = inputText.Replace("1-", "").Replace("2-", "").Replace("3-", "").Replace("4-", "").Replace("5-", "").Split('|');
          
            DataTable dtValores = new DataTable();
          
            if (dtValores.Columns.Count == 0)
            {
               
                dtValores.Columns.Add("descripcion");
                dtValores.Columns.Add("descripcion_corta_sitio");
                dtValores.Columns.Add("equipamento");
                dtValores.Columns.Add("recomendaciones");
                dtValores.Columns.Add("indicaciones");
            }

            DataRow dataRow = dtValores.NewRow();
         
            for (int i = 0; i < rows.Length; i++)
            {
                if (i < dtValores.Columns.Count)
                {
                    dataRow[i] = rows[i].Trim();
                }
            }
            
            dtValores.Rows.Add(dataRow);

            return dtValores;
        }

        public void InsertaTraduccion(string bandera, string Id, string texto, string idiomaDestino, string campo)
        {

            MetodosMovile metodosMovile = new MetodosMovile();

            metodosMovile.au_Traducir_Texto(bandera, Id, texto, idiomaDestino, campo);

        }

        public void GeneraAudio (string tabla,string clave,string campo,string cadena,string idioma)
        {
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();

            objWs.GeneraStream(tabla, clave, campo, cadena, idioma);
        }

        public List<string> BuscarLugaresDestacados(string nombreCiudad)
        {
            List<string> lugaresDestacados = new List<string>();

            string queryString = $"query=Lugares destacados en {nombreCiudad}&key=AIzaSyD_BcdT_heUpoSU7iFbndqI_rxmMbFsHAA";

            string requestUrl = $"https://maps.googleapis.com/maps/api/place/textsearch/json?{queryString}";
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            HttpResponseMessage response = client.GetAsync(requestUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                string responseContent = response.Content.ReadAsStringAsync().Result;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                dynamic jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);

                foreach (var result in jsonData.results)
                {
                    string name = result.name;
                    lugaresDestacados.Add(name);
                }
            }
            else
            {
                Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
            }
            return lugaresDestacados;
        }
        public static string ConsumeTripAdvisorAPI(string location)
        {
            var apiKey = "705F38C37D2D4FB6B3F5B556559073EA"; 

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.content.tripadvisor.com/api/v1/location/search?key={apiKey}&searchQuery={location}&language=es"),
                Headers =
        {
            { "accept", "application/json" },
        },
            };
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            using (var response = client.SendAsync(request).Result)
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                return responseBody;
            }
        }

        public string ConsumeGpt(string promptIn)
        {

           
            var apiKey = "aqui va la apikey";
            var prompt = promptIn; 
            var message = new
            {
                content = prompt,
                role = "system"
            };
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                messages = new List<object> { message },
                max_tokens = 2500,
                temperature = 0.1,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0,
                model = "gpt-4"
                //model = "gpt-3.5-turbo-16k"
            };
          
            var requestBodyJson = System.Text.Json.JsonSerializer.Serialize(requestBody);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var response = client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(requestBodyJson, System.Text.Encoding.UTF8, "application/json")).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var chatGPTResponse = JsonConvert.DeserializeObject<ChatGPTResponse>(responseJson);
            var responseMessageGPT = chatGPTResponse.choices[0].message.content;

            return responseMessageGPT;
        }


        public Coordenadas BuscarCoordenadas(string nombreSitio, string nombreCiudad)
        {
            string apiKey = "AIzaSyD_BcdT_heUpoSU7iFbndqI_rxmMbFsHAA";
            string addres = $"{nombreSitio}, {nombreCiudad}";
            string url = "https://maps.googleapis.com/maps/api/geocode/json?address=" + addres + "&key=" + apiKey;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                    double latitud = jsonData.results[0].geometry.location.lat;
                    double longitud = jsonData.results[0].geometry.location.lng;

                    Coordenadas coordenadas = new Coordenadas
                    {
                        Latitud = latitud.ToString(),
                        Longitud = longitud.ToString()
                    };
                    return coordenadas;
                }
                else
                {
                    return null;
                }
            }
        }

        public string buscarImagen(string lugar)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://google.serper.dev/");

                string apiUrl = "images";

                client.DefaultRequestHeaders.Add("X-API-KEY", "8a067c27e64529ee48d7ddcf9195d24823694976");

                var body = new { q = lugar };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    var data = JObject.Parse(responseContent);
                    //string url = data.SelectToken("images[0].imageUrl").Value<string>();
                    string urlImageSmall = data.SelectToken("images[0].thumbnailUrl").Value<string>();
                    //string ajusteImagenUrl = url.Replace(".jpg", "=s100.jpg");

                    return urlImageSmall;
                }
                else
                {
                    return null;
                }
            }
        }

        public class ImagenResponse
        {
            public ImagenResults[] images_results { get; set; }
        }

        public class ImagenResults
        {
            public string thumbnail;
        }


        public class ChatGPTResponse
        {
            public ChatGPTChoice[] choices { get; set; }
        }

        public class ChatGPTChoice
        {

            public ChatGPTMessage message { get; set; }
            public string text { get; set; }
            public double? logprobs { get; set; }
            public string finish_reason { get; set; }
        }

        public class ChatGPTMessage
        {
            public string content { get; set; }
            public string role { get; set; }
        }

        class Ubicacion
        {
            public string nombreSitio { get; set; }
            public string coordenadas { get; set; }
            public string descripcionCorta { get; set; }
            public string descripcionJocosa { get; set; }
        }


        class lugar

        {
            public string Coordenada { get; set; }
            public string descripcionJocosa { get; set; }
            public string descripcionCorta { get; set; }
            public string contexto { get; set; }
            public string equipamento { get; set; }
            public string recomendacion { get; set; }

        }

        public class Coordenadas
        {
            public string Latitud { get; set; }
            public string Longitud { get; set; }
        }

        public class CircuitoReturn
        {
            public string IdCircuito { get; set; }
            public string NombreSitio { get; set; }
            public string Mensaje { get; set; }
            public string Img { get; set; }
            public int numDia { get; set; }
        }

        public class TraduccionReturn
        {
            public string Mensaje { get; set; }
            public string IdCircuito { get; set; }
        }

        public class TraduccionReturnSitio
        {
            public string Mensaje { get; set; }
            public string IdSitio { get; set; }
            public string IdCircuito { get; set; }
            public string Img { get; set; }
        }
        public class ConsultaSitiosReturn
        {
            public string Mensaje { get; set; }
            public string PrimerNombre { get; set; }
            public string PrimerIdSitio { get; set; }
            public string idCircuito { get; set; }
            public int cantidad { get; set; }
        }

        public class messageReturn
        {
            public string Message { get; set; }
            public string NextIdSitio { get; set; }
            public string NextNombreSitio { get; set; }
            public string NombreCircuito { get; set; }
            public string idCircuito { get; set; }

        }
        public class Address
        {
            public string street1 { get; set; }
            public string street2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string address_string { get; set; }
            public string postalcode { get; set; }
        }

        public class Location
        {
            public string location_id { get; set; }
            public string name { get; set; }
            public Address address_obj { get; set; }
        }

        public class Root
        {
            public List<Location> data { get; set; }
        }

    }

}
