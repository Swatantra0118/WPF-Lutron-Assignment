using Caliburn.Micro;
using LutronOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.ViewModels
{
    public class productViewModel : Screen, INotifyPropertyChanged
    {

        private ProductModel _product;
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                NotifyOfPropertyChange(nameof(Task));
            }
        }

        public productViewModel(ProductModel product)
        {
            Product = product;
        }

    }
}
