using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Brand
{
    public int Id { get; set; }

    public int Name { get; set; }

    public int BrandStatusId { get; set; }

    public int Created { get; set; }

    public int Updated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
