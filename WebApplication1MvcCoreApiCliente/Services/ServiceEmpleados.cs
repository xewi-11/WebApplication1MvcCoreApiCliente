
using NugetApiModels.Models;
using System.Net.Http.Headers;
namespace WebApplication1MvcCoreApiCliente.Services
{
    public class ServiceEmpleados
    {
        private string apiUrl;

        //NECESITAMOS INDICAR EL TIPO DE DATOS QUE VAMOS A LEER

        private MediaTypeWithQualityHeaderValue header;

        public ServiceEmpleados(IConfiguration conf)
        {
            this.apiUrl = conf.GetValue<string>("ApiUrls:ApiEmpleados");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }
        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/empleados";
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Empleado>>();
                }
                else
                {
                    throw new Exception("Error en la api :" + (int)response.StatusCode);
                }

            }
        }
        public async Task<Empleado> FindEmpleadoById(int emp_no)
        {


            using (HttpClient client = new HttpClient())
            {
                string request = "/api/empleados/" + emp_no;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Empleado>();
                }
                else
                {
                    throw new Exception("Error en la api :" + (int)response.StatusCode);
                }


            }


        }
        public async Task<string> GetOficiosAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/empleados/oficios";
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<string>();
                }
                else
                {
                    throw new Exception("Error en la api :" + (int)response.StatusCode);
                }
            }
        }
    }
}
