namespace ANYREAD.Models
{
    public interface IStaff:IUser
    {
        IRole Role { get; set; }
    }
}