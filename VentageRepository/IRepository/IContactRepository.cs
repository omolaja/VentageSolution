using VentageRepositoryModel.Model;

namespace VentageRepository.Repository
{
    public interface IContactRepository
    {
        Task<int> CreateContact(ContactModel entity);
        Task<int> DeleteCustomer(int id);
        Task<IEnumerable<ContactModel>> GetAllContact();
        Task<ContactModel> GetContactById(int id);
        Task<IEnumerable<ContactModel>> GetAllContactById(int Id);
        Task<int> UpdateContact(ContactModel entity);
    }
}