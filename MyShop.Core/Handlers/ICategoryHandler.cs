using MyShop.Core.Model;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Responses;

namespace MyShop.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category>> CreateAsync(EditorCategoryRequest model);
    Task<Response<Category>> UpdateAsync(EditorCategoryRequest model,int id);
    Task<Response<Category>> DeleteAsync(EditorCategoryRequest model);
    Task<Response<Category>> DeleteAsync(int id);
    Task<Response<Category>> GetByIdAsync(EditorCategoryRequest model);
    Task<Response<List<Category>>> GetAll();
}