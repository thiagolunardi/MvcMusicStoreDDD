using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Application.Interfaces;
using MvcMusicStore.CrossCutting.InversionOfControl;
using MvcMusicStore.Domain.Entities;
using MvcMusicStore.Domain.Interfaces.Repository;
using Ninject;

namespace MvcMusicStore.Models
{
    public class ShoppingCart
    {
        private readonly ICartAppService _cartAppService;
        private readonly IOrderAppService _orderAppService;
        private readonly IOrderDetailAppService _orderDetailAppService;
        public ShoppingCart(ICartAppService cartAppService, IOrderDetailAppService orderDetailAppService, IOrderAppService orderAppService)
        {
            _cartAppService = cartAppService;
            _orderDetailAppService = orderDetailAppService;
            _orderAppService = orderAppService;
        }

        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var ioc = new IoC();

            var cartAppService = ioc.Kernel.Get<ICartAppService>();
            var orderDetailAppService = ioc.Kernel.Get<IOrderDetailAppService>();
            var orderAppService = ioc.Kernel.Get<IOrderAppService>();

            var cart = new ShoppingCart(cartAppService, orderDetailAppService, orderAppService);
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Album album)
        {
            // Get the matching cart and album instances
            var cartItem = _cartAppService.Find(
                c => c.CartId == ShoppingCartId &&
                     c.AlbumId == album.AlbumId).SingleOrDefault();

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new Cart
                {
                    AlbumId = album.AlbumId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };

                _cartAppService.Create(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.Count++;
            }
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _cartAppService.Find(
                cart => cart.CartId == ShoppingCartId &&
                        cart.RecordId == id).Single();
            
            if (cartItem == null) return 0;
            
            var itemCount = 0;
            if (cartItem.Count > 1)
            {
                cartItem.Count--;
                itemCount = cartItem.Count;
            }
            else
            {
                _cartAppService.Remove(cartItem);
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = _cartAppService.Find(cart => cart.CartId == ShoppingCartId);
            _cartAppService.Remove(cartItems);
        }

        public List<Cart> GetCartItems()
        {
            return _cartAppService.Find(cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            return _cartAppService.Find(cartItem => cartItem.CartId == ShoppingCartId).Count();
        }

        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            return _cartAppService
                .Find(cartItem => cartItem.CartId == ShoppingCartId)
                .Sum(cartItem => cartItem.Album.Price);
        }

        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();

            // Iterate over the items in the cart, adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    AlbumId = item.AlbumId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Album.Price,
                    Quantity = item.Count
                };

                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Album.Price);

                _orderDetailAppService.Create(orderDetail);
            }

            // Set the order's total to the orderTotal count
            order.Total = orderTotal;

            // Save the order
            _orderAppService.Update(order);

            // Empty the shopping cart
            EmptyCart();

            // Return the OrderId as the confirmation number
            return order.OrderId;
        }

        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] != null) 
                return context.Session[CartSessionKey].ToString();

            if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
            {
                context.Session[CartSessionKey] = context.User.Identity.Name;
            }
            else
            {
                // Generate a new random GUID using System.Guid class
                Guid tempCartId = Guid.NewGuid();

                // Send tempCartId back to client as a cookie
                context.Session[CartSessionKey] = tempCartId.ToString();
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = _cartAppService.Find(c => c.CartId == ShoppingCartId).ToList();

            foreach (var item in shoppingCart)
                item.CartId = userName;

            _cartAppService.Update(shoppingCart);
        }
    }
}