﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseThucHanh.Models.ViewModel
{
    public class CartService
    {
        private readonly HttpSessionStateBase session;

        // Constructor to initialize session
        public CartService(HttpSessionStateBase session)
        {
            this.session = session;
        }

        // Get the cart from the session, or create a new one if it doesn't exist
        public Cart GetCart()
        {
            var cart = (Cart)session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                session["Cart"] = cart;
            }
            return cart;
        }

        // Clear the cart from the session
        public void ClearCart()
        {
            session["Cart"] = null;
        }
    }
}