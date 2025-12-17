using System.ComponentModel.DataAnnotations;

namespace ArasvaAssignment.Application.Dtos.MemberDtos
{
    public class UpdateMemberDto
    {          
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [RegularExpression(
           @"^(?:\+91|0)?[6-9]\d{9}$",
            ErrorMessage = "Mobile number must be a valid 10-digit Indian mobile number"
        )]
        public string Mobile { get; set; }

        [RegularExpression(
           "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
           ErrorMessage = "Password must be at least 8 characters long and include uppercase, lowercase, number, and special character."
       )]
        public string Password { get; set; }
        public int IsActive { get; set; }
    }
}
