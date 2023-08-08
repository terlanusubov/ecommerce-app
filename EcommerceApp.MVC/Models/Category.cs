using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Category
{
    public int Id { get; set; }

    public int Name { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
