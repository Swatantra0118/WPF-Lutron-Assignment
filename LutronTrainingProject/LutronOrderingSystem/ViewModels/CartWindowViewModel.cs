using Caliburn.Micro;
using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.Helpers;
using LutronOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace LutronOrderingSystem.ViewModels
{
    public class CartWindowViewModel : Screen
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
        private readonly DatabaseManager databasemanager;
        public ICommand CheckoutCommand { get; private set; }
        public CartWindowViewModel(BindableCollection<CartItemViewModel> cartItems)
        {
            CartItems = cartItems;
            CheckoutCommand = new RelayCommand(Checkout);
            databasemanager = new DatabaseManager();
        }
        private void Checkout(object obj)
        {
            WindowManager _windowManager = new WindowManager();
            _windowManager.ShowDialogAsync(new CheckoutConfirmationViewModel());
            foreach (var c in CartItems)
                {
                    ProductModel p = databasemanager.GetProductById(c.Product.ModelId);
                    p.Quantity -= c.Quantity;
                    databasemanager.UpdateProduct(p);
                }
                CartItems.Clear();

            
        }
        //private void checkout(object obj)
        //{
        //    WindowManager windowManager = new WindowManager();
        //    windowManager.ShowDialogAsync(new CheckoutConfirmationViewModel());

        //}
    }
    public class CheckoutConfirmationViewModel : Screen
    {
        public void Confirm()
        {
            TryCloseAsync(true);
        }

        public void Cancel()
        {
            TryCloseAsync(false);
        }
    }
}