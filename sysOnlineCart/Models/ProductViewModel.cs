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
        [DataType(DataType.Date)]
        public DateTime manufacturingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiryDate { get; set; }

        [NotMapped]
        public HttpPostedFileBase FileContent { get; set; } 
        [Display(Name = "Choose Image to upload")]
        public string ImageUrl { get; set; }

        public string CatergoryName { get; set; }

        public string productDescription { get; set; }
        public float promotionPrice { get; set; }
        public float productPrice { get; set; }
        public int productQuantity { get; set; }

        //public string GalleryImageUrl { get; set; }
        //public virtual List<ProductGallery> prodcutImages { get; set; }
    }
}
 