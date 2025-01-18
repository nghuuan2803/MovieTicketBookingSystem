using Microsoft.AspNetCore.Identity;
using MTBS.Domain.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(30)]
        public required string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        [MaxLength(15)]
        public string Sex { get; set; } = Gender.Male;

        [MaxLength(200)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? Avatar { get; set; }

        public CustomerLevel CustomerLevel { get; set; } = CustomerLevel.None;

        public DateTimeOffset CreatedAt { get; set; }
        [MaxLength(32)]
        public string CreatedBy { get; set; } = "System";

        public DateTimeOffset? UpdatedAt { get; set; }
        [MaxLength(32)]
        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<UserVoucher>? UserVouchers { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
    }
}
