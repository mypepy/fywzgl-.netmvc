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

    public partial class plans
    {
        public int pid { get; set; }
        [Required(ErrorMessage = "请输入计划标题")]
        public string pname { get; set; }
        public System.DateTime ptime { get; set; }
        public string pmark { get; set; }
    }
}
