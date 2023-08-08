using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Size
{
    public int Id { get; set; }

    public int Name { get; set; }

    public int? Created { get; set; }

    public int? Updated { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
