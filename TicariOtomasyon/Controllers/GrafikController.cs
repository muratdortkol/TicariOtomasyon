using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var GrafikCiz = new Chart(600, 600);
            GrafikCiz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Telefon", "Laptop" }, yValues: new[] { 85, 241, 78 }).Write();
            return File(GrafikCiz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();


        public ActionResult Index3()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yValue.Add(y.Stok));
            var grafik = new Chart(width:800,height:800)
                .AddTitle("Stoklar")
                .AddSeries(chartType:"pie", name:"Stok", xValue: xValue, yValues:yValue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> list = new List<Sinif1>();
            list.Add(new Sinif1()
            {
                UrunAd="Bilgisayar",
                Stok=110
            });
            list.Add(new Sinif1()
            {
                UrunAd="Telefon",
                Stok=55
                
            });
            list.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                Stok = 70

            });
            list.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                Stok = 88

            });
            list.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 187

            });
            return list;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new Sinif2
                {
                    Stk = x.Stok,
                    UrnAd = x.UrunAd
                }).ToList();
            }
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}