using Microsoft.AspNetCore.Identity;
using MTBS.Domain.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities.Auth
{
    public class User : IdentityUser
    {
        public required string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; } = Gender.Male;
        public string? Address { get; set; }
        public CustomerLevel CustomerLevel { get; set; } = CustomerLevel.None;

        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = "System";

        public DateTimeOffset? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
