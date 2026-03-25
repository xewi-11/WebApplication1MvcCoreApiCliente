using Microsoft.AspNetCore.Mvc;
using NugetApiModels.Models;
using WebApplication1MvcCoreApiCliente.Services;

namespace WebApplication1MvcCoreApiCliente.Controllers
{
    public class EmpleadosController : Controller
    {

        private ServiceEmpleados service;

        public EmpleadosController(ServiceEmpleados service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Empleado> empleados = await this.service.GetEmpleadosAsync();
            return View(empleados);
        }
        public async Task<IActionResult> Detalles(int emp_no)
        {
            Empleado emp = await this.service.FindEmpleadoById(emp_no);
            return View(emp);
        }
    }
}
