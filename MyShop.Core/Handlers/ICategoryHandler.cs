using MyShop.Core.Model;
using MyShop.Core.Responses;

namespace MyShop.Core.Handlers;

public interface ICategoryHandler
{
    Task<Response<Category>> Create(Category category);
    Task<Response<Category>> Update(Category category,int id);
    Task<Response<Category>> Delete(int id);
    Task<Response<Category>> GetById(int id);
    Task<Response<List<Category>>> GetAll();
}