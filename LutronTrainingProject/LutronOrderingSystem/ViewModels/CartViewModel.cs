using Caliburn.Micro;
using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.Models;
using System.Linq;

namespace LutronOrderingSystem.ViewModels
{
    public class CartViewModel : Screen
    {
        private BindableCollection<CartItemViewModel> _cartItems;
        public BindableCollection<CartItemViewModel> CartItems
        {
            get { return _cartItems; }
            set
            {
                _cartItems = value;
                NotifyOfPropertyChange(() => CartItems);
            }
        }
        private readonly IWindowManager _windowManager;

        public CartViewModel(IWindowManager windowManager)
        {
            CartItems = new BindableCollection<CartItemViewModel>();
            _windowManager = windowManager;
        }
        public void AddToCart(ProductModel product)
        {
            // Check if the product is already in the cart
            var existingItem = CartItems.FirstOrDefault(item => item.Product.ModelId == product.ModelId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                CartItems.Add(new CartItemViewModel(product, 1));
            }
        }

        public void RemoveFromCart(CartItemViewModel cartItem)
        {
            CartItems.Remove(cartItem);
        }
        
        public void ShowCart()
        {
            _windowManager.ShowDialogAsync(new CartWindowViewModel(CartItems));
        }

        public void clear()
        {
            CartItems.Clear();
        }
    }

}