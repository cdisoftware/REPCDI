
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CDI.Comun
{
    public class iCalendar
    {
        private string sAQuien;
        private string sLocalizacion;
        private string sAsunto;
        private string sMessDescrp;
        private DateTime dComienzo;
        private DateTime dFinal;
        private string sPrioridad;
        private System.IO.StreamWriter writer = null;

        public string prioridad
        {
            set
            {
                sPrioridad = value;
            }
        }

        public DateTime final
        {
            set
            {
                dFinal = value;
            }
        }

        public DateTime comienzo
        {
            set
            {
                dComienzo = value;
            }
        }

        public string mensaje
        {
            set
            {
                sMessDescrp = value;
            }
        }

        public string asunto
        {
            set
            {
                sAsunto = value;
            }
        }

        public string localizacion
        {
            set
            {
                sLocalizacion = value;
            }
        }

        public string to
        {
            set
            {
                sAQuien = value;
            }
        }


        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        string DateFormat
        {
            get
            {
                return "yyyyMMddTHHmmssZ"; // 20060215T092000Z
            }
        }


        public string ProcessRequest()
        {
            DateTime startDate = dComienzo;
            DateTime endDate = dFinal;
            string organizer = Herramienta.TraerConfiguracion("CorreoFrom");
            string organizerName = Herramienta.TraerConfiguracion("NombreFrom");
            string location = sLocalizacion;
            string summary = sAsunto;
            string description = sMessDescrp;
            string Priority = sPrioridad;
            string para = sAQuien;

            string filePath = string.Empty;
            string path = Herramienta.TraerConfiguracion("AdjRutaServidor");
            filePath = path + "/"+ summary.Replace("(","").Replace(")","").Replace(":","").Replace(" ","") + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".ics";
            writer = new System.IO.StreamWriter(filePath);

            string diaIni = startDate.ToString(DateFormat);
            string diaFin = endDate.ToString(DateFormat);

            writer.WriteLine("BEGIN:VCALENDAR");
            writer.WriteLine("\nVERSION:2.0");
            writer.WriteLine("\nMETHOD:REQUEST");
            writer.WriteLine("\nBEGIN:VTIMEZONE");
            writer.WriteLine("\nCALSCALE:GREGORIAN");
            writer.WriteLine("\nTZID: (GMT0000) (GMT00:00)");
            writer.WriteLine("\nBEGIN:STANDARD");
            writer.WriteLine("\nTZOFFSETFROM:0000");
            writer.WriteLine("\nTZOFFSETTO:0000");
            writer.WriteLine("\nEND:STANDARD");
            writer.WriteLine("\nEND:VTIMEZONE");
            writer.WriteLine("\nBEGIN:VEVENT");
            writer.WriteLine("\nATTENDEE;ROLE=REQ-PARTICIPANT;PARTSTAT=NEEDS-ACTION;CUTYPE=INDIVIDUAL;RSVP=TRUE;CN='" + para + "':MAILTO:" + para);
            writer.WriteLine("\nORGANIZER;CN='" + organizerName + "':MAILTO:" + organizer);
            //writer.WriteLine("\nDTSTART:" + diaIni);
            //writer.WriteLine("\nDTEND:" + diaFin);
            writer.WriteLine("\nDTSTART;TZID=US/Pacific:" + diaIni);
            writer.WriteLine("\nDTEND;TZID=US/Pacific:" + diaFin);                                
            writer.WriteLine("\nSEQUENCE:0");
            writer.WriteLine("\nLOCATION;LANGUAGE=es:" + location);
            writer.WriteLine("\nUID:" + DateTime.Now.ToString(DateFormat) + "@cdi.com.co");
            writer.WriteLine("\nDTSTAMP:" + DateTime.Now.ToString(DateFormat));
            writer.WriteLine("\nSUMMARY;LANGUAGE=es:" + summary);
            writer.WriteLine("\nDESCRIPTION;LANGUAGE=es:" + description);
            writer.WriteLine("\nSTATUS:CONFIRMED");
            writer.WriteLine("\nPRIORITY:" + Priority);
            writer.WriteLine("\nCREATED:" + DateTime.Now.ToString(DateFormat));
            writer.WriteLine("\nCLASS:PUBLIC");
            writer.WriteLine("\nEND:VEVENT");
            writer.WriteLine("\nEND:VCALENDAR");
            writer.Close();

            return filePath;
        }

        public void ProcessRequest2()
        {
            DateTime startDate = dComienzo;
            DateTime endDate = dFinal;
            string organizer = sAQuien; //"mostmuchomostcsharp@gmail.com";
            string location = sLocalizacion;//"My House";
            string summary = sAsunto;//"My Event";
            string description = sMessDescrp;//"Please come to\\nMy House";
            string Priority = sPrioridad;

            writer.WriteLine("BEGIN:VCALENDAR");
            writer.WriteLine("\nVERSION:2.0");
            writer.WriteLine("\nMETHOD:REQUEST");
            writer.WriteLine("\nBEGIN:VEVENT");
            writer.WriteLine("\nCALSCALE:GREGORIAN");
            writer.WriteLine("\nORGANIZER:MAILTO:" + organizer);
            writer.WriteLine("\nDTSTART:" + startDate.ToUniversalTime().ToString(DateFormat));
            writer.WriteLine("\nDTEND:" + endDate.ToUniversalTime().ToString(DateFormat));
            writer.WriteLine("\nLOCATION:" + location);
            writer.WriteLine("\nUID:" + DateTime.Now.ToUniversalTime().ToString(DateFormat) + "@mysite.com");
            writer.WriteLine("\nDTSTAMP:" + DateTime.Now.ToUniversalTime().ToString(DateFormat));
            writer.WriteLine("\nSUMMARY:" + summary);
            writer.WriteLine("\nDESCRIPTION:" + description);
            writer.WriteLine("\nPRIORITY:" + Priority);
            writer.WriteLine("\nCLASS:PUBLIC");
            writer.WriteLine("\nEND:VEVENT");
            writer.WriteLine("\nEND:VCALENDAR");
            writer.Close();
        }
    }
}
