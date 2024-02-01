using ExtremeClassified.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace ExtremeClassified.Domain.Identity
{
    /// <summary>
    /// Author: Abrar Ahmad
    /// User Entity in database
    /// </summary>
    [Table("Users")]
    public class User : EntityBase
    {
        [Key, MaxLength(36), Column("UserId")]
        public new string KeyField { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(150), Required, Column("UserName")]
        public new string NameField { get; set; }

        [MaxLength(250), Required]
        public string Email { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(150)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(250)]
        public string JobTitle { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [MaxLength(250)]
        public string Industry { get; set; }

        [MaxLength(250)]
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int CompanyId { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string SecurityStamp { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public bool AllowMultipleDevices { get; set; }
        public bool IsOnline { get; set; }
        public DateTimeOffset? LockoutDate { get; set; }
        public DateTimeOffset? LastLoginDate { get; set; }

        [MaxLength(250)]
        public string UserType { get; set; }

    }
}