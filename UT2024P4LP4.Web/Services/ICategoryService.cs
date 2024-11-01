using UT2024P4LP4.Web.Data.Dtos;

namespace UT2024P4LP4.Web.Services
{
	public interface ICategoryService
	{
		Task<Result> Create(CategoriaRequest categoria);
		Task<Result> Delete(int id);
		Task<ResultList<CategoriaDto>> Get();
		Task<Result> Update(CategoriaRequest categoria);
	}
}