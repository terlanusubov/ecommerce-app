﻿using System;
using System.Collections.Generic;

namespace EcommerceApp.MVC.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
