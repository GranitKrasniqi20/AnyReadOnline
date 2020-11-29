using ANYREAD.Models.Interfaces;

namespace ANYREAD.Models
{
    public interface IAddress
    {
        string Address1 { get; set; }
        string Address2 { get; set; }
        int AddressID { get; set; }
        string City { get; set; }
        IClient Client { get; set; }
        int ClientID { get; set; }
        ICountry Country { get; set; }
        int CountryID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PostalCode { get; set; }
    }
}