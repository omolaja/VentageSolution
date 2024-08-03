using System.Threading.Tasks;
using VentageRepositoryModel.Model;

namespace VentageServices.Services
{
    public interface ICustomerService
    {
        Task<ResponseModel?> PostCustomer(CustomerModel entity);
        Task<CustomerModel?> GetCustomerById(int Id);
        Task<List<CustomerModel>> GetAllCustomer();
    }
}