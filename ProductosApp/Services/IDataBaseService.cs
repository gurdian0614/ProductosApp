using ProductosApp.Models;

namespace ProductosApp.Services
{
    /// <summary>
    /// Interfaz donde estan los metodos para el uso con la base de datos
    /// </summary>
    public interface IDataBaseService
    {
        /// <summary>
        /// Obtener todo el listado de productos
        /// </summary>
        /// <returns>Listado de productos</returns>
        public Task<List<Producto>> GetAllProductos();

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="producto">Objeto con los registros a crear</param>
        /// <returns>Numero de productos creados</returns>
        public Task<int> CreateProducto(Producto producto);

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name="producto">Objeto con los registros a actualizar</param>
        /// <returns>Numero de productos actualizados</returns>
        public Task<int> UpdateProducto(Producto producto);

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="id">Id del producto a eliminar</param>
        /// <returns>Numero de productos eliminados</returns>
        public Task<int> DeleteProducto(int id);
    }
}
