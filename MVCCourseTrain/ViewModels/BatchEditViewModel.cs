using MVCCourseTrain.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourseTrain.ViewModels
{
    public class BatchEditViewModel
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required()]
        public string Name { get; set; }

        [Required]
        [BudgetRange(0, 99)]
        public decimal Budget { get; set; }

        [Required]
        public System.DateTime StartDate { get; set; }
    }
}