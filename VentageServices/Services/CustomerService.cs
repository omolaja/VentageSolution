using System;
using VentageRepository.Repository;
using VentageRepositoryModel.Model;

namespace VentageServices.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerModel _customerModel;
        private readonly IContactRepository _contactRepository;
        private readonly ResponseModel _responseModel;
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CustomerService(ICustomerRepository customerRepository, ICustomerModel customerModel,
            IContactRepository contactRepository, ResponseModel responseModel, ICustomerAddressRepository customerAddressRepository)
        {
            _customerRepository = customerRepository;
            _customerModel = customerModel;
            _contactRepository = contactRepository;
            _responseModel = responseModel;
            _customerAddressRepository = customerAddressRepository;
        }

        public async Task<ResponseModel?> PostCustomer(CustomerModel entity)
        {
            var response = await _customerRepository.CreateCustomer(entity);

            if (response > 0)
            {
                entity.Address.CustomerId = response;
                await _customerAddressRepository.CreateCustomerAddress(entity.Address);
                foreach (var contact in entity.Contacts)
                {
                    contact.CustomerId = response;
                    await _contactRepository.CreateContact(contact);
                }

                _responseModel.responseCode = "00";
                _responseModel.responseMessage = "Successfully Created";
            }
            else
            {
                _responseModel.responseCode = "01";
                _responseModel.responseMessage = "Something went wrong!!!";
            }

            return _responseModel;
        }


        public async Task<CustomerModel?> GetCustomerById(int Id)
        {
            var response = await _customerRepository.GetCustomerById(Id);

            if(response != null)
            {
                //Get the customer address detail
                var customerAddress = await _customerAddressRepository.GetCustomerAddressById(response.Id);
                response.Address = customerAddress;

                var contact = await _contactRepository.GetAllContactById(response.Id);
                response.Contacts = contact.ToList();
            }

            return response;
        }


        public async Task<List<CustomerModel>> GetAllCustomer()
        {
            var response = await _customerRepository.GetAllCustomer();

            return response.ToList();
        }
    }
}

