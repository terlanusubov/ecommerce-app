using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class ProductPhoto
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Image { get; set; } = null!;

    public bool IsMain { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Product Product { get; set; } = null!;
}
