using System;
using System.Data;
using CDI.Comun;
using System.Collections.Generic;
using System.Net.Mail;

namespace CT.ADMIN.BL
{
    public class clsHerramientas
    {
        public void InsertaLog(string Mensaje, string Tipo)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Mensaje", Mensaje, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Tipo", Tipo, SqlDbType.VarChar, null));
                object dtCircuitos = objCon.ExecuteProc("", "", "sp_Inserta_Log", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaPaises()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                object dtPaises = objCon.ExecuteProc("", "", "pa_Consultar_Paises", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtPaises;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Ciudades Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaCiudades(string CodPais)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodPais", CodPais, SqlDbType.VarChar, null));
                object dtCiudades = objCon.ExecuteProc("", "", "pa_Consultar_Ciudades", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtCiudades;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Ciudades Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaTipoId()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                object dtPaises = objCon.ExecuteProc("", "", "pa_Consultar_TipoId", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtPaises;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Ciudades Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataTable CargaRangoEdad()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                object dtPaises = objCon.ExecuteProc("", "", "pa_Consulta_Rango_Edad", parametrosEntrada, ref parametrosSalida);
                return (DataTable)dtPaises;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consulta_Rango_Edad Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public void GuardaUsuarioGuia(byte[] Imagen)
        {
            try
            {
                clsConexion objCon = new clsConexion();
                List<InParameter> parametrosEntrada = new List<InParameter>();
                List<OutParameter> parametrosSalida = new List<OutParameter>();
                try
                {
                    parametrosEntrada.Add(new InParameter("@Imagen", Imagen, SqlDbType.VarBinary, null));
                    object dtCircuitos = objCon.ExecuteProc("", "", "BORRAR_INSERTA_IMAGEN", parametrosEntrada, ref parametrosSalida);
                }
                catch (Exception e)
                {
                    CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                    throw e;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardaImagen(string Imagen, string Orden, string Sitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Imagen", Imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Orden", Orden, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_sitio", Sitio, SqlDbType.VarChar, null));
                object dtCircuitos = objCon.ExecuteProc("", "", "pa_Insert_ImagenSitio", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public String Enviar_Correo(String Cod_Celular)
        {
            String nv = "", cc = "";
            try
            {
                nv = "";
                cc = "carlostapasco@gmail.com";
                MailMessage mail = new MailMessage("cdiamazonws@gmail.com", cc)
                {
                    From = new MailAddress(cc),
                    Subject = "Bienvenido a Circuitos Turisticos"
                };
                string Body = "Su codigo es " + nv + "";
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", //Or Your SMTP Server Address
                    Credentials = new System.Net.NetworkCredential("cdiamazonws@gmail.com", "Cdi.2017"),

                    EnableSsl = true
                };
                smtp.Send(mail);

                return "Correo enviado";//serializer.Serialize(rows);
            }
            catch (Exception e)
            {
                return "Sin Resultado " + e;
            }
        }

        public void ActualizaPassword(string Email, string Password)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Email", Email, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Password", Password, SqlDbType.VarChar, null));
                object dtCircuitos = objCon.ExecuteProc("", "", "pa_Actualiza_Password", parametrosEntrada, ref parametrosSalida);
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog("Get_Circuitos_Admin Falla excepción: " + ex.Message, CDITrace.Tipo.Error);
                throw ex;
            }
        }
    }
}
