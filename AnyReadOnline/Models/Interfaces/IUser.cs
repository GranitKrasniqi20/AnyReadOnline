namespace ANYREAD.Models
{
    public interface IUser
    {
        int AddressID { get; set; }
        string ConfirmEmail { get; set; }
        string ConfirmPassword { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        Gender Gender { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string PhoneNumber { get; set; }
        int UserID { get; set; }
        string UserName { get; set; }
    }
}