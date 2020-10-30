using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sysOnlineCart.Models
{
    public class ProductContext
    {
    }


    public class Clients
    {
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }

    public class Products
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public DateTime manufacturingDate { get; set; }
        public DateTime expiryDate { get; set; }
        public Byte[] productImage { get; set; }
        public ProductCatergory catergory { get; set; }
        public string productDescription { get; set; }
        public float promotionPrice { get; set; }
        public float productPrice { get; set; }
        public int productQuantity { get; set; }
    }


    public class ProductCatergory
    {
        public int CatId { get; set; }
        public string CatergoryName {get;set;}
}

public class OnlineCart
{
    public int orderNumber { get; set; }
    public Clients clientId { get; set; }
    public DateTime orderDate { get; set; }
    public Products productId { get; set; }
   // public string orderNumber { get; set; }
    public int Quantity { get; set; }
    public float totalPrice { get; set; }
}

public class ProductDespatch
{
    public int despatchId { get; set; }
    public OnlineCart oerderdesNumber { get; set; }
}

}