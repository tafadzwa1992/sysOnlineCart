using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace sysOnlineCart.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string phone { get; set; }
       // public string email { get; set; }
    }

    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string productName { get; set; }
        [DataType(DataType.Date)]
        public DateTime manufacturingDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiryDate { get; set; }
        [Display(Name = "Choose Image to upload")]
        public string ImageUrl { get; set; }
       // public ProductCatergory catergory { get; set; }
        public string productDescription { get; set; }
        public float promotionPrice { get; set; }
        public float productPrice { get; set; }
        public int productQuantity { get; set; }
        [NotMapped]
        public HttpPostedFileBase FileContent { get; set; }
        public virtual List<ProductGallery> prodcutImages { get; set; }

    }

    public class ProductGallery
    {
        public int id { get; set; }
        public Product productId { get; set; }
        [NotMapped]
        public HttpPostedFileBase FileContents { get; set; }

        public string GalleryImageUrl { get; set; }
    }

    public class ProductCatergory
    {
        [Key]
        public int CatId { get; set; }
        public string CatergoryName {get;set;}
        public int prodcutId { get; set; }
    }

    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Cart(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
    public class OnlineCart
         {
               [Key]
             public string orderNumber { get; set; }
             public Client clientId { get; set; }
             public DateTime orderDate { get; set; }
            public ICollection<Product> productId { get; set; }
   // public string orderNumber { get; set; }
            public int Quantity { get; set; }
            public float totalPrice { get; set; }
        }

    public class ProductDespatch
        {
        [Key]
        public int despatchId { get; set; }
        public OnlineCart oerderdesNumber { get; set; }
        }

}