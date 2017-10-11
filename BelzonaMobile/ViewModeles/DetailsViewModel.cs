﻿using System;
using BelzonaMobile.Models;

namespace BelzonaMobile.ViewModels
{
    public class DetailsViewModel
    {
        public Product Product { get; set; }
        public DetailsViewModel(Product product)
        {
            Product = product;
        }
    }
}