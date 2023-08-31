using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy ="AdminPolicy")]
    public class CustomersController : Controller
    {
        private readonly IService<Musteri> _serviceMusteri;
        private readonly IService<Arac> _serviceArac;

        public CustomersController(IService<Musteri> serviceMusteri, IService<Arac> serviceArac)
        {
            _serviceMusteri = serviceMusteri;
            _serviceArac = serviceArac;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _serviceMusteri.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Musteri musteri)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    await _serviceMusteri.AddAsync(musteri);

                    await _serviceMusteri.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu!!");
                }
            }

            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            return View(musteri);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            var model=await _serviceMusteri.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceMusteri.Update(musteri);

                    await _serviceMusteri.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu!!");
                }
            }

            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            return View(musteri);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _serviceMusteri.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Musteri musteri)
        {
            try
            {
                _serviceMusteri.Delete(musteri);

                await _serviceMusteri.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View(); ;
            }
        }
    }
}
