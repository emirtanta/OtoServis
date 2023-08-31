using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class BrandsController : Controller
    {
        private readonly IService<Marka> _service;

        public BrandsController(IService<Marka> service)
        {
            _service = service;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var model = await _service.GetAllAsync();

            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Marka marka)
        {
            try
            {
                await _service.AddAsync(marka);
                await _service.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                ModelState.AddModelError("", "Hata oluştu!!");
            }

            return View(marka);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model=await _service.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id,Marka marka)
        {
            try
            {
                _service.Update(marka);

                await _service.SaveAsync();

                return RedirectToAction(nameof (Index));
            }
            catch 
            {

                ModelState.AddModelError("","Hata Oluştu!!!");
            }

            return View(marka);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var model=await _service.FindAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Delete(int id,Marka marka)
        {
            try
            {
                _service.Delete(marka);

                _service.Save();

                return RedirectToAction(nameof(Index));
            }
            catch 
            {

                return View();
            }
        }
    }
}
