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


        // GENERACION DE CIRCUITOS AUTOMATICOS 

        [OperationContract]
        [WebGet(UriTemplate = "Movile_Crear_Circuitos/{nameCity}/{nameCountry}/{ParEntrada}/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        public string GeneraCircuito(string nameCity, string nameCountry, string ParEntrada, string TokenApi)
        { 
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            MetodosMovile metodosMovile = new MetodosMovile();

            if (TokenApi == Desencripta)
            {
                try
                {
                    //metodos = new Metodos();
                    string Nombre = null;
                    string NameCity = nameCity;
                    string NameCountry = nameCountry;
                    string NumberDay = ParEntrada;
                    string service = "¡Circuito creado!";
                    try
                    {
                        string PreguntaPruebaDos = "Ponte en el papel de un buen GUIA DE TURISMO Y HACIENDO REFERENCIA EN ESTE ORDEN A COORDENADA, DESCRIPCION JOCOSA EXTENDIDA, DESCRIPCION CORTA, CONTEXTO HISTORICO, EQUIPAMIENTO Y RECOMENDACIONES COMO EN EL SIGUIENTE EJEMPLO :" +
                                                   "4.8143° N" +
                                                   "|¡Hola! ¡Bienvenido a Pereira, la ciudad del café con un toque de diversión! Aquí encontrarás un destino que combina la riqueza histórica con un ambiente alegre y acogedor. Explora las calles llenas de historia y anécdotas que harán reír hasta al más serio. Conoce a los pereiranos, conocidos por su sentido del humor y su pasión por el café. Prepárate para disfrutar de una experiencia única llena de risas y sabores que te harán vibrar. ¡Pereira te espera con los brazos abiertos y una taza de café lista para endulzar tus días!" +
                                                   "|La ciudad de la eterna sonrisa y el café encantador." +
                                                   "|La Fundaciónde Pereira es la capital del departamento de Risaralda en Colombia fue fundada el 30 de agosto de 1863 por el abogado y político colombiano Francisco Pereira Martínez, inicialmente, la ciudad fue establecida como una villa en un valle conocido como Valle de Risaralda, con el tiempo Pereira se ha convertido en una importante ciudad colombiana debido a su ubicación estratégica y su desarrollo económico,una de las tradiciones más destacadas es la Feria de la Cosecha, que se celebra en agosto, durante esta festividad, se llevan a cabo desfiles, conciertos, muestras artesanales y actividades relacionadas con la agricultura y la producción de café, uno de los principales productos de la región acontecimientos a lo largo de su historia, Pereira ha experimentado varios acontecimientos significativos. Durante el siglo XX, la ciudad experimentó un importante crecimiento económico gracias a la expansión de la industria del café y el desarrollo de la infraestructura. En 1966, Pereira sufrió un terremoto que causó daños significativos en la ciudad, pero logró recuperarse rápidamente. La cultura en Pereira es diversa y rica. La ciudad cuenta con varios museos, teatros y espacios culturales que promueven las artes y la música. La música tradicional de la región se caracteriza por géneros como el bambuco, el pasillo y la guabina. Además, la gastronomía pereirana destaca por platos como la bandeja paisa, el sancocho y la arepa. Pereira es conocida por su cultura diversa y su importancia en la producción de café en Colombia." +
                                                   "|Equipaciones a tener en cuenta en pereira: Ropa fresca y ligera, si lo deseas, gafas de sol y gorras." +
                                                   "|Recomendaciones a tener en cuenta en pereira: Transporte: Una vez en la ciudad, puedes moverte en taxi, transporte público o alquilar un carro.Algunas áreas recomendadas para hospedarse son el centro de la ciudad y el sector de El Cable. Gastronomía: No te pierdas la oportunidad de probar la deliciosa gastronomía de Pereira. Prueba platos típicos como la arepa de chocolo, la bandeja paisa y el sancocho de gallina. Además, disfruta de un delicioso café colombiano, ya que Pereira es parte de la región del Eje Cafetero." +
                                                   "QUIERO OBTENER UNA RESPUESTA IGUAL CON ESA ESTRUCTURA PERO PARA EL LUGAR DE rplcnombresitio " +
                                                   "TIENE QUE TENER ESA MISMA ESTRUCTURA DE EJEMPLO PERO CON EL CONTENIDO DEL LUGAR QUE HE PEDIDO" +
                                                   "ES DE GRAN IMPORTANCIA SEPARAR CADA ESPECIFICACION CON | EXACTAMENTE IGUAL A COMO ESTA EN EL EJEMPLO PRESENTADO";


                        string Resultado = String.Format("{0} {1}, {2}", NameCity, NameCountry, NumberDay);
                        ResultadoConcat = $"{NameCity} {NameCountry}, {NumberDay} ";

                        string PreguntaCircuito = PreguntaPruebaDos.Replace("rplcnombresitio", ResultadoConcat);

                        NombreSitio = ResultadoConcat;


                        //Prueba Nuget Coordenada
                        string[] SinDay = NombreSitio.Split(',');
                        string nombreciudad = SinDay[0];

                        //string getCoordenadas = getCoordenada;
                        //DataTable dtPreguntas = metodos.au_Consulta_Circuito(PreguntaPruebaDos.Replace("rplcnombresitio", ParEntrada));
                        //clsCircuitos objCircuitos = new clsCircuitos();
                        DataTable UbicacionCircuito = metodosMovile.ConsultaNombreCiudad(nameCity, nameCountry);

                        string idCiudad = UbicacionCircuito.Rows[0]["id_ciudad"].ToString();
                        string idPais = UbicacionCircuito.Rows[0]["id_pais"].ToString();
                        string Respuesta = ConsumeGpt(PreguntaCircuito);


                        if (Respuesta != null || Respuesta.Length > 0)
                        {

                            Nombre = ResultadoConcat;

                            string[] SinNumerico = Nombre.Split(',');
                            bool tieneMasDeDosCaracteres = SinNumerico.Any(elemento => elemento.Length >= 2);
                            string NombreLugar = Nombre;
                            string NumDias = " ";
                            string img = " ";
                            //Coordenadas getCoordenada = BuscarCoordenadas(NameCity, NameCountry);
                            //if (getCoordenada != null)
                            //{
                            //    string latitudCapa = getCoordenada.Latitud;
                            //    string longitudCapa = getCoordenada.Longitud;

                            if (tieneMasDeDosCaracteres == true)
                            {
                                NombreLugar = SinNumerico[0].Trim();
                                NumDias = SinNumerico[1].Trim() + " días";
                                img = buscarImagen(NombreLugar);
                            }
                            else
                            {
                                NombreLugar = Nombre.Trim();
                                NumDias = " ";
                                img = buscarImagen(NombreLugar);
                            }
                            int estadoCircuito = 1;
                            DataTable dtCircuito = ConvertirCadenaTablaCircuito(Respuesta);
                            string idCircuito = InsertaCircuitos(nombreciudad, dtCircuito, img, NumDias, idCiudad, estadoCircuito);
                            //DataTable dtSitios = metodos.au_Consulta_Sitio(Nombre);

                            ConsultaSitios(idCircuito);
                            //}
                            return service;

                        }
                        else
                        {
                            return "Ha ocurrido un error con la creación del circuito";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return "¡La creacion del circuito ha fallado! Parece que ha habido una falla o sobrecarga. Por favor, verifique su circuito";
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                    return "¡La creacion del circuito ha fallado! Parece que ha habido una falla o sobrecarga. Por favor, verifique su circuito";
                }

        
            }
            else
            {
                return "{resultado:Error token cliente}";
            }
            
        }
        public string InsertaCircuitos(string NombreCircuito, DataTable dtCircuito, string img, string Duracion, string idCiudad, int estadoCircuito)
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
            string DatosLongitud = dtCircuito.Rows[0]["Coordenada"].ToString();
            //string DatosLongitud = longitudCapa;
            objWs.pa_Actualiza_General("circuito", idCircuito.ToString(), CamposLongitud, DatosLongitud, "es");

            string CamposLatitud = "Latitud_Capa";
            string DatosLatitud = dtCircuito.Rows[0]["Coordenada"].ToString();
            //string DatosLatitud= latitudCapa;
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


            //DataTable dtCircuitos = objCircuitos.ConsultaCircuitos("es", "108");

            return idCircuito;
        }

        public string InsertaSitio(string idCircuito, string NombreSitio, int Orden, DataTable dtInfoSitio, string latitud, string longitud)
        {
            ATT_WS.AppToTripWSSoapClient objWs = new ATT_WS.AppToTripWSSoapClient();
            //try
            //{
            string CamposNombre = "nombre_sitio";
            string DatosNombre = NombreSitio;
            string idSitio = objWs.pa_Insert_General("sitio", idCircuito.ToString(), CamposNombre, DatosNombre, "es");

            string CamposOrden = "orden";
            string DatosOrden = Orden.ToString();
            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposOrden, DatosOrden, "es");

            //string CamposLatitud = "latitud";
            //string DatosLatitud = dtInfoSitio.Rows[0]["latitud"].ToString();
            //objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLatitud, DatosLatitud, "es");

            //string CamposLongitud = "longitud";
            //string DatosLongitud = dtInfoSitio.Rows[0]["longitud"].ToString();
            //objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLongitud, DatosLongitud, "es");

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
            string DatosIndicaciones = dtInfoSitio.Rows[0]["recomendaciones"].ToString();
            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposIndicaciones, DatosIndicaciones, "es");

            string CamposLatitud = "latitud";
            string DatosLatitud = latitud;
            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLatitud, DatosLatitud, "es");

            string CamposLongitud = "longitud";
            string DatosLongitud = longitud;
            objWs.pa_Actualiza_General("sitio", idSitio.ToString(), CamposLongitud, DatosLongitud, "es");



            return idSitio;
            //string CamposImagenSitio = "imagen";
            //string DatosImagenSitio = imagenSitio;
            //objWs.pa_Insert_General("imagen_sitio", idSitio.ToString(), CamposImagenSitio, DatosImagenSitio, "es");

            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //}

        }


        public string ConsumeGpt(string promptIn)
        {

            //sk - iLKJz6pnOvQsxza6LOreT3BlbkFJ0X2uMKiBnt3IyZZ08VRQ
            // var apiKey = "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";
            var apiKey = "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";// Reemplace "SU_API_KEY" con su clave de API válida
            var prompt = promptIn; // Reemplace con su texto de entrada
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
                temperature = 0.5,
                top_p = 1,
                frequency_penalty = 0,
                presence_penalty = 0,
                model = "gpt-3.5-turbo-16k"
            };
            //Modelos
            //"text-davinci-003"
            //"gpt-3.5-turbo"
            var requestBodyJson = System.Text.Json.JsonSerializer.Serialize(requestBody);
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            var response = client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(requestBodyJson, System.Text.Encoding.UTF8, "application/json")).Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var chatGPTResponse = JsonConvert.DeserializeObject<ChatGPTResponse>(responseJson);
            var responseMessageGPT = chatGPTResponse.choices[0].message.content;

            return responseMessageGPT;
        }


        public void ConsultaSitios(string idCircuito)
        {
            MetodosMovile metodosMovile = new MetodosMovile();
            try
            {
                int OrdenImagenSitio = 1;
                int Orden = 1;
                //NombreSitio = NombreSitio;
                ResultadoConcat = ResultadoConcat;
                string[] SinDay = NombreSitio.Split(',');
                string nombreciudad = SinDay[0];

                string preguntaSitio = "DADO EL SIGUIENTE EJEMPLO:" +
                       "Viaducto|Parque de Bolivar|Ukumari|Museo del Arte Moderno de Pereira|Parque Consotá|Réplica de Pereira " +
                       "QUIERO OBTENER SITIOS CULTURALES SIMILARES COMO EN EL EJEMPLO PERESENTADO Y EN ESE MISMO FORMATO, PERO PARA EL LUGAR DE rplcnombresitio DIAS PARA VISITAR LOS SITIOS, " +
                       "TIENE QUE TENER ESA MISMA ESTRUCTURA DE EJEMPLO PERO CON SITIOS DEL LUGAR QUE HE PEDIDO :" + nombreciudad +
                       "Y CERRAR CON |";

                string PreguntaNombreSitios = preguntaSitio.Replace("rplcnombresitio", ResultadoConcat);
                string RespuestaNameSites = ConsumeGpt(PreguntaNombreSitios);
                string[] SitesName = RespuestaNameSites.Split('|');
                HashSet<string> SitesUnicos = new HashSet<string>();
                foreach (string sitio in SitesName)
                //Recorre sitesName y verifica si no hay sitios repetidos agrega
                {
                    if (!SitesUnicos.Contains(sitio))
                    {
                        SitesUnicos.Add(sitio);

                        // Verificar si se ha alcanzado el límite de 50 sitios
                        if (SitesUnicos.Count > 45)
                        {
                            break;
                        }
                    }
                }
                string[] SitesNames = SitesUnicos.ToArray();

                //Recorre la lista de SitesNames para buscar info de cada sitio
                foreach (string sitio in SitesNames)
                {

                    string PreguntaDescSitio = "Ponte en el papel de un buen GUIA DE TURISMO HACIENDO REFERENCIA EN ESTE ORDEN A  LATITUD, LONGITUD, DESCRIPCION JOCOSA EXTENDIDA, DESCRIPCION CORTA, EQUIPAMIENTO, RECOMENDACIONES Y INDICACIONES COMO EN EL SIGUIENTE EJEMPLO: " +
                       "4.8083° N|" +
                       "75.6964° W|" +
                       "El Viaducto de Pereira es una impresionante estructura vial que atraviesa la ciudad. Con su diseño arquitectónico único y sus vistas panorámicas, es un punto de referencia emblemático.El Viaducto de Pereira es una impresionante estructura vial que atraviesa la ciudad. Con su diseño arquitectónico único y sus vistas panorámicas, es un punto de referencia emblemático que ofrece diversas actividades y atracciones para los visitantes,el Viaducto de Pereira ofrece impresionantes vistas de la ciudad y sus alrededores. Puedes disfrutar de paisajes urbanos, montañas y valles mientras caminas o conduces a lo largo del viaducto.Puedes caminar, correr o andar en bicicleta mientras disfrutas del entorno escénico.|" +
                       "Una estructura vial icónica.|" +
                       "Cámara fotográfica, protector solar, calzado cómodo.|" +
                       "Disfruta de la vista panorámica y captura fotos increíbles.|" +
                       "El viaducto se encuentra en el centro de la ciudad de Pereira, conectando diferentes sectores y facilitando el tránsito entre ellos.| " +
                    "QUIERO OBTENER  ESPECIFICACIONES COMO LAS DEL EJEMPLO PERO CON EL CONTENIDO DEL SITIO QUE HE PEDIDO: " + sitio + " de " + nombreciudad +
                   " TIENE QUE TENER ESA MISMA ESTRUCTURA DEL SITIO QUE PEDÍ, A CADA PUNTO SEPARARSE CON | COMO EN EL EJEMPLO PRESENTADO";

                    //ES DE GRAN IMPORTANCIA QUE SEPARES CADA ESPECIFICACION CON | EXACTAMENTE IGUAL A COMO ESTA EN EL EJEMPLO PRESENTADO
                    Coordenadas Coordenada = BuscarCoordenadas(sitio, nombreciudad);
                    if (Coordenada != null)
                    {
                        string latitud = Coordenada.Latitud.Replace(",", ".");
                        string longitud = Coordenada.Longitud.Replace(",", "."); ;


                        string RespuestaDesSitio = ConsumeGpt(PreguntaDescSitio);
                        DataTable dtInfoSitio = ConvertirCadenaTablaSitio(RespuestaDesSitio);
                        string idSitio = InsertaSitio(idCircuito, sitio, Orden, dtInfoSitio, latitud, longitud);

                        // Obtener la imagen del sitio
                        //string imageUrl = buscarImagen(sitio);
                        // Insertar la imagen del sitio
                        string respuestaImagen = buscarImagen(sitio);
                        metodosMovile.InsertarImagenSitio(respuestaImagen, respuestaImagen, OrdenImagenSitio, idSitio);
                        OrdenImagenSitio++;
                        //string ResponseImg = buscarImagen(sitio);
                        //InsertaImagenSitio(idSitio, OrdenImagenSitio, ResponseImg);
                        //OrdenImagenSitio++;
                    }
                    Orden++;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable ConvertirCadenaTablaCircuito(string inputText)
        {
            //string[] delimiters = { "|", "\n\n" };
            string[] rows = inputText.Split('|');
            //string[] rows = inputText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            DataTable dtValores = new DataTable();
            // Agregar las columnas al DataTable si no están presentes
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
            // Agregar los valores a la fila
            for (int i = 0; i < rows.Length; i++)
            {
                if (i < dtValores.Columns.Count)
                {
                    dataRow[i] = rows[i].Trim();
                }
            }
            // Agregar la fila al DataTable
            dtValores.Rows.Add(dataRow);

            return dtValores;
        }

        public DataTable ConvertirCadenaTablaSitio(string inputText)
        {
            //string[] delimiters = { "|", "\n\n" };
            string[] rows = inputText.Split('|');
            //string[] rows = inputText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            DataTable dtValores = new DataTable();
            // Agregar las columnas al DataTable si no están presentes
            if (dtValores.Columns.Count == 0)
            {
                dtValores.Columns.Add("latitud");
                dtValores.Columns.Add("longitud");
                dtValores.Columns.Add("descripcion");
                dtValores.Columns.Add("descripcion_corta_sitio");
                dtValores.Columns.Add("equipamento");
                dtValores.Columns.Add("recomendaciones");
                dtValores.Columns.Add("indicaciones");
            }

            DataRow dataRow = dtValores.NewRow();
            // Agregar los valores a la fila
            for (int i = 0; i < rows.Length; i++)
            {
                if (i < dtValores.Columns.Count)
                {
                    dataRow[i] = rows[i].Trim();
                }
            }
            // Agregar la fila al DataTable
            dtValores.Rows.Add(dataRow);

            return dtValores;
        }

        public DataTable ConvertCadenaTabla(string inputText, int indice)
        {
            string[] rows = inputText.Split('|');

            string[] rowsOrdenado = new string[rows.Length];
            //OrdenarDescendente(rows);
            List<string> lstRows = new List<string>(rows.Length);
            int j = 0;

            foreach (string variable in rows)
            {
                if (variable != "" && !variable.Contains("-"))
                {
                    rowsOrdenado[j] = variable;
                    j++;
                }
            }
            DataTable dtValores = new DataTable();
            for (int i = 0; i < indice; i++)
            {
                string columnName = rowsOrdenado[i].Trim();
                dtValores.Columns.Add(columnName);
            }
            DataRow dataRow = dtValores.NewRow();
            for (int i = 0; i < indice; i++)
            {
                dataRow[i] = rowsOrdenado[i + indice].Trim();
            }
            dtValores.Rows.Add(dataRow);
            return dtValores;

        }


        public string buscarImagen(string lugar)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://google.serper.dev/");

                string apiUrl = "images";

                client.DefaultRequestHeaders.Add("X-API-KEY", "6399f4cb8b65102b606805fc779334118b633714");

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

        //public Coordenadas BuscarCoordenadas(string direccion, string direccionCiudad)
        //{
        //    //string[] SinNumerico = ResultadoConcat.Split(',');
        //    //string direccionComplete = SinNumerico[0] ;

        //    IGeocoder geocoder = new GoogleGeocoder("AIzaSyD_BcdT_heUpoSU7iFbndqI_rxmMbFsHAA");
        //    IEnumerable<Address> approximateLocations = geocoder.GeocodeAsync(direccion + "," + direccionCiudad).GetAwaiter().GetResult();
        //    Address address = approximateLocations.FirstOrDefault();

        //    if (address != null)
        //    {
        //        Coordenadas coordenadas = new Coordenadas
        //        {
        //            Latitud = address.Coordinates.Latitude.ToString(),
        //            Longitud = address.Coordinates.Longitude.ToString()
        //        };

        //        return coordenadas;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///clsCircuitos objCircuitosInd = new clsCircuitos();


        //metodo generaCircuitos

        //public string GeneraCircuito(string nameCity, string nameCountry, string ParEntrada)
        //{

        //}


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
                    double latitud = jsonData.lat;
                    double longitud = jsonData.lng;

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

              
                public string ActivarCircuito(string idCircuito)
        {
            MetodosMovile metodosMovile = new MetodosMovile();
            clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
            try
            {
                string Expresion = "id_circuito = " + idCircuito;
                DataTable dtCircuitos = (DataTable)HttpContext.Current.Session["dtCircuitos"];
                DataRow[] dr = dtCircuitos.Select(Expresion);
                if (dr[0]["estado_circuito"].ToString() == "0" || dr[0]["estado_circuito"].ToString() == "3")
                {
                    bool banImg = true;
                    bool banValGrl = true;
                    StringBuilder Mensaje = new StringBuilder();
                    StringBuilder MensajeImg = new StringBuilder();
                    DataTable dtSitios = ConsultaSitiosXCircuito(idCircuito);
                    foreach (DataRow drs in dtSitios.Rows)
                    {
                        if (drs["contImagenes"].ToString() == "0")
                        {
                            MensajeImg.AppendLine(drs["nombre_sitio"].ToString() + "</br>");
                        }
                    }
                    if (!banImg)
                    {
                        return "0|Cada sitio de este circuito debe tener por lo menos una imágen";
                    }
                    else
                    {
                        if (dr[0]["imagen"].ToString() == "")
                        {
                            return "0|El circuito debe tener una imágen de referencia";
                        }
                        if (dr[0]["ContSitios"].ToString() == "0")
                        {
                            return "0|El circuito debe tener por lo menos un sitio relacionado";
                        }
                    }
                    if (banImg && banValGrl)
                    {
                        metodosMovile.ActualizaEstadoCircuito(idCircuito, "3");
                        HttpContext.Current.Session["dtCircuitos"] = objCircuitos.ConsultaCircuitos("es", HttpContext.Current.Session["idUsuario"].ToString());
                        return "1|Circuito activado correctamente";
                    }
                    else
                    {
                        return "0|Ha ocurrido un error activando el circuito.";
                    }
                }
                else
                {
                    return "0|Ha ocurrido un error activando el circuito.";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable ConsultaSitiosXCircuito(string IdCircuito)
        {
            clsOperacionUsuario objCircuitos = new clsOperacionUsuario();
            try
            {
                return objCircuitos.ConsultaSitios("es", IdCircuito);
            }
            catch (Exception ex)
            {
                throw ex;
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
        //HASTA AQUI
    }


}
