namespace VentageRepositoryModel.Model
{
    public interface ICustomerModel
    {
        string Name { get; set; }
        CustomerAddressModel Address { get; set; }
        string? PhoneNumber { get; set; }
        string? Website { get; set; }
        List<ContactModel> Contacts { get; set; }
    }
}