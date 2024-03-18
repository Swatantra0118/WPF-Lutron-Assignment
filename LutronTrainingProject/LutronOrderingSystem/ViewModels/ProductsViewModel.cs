using Caliburn.Micro;
using LutronOrderingSystem.DataAccess;
using LutronOrderingSystem.Helpers;
using LutronOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static LutronOrderingSystem.Models.ProductModel;

namespace LutronOrderingSystem.ViewModels
{
    public class ProductsViewModel : Screen
    {
        private ObservableCollection<productViewModel> _products;
        public ObservableCollection<productViewModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(nameof(Products));
            }
        }

        private CartViewModel _cartViewModel;
        public CartViewModel CartViewModel
        {
            get { return _cartViewModel; }
            set
            {
                _cartViewModel = value;
                NotifyOfPropertyChange(() => CartViewModel);
            }
        }

        private readonly DatabaseManager databaseManager;
        public ObservableCollection<EnclosureModel> Enclosures { get; set; }
        public ObservableCollection<ControlStationModel> ControlStations { get; set; }


        public ICommand AddCommand { get;  set; }
        public ICommand EditCommand { get;  set; }
        public ICommand DeleteCommand { get;  set; }
        public ICommand ShowControlStationsCommand { get; private set; }
        public ICommand ShowEnclosuresCommand { get; private set; }
        public ICommand AddToCartCommand { get; private set; }
        public ICommand ShowCartCommand { get; private set; }


        public ProductsViewModel()
        {
            databaseManager = new DatabaseManager();
            Enclosures = new ObservableCollection<EnclosureModel>();
            LoadEnclosures();
            ControlStations = new ObservableCollection<ControlStationModel>();
            CartViewModel = new CartViewModel(new WindowManager());
            LoadControlStations();
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(AddProductAsync,CanShowWindow);
            EditCommand = new RelayCommand(EditProduct, CanShowWindow);
            DeleteCommand = new RelayCommand(DeleteProduct);

            ShowControlStationsCommand = new RelayCommand(ShowControlStations);
            ShowEnclosuresCommand = new RelayCommand(ShowEnclosures);
            AddToCartCommand = new RelayCommand(AddToCart);
            ShowCartCommand = new RelayCommand(ShowCart);

        }


        private void AddToCart(object obj)
        {
            if (obj is int modelId)
            {

                ProductModel productModel = databaseManager.GetProductById(modelId);
            
                CartViewModel.AddToCart(productModel); // Call AddToCart method of CartViewModel
                LoadControlStations();
                LoadEnclosures();

            }
        }

        private void ShowCart(object obj)
        {
            CartViewModel.ShowCart(); // Call ShowCart method of CartViewModel
            LoadControlStations();
            LoadEnclosures();

        }

        private void ShowControlStations(object obj)
        {
            IsControlStationsVisible = true;
            IsEnclosuresVisible = false;
        }

        private void ShowEnclosures(object obj)
        {
            IsControlStationsVisible = false;
            IsEnclosuresVisible = true;
        }

        private bool _isControlStationsVisible = true;
        public bool IsControlStationsVisible
        {
            get { return _isControlStationsVisible; }
            set
            {
                _isControlStationsVisible = value;
                NotifyOfPropertyChange(nameof(IsControlStationsVisible));
            }
        }

        private bool _isEnclosuresVisible;
        public bool IsEnclosuresVisible
        {
            get { return _isEnclosuresVisible; }
            set
            {
                _isEnclosuresVisible = value;
                NotifyOfPropertyChange(nameof(IsEnclosuresVisible));
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }
        private void LoadControlStations()
        {
            DataTable dataTable = databaseManager.GetProducts();
            ControlStations.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                // Check if NumberOfButtons is DBNull or not
                if (!Convert.IsDBNull(row["NumberOfButtons"]))
                {
                    ControlStationModel controlStation = new ControlStationModel(
                        Convert.ToInt32(row["ModelId"]),
                        row["ModelDisplayString"].ToString(),
                        row["Description"].ToString(),
                        Convert.ToInt32(row["NumberOfButtons"]),
                        Convert.ToInt32(row["Quantity"])
                    );
                    ControlStations.Add(controlStation);
                }
            }
        }
        private void LoadEnclosures()
        {
            DataTable dataTable = databaseManager.GetProducts();
            Enclosures.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Category"].ToString()=="Enclosure")
                {
                    EnclosureModel enclosure = new EnclosureModel(
                      Convert.ToInt32(row["ModelId"]),
                      row["ModelDisplayString"].ToString(),
                      row["Description"].ToString(),
                      row["MountType"].ToString(),
                      Convert.ToInt32(row["Quantity"])
                  );
                    Enclosures.Add(enclosure);
                }
            }
        }


        private void DeleteProduct(object obj)
        {

            if (obj is int modelId)
            {
                
                databaseManager.DeleteProduct(modelId);
                
                LoadControlStations();
                LoadEnclosures();

            }

        }

        private async void EditProduct(object obj)
        {
            if (obj != null)
            {
                productViewModel productViewModel = null;

                // Check if obj is a ControlStationModel or EnclosureModel
                if (obj is ControlStationModel controlStation)
                {
                    // Convert ControlStationModel to productViewModel
                    productViewModel = new productViewModel(new ProductModel
                    {
                        ModelId = controlStation.ModelId,
                        ModelDisplayString = controlStation.ModelDisplayString,
                        Description = controlStation.Description,
                        NumberOfButtons = controlStation.NumberOfButtons,
                        Quantity = controlStation.Quantity
                    });
                }
                else if (obj is EnclosureModel enclosure)
                {
                    // Convert EnclosureModel to productViewModel
                    productViewModel = new productViewModel(new ProductModel
                    {
                        ModelId = enclosure.ModelId,
                        ModelDisplayString = enclosure.ModelDisplayString,
                        Description = enclosure.Description,
                        Quantity = enclosure.Quantity,
                        MountType = (MountTypeEnum)Enum.Parse(typeof(MountTypeEnum), enclosure.MountType),
                        Category = ProductModel.ProductCategory.Enclosure 
                    });
                }

                if (productViewModel != null)
                {
                    EditProductViewModel editProductViewModel = new EditProductViewModel(productViewModel.Product);
                    WindowManager windowManager = new WindowManager();
                    bool? result = await windowManager.ShowDialogAsync(editProductViewModel);

                    if (result.HasValue && result.Value)
                    {
                        databaseManager.UpdateProduct(editProductViewModel.Product);

                        LoadControlStations();
                        LoadEnclosures();

                        NotifyOfPropertyChange(nameof(ControlStations));
                        NotifyOfPropertyChange(nameof(Enclosures));
                    }
                }
            }
        }
        private async void AddProductAsync(object obj)
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            WindowManager windowManager = new WindowManager();
            bool? result = await windowManager.ShowDialogAsync(addProductViewModel);

            if (result.HasValue && result.Value)
            {
                var newProduct = addProductViewModel.Product;

                try
                {
                    if (string.IsNullOrEmpty(newProduct.ModelDisplayString))
                    {
                        throw new Exception("Model Display String is a required field.");
                    }

                    else if (string.IsNullOrEmpty(newProduct.Description))
                    {
                        throw new Exception("Description is a required field.");
                    }

                    if (newProduct.Category == ProductModel.ProductCategory.ControlStation &&
                        (newProduct.NumberOfButtons == null || newProduct.NumberOfButtons <= 0 || string.IsNullOrEmpty(newProduct.NumberOfButtons.ToString())))
                    {
                        throw new Exception("Number of buttons must be an integer and greater than zero.");
                    }

                    else if (newProduct.Category == ProductModel.ProductCategory.Enclosure &&
                        (newProduct.MountType == null || string.IsNullOrEmpty(newProduct.MountType.ToString())))
                    {
                        throw new Exception("Mount type is required field.");
                    }

                    if (newProduct.Quantity == 0 || newProduct.Quantity <= 0 || !int.TryParse(newProduct.Quantity.ToString(), out _))
                    {
                        throw new Exception("Quantity must be an integer and greater than zero.");
                    }

                    databaseManager.AddProduct(newProduct);

                    LoadControlStations();
                    LoadEnclosures();

                    NotifyOfPropertyChange(nameof(ControlStations));
                    NotifyOfPropertyChange(nameof(Enclosures));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        public Array ProductCategoryValues => Enum.GetValues(typeof(ProductModel.ProductCategory));

        public Array MountTypeValues => Enum.GetValues(typeof(ProductModel.MountTypeEnum));




    }

}
