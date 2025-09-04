using SQLite;

namespace ProductosApp.Models
{
    [Table("Producto")] // Definimos el nombre de la tabla en la base de datos
    public class Producto
    {
        [PrimaryKey, AutoIncrement] // Agregamos llave primaria y que sea autoincrementable
        public int Id { get; set; }
        [NotNull] // No se admiten valores nulos en la base de datos
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
