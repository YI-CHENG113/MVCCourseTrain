using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCourseTrain.ViewModels
{
    public class DepartmentCreate
    {
        [Required( ErrorMessage="請輸入名稱")]
        public string Name { get; set; }
        [Range(0, 99999, ErrorMessage = "請輸入合理的預算範圍 ({1} ~ {2})")]
        public decimal Budget { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}