using ApiCoreHospitales.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebApplication1MvcCoreApiCliente.Services
{
    public class ServiceHospitales
    {
        private string apiUrl;

        //NECESITAMOS INDICAR EL TIPO DE DATOS QUE VAMOS A LEER

        private MediaTypeWithQualityHeaderValue header;


        public ServiceHospitales(IConfiguration conf)
        {
            this.apiUrl = conf.GetValue<string>("ApiUrls:ApiHospitales");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");

        }
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            //Se utiliza la clase HttpClient poaa las peticiones
            using (HttpClient client = new HttpClient())
            {
                string request = "api/hospitales";
                client.BaseAddress = new Uri(this.apiUrl);
                //Indicamos los datosm a leer
                // y limpiamos las cabeceras por normas
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //REalizamos la peticion y capturamos la respuesta
                HttpResponseMessage response = await client.GetAsync(request);
                //En la respuesta tenemos la clave para personalizar errores o leer los datos
                if (response.IsSuccessStatusCode == true)
                {
                    //Leemos los datos en json
                    string json = await response.Content.ReadAsStringAsync();
                    //Convertimos el json a objetos MEDIANTE NEWTON
                    List<Hospital> hospitales = JsonConvert.DeserializeObject<List<Hospital>>(json);
                    return hospitales;
                }
                else
                {
                    throw new Exception("Error en la respuesta de la API: " + (int)response.StatusCode);
                }
            }
        }
        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/Hospitales/" + idHospital;
                client.BaseAddress = new Uri(this.apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode == true)
                {
                    //Si las propiedades del model y del json se llaman igual no es necesario decorar con JSON property y tmp utilizar jsonConvert

                    Hospital hosp = await response.Content.ReadAsAsync<Hospital>();
                    return hosp;
                }
                else
                {
                    throw new Exception("Error en la respuesta de la API: " + (int)response.StatusCode);
                }

            }

        }

    }
}

