﻿namespace WebGameShop.Models
{
    public class ShoppingcartItem
    {
        public int Id { get; set; }

        public Product? Product { get; set; }

        public int Qty { get; set; }

        public string? ShoppingCartId { get; set; }
    }
}
