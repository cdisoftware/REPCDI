using CDI.Comun;
using CT.ADMIN.BL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace Rest_Movile
{
    public class MetodosMovile : AppToTripMovile
    {
        public DataSet mv_Consultar_Ciudades()
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Ciudades", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Ciudades Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consultar_Macros()
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Macro", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consultar_Macros Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consultar_Ciudades_Cp(String token_persona)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("token_persona", token_persona, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Ciudades_Cp", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Ciudades_Cp Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Categoria(string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Categoria", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Categoria Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Macro_Detalle(string nombre_macro, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@nombre_macro", nombre_macro, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Macro_Detalle", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Macro_Detalle Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Circuito_Macro(string codigo_idioma, string token_persona, string ids)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@ids", ids, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Circuito_Macro", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Consulta_Circuito_Macro Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Insert_Persona(string nombres_persona, string apellidos_persona, string correo_persona,
            string celular_persona, string token_persona, string fecha_nacimiento)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@nombres_persona", nombres_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@apellidos_persona", apellidos_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@correo_persona", correo_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@celular_persona", celular_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@fecha_nacimiento", fecha_nacimiento, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_Insert_Persona", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Insert_Persona Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Calificacion_Circuito(string token_persona, int fk_circuito, int calificacion_circuito, string comentario_circuito)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@calificacion_circuito", calificacion_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@comentario_circuito", comentario_circuito, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_Calificacion_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Calificacion_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Calificacion_Sitio(string token_persona, int fk_sitio,
         int valor, string comentario)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@fk_sitio", fk_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@valor", valor, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@comentario", comentario, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_Calificacion_Sitio", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Calificacion_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }


        public DataSet mv_Calificacion_Usuario(int fk_persona, int fk_usuario,
         int calificacion_usuario, string comentario_usuario)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@fk_persona", fk_persona, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@fk_usuario", fk_usuario, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@calificacion_usuario", calificacion_usuario, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@comentario_usuario", comentario_usuario, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_Calificacion_Usuario", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Calificacion_Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Persona(string correo_persona, string token_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@correo_persona", correo_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Persona", parametrosEntrada, ref parametrosSalida);
                return a;



            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Persona Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Circuitos(string ciudad, string codigo_idioma, string pais, string token_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@ciudad", ciudad, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@pais", pais, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Circuitos", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Circuitos Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Traduccion_Circuito(int fk_circuito, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@fk_circuito", fk_circuito, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Traduccion_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Traduccion_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Traduccion_Sitio(int fk_sitio, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@fk_sitio", fk_sitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Traduccion_Sitio", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Traduccion_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Circuito_Info(int id_circuito, string codigo_idioma, string token_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@id_circuito", id_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Circuito_Info", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Circuito_Info Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Recorrido_Circuito(int fk_circuito, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Recorrido_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Recorrido_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Sitio_Info(int id_sitio, string codigo_idioma, string token_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@id_sitio", id_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Sitio_Info", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Sitio_Info Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Web(int id_sitio, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@id_sitio", id_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Web", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Web Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Comprar_Circuito(string persona_token, int fk_circuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("persona_token", persona_token, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Compra_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Compra_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Asignacion_Circuito(string persona_token, int fk_circuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("token_persona", persona_token, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("id_circuito", fk_circuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Asignacion_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Asignacion_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Circuitos_Persona(string persona_token, int fk_circuito, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("token_persona", persona_token, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Recorrido_Circuito_Persona", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Recorrido_Circuito_Persona Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Finalizar_Circuito(int fk_circuito, string persona_token)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("token_persona", persona_token, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("id_circuito", fk_circuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Finalizar_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Finalizar_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Finalizar_Sitio(int id_sitio, string persona_token)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("token_persona", persona_token, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("id_sitio", id_sitio, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Finalizar_Sitio", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Finalizar_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string mv_Traducir(String text, String Entrada, String Salida)
        {
            return pa_Traducir(text, Entrada, Salida);
        }

        //public string pa_Traducir(String text, String Entrada, String Salida)
        //{
        //    if (!text.Equals(""))
        //    {
        //        String url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from=" + Entrada + "&to=" + Salida + "";
        //        if (Entrada.Equals("") || Entrada.Equals("%20"))
        //        {
        //            url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=" + Salida + "";
        //        }
        //        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //        httpWebRequest.ContentType = "application/json";
        //        //httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", "73ca5d43c217480ca2457224f0db6362");
        //        httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", "9353c8730fdc4359825b6d791774574b");
        //        httpWebRequest.Method = "POST";
        //        httpWebRequest.Accept = "application/json";
        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream(), Encoding.UTF8))
        //        {
        //            string json11 = "[{'Text':'" + text.Replace("'", "") + "'}]";
        //            streamWriter.Write(json11);
        //            streamWriter.Flush();
        //            streamWriter.Close();
        //        }
        //        String r;
        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //        using (var sr = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            var result = sr.ReadToEnd();
        //            r = result.Remove(0, 1);
        //            r = r.Remove(r.Length - 1, 1);
        //        }
        //        JObject array = JObject.Parse(r);
        //        JArray a = JArray.Parse(array["translations"].ToString());
        //        r = a[0]["text"].Value<String>();
        //        return r;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        public string pa_Traducir(string text, string Entrada, string Salida)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from=" + Entrada + "&to=" + Salida;
                if (string.IsNullOrEmpty(Entrada) || Entrada.Equals("%20"))
                {
                    url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=" + Salida;
                }

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "9353c8730fdc4359825b6d791774574b");
                    var requestBody = $"[{{'Text':'{text.Replace("'", "")}'}}]";
                    var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    var response = httpClient.PostAsync(url, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        JArray array = JArray.Parse(responseContent);
                        JArray translationsArray = (JArray)array[0]["translations"];
                        string translatedText = translationsArray[0]["text"].Value<string>();
                        return translatedText;
                    }
                }
            }

            return "";
        }

        public DataSet mv_Token_FCM(string token_persona, string token_FCM)
        {
            clsConexion objCon = new clsConexion();

            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_FCM", token_FCM, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Token_FCM", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Token_FCM Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Consulta_Msm_Admin(string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Consulta_Msm_Admin", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Consulta_Msm_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_Respuesta_Encuesta(string id_encuesta, string token_persona, string respuesta)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@id_encuesta", id_encuesta, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@respuesta", respuesta, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "mv_Rta_Encuesta", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Respuesta_Encuesta Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
        public DataSet mv_Actualiza_persona(string correo_persona, string token_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@correo_persona", correo_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@token_persona", token_persona, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_Actualiza_persona", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Actualiza_persona Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_envio_correo_persona(string Bandera, string correo_persona, string Codigo)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@Bandera", Bandera, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@correo_persona", correo_persona, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@Codigo", Codigo, SqlDbType.VarChar, null));


                DataSet a = objCon.ExecuteProcWS("", "", "mv_envio_correo_persona", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_envio_correo_persona Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet mv_consulta_persona_Recuperar(string correo_persona)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@correo_persona", correo_persona, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "mv_consulta_persona_Recuperar", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_consulta_persona_Recuperar Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }

        }
        public DataSet au_consulta_circuito(string NombreSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@NomSitio", NombreSitio, SqlDbType.VarChar, null));

                DataSet a = objCon.ExecuteProcWS("", "", "au_consulta_circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_consulta_persona_Recuperar Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }

        }

        //metodos de creacion de circuitos
        public void InsertarImagenSitio(string imagen, string imagen_img, int orden, string fk_sitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("@imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("@orden", orden, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("@fk_sitio", fk_sitio, SqlDbType.Int, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Insert_ImagenSitio", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Error al insertar imagen de sitio: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaNombreCiudad(string NombreCiudad, string NombrePais)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("NombreCiudad", NombreCiudad, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("NombrePais", NombrePais, SqlDbType.VarChar, null));
                DataTable dtCiudades = (DataTable)objCon.ExecuteProc("", "", "au_Consuta_CiudadXNombre", parametrosEntrada, ref parametrosSalida);
                return dtCiudades;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("au_Consuta_CiudadXNombre Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaCircuitos(string CodIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Circuitos_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaSitios(string CodIdioma, string IdCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("IdCircuito", IdCircuito, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Sitios_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaCategorias()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Categorias_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ConsultaImagenes(string idSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();

            parametrosEntrada.Add(new InParameter("idSitio", idSitio, SqlDbType.VarChar, null));

            try
            {
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "Get_Img_Sitios_Admin", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Img_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaOrdenSitios(string idSitio, string Orden)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("idSitio", idSitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Orden", Orden, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Actualizar_OrdenSitio", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public void EliminaImagenSitio(string idImagen)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("idImagen", idImagen, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Eliminar_ImagenSitio", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable ActualizaEstadoCircuito(string idCircuito, string Estado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito_actualizar", idCircuito, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("estado", Estado, SqlDbType.VarChar, null));
                DataTable dtCircuitos = (DataTable)objCon.ExecuteProc("", "", "pa_Actualiza_Estado_Circuito", parametrosEntrada, ref parametrosSalida);
                return dtCircuitos;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Sitios_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
        public DataSet au_Traducir_Texto(string tipo, string llave, string texto, string codigo_idioma, string campo)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("tipo", tipo, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("llave", llave, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("texto", texto, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("campo", campo, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "au_Actualiza_Idiomas", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("mv_Asignacion_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }


        public DataSet pa_Consulta_CircuitoXId(string idCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", idCircuito, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_circuitoIdiomaXId", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_circuitoIdiomaXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_SiguienteIdSitio_Value(string idCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", idCircuito, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_SiguienteIdSitio_Value", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_SiguienteIdSitio_Value Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_Nombre_SitioXId(string idSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Id_Sitio", idSitio, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_Nombre_SitioXId", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_Nombre_SitioXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_Nombre_CircuitoXId(string idCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Id_Circuito", idCircuito, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_Nombre_CircuitoXId", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_Nombre_CircuitoXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_SitioIdiomaXId(string idSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_sitio", idSitio, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_SitioIdiomaXId", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_SitioIdiomaXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet au_Validar_Traduccion_Circuito(string idCircuito, string codIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {

                parametrosEntrada.Add(new InParameter("id_circuito", idCircuito, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("cod_idioma", codIdioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "au_Validar_Traduccion_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_SitioIdiomaXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet au_Validar_Traduccion_Sitio(string IdSitio, string codIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {

                parametrosEntrada.Add(new InParameter("id_sitio", IdSitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("cod_idioma", codIdioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "au_Validar_Traduccion_Sitio", parametrosEntrada, ref parametrosSalida);
                return a;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_SitioIdiomaXId Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable au_Consulta_Circuito(string NombreSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("NomSitio", NombreSitio, SqlDbType.VarChar, null));
                DataTable a = objCon.ExecuteProcWS("", "", "au_Consulta_Circuito", parametrosEntrada, ref parametrosSalida).Tables[0];
                return a;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable au_Consulta_Sitio(string NombreSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("NomSitio", NombreSitio, SqlDbType.VarChar, null));
                DataTable a = objCon.ExecuteProcWS("", "", "au_Consulta_Sitio", parametrosEntrada, ref parametrosSalida).Tables[0];
                return a;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}