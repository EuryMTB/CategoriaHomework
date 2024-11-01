using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UT2024P4LP4.Web.Data.Entities;
[Table("Productos")]
public class Producto
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Categoria Category { get; set; } = null!;

    #region Metodos
    public static Producto Create(string nombre, int Idcategoria, decimal price, string? descripcion = null)
        => new() { Nombre = nombre, Descripcion = descripcion, CategoryId = Idcategoria, Precio = price };
    public bool Update(string nombre, int idCategoria, decimal precio , string? descripcion = null)
    {
        var save = false;
        if (Nombre != nombre)
        {
            Nombre = nombre; save = true;
        }
        if (Descripcion != descripcion)
        {
            Descripcion = descripcion; save = true;
        }
        if (CategoryId != idCategoria)
        {
            CategoryId = idCategoria;
            save = true;
        }
        if (Precio != precio)
        {
            Precio = precio;
            save = true;

        }
        return save;
    }
    #endregion Metodos
}
