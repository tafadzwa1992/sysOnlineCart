using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sysOnlineCart.Models
{
    public class ClientsViewModel
    {
    }
    public class RegisterClientViewModel
    {
        [Key]
        public int Id { get; set; }
        public string clientId { get; set; }
        public string clientName { get; set; }
        public string phone { get; set; }
    }
}