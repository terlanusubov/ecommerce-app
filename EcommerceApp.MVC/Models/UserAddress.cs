using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class UserAddress
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Address { get; set; } = null!;

    public int AvenueId { get; set; }

    public int? Phone { get; set; }

    public bool IsMain { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Avenue Avenue { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
