using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace sysOnlineCart.Models
{
    public class ProductViewModel
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        public DateTime manufacturingDate { get; set; }
        public DateTime expiryDate { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase FileContent { get; set; }
        public string ImageUrl { get; set; }
        public ProductCatergory catergory { get; set; }
        public string productDescription { get; set; }
        public float promotionPrice { get; set; }
        public float productPrice { get; set; }
        public int productQuantity { get; set; }
    }
}
 