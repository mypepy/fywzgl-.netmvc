//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class goods
    {
        public int gid { get; set; }
        [Required(ErrorMessage = "请输入物资名称")]
        public string gname { get; set; }
        public string img { get; set; }
        public string source { get; set; }
        [Required(ErrorMessage = "请输入物资数量")]
        public int num { get; set; }
        public string unit { get; set; }
        public string gremark { get; set; }
        public Nullable<int> tid { get; set; }
    
        public virtual type type { get; set; }
    }
}
