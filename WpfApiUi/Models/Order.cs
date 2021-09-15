using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApiUi.Models
{
    public class Order
    {   
        public string SenderCity { get; set; }
        public string SenderAddress { get; set; }
        public string RecipientCity { get; set; }    
        public string RecipientAddress { get; set; }
        public int Weight { get; set; }
        public DateTimeOffset Data { get; set; }
        public Guid Id { get; set; }
    }
}
