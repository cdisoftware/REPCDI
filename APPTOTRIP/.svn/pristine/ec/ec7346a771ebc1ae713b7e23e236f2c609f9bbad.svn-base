using CDI.Comun;
using CT.ADMIN.BL;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.Runtime;
using System.Data.SqlClient;
using System.Timers;

namespace CT.ADMIN.WS
{
    public class Metodos
    {
        String[] lenguajes = { "de", "en", "es", "fr", "it", "ja", "pt", "ru", "tr" };
        String[] validacion = { "\\n", "0" };
        String cod_id = "";


        public DataSet pa_Actualizar_Usuario(string IdUsuario, string Nombres, string Apellidos, string TipoDocumento, string DocumentoUsuario, int Ciudad, string FechaNacimiento, string NumeroCertificado, string VigenciaCertificado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("IdUsuario", IdUsuario, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("Nombres", Nombres, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Apellidos", Apellidos, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("TipoDocumento", TipoDocumento, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("DocumentoUsuario", DocumentoUsuario, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("Ciudad", Ciudad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("FechaNacimiento", FechaNacimiento, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("NumeroCertificado", NumeroCertificado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("VigenciaCertificado", VigenciaCertificado, SqlDbType.VarChar, null));
                DataSet dt = objCon.ExecuteProcWS("", "", "pa_Actualizar_Usuario", parametrosEntrada, ref parametrosSalida);
                return dt;
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Actualizar_Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_Circuito(string CodIdioma, int fk_usuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_usuario", fk_usuario, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                /* CDITrace.EscribirLog("pa_consulta_circuito falla excepcion: " + e.Message, CDITrace.Tipo.Error);*/
                throw e;
            }

        }

        public DataSet pa_Consultar_Categorias(string CodIdioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_Categorias", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Categorias falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_Ciudades(string CodPais)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodPais", CodPais, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_Ciudades", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Ciudades falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_ImagenSitio(int IdSitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("IdSitio", IdSitio, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_ImagenSitio", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_ImagenSitio falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_Paises()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                //parametrosEntrada.Add(new InParameter("IdSitio", IdSitio, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_Paises", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Paises falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_Sitios(string CodIdioma, string IdCircuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("CodIdioma", CodIdioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("IdCircuito", IdCircuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_Sitios", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Sitios falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_TipoId()
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {

                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_TipoId", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_TipoId falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consultar_Usuario(int IdUsuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("IdUsuario", IdUsuario, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consultar_Usuario", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Usuario falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Delete_Circuito(int id_circuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", id_circuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Delete_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Delete_Circuito falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Delete_Imagenes(int id_imagen)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_imagen", id_imagen, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Delete_Imagenes", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Delete_Imagenes falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Delete_Sitio(int Id_Sitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Id_Sitio", Id_Sitio, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Delete_Sitio", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Delete_Sitio falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Circuito(string nombre, string contexto, String descripcion_corta, string descripcion, string recomendaciones, string equipamento, int fk_rango_edad, string tiempo_estimado, string codigo_idioma, int fk_categoria, int fk_ciudad, int fk_usuario, string imagen, string imagen_img, int valor, int otra_moneda)
        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            int id_circuito = 0;
            String lenguajecode = codigo_idioma;
            String descripcioncode = descripcion;
            String descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String contextocode = contexto;

            try
            {
                parametrosEntrada.Add(new InParameter("fk_categoria", fk_categoria, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_rango_edad", fk_rango_edad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_ciudad", fk_ciudad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_usuario", fk_usuario, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("tiempo_estimado", tiempo_estimado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("valor", valor, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("otra_moneda", otra_moneda, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Insert_Circuito", parametrosEntrada, ref parametrosSalida);

                foreach (DataTable table in data.Tables)
                {
                    if (table.TableName.Equals("Table"))
                    {
                        id_circuito = Convert.ToInt32(table.Rows[0][0].ToString());
                    }
                }

                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        pa_Insert_Circuito_Idioma(nombre, contexto, descripcion_corta, descripcion, equipamento, recomendaciones, codigo_idioma, id_circuito);
                    }
                    else
                    {
                        if (!descripcion.Equals(""))
                        {
                            descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (!descripcion_corta.Equals(""))
                        {
                            descripcion_cortacode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (!recomendaciones.Equals(""))
                        {
                            recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        }
                        if (!equipamento.Equals(""))
                        {
                            equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        }
                        if (!contexto.Equals(""))
                        {
                            contextocode = pa_Traducir(contexto, codigo_idioma, lenguajes[i]);
                        }

                        lenguajecode = lenguajes[i];

                        pa_Insert_Circuito_Idioma(nombre, contextocode, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, lenguajecode, id_circuito);
                    }
                }
                //metodosAdmin.Insert_Circuito(nombre,descripcion,recomendaciones,equipamento,"","",tiempo_estimado,codigo_idioma,1);
                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
        

        public string pa_Insert_Circuito_Idioma(string nombre, string contexto, string descripcion_corta, string descripcion, string equipamento, string recomendaciones, string codigo_idioma, int fk_circuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("nombre_circuito", nombre, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("contexto", contexto, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_corta_circuito", descripcion_corta, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_circuito", descripcion, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("equipamento", equipamento, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("recomendacion", recomendaciones, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                object dt = objCon.ExecuteProc("", "", "pa_Insert_Circuito_Idioma", parametrosEntrada, ref parametrosSalida);
                return "Registro";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Actualizar_Usuario Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Sitio(string latitud, string longitud, string direccion, string costo, string nombre, string descripcion_corta, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, string horario, string tiempo_estimado, string telefono_sitio, int fk_circuito, int orden)
        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            int id_sitio = 0;
            String lenguajecode = codigo_idioma;
            String nombrecode = nombre;
            String descripcioncode = descripcion;
            String descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String iracode = ira;
            String horariocode = horario;

            try
            {
                parametrosEntrada.Add(new InParameter("latitud", latitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("longitud", longitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("direccion", direccion, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("telefono", telefono_sitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("orden", orden, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("estado_web", 0, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("costo", costo, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Insert_Sitio", parametrosEntrada, ref parametrosSalida);

                foreach (DataTable table in data.Tables)
                {
                    if (table.TableName.Equals("Table"))
                    {
                        id_sitio = Convert.ToInt32(table.Rows[0][0].ToString());
                    }
                }

                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        pa_Insert_Sitio_Idioma(nombre, descripcion_corta, descripcion, equipamento, recomendaciones, ira, codigo_idioma, id_sitio, horario, tiempo_estimado);
                    }
                    else
                    {
                        if (!descripcion_corta.Equals(""))
                        {
                            descripcion_cortacode = pa_Traducir(descripcion_corta, codigo_idioma, lenguajes[i]);
                        }
                        if (!descripcion.Equals(""))
                        {
                            descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (!recomendaciones.Equals(""))
                        {
                            recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        }
                        if (!equipamento.Equals(""))
                        {
                            equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        }
                        if (!ira.Equals(""))
                        {
                            iracode = pa_Traducir(ira, codigo_idioma, lenguajes[i]);
                        }
                        if (!horario.Equals(""))
                        {
                            horariocode = pa_Traducir(horario, codigo_idioma, lenguajes[i]);
                        }
                        lenguajecode = lenguajes[i];

                        pa_Insert_Sitio_Idioma(nombre, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, iracode, lenguajecode, id_sitio, horariocode, tiempo_estimado);
                    }
                }
                //metodosAdmin.Insert_Sitio(latitud, longitud, direccion, costo, "Bogota", "Colombia", nombre, descripcion, equipamento, recomendaciones, tiempo_estimado, "", horario, codigo_idioma, telefono_sitio, ira, fk_circuito);
                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Sitio_Idioma(string nombre, string descripcion_corta, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, int fk_sitio, string horario, string tiempo_estimado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("nombre_sitio", nombre, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_corta_sitio", descripcion_corta, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_sitio", descripcion, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_web", "", SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("equipamento", equipamento, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("recomendaciones", recomendaciones, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("indicaciones", ira, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_sitio", fk_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("horario", horario, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("tiempo_estimado", tiempo_estimado, SqlDbType.NVarChar, null));
                object dt = objCon.ExecuteProc("", "", "pa_Insert_Sitio_Idioma", parametrosEntrada, ref parametrosSalida);
                return "Registro";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio_Idioma Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Insert_ImagenSitio(string imagen, string imagen_img, int orden, int fk_sitio)
        {

            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("orden", orden, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_sitio", fk_sitio, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Insert_ImagenSitio", parametrosEntrada, ref parametrosSalida);
                //metodosAdmin.Insert_Imagen_Sitio(imagen_url, fk_sitio, orden);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_ImagenSitio falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Inserta_Usuario(string nombres_usuario, string apellido_usuario, string tipo_documento, string documento_usuario,
            string correo_usuario, string fecha_nacimiento, int ciudad, string clave, string foto_cuenta, int perfil, string numero_certificado, string vigencia_certificado, string foto_certificado, int estado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("nombres_usuario", nombres_usuario, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("apellidos_usuario", apellido_usuario, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("tipo_documento", tipo_documento, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("documento_usuario", documento_usuario, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("correo_usuario", correo_usuario, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fecha_nacimiento", fecha_nacimiento, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("ciudad", ciudad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("clave", clave, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("foto_cuenta", foto_cuenta, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("perfil", perfil, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("numero_certificado", numero_certificado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("vigencia_certificado", vigencia_certificado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("foto_certificado", foto_certificado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("estado", estado, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Inserta_Usuario", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Inserta_Usuario falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Recuperar_Usuario(string Usuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("Usuario", Usuario, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Recuperar_Usuario", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Recuperar_Usuario falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Update_Circuito(int id_circuito, string nombre, string contexto, string descripcion_corta, string descripcion, string recomendaciones, string equipamento, int fk_rango_edad, string tiempo_estimado, string codigo_idioma, int fk_categoria, string imagen, string imagen_img, int valor, int otra_moneda)
        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            int fk_circuito = id_circuito;
            String lenguajecode = codigo_idioma;
            String descripcioncode = descripcion;
            String descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String contextocode = contexto;

            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", id_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_categoria", fk_categoria, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_rango_edad", fk_rango_edad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("tiempo_estimado", tiempo_estimado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("valor", valor, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("otra_moneda", otra_moneda, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Update_Circuito", parametrosEntrada, ref parametrosSalida);



                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        pa_Update_Circuito_Idioma(id_circuito, nombre, contexto, descripcion_corta, descripcion, equipamento, recomendaciones, codigo_idioma);
                    }
                    else
                    {
                        if (!descripcion_corta.Equals(""))
                        {
                            descripcion_cortacode = pa_Traducir(descripcion_corta, codigo_idioma, lenguajes[i]);
                        }
                        if (!descripcion.Equals(""))
                        {
                            descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (!recomendacionescode.Equals(""))
                        {
                            recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        }
                        if (!equipamentocode.Equals(""))
                        {
                            equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        }
                        if (!contexto.Equals(""))
                        {
                            contextocode = pa_Traducir(contexto, codigo_idioma, lenguajes[i]);
                        }

                        lenguajecode = lenguajes[i];

                        pa_Update_Circuito_Idioma(id_circuito, nombre, contextocode, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, lenguajecode);
                    }
                }

                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Update_Circuito_Idioma(int id_circuito, string nombre, string contexto, string descripcion_corta, string descripcion, string equipamento, string recomendaciones, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("id_circuito", id_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("nombre_circuito", nombre, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("contexto", contexto, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_corta_circuito", descripcion_corta, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_circuito", descripcion, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("equipamento", equipamento, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("recomendacion", recomendaciones, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                object dt = objCon.ExecuteProc("", "", "pa_Update_Circuito_Idioma", parametrosEntrada, ref parametrosSalida);
                return "Registro";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_Circuito_Idioma Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Update_ImagenSitio(string imagen, int orden, int fk_sitio)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("orden", orden, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_sitio", fk_sitio, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Update_ImagenSitio", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_ImagenSitio falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Update_Sitio(int id_sitio, string latitud, string longitud, string direccion, string costo, string nombre, string descripcion_corta, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, string horario, string tiempo_estimado, string telefono_sitio, int fk_circuito, int orden)
        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            String lenguajecode = codigo_idioma;
            String nombrecode = nombre;
            String descripcioncode = descripcion;
            string descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String iracode = ira;
            String horariocode = horario;

            try
            {
                parametrosEntrada.Add(new InParameter("id_sitio", id_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("latitud", latitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("longitud", longitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("direccion", direccion, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("telefono", telefono_sitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("orden", orden, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("costo", costo, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Update_Sitio", parametrosEntrada, ref parametrosSalida);



                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        pa_Update_Sitio_Idioma(nombre, descripcion_corta, descripcion, equipamento, recomendaciones, ira, codigo_idioma, id_sitio, horario, tiempo_estimado);
                    }
                    else
                    {
                        descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        descripcion_cortacode = pa_Traducir(descripcion_corta, codigo_idioma, lenguajes[i]);
                        recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        iracode = pa_Traducir(ira, codigo_idioma, lenguajes[i]);
                        horariocode = pa_Traducir(horario, codigo_idioma, lenguajes[i]);
                        lenguajecode = lenguajes[i];

                        pa_Update_Sitio_Idioma(nombre, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, iracode, lenguajecode, id_sitio, horariocode, tiempo_estimado);
                    }
                }

                return "Datos actualizados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Update_Sitio_Idioma(string nombre, string descripcion_corta, string descripcion, string equipamento,
            string recomendaciones, string ira, string codigo_idioma, int fk_sitio, string horario, string tiempo_estimado)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("nombre_sitio", nombre, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_corta_sitio", descripcion_corta, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("descripcion_sitio", descripcion, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("equipamento", equipamento, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("recomendacion", recomendaciones, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("indicaciones", ira, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_sitio", fk_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("horario", horario, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("tiempo_estimado", tiempo_estimado, SqlDbType.NVarChar, null));
                object dt = objCon.ExecuteProc("", "", "pa_Update_Sitio_Idioma", parametrosEntrada, ref parametrosSalida);
                return "Datos actualizados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_Sitio_Idioma Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }

        }

        public string pa_Send_Mail(string Correo, string Asunto, string Mensaje)
        {

            try
            {
                MailMessage mail = new MailMessage("cdiamazonws@gmail.com", Correo)
                {
                    From = new MailAddress(Correo),
                    Subject = Asunto
                };
                string Body = Mensaje;
                mail.Body = Body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", //Or Your SMTP Server Address
                    Credentials = new System.Net.NetworkCredential("cdiamazonws@gmail.com", "Cdi.2017"),

                    EnableSsl = true
                };
                smtp.Send(mail);
                return "Correo enviado";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("Send_Mail Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                return "Correo no enviado";
            }

        }

        public string pa_Traducir(String text, String Entrada, String Salida)
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

        // Creado por Juan Moreno, modificado by Jhonny G.E
        public string pa_Insert_Categoria(string nombre_categoria, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            int id_categoria = 0;
            String lenguajecode = codigo_idioma;
            String nombrecode = nombre_categoria;
            try
            {
                data = objCon.ExecuteProcWS("", "", "pa_Insert_Categoria", parametrosEntrada, ref parametrosSalida);

                foreach (DataTable table in data.Tables)
                {
                    if (table.TableName.Equals("Table"))
                    {
                        id_categoria = Convert.ToInt32(table.Rows[0][0].ToString());
                    }
                }

                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        pa_Insert_Categoria_Idioma(nombre_categoria, codigo_idioma, id_categoria);
                    }
                    else
                    {
                        if (!nombre_categoria.Equals(""))
                        {
                            nombrecode = pa_Traducir(nombre_categoria, codigo_idioma, lenguajes[i]);
                        }
                        lenguajecode = lenguajes[i];

                        pa_Insert_Categoria_Idioma(nombrecode, lenguajecode, id_categoria);
                    }
                }
                //metodosAdmin.Insert_Sitio(latitud, longitud, direccion, costo, "Bogota", "Colombia", nombre, descripcion, equipamento, recomendaciones, tiempo_estimado, "", horario, codigo_idioma, telefono_sitio, ira, fk_circuito);
                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Categoria_Idioma(string nombre_categoria, string codigo_idioma, int fk_categoria)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("nombre", nombre_categoria, SqlDbType.NVarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_categoria", fk_categoria, SqlDbType.Int, null));
                object dt = objCon.ExecuteProc("", "", "pa_Insert_Categoria_Idioma", parametrosEntrada, ref parametrosSalida);
                return "Registro";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio_Idioma Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }
        //-------------------------------------------------

        //creado por Juan Moreno

        public string pa_Validacion_Estado(int id_usuario)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            string nombres_usuario = "";
            string apellidos_usuario = "";
            string tipo_documento = "";
            string documento_usuario = "";
            string correo_usuario = "";
            int fk_ciudad = 0;
            try
            {
                parametrosEntrada.Add(new InParameter("id_usuario", id_usuario, SqlDbType.Int, null));
                data = objCon.ExecuteProcWS("", "", "pa_Validacion_Estado", parametrosEntrada, ref parametrosSalida);

                foreach (DataTable table in data.Tables)
                {
                    if (table.TableName.Equals("Table"))
                    {
                        nombres_usuario = table.Rows[0][1].ToString();
                        apellidos_usuario = table.Rows[0][2].ToString();
                        tipo_documento = table.Rows[0][3].ToString();
                        documento_usuario = table.Rows[0][4].ToString();
                        correo_usuario = table.Rows[0][5].ToString();
                        fk_ciudad = Convert.ToInt32(table.Rows[0][6].ToString());
                    }
                }


                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Tduracion(string tabla, string codigo_idioma, string texto)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            String lenguajecode = codigo_idioma;
            String textocode = texto;
            try
            {
                parametrosEntrada.Add(new InParameter("tabla", tabla, SqlDbType.VarChar, null));/*duracion*/
                parametrosEntrada.Add(new InParameter("valor", codigo_idioma, SqlDbType.VarChar, null));/*es*/
                parametrosEntrada.Add(new InParameter("texto", texto, SqlDbType.NVarChar, null));/*dias*/

                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        data = objCon.ExecuteProcWS("", "", "pa_Insert_Generica", parametrosEntrada, ref parametrosSalida);

                    }
                    else
                    {
                        if (!texto.Equals(""))
                        {
                            textocode = pa_Traducir(texto, codigo_idioma, lenguajes[i]);
                        }
                        lenguajecode = lenguajes[i];

                        pa_Insert_Tduracion_Idioma(tabla, lenguajecode, textocode);

                    }
                }

                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Insert_Tduracion_Idioma(string tabla, string codigo_idioma, string texto)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("tabla", tabla, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("valor", codigo_idioma, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("texto", texto, SqlDbType.NVarChar, null));
                object dt = objCon.ExecuteProc("", "", "pa_Insert_Generica", parametrosEntrada, ref parametrosSalida);
                return "Registro";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Sitio_Idioma Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_Generica(string tabla, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("tabla", tabla, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("codigo_idioma", codigo_idioma, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_Generica", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Categorias falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Consulta_Generica_Moneda(string tabla)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("tabla", tabla, SqlDbType.VarChar, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Consulta_Generica_Moneda", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Consultar_Categorias falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public DataSet pa_Update_Imagen_Circuito(string imagen, string imagen_img, int id_circuito)
        {
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            try
            {
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("id_circuito", id_circuito, SqlDbType.Int, null));
                DataSet a = objCon.ExecuteProcWS("", "", "pa_Update_Imagen_Circuito", parametrosEntrada, ref parametrosSalida);
                return a;

            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_Imagen_Circuito falla excepcion: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public string pa_Update_Circuito_2(int fk_categoria, int valor, int otra_moneda, int fk_rango_edad, int id_circuito, string nombre = null, string contexto = null, string descripcion_corta = null, string descripcion = null, string recomendaciones = null, string equipamento = null, string tiempo_estimado = null, string codigo_idioma = null, string imagen=null, string imagen_img = null)

        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            int fk_circuito = id_circuito;
            String lenguajecode = codigo_idioma;
            String descripcioncode = descripcion;
            String descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String contextocode = contexto;
            String contextoesp = contexto;
            String recomendacionesesp = recomendaciones;
            String descripcionesp = descripcion;
            String descripcion_cortaesp = descripcion_corta;
            String equipamentoesp = equipamento;

            try
            {

                parametrosEntrada.Add(new InParameter("id_circuito", id_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_categoria", fk_categoria, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("fk_rango_edad", fk_rango_edad, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("tiempo_estimado", tiempo_estimado, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen", imagen, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("imagen_img", imagen_img, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("valor", valor, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("otra_moneda", otra_moneda, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Update_Circuito", parametrosEntrada, ref parametrosSalida);



                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        if (equipamento.Equals("0"))
                        {
                            equipamentoesp = "Borrar";
                        }
                        if (descripcion_corta.Equals("0"))
                        {
                            descripcion_cortaesp = "Borrar";
                        }
                        if (descripcion.Equals("0"))
                        {
                            descripcionesp = "Borrar";
                        }
                        if (recomendaciones.Equals("0"))
                        {
                            recomendacionesesp = "Borrar";
                        }
                        if (contexto.Equals("0"))
                        {
                            contextoesp = "Borrar";
                        }

                        pa_Update_Circuito_Idioma(id_circuito, nombre, contextoesp, descripcion_cortaesp, descripcionesp, recomendacionesesp, recomendacionesesp, codigo_idioma);
                    }                    
                    else
                    {
                        if (equipamento.Equals("0"))
                        {
                            equipamentocode = "Borrar";
                        }
                        else
                        {
                            equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        }
                        if (descripcion_corta.Equals("0"))
                        {
                            descripcion_cortacode = "Borrar";
                        }
                        else
                        {
                            descripcion_cortacode = pa_Traducir(descripcion_corta, codigo_idioma, lenguajes[i]);
                        }
                        if (descripcion.Equals("0"))
                        {
                            descripcioncode = "Borrar";
                        }
                        else
                        {
                            descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (recomendaciones.Equals("0"))
                        {
                            recomendacionescode = "Borrar";
                        }
                        else
                        {
                            recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        }
                        if (contexto.Equals("0"))
                        {
                            contextocode = "Borrar";
                        }
                        else
                        {
                            contextocode = pa_Traducir(contexto, codigo_idioma, lenguajes[i]);
                        }

                        lenguajecode = lenguajes[i];

                        pa_Update_Circuito_Idioma(id_circuito, nombre, contextocode, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, lenguajecode);
                    }
                }

                return "Datos registrados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Insert_Circuito Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }


        }

        public string pa_Update_Sitio_2(int fk_circuito, int orden, int id_sitio, string latitud=null, string longitud=null, string direccion=null, string costo=null, string nombre=null, string descripcion_corta=null, string descripcion=null, string equipamento=null,
            string recomendaciones=null, string ira = null, string codigo_idioma = null, string horario = null, string tiempo_estimado = null, string telefono_sitio = null)
        {
            codigo_idioma = "es";
            clsConexion objCon = new clsConexion();
            List<InParameter> parametrosEntrada = new List<InParameter>();
            List<OutParameter> parametrosSalida = new List<OutParameter>();
            DataSet data = new DataSet();
            String lenguajecode = codigo_idioma;
            String nombrecode = nombre;
            String descripcioncode = descripcion;
            String descripcion_cortacode = descripcion_corta;
            String recomendacionescode = recomendaciones;
            String equipamentocode = equipamento;
            String iracode = ira;
            String horariocode = horario;
            String tiempo_estimado_code = tiempo_estimado;
            String descripcionesp = descripcion;
            String descripcion_cortaesp = descripcion_corta;
            String recomendacionesesp = recomendaciones;
            String equipamentoesp = equipamento;
            String iraesp = ira;
            String horarioesp = horario;
            String tiempo_estimado_esp = tiempo_estimado;

            try
            {
                parametrosEntrada.Add(new InParameter("id_sitio", id_sitio, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("latitud", latitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("longitud", longitud, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("direccion", direccion, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("telefono", telefono_sitio, SqlDbType.VarChar, null));
                parametrosEntrada.Add(new InParameter("fk_circuito", fk_circuito, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("orden", orden, SqlDbType.Int, null));
                parametrosEntrada.Add(new InParameter("costo", costo, SqlDbType.VarChar, null));
                data = objCon.ExecuteProcWS("", "", "pa_Update_Sitio", parametrosEntrada, ref parametrosSalida);



                for (int i = 0; i < lenguajes.Length; i++)
                {
                    if (codigo_idioma.Equals(lenguajes[i]))
                    {
                        if (descripcion.Equals("0"))
                        {
                            descripcionesp = "Borrar";
                        }                        
                        if (equipamento.Equals("0"))
                        {
                            equipamentoesp = "Borrar";
                        }
                        if (recomendaciones.Equals("0"))
                        {
                            recomendacionesesp = "Borrar";
                        }
                        if (ira.Equals("0"))
                        {
                            iraesp = "Borrar";
                        }
                        if (horario.Equals("0"))
                        {
                            horarioesp = "Borrar";
                        }
                        if (tiempo_estimado.Equals("0"))
                        {
                            tiempo_estimado_esp = "Borrar";
                        }
                        if (descripcion_corta.Equals("0"))
                        {
                            descripcion_cortaesp = "Borrar";
                        }
                        pa_Update_Sitio_Idioma(nombre, descripcion_cortaesp, descripcionesp, equipamentoesp, recomendacionesesp, iraesp, codigo_idioma, id_sitio, horarioesp, tiempo_estimado_esp);
                    }
                    else
                    {
                        if (descripcion.Equals("0"))
                        {
                            descripcioncode = "Borrar";
                        }
                        else
                        {
                            descripcioncode = pa_Traducir(descripcion, codigo_idioma, lenguajes[i]);
                        }
                        if (equipamento.Equals("0"))
                        {
                            equipamentocode = "Borrar";
                        }
                        else
                        {
                            equipamentocode = pa_Traducir(equipamento, codigo_idioma, lenguajes[i]);
                        }
                        if (recomendaciones.Equals("0"))
                        {
                            recomendacionescode = "Borrar";
                        }
                        else
                        {
                            recomendacionescode = pa_Traducir(recomendaciones, codigo_idioma, lenguajes[i]);
                        }
                        if (ira.Equals("0"))
                        {
                            iracode = "Borrar";
                        }
                        else
                        {
                            iracode = pa_Traducir(ira, codigo_idioma, lenguajes[i]);
                        }

                        if (horario.Equals("0"))
                        {
                            horariocode = "Borrar";
                        }
                        else
                        {
                            horariocode = pa_Traducir(horario, codigo_idioma, lenguajes[i]);
                        }
                        if (tiempo_estimado.Equals("0"))
                        {
                            tiempo_estimado_code = "Borrar";
                        }
                        else
                        {
                            tiempo_estimado_code = pa_Traducir(tiempo_estimado, codigo_idioma, lenguajes[i]);
                        }

                        if (descripcion_corta.Equals("0"))
                        {
                            descripcion_cortacode = "Borrar";
                        }
                        else
                        {
                            descripcion_cortacode = pa_Traducir(descripcion_corta, codigo_idioma, lenguajes[i]);
                        }                        

                        lenguajecode = lenguajes[i];

                        pa_Update_Sitio_Idioma(nombre, descripcion_cortacode, descripcioncode, equipamentocode, recomendacionescode, iracode, lenguajecode, id_sitio, horariocode, tiempo_estimado_code);
                        
                    }
                }

                return "Datos actualizados con exito";
            }
            catch (Exception e)
            {
                CDITrace.EscribirLog("pa_Update_Sitio Falla excepción: " + e.Message, CDITrace.Tipo.Error);
                throw e;
            }
        }

        public void SendEmail(string body, string destinatario)
        {
            MailMessage email = new MailMessage();
            //email.To.Add(new MailAddress("correo@dominio.com"));
            email.To.Add(new MailAddress("correo@dominio.com"));
            email.From = new MailAddress("correo@dominio.com");
            email.Subject = ("titulo") +" - ";
            email.Body = body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;
            String correo = Herramienta.TraerConfiguracion("EmailR");
            String password = Herramienta.TraerConfiguracion("PasswordR");
            String puerto = Herramienta.TraerConfiguracion("Port");            
            int Port;
            int.TryParse(puerto, out Port);            
            String PasswordDes = Encriptacion.Cifrado(Encriptacion.Operacion.Desencripta, password);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Herramienta.TraerConfiguracion("Host");
            smtp.UseDefaultCredentials = false;
            smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(correo, PasswordDes),
                EnableSsl = true
            };


            try
            {
                smtp.Send(email);
                email.Dispose();
                CDITrace.EscribirLog("Corre electrónico fue enviado satisfactoriamente.", CDITrace.Tipo.Log);                
            }
            catch (Exception ex)
            {
                CDITrace.EscribirLog("Error enviando correo electrónico: " + ex.Message, CDITrace.Tipo.Error);
                throw ex;
            }
        }
        /*Orden: 5*/
        public string GeneraStream(string tabla, string clave, string campo, string cadena, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            BasicAWSCredentials awsCreds = new BasicAWSCredentials("AKIA4D6MRNG4ER5VUQVT", "oVIFepsNOLDQnApfxn6XFhoChangdOBIgI/4K3E9");
            AmazonPollyClient cliente = new AmazonPollyClient(awsCreds, Amazon.RegionEndpoint.USEast1);
            String outputFileName = 
                "C:\\prueba2\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";                
                /*"C:\\inetpub\\wwwroot\\produccion_audios\\" + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";*/
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
                
            else if (tabla.Equals("sitio")){
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
        /*Actualiza reciente 18/09/2019, Orden: 2*/
        public string pa_Actualiza_General(string tabla, string clave, string campo, string valor, string codigo_idioma)
        {
            cod_id = codigo_idioma;
            string[] array_idioma= { "nombre_sitio", "nombre_circuito", "descripcion_sitio", "descripcion_circuito", "equipamento", "recomendacion", "descripcion_corta_sitio", "descripcion_corta_circuito", "contexto", "indicaciones", "horario", "tiempo_estimado"};
            int p = 0;
            int v = 0;
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            List<String> camposArray = new List<string>();
            List<String> valorArray = new List<string>();
            List<String> campo_idioma = new List<string>();
            List<String> valor_idioma = new List<string>();
            do
            {
                p = campo.IndexOf("|");
                v = valor.IndexOf("|");

                if (p != -1)
                {
                    camposArray.Add(campo.Substring(0, p));
                    valorArray.Add(valor.Substring(0, v));

                    for (int x = 0; x < array_idioma.Length; x++)
                    {
                        if (campo.Substring(0, p).Equals(array_idioma[x]))
                        {
                            campo_idioma.Add(campo.Substring(0, p));
                            valor_idioma.Add(valor.Substring(0, v));
                            camposArray.Remove(camposArray[camposArray.Count - 1]);
                            valorArray.Remove(valorArray[valorArray.Count - 1]);
                        }
                    }

                    int length = campo.Length;
                    campo = campo.Substring(p + 1, length - (p + 1));

                    int length2 = valor.Length;
                    valor = valor.Substring(v + 1, length2 - (v + 1));
                }
                else
                {
                    camposArray.Add(campo);
                    valorArray.Add(valor);
                    for (int x = 0; x < array_idioma.Length; x++)
                    {
                        if (campo.Equals(array_idioma[x]))
                        {
                            campo_idioma.Add(campo);
                            valor_idioma.Add(valor);
                            camposArray.Remove(camposArray[camposArray.Count - 1]);
                            valorArray.Remove(valorArray[valorArray.Count - 1]);
                        }
                    }

                    valor = "";
                    campo = "";
                }
                
                

            }
            while (p != -1);

            
                       
            if (campo_idioma.Count > 0) {
                if (tabla.Equals("circuito") || tabla.Equals("sitio")) { 
                
                    for (int i=0;i<campo_idioma.Count; i++)
                    {
                      string cadena_update = "update " + tabla + "_idioma set ";                    
                    
                      for (int j = 0; j < lenguajes.Length; j++){ 
                            
                          if (codigo_idioma.Equals(lenguajes[j])){                                    
                             try
                             {
                               int g = objCon.QueryEscalar(cadena_update+campo_idioma[i]+"='"+valor_idioma[i]+ "' where fk_sitio="+ clave + " and codigo_idioma='"+codigo_idioma+"'");
                             }
                             catch (Exception e)
                             {
                               int g = objCon.QueryEscalar(cadena_update +campo_idioma[i] + "='" + valor_idioma[i] + "' where fk_circuito=" + clave + " and codigo_idioma='"+codigo_idioma+"'");
                             }

                          }
                          else
                          {
                                try
                                {
                                    int g = objCon.QueryEscalar(cadena_update + campo_idioma[i] + "='0' where fk_sitio=" + clave + " and codigo_idioma='" + lenguajes[j] + "'");
                                }
                                catch (Exception e)
                                {
                                    int g = objCon.QueryEscalar(cadena_update + campo_idioma[i] + "='0' where fk_circuito=" + clave + " and codigo_idioma='" + lenguajes[j] + "'");
                                }
                          }

                      }                                
                       
                    }   

                }

            }

            if (camposArray.Count > 0)
            {
                string cadena_update = "update " + tabla + " set";

                for (int i = 0; i < camposArray.Count; i++)
                {
                    if (i == camposArray.Count - 1)
                    {
                        cadena_update = cadena_update + " " + camposArray[i] + " = " + "'" + valorArray[i] + "'";
                    }
                    else
                    {
                        cadena_update = cadena_update + " " + camposArray[i] + " = " + "'" + valorArray[i] + "'" + ", ";
                    }
                    
                }

                cadena_update = cadena_update + " where id_" + tabla + " = " + "'" + clave + "'" + " ";
                int f = objCon.QueryEscalar(cadena_update);
                

            }

            return "Datos actualizados correctamente en "+tabla;
            /*update circuito set fk_categoria = 2 where id_circuito=clave*/
        }

        /*pa_Update_Traducir2 es Antiguo, se remplaza por el pa_Update_Traducir*/
        private void pa_Update_Traducir2(string tabla, List<string> campo_traducirArray, string valor_traducirArray, string clave, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            for (int l = 0; l < lenguajes.Length; l++) {
                if (!codigo_idioma.Equals(lenguajes[l]))
                {

                    string cadena_update = "update " + tabla + "_idioma set";

                    for (int i = 0; i < campo_traducirArray.Count; i++)
                    {
                        String t = pa_Traducir(valor_traducirArray, codigo_idioma, lenguajes[l]).Replace("'","''");
                        if (i == campo_traducirArray.Count - 1)
                        {
                            cadena_update = cadena_update + " " + campo_traducirArray[i] + " = " + " N'" +t + "'";
                        }
                        else
                        {
                            cadena_update = cadena_update + " " + campo_traducirArray[i] + " = " + " N'" +t + "'" + ", ";
                        }

                       /*GeneraStream(tabla, clave, campo_traducirArray[i],t, lenguajes[l]);*/
                    }

                    cadena_update = cadena_update + " where fk_" + tabla + " = " + "'" + clave + "'" + " and codigo_idioma= " + "'" + lenguajes[l] + "'" + " ";

                    int f = objCon.QueryEscalar(cadena_update);

                }
                else
                {
                    string cadena_update = "update " + tabla + "_idioma set";

                    for (int i = 0; i < campo_traducirArray.Count; i++)
                    {
                        if (i == campo_traducirArray.Count - 1)
                        {
                            cadena_update = cadena_update + " " + campo_traducirArray[i] + " = " + " N'" + valor_traducirArray.Replace("'", "''") + "'";
                        }
                        else
                        {
                            cadena_update = cadena_update + " " + campo_traducirArray[i] + " = " + " N'" + valor_traducirArray.Replace("'", "''") + "'" + ", ";
                        }

                      /*GeneraStream(tabla, clave, campo_traducirArray[i], valor_traducirArray[i], lenguajes[l]);*/
                    }

                    cadena_update = cadena_update + " where fk_" + tabla + " = " + "'" + clave + "'" + " and codigo_idioma= " + "'" + codigo_idioma + "'" + " ";

                    int f = objCon.QueryEscalar(cadena_update);
                }           

            }
        }
        /*Orden: 1*/
        public string pa_Insert_General(string tabla, string clave, string campo, string valor, string codigo_idioma)
        {
            
            int p = 0;
            int v = 0;
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            List<String> camposArray = new List<string>();
            List<String> valorArray = new List<string>();

            do
            {
                p = campo.IndexOf("|");
                if (p != -1)
                {
                    camposArray.Add(campo.Substring(0, p));
                    int length = campo.Length;
                    campo = campo.Substring(p + 1, length - (p + 1));

                }
                else
                {
                    camposArray.Add(campo);
                    campo = "";
                }
                v = valor.IndexOf("|");
                if (v != -1)
                {
                    valorArray.Add(valor.Substring(0, v));
                    int length2 = valor.Length;
                    valor = valor.Substring(v + 1, length2 - (v + 1));
                }
                else
                {
                    valorArray.Add(valor);
                    valor = "";
                }

            }
            while (p != -1);
          

            if (camposArray.Count > 0)
            {
                if (tabla.Equals("circuito"))
                {
                    int f = objCon.QueryEscalar("insert into circuito (fk_categoria,fk_rango_edad,fk_ciudad,fk_usuario,fecha_creacion,estado_circuito,valor,otra_moneda) values ('2','12','8142','"+clave+"',GETDATE(),'0','0','1')");
                    DataTable dataTable = objCon.Query("SELECT max(id_circuito) as id from circuito ");
                    string id_circuito =dataTable.Rows[0]["id"].ToString();
                    try
                    {  
                        for(int j = 0; j < camposArray.Count; j++) { 
                            for (int i=0; i < lenguajes.Length; i++) { 
                                /*Validar que el campo no venga vacio*/
                                if (valorArray[j] != ("")) { 
                                    if (codigo_idioma.Equals(lenguajes[i])) {
                                        try { 
                                        int g = objCon.QueryEscalar("insert into circuito_idioma (" + camposArray[j] + ",codigo_idioma,fk_circuito) values (" + "'" + valorArray[j] + "'" + "," + "'" + codigo_idioma + "'" + "," + id_circuito + ")");
                                        }
                                        catch(Exception e)
                                        {
                                        int h = objCon.QueryEscalar("update circuito_idioma set "+ camposArray[j] + "='"+ valorArray[j] + "' where fk_circuito='"+ id_circuito + "'and codigo_idioma='"+ codigo_idioma+"'");
                                        }
                                    }
                                    else
                                    {
                                        try{
                                        int g = objCon.QueryEscalar("insert into circuito_idioma (" + camposArray[j] + ",codigo_idioma,fk_circuito) values ('0','" + lenguajes[i] + "'," + id_circuito + ")");
                                        }
                                        catch(Exception e)
                                        {
                                        int h = objCon.QueryEscalar("update circuito_idioma set " + camposArray[j] + "= '0' where fk_circuito='" + id_circuito + "'and codigo_idioma='" + lenguajes[i]+"'");
                                        }

                                    }
                                }
                                /*GeneraStream(tabla,id_circuito, camposArray[0], valorArray[0],lenguajes[i]);*/
                            }
                        }
                        /*validar si dejar vacios o con valor '0' los campos a traducir*/
                        return id_circuito;
                    }

                    catch (Exception e) {
                        int g = objCon.QueryEscalar("delete from circuito_idioma where fk_circuito=(SELECT max(id_circuito) from circuito) delete from circuito where id_circuito=(SELECT max(id_circuito) from circuito)");

                        return "Favor validar los parametros y valores ingresados";
                    }


                }
                else if (tabla.Equals("sitio"))
                    {
                        int f = objCon.QueryEscalar("insert into sitio (fk_circuito,fecha_creacion) values ('"+ clave + "',GETDATE())");
                        DataTable dataTable = objCon.Query("SELECT max(id_sitio) as id from sitio ");
                        string id_sitio = dataTable.Rows[0]["id"].ToString();
                        try
                        {
                            for (int j = 0; j < camposArray.Count; j++)
                            {
                                for (int i = 0; i < lenguajes.Length; i++)
                                {
                                    if (valorArray[j] != ("")) { 
                                        if (codigo_idioma.Equals(lenguajes[i]))
                                        {
                                            try { 
                                            int g = objCon.QueryEscalar("insert into sitio_idioma (" + camposArray[j] + ",codigo_idioma,fk_sitio) values (" + "'" + valorArray[j] + "'" + "," + "'" + lenguajes[i] + "'" + "," + id_sitio + ")");
                                            }
                                            catch(Exception e) {
                                            int g = objCon.QueryEscalar("update sitio_idioma set "+ camposArray[j] + " = '"+ valorArray[j] + "' where fk_sitio = '"+ id_sitio + "'and codigo_idioma = '"+ codigo_idioma+"'");
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {                                    
                                            int g = objCon.QueryEscalar("insert into sitio_idioma (" + camposArray[j] + ",codigo_idioma,fk_sitio) values ('0', '" + lenguajes[i] + "'" + "," + id_sitio + ")");
                                            }
                                            catch(Exception e)
                                            {
                                            int g = objCon.QueryEscalar("update sitio_idioma set " + camposArray[j] + " = '0' where fk_sitio = '" + id_sitio + "'and codigo_idioma = '" + lenguajes[i] + "'");
                                            }
                                        }
                                    }   /*GeneraStream(tabla, id_sitio, camposArray[0], valorArray[0], lenguajes[i]);*/
                                }                                
                            }
                            return id_sitio;
                        }

                        catch (Exception s)
                        {
                            int h = objCon.QueryEscalar("delete from sitio_idioma where fk_sitio=(SELECT max(id_sitio) from sitio) delete from sitio where id_sitio=(SELECT max(id_sitio) from sitio)");

                        return "Favor validar los parametros y valores ingresados";
                        }
                        


                    }
                    /*Generar TRY-CATCH para validar comunicacion al funcionario describiendo los campos obligatorios de x tabla*/
                    else {
                    string cadena_insert = "insert into " + tabla + " (";
                    for (int i = 0; i < camposArray.Count; i++)
                    {
                        if (i == camposArray.Count - 1)
                        {
                            cadena_insert = cadena_insert + camposArray[i]+ ") ";
                        }
                        else
                        {
                            cadena_insert = cadena_insert + camposArray[i]+ ",";
                        }

                    }

                    cadena_insert = cadena_insert + "values (";

                    for (int l = 0; l < valorArray.Count; l++)
                    {
                        if (l == valorArray.Count - 1)
                        {
                            cadena_insert = cadena_insert + "'" + valorArray[l] + "'" + ") ";
                        }
                        else
                        {
                            cadena_insert = cadena_insert + "'" + valorArray[l] + "'" + ",";
                        }

                    }

                    int f = objCon.QueryEscalar(cadena_insert);
                }
                

            }

            return "Datos insertados correctamente en " + tabla;            
        }        

        public string generastream_programado(string tabla)
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            string[] campos_evaluar = {"nombre_circuito_au","descripcion_circuito_au", "equipamento_au", "recomendacion_au", "descripcion_corta_circuito_au", "contexto_au" };
            string[] campos_encontrar = { "nombre_circuito","descripcion_circuito", "equipamento", "recomendacion", "descripcion_corta_circuito", "contexto" };
            string[] campos_evaluar_sitio = { "nombre_sitio_au", "descripcion_sitio_au", "indicaciones_au", "descripcion_corta_sitio_au" };
            string[] campos_encontrar_sitio = { "nombre_sitio", "descripcion_sitio", "indicaciones", "descripcion_corta_sitio" };
            List<String> campo_traducirArray = new List<string>();
            List<String> codigo_traducirArray = new List<string>();
            try
            {
                if (tabla.Equals("circuito")) { 
                DataTable dataTable = objCon.Query("select id_circuito as id from circuito where id_circuito not in (select fk_circuito_au from circuito_idioma_audio) and estado_circuito in (1,3)");
                /*Valida los cirucitos*/
                    for (int i=0;i< dataTable.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_circuito = dataTable.Rows[i]["id"].ToString();
                            for(int j=0;j<campos_encontrar.Length; j++) {
                                 for (int k = 0; k < lenguajes.Length; k++) { 
                                    DataTable valor = objCon.Query("select " + campos_encontrar[j] + " as campo , codigo_idioma from circuito_idioma where fk_circuito=" + id_circuito);
                                    string valorc = valor.Rows[k]["campo"].ToString();
                                    string codigo = valor.Rows[k]["codigo_idioma"].ToString();
                                    campo_traducirArray.Add(valorc);
                                    codigo_traducirArray.Add(codigo);
                                    if (valorc.Equals("0"))
                                    {
                                    /*Traduce*/
                                    }      
                                    /*genera stream campo a campo*/
                                    /*GeneraStream(tabla, id_circuito, campos_encontrar[j], valorc, codigo);*/
                                }
                            }
                    }
                }
                else if (tabla.Equals("sitio"))
                {
                    DataTable dataTable = objCon.Query("select id_sitio as id from sitio a inner join circuito b on a.fk_circuito=b.id_circuito where b.estado_circuito=1 and a.id_sitio not in (select fk_sitio_au from sitio_idioma_audio)");
                    /*Valida los cirucitos*/
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_sitio = dataTable.Rows[i]["id"].ToString();
                        DataTable validar = objCon.Query("select " + campos_evaluar_sitio[i] + " from sitio_idioma_audio where fk_sitio_au=" + id_sitio);
                        if (validar.Rows.Count < 1)
                        {   /*for para validar los campos*/
                            /*if ()*/
                            for (int j = 0; j < campos_encontrar_sitio.Length; j++)
                            {
                                for (int k = 0; k < lenguajes.Length; k++)
                                {
                                    DataTable valor = objCon.Query("select " + campos_encontrar_sitio[j] + " as campo , codigo_idioma from sitio_idioma where fk_sitio=" + id_sitio);
                                    string valorc = valor.Rows[k]["campo"].ToString();
                                    string codigo = valor.Rows[k]["codigo_idioma"].ToString();
                                    /*genera stream campo a campo*/
                                    GeneraStream(tabla, id_sitio, campos_encontrar_sitio[j], valorc, codigo);
                                }
                            }
                        }
                        else
                        {
                            return "No se debe realizar ningun proceso";
                        }
                    }

                }

            }
            catch (Exception e)
            {
                return "Validar " + e;
            }

            return "Correcto";
        }

        /*Orden: 3*/
        public string validar_traduce()
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();            
            string[] campos_encontrar = { "nombre_circuito", "descripcion_circuito", "equipamento", "recomendacion", "descripcion_corta_circuito", "contexto", "tiempo_estimado" };            
            string[] campos_encontrar_sitio = { "nombre_sitio", "descripcion_sitio","equipamento", "recomendacion","indicaciones","horario","tiempo_estimado", "descripcion_corta_sitio" };
            List<String> campo_traducirArray = new List<string>();
            List<String> codigo_traducirArray = new List<string>();
            string cadena_original = "";
            string codigo_origen = "";
            try
            {
                /*Circuitos por traducir*/
                DataTable dataTable = objCon.Query("select id_circuito as id_circuito from circuito where estado_circuito in (1,3)");
                /*DataTable dataTable = objCon.Query("select id_circuito as id_circuito from circuito where id_circuito in (83)");*/
                string id_circuitoc = dataTable.Rows[0]["id_circuito"].ToString();
                if (id_circuitoc != ("")) { 
                    /*Valida los cirucitos*/
                    for (int i = 0; i < dataTable.Rows.Count; i++){
                        /*Por cada circuito hace esto*/
                        string id_circuito = dataTable.Rows[i]["id_circuito"].ToString();
                        for (int j = 0; j < campos_encontrar.Length; j++){                            
                            DataTable valor = objCon.Query("select "+ campos_encontrar[j]+ " as consulta, codigo_idioma from circuito_idioma where fk_circuito=" + id_circuito);
                            string valida = valor.Rows[0]["consulta"].ToString();
                            if (valida.Equals("0")) { 
                            /*for que recorra*/
                                for (int l = 0; l < valor.Rows.Count; l++)
                                {
                                    string valorc = valor.Rows[l]["consulta"].ToString();
                                    string codigoc = valor.Rows[l]["codigo_idioma"].ToString();                                    
                                        campo_traducirArray.Add(valorc);
                                        codigo_traducirArray.Add(codigoc);
                                        
                                        
                                    
                                }
                                for (int k = 0; k < campo_traducirArray.Count; k++)
                                {
                                    if ((campo_traducirArray[k] != ("0")) && (campo_traducirArray[k] != ("")))
                                    {
                                        cadena_original = campo_traducirArray[k];
                                        codigo_origen = codigo_traducirArray[k];
                                        campo_traducirArray.Remove(campo_traducirArray[k]);
                                        codigo_traducirArray.Remove(codigo_traducirArray[k]);
                                        /*cadena original*/
                                    }

                                }
                                if ((cadena_original!=("0")) && (cadena_original!=(""))) { 
                                    pa_Update_Traducir("circuito", campos_encontrar[j], cadena_original, id_circuito, codigo_origen);
                                    cadena_original = "";
                                    campo_traducirArray.Clear();
                                    codigo_traducirArray.Clear();
                                }
                            }
                        }
                        

                    }
                }

                DataTable sitio = objCon.Query("select id_sitio as id_sitio from sitio a inner join circuito b on a.fk_circuito=b.id_circuito where b.estado_circuito in (1)");
                string id_sitioc = sitio.Rows[0]["id_sitio"].ToString();
                if (id_sitioc != ("")) { 
                /*Valida los cirucitos*/
                    for (int i = 0; i < sitio.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_sitio = sitio.Rows[i]["id_sitio"].ToString();
                        for (int j = 0; j < campos_encontrar_sitio.Length; j++)
                        {
                            DataTable valor = objCon.Query("select " + campos_encontrar_sitio[j] + " as consulta, codigo_idioma from sitio_idioma where fk_sitio=" + id_sitio);
                            string valida = valor.Rows[0]["consulta"].ToString();
                            if (valida.Equals("0"))
                            {
                                /*for que recorra*/
                                for (int l = 0; l < valor.Rows.Count; l++)
                                {
                                    string valorc = valor.Rows[l]["consulta"].ToString();
                                    string codigoc = valor.Rows[l]["codigo_idioma"].ToString();
                                    campo_traducirArray.Add(valorc);
                                    codigo_traducirArray.Add(codigoc);



                                }
                                for (int k = 0; k < campo_traducirArray.Count; k++)
                                {
                                    if ((campo_traducirArray[k] != ("0")) && (campo_traducirArray[k] != ("")))
                                    {
                                        cadena_original = campo_traducirArray[k];
                                        codigo_origen = codigo_traducirArray[k];
                                        campo_traducirArray.Remove(campo_traducirArray[k]);
                                        codigo_traducirArray.Remove(codigo_traducirArray[k]);
                                        /*cadena original*/
                                    }

                                }
                                if ((cadena_original != ("0")) && (cadena_original != (""))) { 
                                    pa_Update_Traducir("sitio", campos_encontrar_sitio[j], cadena_original, id_sitio, codigo_origen);
                                    cadena_original = "";
                                    campo_traducirArray.Clear();
                                    codigo_traducirArray.Clear();
                                }
                            }
                        }


                    }
                }

                /*sitios preview*/
                DataTable sitiopr = objCon.Query("select id_sitio as id_sitio from sitio a inner join circuito b on a.fk_circuito=b.id_circuito where b.estado_circuito in (3)");
                string id_sitiopr = sitiopr.Rows[0]["id_sitio"].ToString();
                if (id_sitiopr != (""))
                {
                    /*Valida los cirucitos*/
                    for (int i = 0; i < sitiopr.Rows.Count; i++)
                    {
                        /*Por cada circuito hace esto*/
                        string id_sitioprv = sitiopr.Rows[i]["id_sitio"].ToString();
                        for (int j = 0; j < campos_encontrar_sitio.Length; j++)
                        {
                            DataTable valor = objCon.Query("select " + campos_encontrar_sitio[j] + " as consulta, codigo_idioma from sitio_idioma where fk_sitio=" + id_sitioprv);
                            string valida = valor.Rows[0]["consulta"].ToString();
                            if (valida.Equals("0"))
                            {
                                /*for que recorra*/
                                for (int l = 0; l < valor.Rows.Count; l++)
                                {
                                    string valorc = valor.Rows[l]["consulta"].ToString();
                                    string codigoc = valor.Rows[l]["codigo_idioma"].ToString();
                                    campo_traducirArray.Add(valorc);
                                    codigo_traducirArray.Add(codigoc);



                                }
                                for (int k = 0; k < campo_traducirArray.Count; k++)
                                {
                                    /*validar que no vengan con valores nulos*/
                                    if ((campo_traducirArray[k] != ("0")) && (campo_traducirArray[k] != ("")))
                                    {
                                        cadena_original = campo_traducirArray[k];
                                        codigo_origen = codigo_traducirArray[k];
                                        campo_traducirArray.Remove(campo_traducirArray[k]);
                                        codigo_traducirArray.Remove(codigo_traducirArray[k]);
                                        /*cadena original*/
                                    }

                                }
                                if ((cadena_original != ("0")) && (cadena_original != (""))) { 
                                    pa_Update_Traducir("sitio", campos_encontrar_sitio[j], cadena_original, id_sitioprv, codigo_origen);
                                    cadena_original = "";
                                    campo_traducirArray.Clear();
                                    codigo_traducirArray.Clear();
                                }
                            }
                        }


                    }
                }

            }
            catch (Exception e)
            {
                return "Validar " + e;
            }

            return "Validadas las traducciones pendientes";
        }

        private void pa_Update_Traducir(string tabla, string campo_traducirArray, string valor_traducirArray, string clave, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            for (int l = 0; l < lenguajes.Length; l++)
            {
                if (!codigo_idioma.Equals(lenguajes[l]))
                {               
                    String t = pa_Traducir(valor_traducirArray, codigo_idioma, lenguajes[l]).Replace("'", "''");
                    string cadena_update = "update " + tabla + "_idioma set " + campo_traducirArray + "=N'" + t + "' where fk_" + tabla + "=" + clave + " and codigo_idioma='" + lenguajes[l] + "'";
                    int f = objCon.QueryEscalar(cadena_update);
                    try
                    {
                        string cadenai = "insert into " + tabla + "_idioma_audio (" + campo_traducirArray + "_au,fk_" + tabla + "_au,codigo_idioma_au) values ('0'," + clave + ",'" + lenguajes[l] + "')";
                        int r = objCon.QueryEscalar(cadenai);
                        
                    }
                    catch(Exception e)
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
        /*Orden: 4*/
        public string validar_stream()
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            string[] campos_evaluar = { "nombre_circuito_au", "descripcion_circuito_au", "descripcion_corta_circuito_au", "contexto_au" };
            string[] campos_encontrar = { "nombre_circuito", "descripcion_circuito", "descripcion_corta_circuito", "contexto" };
            string[] campos_encontrarS = {"nombre_sitio","descripcion_sitio","indicaciones","descripcion_corta_sitio"};
            string[] campos_evaluarS = {"nombre_sitio_au", "descripcion_sitio_au", "indicaciones_au", "descripcion_corta_sitio_au"};
            string cadena_original = "";
            string codigo_origen = "";
            try
            {                                   
                    for (int a = 0; a < campos_evaluar.Length; a++)
                    { 
                        for (int b = 0; b < lenguajes.Length; b++) { 
                            DataTable validar = objCon.Query("select "+ campos_evaluar[a]+ " as consulta, codigo_idioma_au, fk_circuito_au from circuito_idioma_audio where "+campos_evaluar[a]+"='0' and codigo_idioma_au='"+ lenguajes [b]+"'");
                            try { 
                                    string consulta = validar.Rows[0]["consulta"].ToString();
                                    string codigo = validar.Rows[0]["codigo_idioma_au"].ToString();
                                    string clave = validar.Rows[0]["fk_circuito_au"].ToString();
                                    if (consulta != ("")) { 
                                        if (consulta.Equals("0"))
                                        {
                                            DataTable extraccion = objCon.Query("select "+ campos_encontrar[a] + " as consulta from circuito_idioma where fk_circuito="+ clave + " and codigo_idioma='"+ codigo + "'");
                                            string extraccionc = extraccion.Rows[0]["consulta"].ToString();
                                    /*generastream*/
                                            if (extraccionc.Length <= 3000)
                                            {
                                                GeneraStream("circuito", clave, campos_encontrar[a], extraccionc, codigo);
                                            }
                                            else
                                            {
                                                GeneraStreamLong("1", "circuito", clave, campos_encontrar[a], extraccionc.Substring(0, 3000), codigo);
                                                string prueba = extraccionc.Substring(3000);
                                                GeneraStreamLong("2", "circuito", clave, campos_encontrar[a], extraccionc.Substring(3000), codigo);
                                            }
                                        }
                                    }
                            }
                            catch(Exception e)
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
                                    if (extraccionc.Length<=3000) {
                                        GeneraStream("sitio", clave, campos_encontrarS[a], extraccionc, codigo);
                                    }
                                    else
                                    {
                                        GeneraStreamLong("1","sitio", clave, campos_encontrarS[a], extraccionc.Substring(0, 3000), codigo);
                                        string prueba = extraccionc.Substring(3000);
                                        GeneraStreamLong("2","sitio", clave, campos_encontrarS[a], extraccionc.Substring(3000), codigo);
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
                return "validar "+e;
            }

            return "Validado y generados los audios faltantes";
        }

        public string GeneraStreamLong(string orden, string tabla, string clave, string campo, string cadena, string codigo_idioma)
        {
            clsConexion objCon = new clsConexion();
            DataSet data = new DataSet();
            BasicAWSCredentials awsCreds = new BasicAWSCredentials("AKIA4D6MRNG4ER5VUQVT", "oVIFepsNOLDQnApfxn6XFhoChangdOBIgI/4K3E9");
            AmazonPollyClient cliente = new AmazonPollyClient(awsCreds, Amazon.RegionEndpoint.USEast1);
            String outputFileName =
                /*"C:\\inetpub\\wwwroot\\produccion_audios\\" + orden + tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";*/
            "C:\\prueba2\\" + orden+ tabla + "_" + clave + "_" + campo + "_" + codigo_idioma + ".mp3";
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
        /*BCKP REALIZADO*/

        /*METODO SOLICITADO PRO CARLOS TAPASCO*/
        public void EnvioCorreo(string Mail, string body)
        {
            MailMessage email = new MailMessage();
            //email.To.Add(new MailAddress("natica.det@gmail.com"));
            email.To.Add(new MailAddress(Mail));
            email.From = new MailAddress("apptotrip@gmail.com");
            email.Subject = "App To Trip - Descrube el mundo a tu manera";
            email.Body = body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "http://gmail.com";
            smtp.Port = 2525;
            //smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("info@aldeacocina.com.co", "CarBusHo0966");
            smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("apptotrip@gmail.com", "CALLE147$"),
                EnableSsl = true
            };

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }
        }
    }



}

        
