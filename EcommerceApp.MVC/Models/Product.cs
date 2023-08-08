using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class Product
{
    public int Id { get; set; }

    public string MainCode { get; set; } = null!;

    public bool IsMain { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public float Price { get; set; }

    public int? Discount { get; set; }

    public string ShortDesc { get; set; } = null!;

    public int BrandId { get; set; }

    public string ProductCode { get; set; } = null!;

    public bool HasStock { get; set; }

    public int StockCount { get; set; }

    public string Description { get; set; } = null!;

    public int ProductStatusId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    public virtual ICollection<ProductPhoto> ProductPhotos { get; set; } = new List<ProductPhoto>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
