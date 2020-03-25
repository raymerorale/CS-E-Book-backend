namespace WebApi.Models.Users
{
  public class UpdateUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string GradeLevel { get; set; }
        public string Course { get; set; }
        public string Password { get; set; }
    }
}