namespace WebApi.Models.Users
{
  public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string GradeLevel { get; set; }
        public string Course { get; set; }
    }
}