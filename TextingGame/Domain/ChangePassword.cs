using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ChangePassword
    {
        public string? EmailId { get; set; }
        [Required(ErrorMessage ="New password is required")]
        public string? NewPassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        public string? ConfirmPassword { get; set; }
    }
}
