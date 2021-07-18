namespace MVCCourseTrain.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(TEST1MetaData))]
    public partial class TEST1
    {
    }
    
    public partial class TEST1MetaData
    {
        [Required]
        public int num { get; set; }
        
        [StringLength(8, ErrorMessage="欄位長度不得大於 8 個字元")]
        public string Cname { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string Ename { get; set; }
    }
}
