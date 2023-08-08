using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Color
{
    public int Id { get; set; }

    public int Name { get; set; }

    public DateTime? Created { get; set; }

    public int? Updated { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}
