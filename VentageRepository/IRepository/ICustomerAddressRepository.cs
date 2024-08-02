using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public interface ICustomerAddressRepository
    {
        Task<int> CreateCustomerAddress(CustomerAddressModel entity);
        Task<int> DeleteCustomerAddress(int id);
        Task<CustomerAddressModel> GetCustomerAddressById(int id);
        Task<IEnumerable<CustomerAddressModel>> GetAllCustomerAddresses();
        Task<int> UpdateCustomerAddress(CustomerAddressModel entity);
    }
}