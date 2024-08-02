namespace VentageRepositoryModel.Model
{
    public interface IContactModel
    {
        int CustomerId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string EmailAddress { get; set; }
        string PhoneNumnber { get; set; }
    }
}