using Microsoft.AspNetCore.Mvc;
using MTableWeb.Models;
using System.Collections.Generic;

namespace MTableWeb.Controllers
{
    public class CusController : Controller
    {
        public IActionResult Thongtin()
        {
            int? id = HttpContext.Session.GetInt32("idacc");
            using (var context = new MTableContext())
            {
                Account acc = context.Accounts.FirstOrDefault(x => x.Id == id);
                Information infor = context.Information.FirstOrDefault(x => x.Id == id);

                ViewBag.acc= acc;
                ViewBag.infor= infor;   
            }
            return View();
        }
        [HttpPost]
        public IActionResult Capnhat()
        {
            int? id = HttpContext.Session.GetInt32("idacc");
            using (var context = new MTableContext())
            {
                Account acc = context.Accounts.FirstOrDefault(x => x.Id == id);
                Information infor = context.Information.FirstOrDefault(x => x.Id == id);

                acc.Username = HttpContext.Request.Form["acc"];
                acc.Password = HttpContext.Request.Form["pass"];

                infor.FullName = HttpContext.Request.Form["ten"];
                infor.Email = HttpContext.Request.Form["mail"];
                infor.Address = HttpContext.Request.Form["address"];
                infor.Phone = HttpContext.Request.Form["phone"];
                context.Accounts.Update(acc);
                context.Information.Update(infor);
                context.SaveChanges();
            }
            return RedirectToAction("Thongtin");
        }
        public IActionResult Datban()
        {
            int? id = HttpContext.Session.GetInt32("idacc");
            using (var context = new MTableContext())
            {

                List<string> listtime = new List<string> { "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00" };
              
                List<Table> listT = context.Tables.ToList();
                ViewBag.table = listT;

                var test = listT.FirstOrDefault();
                List<Order> listo = context.Orders.Where(x=>x.TableId== test.Id && x.DateOrder.Value.Date== DateTime.Now.Date).ToList();

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

                List<Order> listorder = context.Orders.Where(x=>x.UserOrder== id).OrderByDescending(x=>x.DateOrder).ThenBy(x=>x.TableId).ToList();
                foreach(Order item in listorder)
                {
                    item.Table = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                }
                ViewBag.order= listorder;
                ViewBag.count = listorder.Count;
            }
                return View();
        }
        [HttpPost]
        public IActionResult TimKiemLich()
        {
            int? id = HttpContext.Session.GetInt32("idacc");
            string text = "";
            try { text = HttpContext.Request.Form["btn"]; } catch { }
            DateTime time = DateTime.Now.Date;
            int ban = int.Parse(HttpContext.Request.Form["ban"]);
            try { time = DateTime.Parse(HttpContext.Request.Form["ngay"]); } catch { }
            if (text!= null)
            {
                Order or = new Order();

                or.UserOrder = id;
                or.DateOrder = time;
                or.TableId = ban;
                or.TimeOrder = HttpContext.Request.Form["tg"];
                or.NoteUser = HttpContext.Request.Form["note"];
                or.Status = 1;


                using (var context = new MTableContext())
                {
                    context.Orders.Add(or);
                    context.SaveChanges();
                }
            }

            using (var context = new MTableContext())
            {

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
                List<Order> listorder = context.Orders.Where(x => x.UserOrder == id).OrderByDescending(x => x.DateOrder).ThenBy(x => x.TableId).ToList();
                foreach (Order item in listorder)
                {
                    item.Table = context.Tables.FirstOrDefault(x => x.Id == item.TableId);
                }
                ViewBag.order = listorder;
                ViewBag.count = listorder.Count;
            }

            return View();
        }

      

        public IActionResult DeleteOrder(int id)
        {
            using (var context = new MTableContext())
            {
                var Ord = context.Orders.FirstOrDefault(x => x.Id == id);
                context.Orders.Remove(Ord);
                context.SaveChanges();
            }
            return RedirectToAction("Datban");
        }
    }
}
