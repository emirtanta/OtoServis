using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities;
using OtoServis.Service.Abstract;
using System.Security.Claims;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<Kullanici> _serviceKullanici;
        private readonly IService<Rol> _serviceRol;

        public LoginController(IService<Kullanici> serviceKullanici, IService<Rol> serviceRol)
        {
            _serviceKullanici = serviceKullanici;
            _serviceRol = serviceRol;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email,string password)
        {
            try
            {
                var account = _serviceKullanici.Get(x => x.Email == email && x.Sifre == password && x.AktifMi == true);

                if (account == null) 
                {
                    TempData["Mesaj"] = "Giriş Başarısız";
                }

                else
                {
                    var rol=_serviceKullanici.Get(x=>x.Id==account.RolId);

                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,account.Adi)
                    };

                    if (rol is not null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Adi));
                    }

                    var userIdentity = new ClaimsIdentity(claims, "Login");

                    ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(principal);

                    return Redirect("/Admin");
                }
            }
            catch (Exception)
            {

                TempData["Mesaj"]="Hata Oluştu!!";
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/Admin/Login");
        }
    }
}
