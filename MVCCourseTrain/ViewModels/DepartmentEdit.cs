using MVCCourseTrain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourseTrain.ViewModels
{
    [MetadataType(typeof(DepartmentCreateMetaData))]
    public class DepartmentEdit
    {
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }

        public Nullable<int> InstructorID { get; set; }
    }
}