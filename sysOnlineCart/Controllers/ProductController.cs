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
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Product
        public ActionResult Index()
        {
            var model = context.Products.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<ProductCatergory> list = new List<ProductCatergory>();
            ViewBag.catergory = new SelectList(list, "CatId", "CatergoryName");
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Create(ProductViewModel model)
        {
            //try
            //{
                string fileName = Path.GetFileNameWithoutExtension(model.FileContent.FileName);
                string extension = Path.GetExtension(model.FileContent.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                model.ImageUrl = "~/Photo/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Photo/"), fileName);
                model.FileContent.SaveAs(fileName);

                //Product table
                Product prdct = new Product();
                prdct.productDescription = model.productDescription;
                prdct.productName = model.productName;
                prdct.productQuantity = model.productQuantity;
                prdct.promotionPrice = model.promotionPrice;
                prdct.expiryDate = model.expiryDate;
                prdct.ImageUrl = model.ImageUrl;
        
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    List<ProductGallery> galleryImages = new List<ProductGallery>();
                    var file = Request.Files[i];
                    if (file != null && file.ContentLength > 0)
                    {
                        var ImageName = Path.GetFileName(file.FileName);
                        var FinalName = DateTime.Now.ToString("yymmssfff") + ImageName;
                        ProductGallery fileDetail = new ProductGallery()
                        {
                            GalleryImageUrl = "~/Gallery/" + FinalName
                        };
                        galleryImages.Add(fileDetail);

                        var path = Path.Combine(Server.MapPath("~/Gallery/"), FinalName);
                        file.SaveAs(Server.MapPath("~/Gallery/" + FinalName));
                    }

                    prdct.prodcutImages = galleryImages;
                    context.Products.Add(prdct);
                    context.SaveChanges();


                    int prdctid = prdct.productId;

                    //ProductCatergory table
                    ProductCatergory crtgry = new ProductCatergory();
                    crtgry.prodcutId = prdctid;
                    crtgry.CatergoryName = model.CatergoryName;
                    context.ProductCatergorys.Add(crtgry);
                    context.SaveChanges();

                }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}



            return View();
        }
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}

//Save Gallery
// ProductGallery[] img = new ProductGallery[] { };

//foreach (ProductGallery file in model.prodcutImages)
//{
//     fileName = Path.GetFileNameWithoutExtension(model.FileContent.FileName);
//    extension = Path.GetExtension(model.FileContent.FileName);
//    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
//    file.GalleryImageUrl = "~/Gallery/" + fileName;
//    fileName = Path.Combine(Server.MapPath("~/Gallery/"), fileName);
//    file.FileContents.SaveAs(fileName);
//}