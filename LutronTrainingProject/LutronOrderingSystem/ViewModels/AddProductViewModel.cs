using Caliburn.Micro;
using LutronOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.ViewModels
{
    public class AddProductViewModel : Screen
    {
        private ProductModel _product;
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                NotifyOfPropertyChange(() => Product);
            }
        }

        public AddProductViewModel()
        {
            Product = new ProductModel();
        }
        public async void AddProductAsync()
        {
            await TryCloseAsync(true);
        }
    }
}

