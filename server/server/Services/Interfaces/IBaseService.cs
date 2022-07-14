using System.Collections.Generic;
using System.Threading.Tasks;
using server.Models.Responses;

namespace server.Services.Interfaces;

public interface IBaseService<T>
{
    Task<BaseResponse<T>> Create(T model);

    Task<BaseResponse<T>> GetById(int id);

    Task<BaseResponse<IEnumerable<T>>> GetAll();

    Task<BaseResponse<bool>> Delete(int id);
}