using UT2024P4LP4.Web.Data.Entities;

namespace UT2024P4LP4.Web.Data
{
	public class ApplicationDbContextSeeder
	{
		public static void Run(ApplicationDbContext context)
		{
			if (!context.Categorias.Any())
			{
				var categorias = new List<Categoria>()
			{
				new(){ Descripcion = "No definida"},//1
                new(){ Descripcion = "Alimentos"}   //2
            };
				context.Categorias.AddRange(categorias);
				context.SaveChanges();
			}

		}
	}
}
