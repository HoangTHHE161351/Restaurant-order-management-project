using Microsoft.AspNetCore.Mvc;
using MTableWeb.Models;

namespace MTableWeb.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult QLTK()
        {
            using (var context = new MTableContext())
            {
                List<Information> list = context.Information.Where(x => x.Id != 1).ToList();
                ViewBag.list= list;
            }
            ViewBag.irr = HttpContext.Session.GetString("irr");
                return View();
        }
        public IActionResult Reset(int id)
        {
            using (var context = new MTableContext())
            {
                var acc = context.Accounts.FirstOrDefault(x => x.Id == id);
                var infor = context.Information.FirstOrDefault(x => x.Id == id);
                
                acc.Password = "123";
                context.Accounts.Update(acc);
                context.SaveChanges();
                HttpContext.Session.SetString("irr", $"Da cap nhat lai mat khau {infor.FullName} thanh cong");
            }
           
            return RedirectToAction("QLTK");
        }
        public IActionResult LockAcc(int id)
        {
            using (var context = new MTableContext())
            {
                var acc = context.Accounts.FirstOrDefault(x => x.Id == id);
                var infor = context.Information.FirstOrDefault(x => x.Id == id);
                if (acc.Status == true)
                {
                    acc.Status = false;
                    HttpContext.Session.SetString("irr", $"Da khoa tai khoan cua {infor.FullName} thanh cong");
                }
                else
                {
                    acc.Status= true;
                    HttpContext.Session.SetString("irr", $"Da mo khoa tai khoan cua {infor.FullName} thanh cong");
                }
                context.Accounts.Update(acc);
                context.SaveChanges();

            }
            return RedirectToAction("QLTK");
        }
        [HttpPost]
        public IActionResult Addnew()
        {
            using (var context = new MTableContext())
            {
                string user = HttpContext.Request.Form["acc"];
                Account acc = context.Accounts.FirstOrDefault(x => x.Username == user);
                if(acc!= null)
                {
                    HttpContext.Session.SetString("irr", $"Tao moi tai khoan that bai");
                }
                else
                {
                    Account a = new Account();
                    a.Username = user;
                    a.Password = "123";
                    a.Role = 1;
                    a.Status = true;
                    context.Accounts.Add(a);
                    context.SaveChanges();

                    Information i = new Information();
                    i.Id = a.Id;
                    i.FullName= HttpContext.Request.Form["ten"];
                    i.Email= HttpContext.Request.Form["email"];
                    i.Address= HttpContext.Request.Form["dc"];
                    i.Phone= HttpContext.Request.Form["sdt"];
                    context.Information.Add(i);
                    context.SaveChanges();
                    HttpContext.Session.SetString("irr", $"Tao moi tai khoan thanh cong");
                }
            }
                return RedirectToAction("QLTK");
        }

        public IActionResult QLOrder()
        {
            using(var context = new MTableContext())
            {
                List<Order> list = context.Orders.OrderByDescending(x => x.DateOrder).ThenBy(x => x.TableId).ToList();

              
                ViewBag.list = list;
                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };

                List<Table> listT = context.Tables.ToList();
                ViewBag.table = listT;

                var test = listT.FirstOrDefault();
                List<Order> listo = context.Orders.Where(x => x.TableId == test.Id && x.DateOrder.Value.Date == DateTime.Now.Date).ToList();

                foreach (Order item in listo)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }
                ViewBag.time = listtime;
                ViewBag.date = DateTime.Now.Date;
                ViewBag.time1 = DateTime.Now.ToString("yyyy-MM-dd");
                ViewBag.acc = context.Information.Where(x => x.Id != 1).ToList();
            }
            return View();
        }
        [HttpPost]
        public IActionResult TimKiemLich()
        {
            string text = "";
            try { text = HttpContext.Request.Form["btn"]; } catch { }
            DateTime time = DateTime.Now.Date;
            int ban = int.Parse(HttpContext.Request.Form["ban"]);
            try { time = DateTime.Parse(HttpContext.Request.Form["ngay"]); } catch { }
            
            if (text != null)
            {
                Order or = new Order();
                or.DateOrder = time;
                or.TableId = ban;
                or.TimeOrder = HttpContext.Request.Form["tg"];
                or.NoteUser = HttpContext.Request.Form["note"];
                or.Status = 1;
                or.UserOrder = int.Parse(HttpContext.Request.Form["acc"]);
                using (var context = new MTableContext())
                {
                    context.Orders.Add(or);
                    context.SaveChanges();
                }
            }

            using (var context = new MTableContext())
            {
                ViewBag.acc = context.Information.Where(x => x.Id != 1).ToList();

                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };

                List<Table> listT = context.Tables.ToList();
                ViewBag.table = listT;

                var test = listT.FirstOrDefault();
                List<Order> listo = context.Orders.Where(x => x.TableId == ban && x.DateOrder.Value.Date == time.Date).ToList();

                foreach (Order item in listo)
                {
                    string s = listtime.FirstOrDefault(x => x == item.TimeOrder);
                    if (s != null)
                    {
                        listtime.Remove(s);
                    }
                }


                ViewBag.time = listtime;
                ViewBag.time1 = time.ToString("yyyy-MM-dd");
                ViewBag.ban = ban;
                List<Order> listorder = context.Orders.OrderByDescending(x => x.DateOrder).ThenBy(x => x.TableId).ToList();
                foreach (Order item in listorder)
                {
                    item.Table = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                }
                ViewBag.order = listorder;
                ViewBag.count = listorder.Count;
            }

            return View();
        }

        public IActionResult ChiTiet(int id)
        {
            using (var context = new MTableContext())
            {
                Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                ViewBag.or = or;
            }
            return View();
        }
        public IActionResult Confirm()
        {
            int id = int.Parse(HttpContext.Request.Form["id"]);
            string type1 = HttpContext.Request.Form["btn1"];
            string type2 = HttpContext.Request.Form["btn2"];
            if(type1!= null)
            {
                using (var context = new MTableContext())
                {
                    Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                    or.Status = 2;
                    or.DateCf = DateTime.Now;
                    or.NoteEmployee = HttpContext.Request.Form["note"];
                    context.Orders.Update(or);
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new MTableContext())
                {
                    Order or = context.Orders.FirstOrDefault(x => x.Id == id);
                    or.Status = 3;
                    or.DateCf = DateTime.Now;
                    or.NoteEmployee = HttpContext.Request.Form["note"];
                    context.Orders.Update(or);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("QLOrder");
        }
    }
}
