using Persistence.Model;

namespace Domain
{
    public class Register : TblUser
    {
        public string? ConfirmPassword { get; set; }
    }
}
