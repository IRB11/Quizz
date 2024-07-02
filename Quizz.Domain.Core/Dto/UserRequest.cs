namespace Quizz.Domain.Core.Dto
{
    public class UserRequest
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public RoleRequest Role { get; set; }
        public string Token { get; set; }
    }
}
