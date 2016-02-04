using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class SalesData
    {
        public int Id { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        [Display(Name = "Kitchen & Bath")]
        public int KitchenAndBath { get; set; }
        [Display(Name = "Home & Garden")]
        public int HomeAndGarden { get; set; }
        [Display(Name = "Electronics")]
        public int Electronics { get; set; }
        [Display(Name = "Books & Media")]
        public int BooksAndMedia { get; set; }
    }
}