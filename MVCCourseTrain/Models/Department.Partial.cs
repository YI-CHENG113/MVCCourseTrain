namespace MVCCourseTrain.Models
{
    using MVCCourseTrain.ValidationAttributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department:IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (HasDirtyWord(Name))
            {
                yield return new ValidationResult("名稱不能包含髒話", new string[] { "Name" });
            }
        }
        private bool HasDirtyWord(string name)
        {
            if (name.Contains("shxx"))
            {
                return true;
            }

            return false;
        }

    }

    public partial class DepartmentMetaData
    {
        [Required]
        public int DepartmentID { get; set; }

        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        public decimal Budget { get; set; }
        [Required]
        public System.DateTime StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<Course> Course { get; set; }
        public virtual Person Manager { get; set; }
    }
    public partial class DepartmentCreateMetaData
    {
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }
        [BudgetRange]
        public decimal Budget { get; set; }

        [UIHint("InstructorID")]
        public Nullable<int> InstructorID { get; set; }
    }
    public partial class DepartmentEditMetaData
    {
        [Required(ErrorMessage = "請輸入名稱")]
        public string Name { get; set; }
        [BudgetRange]
        public decimal Budget { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }

        [UIHint("InstructorID")]
        public Nullable<int> InstructorID { get; set; }
    }

}
