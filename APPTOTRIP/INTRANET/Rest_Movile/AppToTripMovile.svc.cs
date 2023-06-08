using CDI.Comun;
using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

/*
    Modificado by:Jhonny Guarnizo 14/02/2020
*/

namespace Rest_Movile
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AppToTripMovile
    {
        MetodosMovile metodosMovile;



        [OperationContract]
        [WebGet(UriTemplate = "Movile_Consulta_Ciudades/{TokenApi}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string Movile_Consulta_Ciudades(string TokenApi)
        {
            string Desencripta = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, Herramienta.TraerConfiguracion("TokenApp"));
            if (TokenApi == Desencripta)
            {
                DataTable dataTable = new DataTable();
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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

                metodosMovile = new MetodosMovile();
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

                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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

                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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
                metodosMovile = new MetodosMovile();
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

    }


}
