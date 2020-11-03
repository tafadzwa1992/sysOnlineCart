using sysOnlineCart.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sysOnlineCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(Product model, HttpPostedFileBase FileContent, HttpPostedFileBase[] FileContent2)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            //Save Main Image
            string fileName = Path.GetFileNameWithoutExtension(FileContent.FileName);
            string extension = Path.GetExtension(FileContent.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            model.ImageUrl = "~/Photo/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Photo/"), fileName);
            FileContent.SaveAs(fileName);

            //Save Gallery
            foreach (var file in FileContent2)
            {
                if (file != null && file.ContentLength > 0)
                {
                    file.SaveAs(Path.Combine(Server.MapPath("/uploads"), Guid.NewGuid() + Path.GetExtension(file.FileName)));
                }
               // model.prodcutImages = "/uploads" + 
            }

            return View();
        }
    }
}