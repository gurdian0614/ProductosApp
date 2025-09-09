
using ProductosApp.Models;
using SQLite;

namespace ProductosApp.Services
{
    public class DataBaseService : IDataBaseService
    {
        private SQLiteAsyncConnection _db;

        public DataBaseService() 
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Productos.db3");
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Producto>();
        }

        public async Task<int> CreateProducto(Producto producto)
        {
            return await _db.InsertAsync(producto);
        }

        public async Task<int> DeleteProducto(Producto producto)
        {
            return await _db.DeleteAsync(producto);
        }

        public async Task<List<Producto>> GetAllProductos()
        {
            return await _db.Table<Producto>().ToListAsync();
        }

        public async Task<int> UpdateProducto(Producto producto)
        {
            return await _db.UpdateAsync(producto);
        }
    }
}
