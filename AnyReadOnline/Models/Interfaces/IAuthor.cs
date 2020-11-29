namespace ANYREAD.Models
{
    public interface IAuthor
    {
        int AuthorID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
    }
}