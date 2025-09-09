
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosApp.Models;
using ProductosApp.Services;
using System.Collections.ObjectModel;

namespace ProductosApp.ViewModels
{
    public partial class ProductoViewModel : ObservableObject
    {
        private DataBaseService _dbService;

        [ObservableProperty]
        private Producto _productoSeleccionado;

        [ObservableProperty]
        private ObservableCollection<Producto> _productoCollection;

        public ProductoViewModel()
        {
            _dbService = new DataBaseService();
            ProductoCollection = new ObservableCollection<Producto>();
            LoadProductosCommand.ExecuteAsync(null);
            ProductoSeleccionado = new Producto();
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
            try
            {
                if (ProductoSeleccionado.Nombre == "")
                {
                    Alerta("Escriba el nombre del producto");
                    return;
                }

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
            catch (Exception ex) 
            {
                Alerta($"Ha ocurrido un error: {ex.Message}");
            }

            
        }

        [RelayCommand]
        private void CrearProducto()
        {
            ProductoSeleccionado = new Producto();
        }

        [RelayCommand]
        private async Task EliminarProducto()
        {
            try
            {
                if (ProductoSeleccionado != null && ProductoSeleccionado.Id != 0)
                {
                    await _dbService.DeleteProducto(ProductoSeleccionado);
                    await LoadProductos();
                    ProductoSeleccionado = new Producto();
                }
            }
            catch (Exception ex)
            {
                Alerta($"Ha ocurrido un error: {ex.Message}");
            }
        }

        private void Alerta(string mensaje)
        {
            Application.Current!.MainPage!.DisplayAlert("", mensaje, "Aceptar");
        }
    }
}
