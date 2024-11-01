using Microsoft.EntityFrameworkCore;
using UT2024P4LP4.Web.Data;
using UT2024P4LP4.Web.Data.Dtos;
using UT2024P4LP4.Web.Data.Entities;

namespace UT2024P4LP4.Web.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IApplicationDbContext dbContext;

		public CategoryService(IApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<ResultList<CategoriaDto>> Get()
		{
			try
			{
				var r = await dbContext.Categorias.Select(x => new CategoriaDto() { Id = x.Id, Descripcion = x.Descripcion }).ToListAsync();

				return ResultList<CategoriaDto>.Success(r);

			}
			catch (Exception e)
			{
				return ResultList<CategoriaDto>.Failure($"☠️ Error: {e.Message}");
			}
		}

		public async Task<Result> Create(CategoriaRequest categoria)
		{
			try
			{
				var catageria = Categoria.Create(categoria.Descripcion);
				dbContext.Categorias.Add(catageria);
				await dbContext.SaveChangesAsync();
				return Result.Success("Categoria registrada con éxito");
			}
			catch (Exception e)
			{
				return Result.Failure($"☠️ Error: {e.Message}");

			}

		}

		public async Task<Result> Update(CategoriaRequest categoria)
		{
			try
			{
				var entity = await dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == categoria.Id);
				if (entity == null)
				{
					return Result.Failure($"☠️ Producto No encontrado: {categoria.Descripcion}");

				}
				if (entity.Update(categoria.Descripcion))
				{
					await dbContext.SaveChangesAsync();

					return Result.Success("Categoria Actualiza con éxito");
				}
				return Result.Success("🐫 No has realizado ningun cambio!");


			}
			catch (Exception e)
			{
				return Result.Failure($"☠️ Error: {e.Message}");

			}

		}

		public async Task<Result> Delete(int id)
		{
			try
			{
				var entity = await dbContext.Categorias.FirstOrDefaultAsync(x => x.Id == id);
				if (entity == null)
				{
					return Result.Failure($"☠️ Producto No encontrado: {id}");

				}
				dbContext.Categorias.Remove(entity);
				await dbContext.SaveChangesAsync();

				return Result.Success("Categoria Actualiza con éxito");
			}
			catch (Exception e)
			{
				return Result.Failure($"☠️ Error: {e.Message}");

			}

		}

	}
}
