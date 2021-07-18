using MVCCourseTrain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourseTrain.ViewModels
{
    
    public class MBViewModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Tel { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }
}