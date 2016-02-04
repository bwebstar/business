using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Business.Models
{
    public class SalesPersonSales
    {
        public int Id { get; set; }
        [Display(Name = "Sales Person")]
        public string SalesPerson { get; set; }
        [Display(Name = "Software Sales")]
        public int SoftwareSales { get; set; }
        [Display(Name = "Services Sales")]
        public int ServicesSales { get; set; }
        [Display(Name = "Support Sales")]
        public int SupportSales { get; set; }
    }
}