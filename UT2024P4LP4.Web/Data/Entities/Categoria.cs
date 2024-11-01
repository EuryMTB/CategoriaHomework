using System.ComponentModel.DataAnnotations;

namespace UT2024P4LP4.Web.Data.Entities
{
	public class Categoria
	{
		[Key]
		public int Id { get; set; }

		public string Descripcion { get; set; } = null!;
		public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();


		#region Methods

		public static Categoria Create(string Description) => new() { Descripcion = Description };

		public bool Update(string Description)
		{
			if (this.Descripcion != Description)
			{
				this.Descripcion = Description;
				return true;
			}
			return false;
		}
		#endregion




	}
}
