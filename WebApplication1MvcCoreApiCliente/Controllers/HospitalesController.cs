using ApiCoreHospitales.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1MvcCoreApiCliente.Services;

namespace WebApplication1MvcCoreApiCliente.Controllers
{
    public class HospitalesController : Controller
    {
        private ServiceHospitales service;
        public HospitalesController(ServiceHospitales service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
            return View();
        }
        public async Task<IActionResult> ClienteService()
        {
            List<Hospital> hospitales = await this.service.GetHospitalesAsync();
            return View(hospitales);
        }
        public async Task<IActionResult> FindHospital(int idHospital)
        {
            Hospital hosp = await this.service.FindHospitalAsync(idHospital);
            return View(hosp);
        }
    }
}
