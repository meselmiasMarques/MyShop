using MyShop.Core.Model;
using MyShop.Core.Requests;
using MyShop.Core.Requests.Categories;
using MyShop.Core.Requests.ProductRequest;
using MyShop.Core.Responses;

namespace MyShop.Core.Handlers;

public interface IProductHandler
{
    Task<Response<Product>> CreateAsync(EditorProductRequest model);
    Task<Response<Product>> UpdateAsync(EditorProductRequest model,int id);
    Task<Response<Product>> DeleteAsync(EditorProductRequest model);
    Task<Response<Product>> GetByIdAsync(EditorProductRequest model);
    Task<Response<List<Product>>> GetAll();
    Task<Response<List<Product>>> GetAllByCategory(int categoryId);
    Task<Response<Product>> UploadImage(UploadImageViewModel model,int id);
    
}