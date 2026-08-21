using SysproAssigment.Shared.Response;

namespace SysproTech.App.Interfaceses
{
    public interface IApiServices
    {
        Task<Result<T>> GetAsync<T>(string endpoint);
        Task<Result<T>> PostAsync<T>(string endpoint, object data);
        Task<Result<T>> PutAsync<T>(string endpoint, object data);
        Task<Result<T>> DeleteAsync<T>(string endpoint, Guid id);
    }
}
