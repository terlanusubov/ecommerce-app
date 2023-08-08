using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Avenue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RegionId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}
