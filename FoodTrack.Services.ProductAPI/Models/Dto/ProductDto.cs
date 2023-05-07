﻿using System.ComponentModel.DataAnnotations;

namespace FoodTrack.Services.ProductAPI.Models.Dto
{
    public class ProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public String Description { get; set; }
        public String CategoryName { get; set; }
        public String ImageUrl { get; set; }
    }
}

