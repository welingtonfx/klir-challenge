﻿using Klir.TechChallenge.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Infra.ViewModels
{
    public class CartItem : ICartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public bool IsPromotion { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal Amount { get; set; }

        public void SetNoPromotion()
        {
            this.IsPromotion = false;
        }

        public void SetPromotion()
        {
            this.IsPromotion = true;
        }
    }
}
