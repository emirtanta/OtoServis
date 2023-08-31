using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using OtoServis.Entities;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy ="AdminPolicy")]
    public class RolesController : Controller
    {
        private readonly IService<Rol> _serviceRol;

        public RolesController(IService<Rol> serviceRol)
        {
            _serviceRol = serviceRol;
        }

        public async Task<IActionResult> Index()
        {
            var model=await _serviceRol.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol rol)
        {
            try
            {
                _serviceRol.Add(rol);

                await _serviceRol.SaveAsync();

                return RedirectToAction(nameof(Index));

            }
            catch 
            {

                return View(); ;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model=await _serviceRol.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Rol rol)
        {
            try
            {
                _serviceRol.Update(rol);    

                await _serviceRol.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model=await _serviceRol.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Rol rol)
        {
            try
            {
                _serviceRol.Delete(rol);

                await _serviceRol.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View();
            }
        }
    }
}
