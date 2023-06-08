using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;

namespace CDI.Common
{
    public class JsonWebToken
    {
        private const string Key = "PGNSecurity";

        /// <summary>
        /// Crea el token para autenticacion 
        /// </summary>
        /// <param name="Usuario">datos del usuario logueado</param>
        /// <returns></returns>
        public static string Crear(DatosSeguridad Usuario)
        {
            try
            {
                string Payload = @"{""Date"":""" + Usuario.Date + @""", ""User"": """ + Usuario.User + @""", ""Regional"": """ + Usuario.Regional + @""", ""Ent"": """ + Usuario.Ent + @""", ""Cedula"": """ + Usuario.Cedula + @"""}";

                string Header = @"{""alg"": ""HS256"",  ""typ"": ""JWT""}";

                string Payload64 = ParseoBase64(Payload);
                string Header64 = ParseoBase64(Header);

                string Mensaje = Header64 + "." + Payload64;

                string tokenString = EncryptTDES(Mensaje, Key);

                return tokenString;
            }
            catch (Exception ex)
            {
                throw new Exception("ocurrio un error en la generacion del token JWT", ex);
            }
        }

        public static string Crear(string Usuario, string Entidad)
        {
            try
            {
                DateTime Date = DateTime.UtcNow;
                string Payload = @"{""Date"":""" + Date.ToString("ddMMyyyyHHmmss") + @""", ""User"": """ + Usuario + @""", ""Regional"": ""51"", ""Ent"": """ + Entidad + @"""}";

                string Header = @"{""alg"": ""HS256"",  ""typ"": ""JWT""}";

                string Payload64 = ParseoBase64(Payload);
                string Header64 = ParseoBase64(Header);

                string Mensaje = Header64 + "." + Payload64;

                string tokenString = EncryptTDES(Mensaje, Key);

                return tokenString;
            }
            catch (Exception ex)
            {
                throw new Exception("ocurrio un error en la generacion del token JWT", ex);
            }
        }

        /// <summary>
        /// Parsea un texto a base 64
        /// </summary>
        /// <param name="txt">la cadena de caracteres</param>
        /// <returns>string en base 64</returns>
        private static string ParseoBase64(string pTxt)
        {
            try
            {
                byte[] bDatos = Encoding.UTF8.GetBytes(pTxt);

                string datos = Convert.ToBase64String(bDatos);

                return datos;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Error en [ParseoBase64]. Detalle: ", ex);
                return null;
            }
        }

        /// <summary>
        /// Valida el token para contruir la session
        /// </summary>
        /// <param name="token">Token JWT a validar</param>
        /// <param name="Minutos">Los minutos que permite la validacion.</param>
        /// <returns>Entrega el objeto lleno o nulo sin no se pudo validar</returns>
        public static bool ValidateToken(string Token, int Minutos = 5)
        {
            try
            {
                if (Token != null)
                {
                    string encrypted = HttpUtility.UrlEncode(Token);

                    encrypted = encrypted.Replace("%3a", ":");
                    encrypted = encrypted.Replace("%40", "@");
                    encrypted = encrypted.Replace("%24", "$");
                    encrypted = encrypted.Replace("%3d", "=");
                    encrypted = encrypted.Replace("%3b", ";");
                    encrypted = encrypted.Replace("%2c", ",");
                    encrypted = encrypted.Replace("%2f", "/");
                    encrypted = encrypted.Replace("%3f", "?");
                    encrypted = encrypted.Replace("%2b", "+");
                    encrypted = encrypted.Replace("%20", "+");

                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ingresa a ValidateToken Token [" + encrypted + "] ", CDITrace.Tipo.Log);
                    string descript = DecryptTDES(encrypted, Key);

                    if (descript != null)
                    {
                        string[] Valores = Herramienta.SepararARegistro(descript, 46);

                        if (Valores.Length > 0)
                        {
                            byte[] decodedData = Convert.FromBase64String(Valores[1]);

                            string sJson = Encoding.UTF8.GetString(decodedData);

                            if (sJson != null)
                            {
                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "JSON " + sJson, CDITrace.Tipo.Log);
                                List<DatosSeguridad> val = new List<DatosSeguridad>();
                                val.Add(JsonConvert.DeserializeObject<DatosSeguridad>(sJson));

                                if (val != null)
                                {
                                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "fecha " + val[0].Date, CDITrace.Tipo.Log);

                                    DateTime DateIng = DateTime.ParseExact(val[0].Date, "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);

                                    TimeSpan DiferenciaTiempo = DateTime.Now - DateIng;

                                    if (Minutos == -1)
                                    {
                                        Minutos = 5;
                                    }

                                    if (DiferenciaTiempo.TotalMinutes <= Minutos)
                                    {
                                        return true;
                                    }

                                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El fecha esta erronea o esta fuera del intervalo de " + Minutos + " minutos: " + val[0].Date + " querystring " + encrypted, CDITrace.Tipo.Log);
                                    return false;
                                }

                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token esta erroneo: " + sJson, CDITrace.Tipo.Log);
                                return false;
                            }

                            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El valor del token esta erroneo: " + sJson, CDITrace.Tipo.Log);
                            return false;
                        }

                        CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token no trae el formato correcto: " + descript, CDITrace.Tipo.Log);
                        return false;
                    }

                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: No se pudo descencriptar el valor : " + encrypted, CDITrace.Tipo.Log);
                    return false;
                }

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token viene null ", CDITrace.Tipo.Log);
                return false;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: ", ex);
                return false;
            }
        }

        /// <summary>
        /// Valida el token para contruir la session
        /// </summary>
        /// <param name="token">Token JWT a validar</param>
        /// <param name="Minutos">Los minutos que permite la validacion.</param>
        /// <returns>Entrega el objeto lleno o nulo sin no se pudo validar</returns>
        public static DatosSeguridad ValidateRequest(MethodBase Nombre, HttpRequest request, int Minutos = 5)
        {
            try
            {
                string encrypted = "";
                if (request.QueryString["t"] != null || HttpContext.Current.Session["t"] != null)
                {
                    if(request.QueryString["t"] != null)
                    {
                        HttpContext.Current.Session.Add("t", request.QueryString["t"]);
                    }
                    if (request.QueryString["t"] != null)
                    {
                        encrypted = HttpUtility.UrlEncode(request.QueryString["t"].ToString());
                    }
                    else if (HttpContext.Current.Session["t"] != null)
                    {
                        encrypted = HttpUtility.UrlEncode(HttpContext.Current.Session["t"].ToString());
                    }
                    encrypted = encrypted.Replace("%3a", ":");
                    encrypted = encrypted.Replace("%40", "@");
                    encrypted = encrypted.Replace("%24", "$");
                    encrypted = encrypted.Replace("%3d", "=");
                    encrypted = encrypted.Replace("%3b", ";");
                    encrypted = encrypted.Replace("%2c", ",");
                    encrypted = encrypted.Replace("%2f", "/");
                    encrypted = encrypted.Replace("%3f", "?");

                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ingresa a ValidateToken Token [" + encrypted + "]  Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Log);
                    string descript = DecryptTDES(encrypted, Key);

                    if (descript != null)
                    {
                        string[] Valores = Herramienta.SepararARegistro(descript, 46);

                        if (Valores.Length > 0)
                        {
                            byte[] decodedData = Convert.FromBase64String(Valores[1]);

                            string sJson = Encoding.UTF8.GetString(decodedData);

                            if (sJson != null)
                            {
                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "JSON " + sJson + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Log);
                                List<DatosSeguridad> val = new List<DatosSeguridad>();
                                val.Add(JsonConvert.DeserializeObject<DatosSeguridad>(sJson));

                                if (val != null)
                                {
                                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "fecha " + val[0].Date + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Log);

                                    DateTime DateIng = DateTime.ParseExact(val[0].Date, "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);

                                    TimeSpan DiferenciaTiempo = DateTime.Now - DateIng;

                                    if (Minutos == -1)
                                    {
                                        Minutos = 5;
                                    }

                                    if (DiferenciaTiempo.TotalMinutes <= Minutos)
                                    {
                                        return val[0];
                                    }

                                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El fecha esta erronea o esta fuera del intervalo de " + Minutos + " minutos: " + val[0].Date + " querystring " + encrypted + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                                    return null;
                                }

                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token esta erroneo: " + sJson + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                                return null;
                            }

                            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El valor del token esta erroneo: " + sJson + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                            return null;
                        }

                        CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token no trae el formato correcto: " + descript + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                        return null;
                    }

                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: No se pudo descencriptar el valor : " + encrypted + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                    return null;
                }
                else
                {
                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: No se encuentra el querystring t" + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", CDITrace.Tipo.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: " + " Metodo: " + Nombre.Name + " de la clase: " + Nombre.ReflectedType.FullName + "", ex);
                return null;
            }
        }

        /// <summary>
        /// Valida el token para contruir la session
        /// </summary>
        /// <param name="token">Token JWT a validar</param>
        /// <param name="Minutos">Los minutos que permite la validacion.</param>
        /// <returns>Entrega el objeto lleno o nulo sin no se pudo validar</returns>
        public static DatosSeguridad ValidarToken(string Token, int Minutos = 5)
        {
            try
            {
                string encrypted = Token;

                encrypted = encrypted.Replace("%3a", ":");
                encrypted = encrypted.Replace("%40", "@");
                encrypted = encrypted.Replace("%24", "$");
                encrypted = encrypted.Replace("%3d", "=");
                encrypted = encrypted.Replace("%3b", ";");
                encrypted = encrypted.Replace("%2c", ",");
                encrypted = encrypted.Replace("%2f", "/");
                encrypted = encrypted.Replace("%3f", "?");

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ingresa a ValidateToken Token [" + encrypted + "] ", CDITrace.Tipo.Log);
                string descript = DecryptTDES(encrypted, Key);

                if (descript != null)
                {
                    string[] Valores = Herramienta.SepararARegistro(descript, 46);

                    if (Valores.Length > 0)
                    {
                        byte[] decodedData = Convert.FromBase64String(Valores[1]);

                        string sJson = Encoding.UTF8.GetString(decodedData);

                        if (sJson != null)
                        {
                            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "JSON " + sJson, CDITrace.Tipo.Log);
                            List<DatosSeguridad> val = new List<DatosSeguridad>();
                            val.Add(JsonConvert.DeserializeObject<DatosSeguridad>(sJson));

                            if (val != null)
                            {
                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "fecha " + val[0].Date, CDITrace.Tipo.Log);

                                DateTime DateIng = DateTime.ParseExact(val[0].Date, "ddMMyyyyHHmmss", CultureInfo.InvariantCulture);

                                TimeSpan DiferenciaTiempo = DateTime.Now - DateIng;

                                if (Minutos == -1)
                                {
                                    Minutos = 5;
                                }

                                if (DiferenciaTiempo.TotalMinutes <= Minutos)
                                {
                                    return val[0];
                                }

                                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El fecha esta erronea o esta fuera del intervalo de " + Minutos + " minutos: " + val[0].Date + " querystring " + encrypted, CDITrace.Tipo.Error);
                                return null;
                            }

                            CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token esta erroneo: " + sJson, CDITrace.Tipo.Error);
                            return null;
                        }

                        CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El valor del token esta erroneo: " + sJson, CDITrace.Tipo.Error);
                        return null;
                    }

                    CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: El token no trae el formato correcto: " + descript, CDITrace.Tipo.Error);
                    return null;
                }

                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: No se pudo descencriptar el valor : " + encrypted, CDITrace.Tipo.Error);
                return null;
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error en el ValidateToken: ", ex);
                return null;
            }
        }
        private static string EncryptTDES(string pMensaje, string pKey)
        {
            TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            string result = null;
            try
            {
                byte[] encryptdata = Encoding.UTF8.GetBytes(pMensaje);

                tDESalg.Mode = CipherMode.ECB;
                tDESalg.Padding = PaddingMode.PKCS7;

                byte[] hash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(pKey));
                byte[] Key = new byte[tDESalg.KeySize / 8];
                Array.Copy(hash, Key, hash.Length < Key.Length ? hash.Length : Key.Length);

                tDESalg.Key = Key;
                ICryptoTransform cryptoTransform = tDESalg.CreateEncryptor();

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(encryptdata, 0, encryptdata.Length);
                        cryptoStream.FlushFinalBlock();
                        result = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrio un error descriptando: {0}", e.Message + e.StackTrace);
                return null;
            }
            return result;
        }

        private static string DecryptTDES(string pMensaje, string decryptionKey)
        {
            string decryptString = "";
            TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            try
            {
                byte[] decodedData = Convert.FromBase64String(pMensaje);
                tDESalg.Mode = CipherMode.ECB;
                tDESalg.Padding = PaddingMode.PKCS7;//According to MS, same as PKCS5PADDING

                byte[] hash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(decryptionKey));
                byte[] Key = new byte[tDESalg.KeySize / 8]; //The size of the Key property must be the same as the KeySize property divided by 8
                Array.Copy(hash, Key, hash.Length < Key.Length ? hash.Length : Key.Length);

                tDESalg.Key = Key;
                ICryptoTransform cryptoTransform = tDESalg.CreateDecryptor();

                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(decodedData, 0, decodedData.Length);
                        cryptoStream.FlushFinalBlock();
                        decryptString = Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ocurrio un error descriptando:. Detalle: " + e.Message, CDITrace.Tipo.Error);
                return null;
            }

            return decryptString;
        }

        public static DatosSeguridad ValidaSession(MethodBase Nombre, Page request)
        {
            int TiempoSession = Herramienta.ParseoTexto(Herramienta.TraerConfiguracion("TiempoSession"));
            int TiempoActualS = 0;
                       
            if (request.Session["session"] == null)
            {
                TiempoActualS = TiempoSession;
            }
            else
            {
                TiempoActualS = Herramienta.ParseoTexto(request.Session["session"]);
                TiempoActualS = TiempoActualS + TiempoSession;
            }

            request.Session["session"] = TiempoActualS;
            DatosSeguridad usuario = ValidateRequest(Nombre, request.Request, TiempoActualS);

            return usuario;
        }
    }
}
