using eserProje.Data;
using eserProje.Helpers;
using eserProje.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace eserProje.Controllers
{
    public class HesapController : Controller
    {
        private readonly eserDbContext _context;
        public HesapController(eserDbContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris(string Email, string Password)
        {
            ClaimsIdentity myIdentity = null;
            bool identityIsValid = false;
            Userr selectedUser = await _context.Userrs.Include(k => k.Rolee).FirstOrDefaultAsync(m => m.Email == Email && m.Password == Password);

            if (selectedUser == null)
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                return View();
            }

            myIdentity = new ClaimsIdentity
                (new[]
                        {
                            new Claim(ClaimTypes.Sid,selectedUser.UserrID.ToString()),
                            new Claim(ClaimTypes.Email,selectedUser.Email),
                            new Claim(ClaimTypes.Role,selectedUser.Rolee.RoleeName),
                        }, CookieAuthenticationDefaults.AuthenticationScheme
                );

            identityIsValid = true;

            if (identityIsValid)
            {
                ClaimsPrincipal principals = new ClaimsPrincipal(myIdentity);
                Task loginn = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principals);

                if (selectedUser.RoleeID == 1)
                {
                    return Redirect("~/Hesap/EpostaGonderildiBilgilendirmesi");
                }
                else if (selectedUser.RoleeID == 2)
                {
                    return Redirect("~/Home/Index");
                }
                else if (selectedUser.RoleeID == 3)
                {
                    return Redirect("~/AdminHome/Index");
                }
                else
                {
                    return Redirect("~/Hesap/Giris");
                }
            }
            return View();

        }

        public IActionResult Kayit()
        {
            Userr x = new Userr();
            return View(x);
        }
        public IActionResult EpostaGonderildiBilgilendirmesi()
        {
            return View();
        }
        public IActionResult AktivasyonEpostasiTekrarGonder()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kayit([Bind("Email,Password,RePassword")] Userr userr)

        {   userr.RoleeID = 1;

            if (ModelState.IsValid)
            {
                Userr selectedUser = _context.Userrs.FirstOrDefault(a => a.Email == userr.Email);
                if (selectedUser!=null)
                {
                    ModelState.AddModelError("", "Böyle bir kullanıcı zaten var.");
                    return View(userr);
                }
                
                _context.Userrs.Add(userr);
                _context.SaveChanges();

                Emaill.SendMaill(userr.Email);

                return RedirectToAction("Giris","Hesap");
            }
            return View(userr);
        }
    }
}
