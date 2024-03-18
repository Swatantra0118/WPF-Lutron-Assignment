using Caliburn.Micro;
using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.Models;

namespace LutronOrderingSystem.ViewModels
{
    public class EditProductViewModel : Screen
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

        private readonly DatabaseManager _databaseManager;

        public EditProductViewModel(ProductModel product)
        {
            _databaseManager = new DatabaseManager();
            Product = product;
        }

        public void SaveChanges()
        {
            _databaseManager.UpdateProduct(Product);
            TryCloseAsync(true); 
        }

        public void Cancel()
        {
            TryCloseAsync(false); 
        }
    }
}
