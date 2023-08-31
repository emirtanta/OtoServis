using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Utils;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy ="AdminPolicy")]
    public class CarsController : Controller
    {
        private readonly ICarService _service;
        private readonly IService<Marka> _serviceMarka;

        public CarsController(ICarService service, IService<Marka> serviceMarka)
        {
            _service = service;
            _serviceMarka = serviceMarka;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _service.GetCustomCarList();

            return View(model);
        }

        public IActionResult Details() 
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Arac arac,IFormFile? Resim1,IFormFile? Resim2,IFormFile? Resim3)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "/Img/Cars/");
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim2, "/Img/Cars/");
                    arac.Resim1 = await FileHelper.FileLoaderAsync(Resim3, "/Img/Cars/");

                    await _service.AddAsync(arac);

                    await _service.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu!");
                }
            }

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            return View(arac);
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            var model=await _service.FindAsync(id);

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Arac arac,IFormFile? Resim1,IFormFile? Resim2,IFormFile? Resim3)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Resim1 is not null) 
                    {
                        arac.Resim1 = await FileHelper.FileLoaderAsync(Resim1, "Img/Cars/");
                    }

                    if (Resim2 is not null)
                    {
                        arac.Resim2 = await FileHelper.FileLoaderAsync(Resim2, "Img/Cars/");
                    }

                    if (Resim3 is not null)
                    {
                        arac.Resim3 = await FileHelper.FileLoaderAsync(Resim3, "Img/Cars/");
                    }

                    _service.Update(arac);

                    await _service.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu");
                }
            }

            ViewBag.MarkaId = new SelectList(await _serviceMarka.GetAllAsync(), "Id", "Adi");

            return View(arac);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model=await _service.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Arac arac)
        {
            try
            {
                _service.Delete(arac);

                await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View();
            }
        }
    }
}
