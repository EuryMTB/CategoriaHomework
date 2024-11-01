using UT2024P4LP4.Web.Data.Entities;
using UT2024P4LP4.Web.Data.Migrations;

namespace UT2024P4LP4.Web.Data.Dtos;
public record ProductoDto(int Id, string Nombre, string? Descripcion, decimal Precio, Categoria Categoria)
{
    public ProductoRequest ToRequest()
    => new() { Id = this.Id, Nombre = this.Nombre,Descripcion = this.Descripcion, Categoria = new CategoriaDto(){ Descripcion = this.Categoria.Descripcion, Id= this.Categoria.Id   }, Precio = this.Precio };
};
public class ProductoRequest
{
    public int Id { get; set; } = 0;
    public string Nombre { get; set; } = "";
    public string? Descripcion { get; set; } = null;

    public decimal Precio { get; set; }

    public CategoriaDto Categoria { get; set; } = null!;
}
