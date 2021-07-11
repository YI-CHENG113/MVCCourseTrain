using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCourseTrain.ViewModels
{
    public class DepartmentEdit
    {
        [Required(ErrorMessage ="請輸入名稱")]
        public string Name { get; set; }
        [Range(0, 99999, ErrorMessage = "請輸入合理的預算範圍 ({1} ~ {2})")]
        public decimal Budget { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }

        public Nullable<int> InstructorID { get; set; }
    }
}