using CleanArchMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.Application.DTOs
{
    public  class ProductDTO
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "The {0} is required")]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "The {0} is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [MaxLength(250)]
        [DisplayName("Image URL")]
        public string ImageUrl { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "The {0} is required")]
        [Range(1,9999)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [DisplayName("Category")]
        public Category Category { get; set; }

        public int CategoryId { get; set; }
    }
}
