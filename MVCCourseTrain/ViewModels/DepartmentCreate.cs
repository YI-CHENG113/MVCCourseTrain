using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using MVCCourseTrain.Models;

namespace MVCCourseTrain.ViewModels
{
    [MetadataType(typeof(DepartmentCreateMetaData))]
    public class DepartmentCreate
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        [UIHint("InstructorID")]
        public Nullable<int> InstructorID { get; set; }
    }
}