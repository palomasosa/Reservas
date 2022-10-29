using System.Text;
using System.Text.Json;
using System.Globalization;

namespace Reservas.Client.Servicios
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient cliente;

        public HttpService(HttpClient cliente)
        {
            this.cliente = cliente;
        }


        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var respuesta = await cliente.GetAsync(url);
            if (respuesta.IsSuccessStatusCode)
            {
                var response = await DeserealizarRespuesta<T>(respuesta);
                return new HttpRespuesta<T>(response, false, respuesta);
            }
            else
            {
                return new HttpRespuesta<T>(default, true, respuesta);
            }
        }

        public async Task<HttpRespuesta<object>> Post<T>(string url, T enviar)
        {
            try
            {
                var enviarJson = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
                var respuesta = await cliente.PostAsync(url, enviarContent);
                return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<HttpRespuesta<object>> Put<T>(string url, T enviar)
        {
            try
            {
                var enviarJson = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJson, Encoding.UTF8, "application/json");
                var respuesta = await cliente.PutAsync(url, enviarContent);
                return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<HttpRespuesta<object>> Delete(string url)
        {
            var respuesta = await cliente.DeleteAsync(url);
            return new HttpRespuesta<object>(null, !respuesta.IsSuccessStatusCode, respuesta);
        }

        private async Task<T> DeserealizarRespuesta<T>(HttpResponseMessage respuesta)
        {
            var respuestaString = await respuesta.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(respuestaString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
                );
        }

    }
}
