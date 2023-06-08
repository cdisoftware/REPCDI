using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CDI.Common
{
    public class Encriptacion
    {
        /// <summary>
        /// Encripta a través de distintos métodos
        /// </summary>
        /// <param name="modo">1.Encripta, 2.Desencripta</param>
        /// <param name="Algoritmo">1.DES 2.TripleDES 3.RC2 4.Rijndael</param>
        /// <param name="cadena">Cadena a encriptar</param>
        /// <param name="key">Llave</param>
        /// <param name="VecI">Vector de encripción</param>
        /// <returns></returns>
        public static string Cifrado(string modo, string Algoritmo, string cadena, string key, string VecI)
        {
            Byte[] plaintext;

            if (modo == "1")
            {
                plaintext = Encoding.ASCII.GetBytes(cadena);
            }
            else
            {
                plaintext = Convert.FromBase64String(cadena);
            }

            Byte[] keys = Encoding.ASCII.GetBytes(key);
            MemoryStream memdata = new MemoryStream();
            ICryptoTransform transforma;

            switch (Algoritmo)
            {
                //DES
                case "1":
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    des.Mode = CipherMode.CBC;
                    if (modo == "1")
                    {
                        transforma = des.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    else
                    {
                        transforma = des.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    break;
                //TripleDES
                case "2":
                    TripleDESCryptoServiceProvider des3 = new TripleDESCryptoServiceProvider();
                    des3.Mode = CipherMode.CBC;
                    if (modo == "1")
                    {
                        transforma = des3.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    else
                    {
                        transforma = des3.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    break;
                //RC2
                case "3":
                    RC2CryptoServiceProvider rc2 = new RC2CryptoServiceProvider();
                    rc2.Mode = CipherMode.CBC;
                    if (modo == "1")
                    {
                        transforma = rc2.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    else
                    {
                        transforma = rc2.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    break;
                //Rijndael
                case "4":
                    RijndaelManaged rj = new RijndaelManaged();
                    rj.Mode = CipherMode.CBC;
                    if (modo == "1")
                    {
                        transforma = rj.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    else
                    {
                        transforma = rj.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    break;
                default:
                    RijndaelManaged rjD = new RijndaelManaged();
                    rjD.Mode = CipherMode.CBC;
                    if (modo == "1")
                    {
                        transforma = rjD.CreateEncryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    else
                    {
                        transforma = rjD.CreateDecryptor(keys, Encoding.ASCII.GetBytes(VecI));
                    }
                    break;
            }

            CryptoStream encstream = new CryptoStream(memdata, transforma, CryptoStreamMode.Write);
            encstream.Write(plaintext, 0, plaintext.Length);
            encstream.FlushFinalBlock();
            encstream.Close();
            if (modo == "1")
            {
                cadena = Convert.ToBase64String(memdata.ToArray());
            }
            else if (modo == "2")
            {
                cadena = Encoding.ASCII.GetString(memdata.ToArray());
            }
            return cadena;
        }

        /// <summary>
        /// Encripta un texto con el algoritmo md5
        /// </summary>
        /// <param name="plainText">Texto a encriptar</param>
        /// <returns>Texto encriptado</returns>
        public static string md5(string plainText)
        {
            MD5 enc = MD5.Create();
            byte[] rescBytes = Encoding.ASCII.GetBytes(plainText);
            byte[] hashBytes = enc.ComputeHash(rescBytes);

            StringBuilder str = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                str.Append(hashBytes[i].ToString("x2"));
            }

            return str.ToString();
        }

        public static string getMd5Hash(String input)
        {
            // Crea una nueva instancia del objeto MD5.
            MD5 md5Hasher = MD5.Create();
            // Convierte la cadena ingresada a un array de bytes y genera el hash.
            Byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            // Dim i As Integer
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        /// <summary>
        /// Enumeracion para operacion de cifrado
        /// </summary>
        public enum Operacion
        {
            /// <summary>
            /// Para encritar la cadena
            /// </summary>
            Encripta,
            /// <summary>
            /// Para desencritar la cadena
            /// </summary>
            Desencripta,
        }

        /// <summary>
        /// Encripta a través de distintos métodos
        /// </summary>
        /// <param name="modo">Operacion a realizar</param>
        /// <param name="cadena">Cadena a encriptar</param>
        /// <returns>String con el resultado segun la operacion</returns>
        public static string Cifrado(Operacion modo, string cadena)
        {
            try
            {
                string sModo = string.Empty;

                if (modo == Operacion.Encripta)
                {
                    sModo = "1";
                }
                else if (modo == Operacion.Desencripta)
                {
                    sModo = "2";
                }
                if (cadena != "")
                {
                    return Cifrado(sModo, "2", cadena, "password12345678", "password12345678");
                }
                else
                {
                    CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ha ocurrido un error en la clase Encriptacion metodo, Cifrado la cadena viene vacia.", CDI.Common.CDITrace.Tipo.Error);
                    return "";
                }
            }
            catch (Exception ex)
            {
                CDI.Common.CDITrace.EscribirLog(System.Reflection.MethodBase.GetCurrentMethod(), "Ha ocurrido un error en la clase Encriptacion metodo, Cifrado" , ex);
                return "";
            }
        }
    }
}