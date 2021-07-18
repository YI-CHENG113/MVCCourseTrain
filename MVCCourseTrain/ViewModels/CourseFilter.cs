using MVCCourseTrain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourseTrain.ViewModels
{
    public class CourseFilter
    {
        public string keyword { get; set; }

        [RegularExpression(@"(CourseId|Credits|Title)")]
        public string sortBy { get; set; } = "CourseId";

        [RegularExpression(@"(ASC|DESC)")]
        public string sortDirection { get; set; } = "ASC";
    }
}