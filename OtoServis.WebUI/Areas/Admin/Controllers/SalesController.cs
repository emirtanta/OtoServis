using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Policy ="AdminPolicy")]
    public class SalesController : Controller
    {
        private readonly IService<Satis> _serviceSatis;
        private readonly IService<Arac> _serviceArac;
        private readonly IService<Musteri> _serviceMusteri;

        public SalesController(IService<Satis> serviceSatis, IService<Arac> serviceArac, IService<Musteri> serviceMusteri)
        {
            _serviceSatis = serviceSatis;
            _serviceArac = serviceArac;
            _serviceMusteri = serviceMusteri;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _serviceSatis.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Satis satis)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceSatis.AddAsync(satis);

                    await _serviceSatis.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu!!");
                }
            }

            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");

            return View(satis);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");

            var model=_serviceSatis.FindAsync(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Satis satis)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    _serviceSatis.Update(satis);

                    await _serviceSatis.SaveAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch 
                {

                    ModelState.AddModelError("","Hata Oluştu!!");
                }
            }

            ViewBag.AracId = new SelectList(await _serviceArac.GetAllAsync(), "Id", "Modeli");

            ViewBag.MusteriId = new SelectList(await _serviceMusteri.GetAllAsync(), "Id", "Adi");

            return View(satis);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model=await _serviceSatis.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,Satis satis)
        {
            try
            {
                _serviceSatis.Delete(satis);

                await _serviceSatis.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View();
            }
        }
    }
}
