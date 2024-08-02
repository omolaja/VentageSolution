namespace VentageRepositoryModel.Model
{
    public interface ICustomerAddressModel
    {
        string Address { get; set; }
        string PostCode { get; set; }
        string CountryId { get; set; }
        int CustomerId { get; set; }
    }
}