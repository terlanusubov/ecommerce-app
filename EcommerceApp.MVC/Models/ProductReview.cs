using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class ProductReview
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public string Review { get; set; } = null!;

    public DateTime ReviewDate { get; set; }

    public int Rate { get; set; }

    public int ProductReviewStatusId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
