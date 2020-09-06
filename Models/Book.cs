using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    //public class BookCount
    //{
    //    public int ID { get; set; }
    //    public int Count { get; set; }
    //}
    public class Book
    {
        public int ID { get; set; }

        [Required, Display(Name = "Название"), StringLength(100, MinimumLength = 3, ErrorMessage = "Длина строки должна быть 3-100.")]
        public string Title { get; set; }

        [Display(Name = "Стоимость"), Column(TypeName = "decimal(18, 0)"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        public int Count { get; set; }
    }
}
