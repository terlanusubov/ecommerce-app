using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public int UserRoleId { get; set; }

    public byte[] Password { get; set; } = null!;

    public int UserStatusId { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

    public virtual UserRole UserRole { get; set; } = null!;
}
