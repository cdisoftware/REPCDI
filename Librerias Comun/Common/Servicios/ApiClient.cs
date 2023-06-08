using System.Collections.Generic;

namespace CDI.Common.Servicios
{
    public class ApiClient
    {
        /// <summary>
        /// Set the URL with the vars "https://{AccountName}.{Environment}.com/api/"
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// AccountName for untipical format api url (See Pricing API > Prices And Fixed Prices)
        /// </summary>
        public string AccountName { get; set; }

        public Dictionary<string, string> Headers { get; set; }

        public string ContentType { get; set; } = "application/json";
    }
}