using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sysOnlineCart.Models
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        private string strtacrt = "Cart";
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session[strtacrt] == null)
            {
                List<Cart> ccart = new List<Cart>()
                {
                    new Cart(db.Products.Find(id), 1)
                };
                Session[strtacrt] = ccart;
            }
            else
            {
                List<Cart> ccart = (List<Cart>)Session[strtacrt];
                int check = IsExistingCheck(id);
                if (check == -1)

                    ccart.Add(new Cart(db.Products.Find(id), 1));

                else

                    ccart[check].Quantity++; 
                

                ccart.Add(new Cart(db.Products.Find(id), 1));
                Session[strtacrt] = ccart;
            }
          
            return View("Index");
        }
        private int IsExistingCheck(int? id)
        {
            List<Cart> ccart = (List<Cart>)Session[strtacrt];
            
            for(int i=0; i < ccart.Count; i++)
            {
                if (ccart[i].Product.productId == id) return i;
            }
            return -1;
        }
    }
}