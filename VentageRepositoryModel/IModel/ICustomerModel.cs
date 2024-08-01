namespace VentageRepositoryModel.Model
{
    public interface ICustomerModel
    {
        string Name { get; set; }
        CustomerAddress Address { get; set; }
        string Country { get; set; }
        string? PhoneNumber { get; set; }
        string? Website { get; set; }
        List<Contact> Contacts { get; set; }
    }
}