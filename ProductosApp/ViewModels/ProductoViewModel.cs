
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosApp.Models;
using ProductosApp.Services;
using System.Collections.ObjectModel;

namespace ProductosApp.ViewModels
{
    public partial class ProductoViewModel : ObservableObject
    {
        private readonly IDataBaseService _dbService;

        [ObservableProperty]
        private Producto _productoSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Producto> _productoCollection;

        public ProductoViewModel(IDataBaseService dbService)
        {
            _dbService = dbService;
            ProductoCollection = new ObservableCollection<Producto>();
            LoadProductosCommand.ExecuteAsync(null);
        }

        [RelayCommand]
        private async Task LoadProductos()
        {
            var productos = await _dbService.GetAllProductos();
            ProductoCollection.Clear();

            foreach (var producto in productos) {
                ProductoCollection.Add(producto);
            }
        }

        [RelayCommand]
        private async Task GuardarProducto()
        {
            if (ProductoSeleccionado.Id == 0)
            {
                await _dbService.CreateProducto(ProductoSeleccionado);
            }
            else
            {
                await _dbService.UpdateProducto(ProductoSeleccionado);
            }

            await LoadProductos();
            ProductoSeleccionado = new Producto();
        }

        [RelayCommand]
        private void CrearProducto()
        {
            ProductoSeleccionado = new Producto();
        }

        [RelayCommand]
        private async Task EliminarProducto()
        {
            if (ProductoSeleccionado != null && ProductoSeleccionado.Id != 0)
            {
                await _dbService.DeleteProducto(ProductoSeleccionado.Id);
                await LoadProductos();
                ProductoSeleccionado= new Producto();
            }
        }
    }
}
