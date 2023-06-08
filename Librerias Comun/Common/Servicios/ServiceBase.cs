using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDI.Common.Servicios
{
    public class ServiceBase : IServiceBase
    {
        private HttpClient _httpClient = new HttpClient();
        private readonly ApiClient _apiClient;

        public ServiceBase(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public void SetHeaders()
        {
            if (_apiClient.Headers == null) return;

            foreach (var header in _apiClient.Headers)
            {
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        public async Task<HttpResponseMessage> ExecuteGet()
        {
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecuteGet " + _apiClient.Url, Logs.Tipo.Log);
            _httpClient = new HttpClient();
            HttpResponseMessage responseHttp = null;

            using (_httpClient)
            {
                this.SetHeaders();
                responseHttp = await _httpClient.GetAsync(_apiClient.Url);
            }

            return responseHttp;
        }

        public async Task<HttpResponseMessage> ExecutePost(string objectJson)
        {
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePost " + _apiClient.Url, Logs.Tipo.Log);

            _httpClient = new HttpClient();

            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePost vtex JSON " + objectJson, Logs.Tipo.Log);
            HttpContent content = new StringContent(objectJson, Encoding.UTF8, _apiClient.ContentType);
            HttpResponseMessage responseHttp = null;

            using (_httpClient)
            {
                this.SetHeaders();
                responseHttp = await _httpClient.PostAsync(_apiClient.Url, content);
            }

            return responseHttp;
        }

        /*protected async Task<HttpResponseMessage> ExecutePatch(string objectJson)
        {
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePatch " + _apiClient.Url, Logs.Tipo.Log);
            _httpClient = new HttpClient();
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePatch vtex JSON " + objectJson, Logs.Tipo.Log);
            HttpContent content = new StringContent(objectJson, Encoding.UTF8, _apiClient.ContentType);
            HttpResponseMessage responseHttp = null;

            using (_httpClient)
            {
                this.SetHeaders();
                responseHttp = await _httpClient.PatchAsync(_apiClient.Url, content);
            }

            return responseHttp;
        }*/

        protected async Task<HttpResponseMessage> ExecutePut(string objectJson)
        {
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePut " + _apiClient.Url, Logs.Tipo.Log);
            _httpClient = new HttpClient();
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecutePut vtex JSON " + objectJson, Logs.Tipo.Log);

            HttpContent content = new StringContent(objectJson, Encoding.UTF8, _apiClient.ContentType);
            HttpResponseMessage responseHttp = null;

            using (_httpClient)
            {
                this.SetHeaders();
                responseHttp = await _httpClient.PutAsync(_apiClient.Url, content);
            }

            return responseHttp;
        }

        public async Task<HttpResponseMessage> ExecuteDelete()
        {
            //Logs.EscribirLog(new System.Diagnostics.StackFrame(true), "ExecuteDelete " + _apiClient.Url, Logs.Tipo.Log);
            _httpClient = new HttpClient();
            HttpResponseMessage responseHttp = null;

            using (_httpClient)
            {
                this.SetHeaders();
                responseHttp = await _httpClient.DeleteAsync(_apiClient.Url);
            }

            return responseHttp;
        }
    }
}
