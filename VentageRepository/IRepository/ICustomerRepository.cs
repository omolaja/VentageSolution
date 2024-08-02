using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(CustomerModel entity);
        Task<int> DeleteCustomer(int id);
        Task<IEnumerable<CustomerModel>> GetAllCustomer();
        Task<CustomerAddressModel> GetCustomerById(int id);
        Task<int> UpdateCustomer(CustomerModel entity);
    }
}