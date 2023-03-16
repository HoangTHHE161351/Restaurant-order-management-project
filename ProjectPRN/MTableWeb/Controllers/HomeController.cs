using Microsoft.AspNetCore.Mvc;
using MTableWeb.Models;

namespace MTableWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.err = HttpContext.Session.GetString("errdn");
            return View();
        }
        [HttpPost]
        public IActionResult Dangnhap()
        {
            string acc = HttpContext.Request.Form["acc"];
            string pass = HttpContext.Request.Form["pass"];
            using (var context = new MTableContext())
            {
                Account ac = context.Accounts.Where(x => x.Username == acc && x.Password == pass).FirstOrDefault();
                if (ac == null)
                {
                    HttpContext.Session.SetString("errdn", "Ban nhap sai thong tin");
                    return RedirectToAction("Index");
                }
                else
                {
                    if (ac.Status == false)
                    {
                        HttpContext.Session.SetString("errdn", "Tai khoan da bi khoa");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        if (ac.Role == 0)
                        {
                            return Redirect("/Admin/QLTK");
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("idacc", ac.Id);
                            return Redirect("/Cus/Thongtin");
                        }
                    }
                }

            }
           
        }
        public IActionResult Thoat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
