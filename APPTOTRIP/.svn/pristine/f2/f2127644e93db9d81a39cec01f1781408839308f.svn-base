
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using CDI.Comun;
using CT.ADMIN.BL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace AttomTraslation
{
    class Program
    {
        public static Boolean process = true;
        public static Boolean process_streaming = true;

        static void Main(string[] args)
        {
            
            System.Timers.Timer oTimer = new System.Timers.Timer();
            oTimer.Interval = 6000;

            oTimer.Elapsed += EventoIntervalo;

            oTimer.Enabled = true;

            Console.ReadLine();
        }

        private static void EventoIntervalo(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Traducciones
            if (process)
            {
                process = false;
                Metodo metodo = new Metodo();
                Console.WriteLine("Iniciando a las: {0}", e.SignalTime);
                metodo.validar_traduce();
                process = true;
            }
            else {
                Console.Clear();
                Console.WriteLine("Procesando a las: {0}", e.SignalTime);
            }

            if (process_streaming)
            {
                process_streaming = false;
                Metodo metodo = new Metodo();
                Console.WriteLine("Generando Audio a las: {0}", e.SignalTime);
                metodo.validar_stream();
                process_streaming = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Procesando audios: {0}", e.SignalTime);
            }

        }
    }

    internal class Metodo
    {
        public void Tarea() {
            Thread.Sleep(5000);
        }

        String[] lenguajes = { "de", "en", "es", "fr", "it", "ja", "pt", "ru", "tr" };


        public string validar_traduce()
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            string[] campos_encontrar = { "nombre_circuito", "descripcion_circuito", "equipamento", "recomendacion", "descripcion_corta_circuito", "contexto", "tiempo_estimado" };
            string[] campos_encontrar_sitio = { "nombre_sitio", "descripcion_sitio", "equipamento", "recomendacion", "indicaciones", "horario", "tiempo_estimado", "descripcion_corta_sitio" };
            List<String> campo_traducirArray = new List<string>();
            List<String> codigo_traducirArray = new List<string>();
            string cadena_original = "";
            string codigo_origen = "";
            try
            {
                /*Circuitos por traducir*/
                DataTable dataTable = objCon.Query(@"select distinct id_circuito from circuito
                inner join circuito_idioma on circuito_idioma.fk_circuito= id_circuito where estado_circuito in (1,3) and (nombre_circuito='0'
                or descripcion_circuito='0' or descripcion_corta_circuito='0' or recomendacion='0' or equipamento='0' or contexto='0')");
                if (dataTable.Rows.Count != 0)
                {
                    /*Valida los cirucitos*/
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_circuito = dataTable.Rows[i]["id_circuito"].ToString();
                        Console.WriteLine("traducion id_circuito" + id_circuito);
                        for (int j = 0; j < campos_encontrar.Length; j++)
                        {
                            DataTable valor = objCon.Query("select " + campos_encontrar[j] + " as consulta, codigo_idioma from circuito_idioma where fk_circuito=" + id_circuito + " and " + campos_encontrar[j] + "='0'");

                            if (valor.Rows.Count != 0)
                            {
                                DataTable origen = objCon.Query(@"select " + campos_encontrar[j] + " as consulta, idioma from circuito_idioma " +
                                "inner join circuito on circuito.id_circuito=circuito_idioma.fk_circuito inner join usuario on usuario.id_usuario=circuito.fk_usuario where circuito_idioma.fk_circuito =" + id_circuito + " and circuito_idioma.codigo_idioma=idioma");
                                if (origen.Rows.Count != 0)
                                {
                                    cadena_original = origen.Rows[0]["consulta"].ToString();
                                    codigo_origen = origen.Rows[0]["idioma"].ToString();
                                    if ((cadena_original != ("0")) && (cadena_original != ("")))
                                    {
                                        update_traducir("circuito", campos_encontrar[j], cadena_original, id_circuito, codigo_origen);
                                        cadena_original = "";
                                        codigo_origen = "";
                                    }
                                }
                            }
                        }
                    }
                }

                DataTable sitio = objCon.Query(@"select distinct fk_sitio from sitio_idioma where fk_sitio in (select id_sitio from sitio
                inner join circuito  on sitio.fk_circuito=circuito.id_circuito where circuito.estado_circuito in (1)) and (
                nombre_sitio='0' or descripcion_sitio='0' or descripcion_corta_sitio='0' or recomendacion='0' or indicaciones='0')");

                if (sitio.Rows.Count != 0)
                {
                    /*Valida los cirucitos*/
                    for (int i = 0; i < sitio.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_sitio = sitio.Rows[i]["fk_sitio"].ToString();
                        Console.WriteLine("traducion id_sitio" + id_sitio);
                        for (int j = 0; j < campos_encontrar_sitio.Length; j++)
                        {
                            DataTable valor = objCon.Query("select " + campos_encontrar_sitio[j] + " as consulta, codigo_idioma from sitio_idioma where fk_sitio=" + id_sitio + " and " + campos_encontrar_sitio[j] + "='0'");

                            if (valor.Rows.Count != 0)
                            {
                                DataTable origen = objCon.Query(@"select " + campos_encontrar_sitio[j] + " as consulta, idioma from sitio_idioma " +
                                "inner join sitio on sitio.id_sitio=sitio_idioma.fk_sitio inner join circuito on circuito.id_circuito=sitio.fk_circuito inner join usuario  on usuario.id_usuario=circuito.fk_usuario where fk_sitio =" + id_sitio + " and sitio_idioma.codigo_idioma=idioma");

                                if (origen.Rows.Count != 0)
                                {
                                    cadena_original = origen.Rows[0]["consulta"].ToString();
                                    codigo_origen = origen.Rows[0]["idioma"].ToString();
                                    if ((cadena_original != ("0")) && (cadena_original != ("")))
                                    {
                                        update_traducir("sitio", campos_encontrar_sitio[j], cadena_original, id_sitio, codigo_origen);
                                        cadena_original = "";
                                        campo_traducirArray.Clear();
                                        codigo_traducirArray.Clear();
                                    }
                                }
                            }
                        }


                    }
                }

                /*sitios preview*/
                DataTable sitiopr = objCon.Query(@"select distinct fk_sitio from sitio_idioma where fk_sitio in (select id_sitio from sitio
                inner join circuito  on sitio.fk_circuito=circuito.id_circuito where circuito.estado_circuito in (3)) and (
                nombre_sitio='0' or descripcion_sitio='0' or descripcion_corta_sitio='0' or recomendacion='0' or indicaciones='0')");

                if (sitiopr.Rows.Count != 0)
                {
                    /*Valida los cirucitos*/
                    for (int i = 0; i < sitiopr.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_sitio = sitiopr.Rows[i]["fk_sitio"].ToString();

                        Console.WriteLine("traducion id_sitio preview" + id_sitio);
                        for (int j = 0; j < campos_encontrar_sitio.Length; j++)
                        {
                            DataTable valor = objCon.Query("select " + campos_encontrar_sitio[j] + " as consulta, codigo_idioma from sitio_idioma where fk_sitio=" + id_sitio + " and " + campos_encontrar_sitio[j] + "='0'");

                            if (valor.Rows.Count != 0)
                            {
                                DataTable origen = objCon.Query(@"select " + campos_encontrar_sitio[j] + " as consulta, idioma from sitio_idioma " +
                                "inner join sitio on sitio.id_sitio=sitio_idioma.fk_sitio inner join circuito on circuito.id_circuito=sitio.fk_circuito inner join usuario  on usuario.id_usuario=circuito.fk_usuario where fk_sitio =" + id_sitio + " and sitio_idioma.codigo_idioma=idioma");

                                if (origen.Rows.Count != 0)
                                {
                                    cadena_original = origen.Rows[0]["consulta"].ToString();
                                    codigo_origen = origen.Rows[0]["idioma"].ToString();
                                    if ((cadena_original != ("0")) && (cadena_original != ("")))
                                    {
                                        update_traducir("sitio", campos_encontrar_sitio[j], cadena_original, id_sitio, codigo_origen);
                                        cadena_original = "";
                                        campo_traducirArray.Clear();
                                        codigo_traducirArray.Clear();
                                    }
                                }
                            }
                        }


                    }
                }

            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("traducion excepcion" + e);
                return "Validar " + e;
            }

            return "Validadas las traducciones pendientes";
        }
        public string traducir(String text, String Entrada, String Salida)
        {
            if (!text.Equals(""))
            {
                String url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&from=" + Entrada + "&to=" + Salida + "";
                if (Entrada.Equals("") || Entrada.Equals("%20"))
                {
                    url = "https://api.cognitive.microsofttranslator.com/translate?api-version=3.0&to=" + Salida + "";
                }
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                //httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", "73ca5d43c217480ca2457224f0db6362");
                httpWebRequest.Headers.Add("Ocp-Apim-Subscription-Key", "9353c8730fdc4359825b6d791774574b");
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream(), Encoding.UTF8))
                {
                    string json11 = "[{'Text':'" + text.Replace("'", "") + "'}]";
                    streamWriter.Write(json11);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                String r;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = sr.ReadToEnd();
                    r = result.Remove(0, 1);
                    r = r.Remove(r.Length - 1, 1);
                }
                JObject array = JObject.Parse(r);
                JArray a = JArray.Parse(array["translations"].ToString());
                r = a[0]["text"].Value<String>();
                return r;
            }
            else
            {
                return "";
            }
        }
        private void update_traducir(string tabla, string campo_traducirArray, string valor_traducirArray, string clave, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            for (int l = 0; l < lenguajes.Length; l++)
            {
                Tarea();
                if (!codigo_idioma.Equals(lenguajes[l]))
                {
                    String t = traducir(valor_traducirArray, codigo_idioma, lenguajes[l]).Replace("'", "''");
                    string cadena_update = "update " + tabla + "_idioma set " + campo_traducirArray + "=N'" + t + "' where fk_" + tabla + "=" + clave + " and codigo_idioma='" + lenguajes[l] + "'";
                    int f = objCon.QueryEscalar(cadena_update);
                    try
                    {
                        string cadenai = "insert into " + tabla + "_idioma_audio (" + campo_traducirArray + "_au,fk_" + tabla + "_au,codigo_idioma_au) values ('0'," + clave + ",'" + lenguajes[l] + "')";
                        int r = objCon.QueryEscalar(cadenai);

                    }
                    catch (Exception e)
                    {
                        string cadenau = "update " + tabla + "_idioma_audio set " + campo_traducirArray + "_au='0' where fk_" + tabla + "_au=" + clave + " and codigo_idioma_au='" + lenguajes[l] + "'";
                        int c = objCon.QueryEscalar(cadenau);
                    }
                }
                else
                {
                    string cadena_update = "update " + tabla + "_idioma set " + campo_traducirArray + "=N'" + valor_traducirArray + "' where fk_" + tabla + "=" + clave + " and codigo_idioma='" + codigo_idioma + "'";
                    int f = objCon.QueryEscalar(cadena_update);
                    try
                    {
                        string cadenai = "insert into " + tabla + "_idioma_audio (" + campo_traducirArray + "_au,fk_" + tabla + "_au,codigo_idioma_au) values ('0'," + clave + ",'" + codigo_idioma + "')";
                        int r = objCon.QueryEscalar(cadenai);

                    }
                    catch (Exception e)
                    {
                        string cadenau = "update " + tabla + "_idioma_audio set " + campo_traducirArray + "_au='0' where fk_" + tabla + "_au=" + clave + " and codigo_idioma_au='" + codigo_idioma + "'";
                        int c = objCon.QueryEscalar(cadenau);
                    }

                }

            }
        }

        public string validar_stream()
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            string[] campos_evaluar = { "nombre_circuito_au", "descripcion_circuito_au", "descripcion_corta_circuito_au", "contexto_au" };
            string[] campos_encontrar = { "nombre_circuito", "descripcion_circuito", "descripcion_corta_circuito", "contexto" };
            string[] campos_encontrarS = { "nombre_sitio", "descripcion_sitio", "indicaciones", "descripcion_corta_sitio" };
            string[] campos_evaluarS = { "nombre_sitio_au", "descripcion_sitio_au", "indicaciones_au", "descripcion_corta_sitio_au" };
            
            try
            {
                for (int a = 0; a < campos_evaluar.Length; a++)
                {
                    for (int b = 0; b < lenguajes.Length; b++)
                    {
                        DataTable validar = objCon.Query("select " + campos_evaluar[a] + " as consulta, codigo_idioma_au, fk_circuito_au from circuito_idioma_audio where " + campos_evaluar[a] + "='0' and codigo_idioma_au='" + lenguajes[b] + "'");
                        try
                        {
                            string consulta = validar.Rows[0]["consulta"].ToString();
                            string codigo = validar.Rows[0]["codigo_idioma_au"].ToString();
                            string clave = validar.Rows[0]["fk_circuito_au"].ToString();
                            if (consulta != (""))
                            {
                                if (consulta.Equals("0"))
                                {
                                    DataTable extraccion = objCon.Query("select " + campos_encontrar[a] + " as consulta from circuito_idioma where fk_circuito=" + clave + " and codigo_idioma='" + codigo + "'");
                                    string extraccionc = extraccion.Rows[0]["consulta"].ToString();
                                    /*generastream*/
                                    if (extraccionc.Length <= 3000)
                                    {
                                        genera_streaming("circuito", clave, campos_encontrar[a], extraccionc, codigo);
                                    }
                                    else
                                    {
                                        genera_streaming_long("1", "circuito", clave, campos_encontrar[a], extraccionc.Substring(0, 3000), codigo);
                                        string prueba = extraccionc.Substring(3000);
                                        genera_streaming_long("2", "circuito", clave, campos_encontrar[a], extraccionc.Substring(3000), codigo);
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }

                for (int a = 0; a < campos_evaluarS.Length; a++)
                {
                    for (int b = 0; b < lenguajes.Length; b++)
                    {
                        DataTable validar = objCon.Query("select " + campos_evaluarS[a] + " as consulta, codigo_idioma_au, fk_sitio_au from sitio_idioma_audio where " + campos_evaluarS[a] + "='0' and codigo_idioma_au='" + lenguajes[b] + "'");
                        try
                        {
                            string consulta = validar.Rows[0]["consulta"].ToString();
                            string codigo = validar.Rows[0]["codigo_idioma_au"].ToString();
                            string clave = validar.Rows[0]["fk_sitio_au"].ToString();
                            if (consulta != (""))
                            {
                                if (consulta.Equals("0"))
                                {
                                    DataTable extraccion = objCon.Query("select " + campos_encontrarS[a] + " as consulta from sitio_idioma where fk_sitio=" + clave + " and codigo_idioma='" + codigo + "'");
                                    string extraccionc = extraccion.Rows[0]["consulta"].ToString();
                                    /*generastream*/
                                    int longi = 3100;
                                    if (extraccionc.Length <= 3000)
                                    {
                                        genera_streaming("sitio", clave, campos_encontrarS[a], extraccionc, codigo);
                                    }
                                    else
                                    {
                                        genera_streaming_long("1", "sitio", clave, campos_encontrarS[a], extraccionc.Substring(0, 3000), codigo);
                                        string prueba = extraccionc.Substring(3000);
                                        genera_streaming_long("2", "sitio", clave, campos_encontrarS[a], extraccionc.Substring(3000), codigo);
                                    }

                                }
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
            }
            catch (Exception e)
            {
                return "validar " + e;
            }

            return "Validado y generados los audios faltantes";
        }
        public string genera_streaming(string tabla, string clave, string campo, string cadena, string codigo_idioma)
        {
            Tarea();
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            BasicAWSCredentials awsCreds = new BasicAWSCredentials("AKIA4D6MRNG4ER5VUQVT", "oVIFepsNOLDQnApfxn6XFhoChangdOBIgI/4K3E9");
            AmazonPollyClient cliente = new AmazonPollyClient(awsCreds, Amazon.RegionEndpoint.USEast1);
            String outputFileName =
            "C:\\inetpub\\wwwroot\\produccion_audios\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";
            /*"C:\\prueba2\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3"; */
            /*"C:\\inetpub\\wwwroot\\prueba\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3"; */
            DescribeVoicesRequest describeVoicesRequest = new DescribeVoicesRequest();
            DescribeVoicesResponse describeVoicesResult = cliente.DescribeVoices(describeVoicesRequest);
            List<Voice> voices = describeVoicesResult.Voices;
            VoiceId l = VoiceId.Lucia;
            /*String a= voices[13].LanguageCode;*/
            if (tabla.Equals("circuito"))
            {
                if (codigo_idioma.Equals("es"))
                {
                    DataTable voiceid = objCon.Query("select voice_id as voice from circuito a inner join ciudad c on a.fk_ciudad= c.id_ciudad where id_circuito=" + clave);
                    string voice = voiceid.Rows[0]["voice"].ToString();
                    if (voice != ("0"))
                    {

                        int resvoice = Int32.Parse(voice);
                        l = voices[resvoice].Id;
                        var synthesizeSpeechRequestN = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestN);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Exception caught: " + e.Message);
                        }
                        return "algo";

                    }
                    else
                    {
                        for (int h = 0; h < voices.Count; h++)
                        {
                            string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                            if (codigo_idioma.Equals(p))
                            {
                                l = voices[h].Id;
                            }

                        }

                        var synthesizeSpeechRequestNS = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestNS);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception f)
                        {
                            Console.WriteLine("Exception caught: " + f.Message);
                        }
                        return "algo";

                    }
                }
                else
                {
                    for (int h = 0; h < voices.Count; h++)
                    {
                        string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                        if (codigo_idioma.Equals(p))
                        {
                            l = voices[h].Id;
                        }

                    }

                    var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
                    {
                        OutputFormat = OutputFormat.Mp3,
                        VoiceId = l,
                        Text = cadena,
                    };

                    try
                    {
                        using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                        {
                            var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequest);
                            byte[] buffer = new byte[2 * 1024];
                            int readBytes;

                            var inputStream = synthesizeSpeechResponse.AudioStream;
                            while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                outputStream.Write(buffer, 0, readBytes);
                        }

                        try
                        {
                            int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                        }
                        catch (Exception f)
                        {
                            int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                        }


                    }

                    catch (Exception f)
                    {
                        Console.WriteLine("Exception caught: " + f.Message);
                    }
                    return "algo";
                }
            }

            else if (tabla.Equals("sitio"))
            {
                if (codigo_idioma.Equals("es"))
                {
                    DataTable voiceid = objCon.Query("select voice_id as voice from sitio a inner join circuito b on a.fk_circuito = b.id_circuito inner join ciudad c on b.fk_ciudad = c.id_ciudad where a.id_sitio =" + clave);
                    string voice = voiceid.Rows[0]["voice"].ToString();
                    if (voice != ("0"))
                    {

                        int resvoice = Int32.Parse(voice);
                        l = voices[resvoice].Id;
                        var synthesizeSpeechRequestN = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestN);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Exception caught: " + e.Message);
                        }
                        return "algo";

                    }
                    else
                    {
                        for (int h = 0; h < voices.Count; h++)
                        {
                            string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                            if (codigo_idioma.Equals(p))
                            {
                                l = voices[h].Id;
                            }

                        }

                        var synthesizeSpeechRequestNS = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestNS);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception f)
                        {
                            Console.WriteLine("Exception caught: " + f.Message);
                        }
                        return "algo";

                    }
                }
                else
                {
                    for (int h = 0; h < voices.Count; h++)
                    {
                        string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                        if (codigo_idioma.Equals(p))
                        {
                            l = voices[h].Id;
                        }

                    }

                    var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
                    {
                        OutputFormat = OutputFormat.Mp3,
                        VoiceId = l,
                        Text = cadena,
                    };

                    try
                    {
                        using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                        {
                            var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequest);
                            byte[] buffer = new byte[2 * 1024];
                            int readBytes;

                            var inputStream = synthesizeSpeechResponse.AudioStream;
                            while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                outputStream.Write(buffer, 0, readBytes);
                        }

                        try
                        {
                            int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                        }
                        catch (Exception f)
                        {
                            int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                        }


                    }

                    catch (Exception f)
                    {
                        Console.WriteLine("Exception caught: " + f.Message);
                    }
                    return "algo";
                }
            }

            return "algo";


        }
        public string genera_streaming_long(string orden, string tabla, string clave, string campo, string cadena, string codigo_idioma)
        {
            Tarea();
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            BasicAWSCredentials awsCreds = new BasicAWSCredentials("AKIA4D6MRNG4ER5VUQVT", "oVIFepsNOLDQnApfxn6XFhoChangdOBIgI/4K3E9");
            AmazonPollyClient cliente = new AmazonPollyClient(awsCreds, Amazon.RegionEndpoint.USEast1);
            String outputFileName =
            "C:\\inetpub\\wwwroot\\produccion_audios\\" + orden + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";
            /*"C:\\inetpub\\wwwroot\\prueba\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";*/
            /*"C:\\inetpub\\wwwroot\\prueba\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3"; */
            DescribeVoicesRequest describeVoicesRequest = new DescribeVoicesRequest();
            DescribeVoicesResponse describeVoicesResult = cliente.DescribeVoices(describeVoicesRequest);
            List<Voice> voices = describeVoicesResult.Voices;
            VoiceId l = VoiceId.Lucia;
            /*String a= voices[13].LanguageCode;*/
            if (tabla.Equals("circuito"))
            {
                if (codigo_idioma.Equals("es"))
                {
                    DataTable voiceid = objCon.Query("select voice_id as voice from circuito a inner join ciudad c on a.fk_ciudad= c.id_ciudad where id_circuito=" + clave);
                    string voice = voiceid.Rows[0]["voice"].ToString();
                    if (voice != ("0"))
                    {

                        int resvoice = Int32.Parse(voice);
                        l = voices[resvoice].Id;
                        var synthesizeSpeechRequestN = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestN);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Exception caught: " + e.Message);
                        }
                        return "algo";

                    }
                    else
                    {
                        for (int h = 0; h < voices.Count; h++)
                        {
                            string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                            if (codigo_idioma.Equals(p))
                            {
                                l = voices[h].Id;
                            }

                        }

                        var synthesizeSpeechRequestNS = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestNS);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception f)
                        {
                            Console.WriteLine("Exception caught: " + f.Message);
                        }
                        return "algo";

                    }
                }
                else
                {
                    for (int h = 0; h < voices.Count; h++)
                    {
                        string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                        if (codigo_idioma.Equals(p))
                        {
                            l = voices[h].Id;
                        }

                    }

                    var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
                    {
                        OutputFormat = OutputFormat.Mp3,
                        VoiceId = l,
                        Text = cadena,
                    };

                    try
                    {
                        using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                        {
                            var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequest);
                            byte[] buffer = new byte[2 * 1024];
                            int readBytes;

                            var inputStream = synthesizeSpeechResponse.AudioStream;
                            while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                outputStream.Write(buffer, 0, readBytes);
                        }

                        try
                        {
                            int g = objCon.QueryEscalar("insert into " + tabla + "_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_" + tabla + "_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                        }
                        catch (Exception f)
                        {
                            int h = objCon.QueryEscalar("update " + tabla + "_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_" + tabla + "_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                        }


                    }

                    catch (Exception f)
                    {
                        Console.WriteLine("Exception caught: " + f.Message);
                    }
                    return "algo";
                }
            }

            else if (tabla.Equals("sitio"))
            {
                if (codigo_idioma.Equals("es"))
                {
                    DataTable voiceid = objCon.Query("select voice_id as voice from sitio a inner join circuito b on a.fk_circuito = b.id_circuito inner join ciudad c on b.fk_ciudad = c.id_ciudad where a.id_sitio =" + clave);
                    string voice = voiceid.Rows[0]["voice"].ToString();
                    if (voice != ("0"))
                    {

                        int resvoice = Int32.Parse(voice);
                        l = voices[resvoice].Id;
                        var synthesizeSpeechRequestN = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestN);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception e)
                        {
                            Console.WriteLine("Exception caught: " + e.Message);
                        }
                        return "algo";

                    }
                    else
                    {
                        for (int h = 0; h < voices.Count; h++)
                        {
                            string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                            if (codigo_idioma.Equals(p))
                            {
                                l = voices[h].Id;
                            }

                        }

                        var synthesizeSpeechRequestNS = new SynthesizeSpeechRequest()
                        {
                            OutputFormat = OutputFormat.Mp3,
                            VoiceId = l,
                            Text = cadena,
                        };

                        try
                        {
                            using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                            {
                                var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequestNS);
                                byte[] buffer = new byte[2 * 1024];
                                int readBytes;

                                var inputStream = synthesizeSpeechResponse.AudioStream;
                                while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                    outputStream.Write(buffer, 0, readBytes);
                            }

                            try
                            {
                                int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                            }
                            catch (Exception f)
                            {


                                int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                            }


                        }

                        catch (Exception f)
                        {
                            Console.WriteLine("Exception caught: " + f.Message);
                        }
                        return "algo";

                    }
                }
                else
                {
                    for (int h = 0; h < voices.Count; h++)
                    {
                        string p = voices[h].LanguageCode.ToString().Substring(0, 2);
                        if (codigo_idioma.Equals(p))
                        {
                            l = voices[h].Id;
                        }

                    }

                    var synthesizeSpeechRequest = new SynthesizeSpeechRequest()
                    {
                        OutputFormat = OutputFormat.Mp3,
                        VoiceId = l,
                        Text = cadena,
                    };

                    try
                    {
                        using (var outputStream = new FileStream(outputFileName, FileMode.Create, FileAccess.Write))
                        {
                            var synthesizeSpeechResponse = cliente.SynthesizeSpeech(synthesizeSpeechRequest);
                            byte[] buffer = new byte[2 * 1024];
                            int readBytes;

                            var inputStream = synthesizeSpeechResponse.AudioStream;
                            while ((readBytes = inputStream.Read(buffer, 0, 2 * 1024)) > 0)
                                outputStream.Write(buffer, 0, readBytes);
                        }

                        try
                        {
                            int g = objCon.QueryEscalar("insert into sitio_idioma_audio (" + campo + "_au,codigo_idioma_au,fk_sitio_au) values (N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "','" + codigo_idioma + "'," + clave + ")");

                        }
                        catch (Exception f)
                        {
                            int h = objCon.QueryEscalar("update sitio_idioma_audio set " + campo + "_au=N'" + outputFileName.Replace("C:\\inetpub\\wwwroot\\produccion_audios", "http://34.215.136.170").Replace("\\", "/") + "' where fk_sitio_au='" + clave + "' and codigo_idioma_au='" + codigo_idioma + "'");
                        }


                    }

                    catch (Exception f)
                    {
                        Console.WriteLine("Exception caught: " + f.Message);
                    }
                    return "algo";
                }
            }

            return "algo";


        }
        
    }
}
