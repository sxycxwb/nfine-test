using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage.User.DTO
{
    public class UserExcelOutPut
    {
        [Description("账户")]
        public string F_Account { get; set; }
        [Description("真实姓名")]
        public string F_RealName { get; set; }
        [Description("昵称")]
        public string F_NickName { get; set; }
        [Description("生日")]
        public DateTime? F_Birthday { get; set; }
        [Description("手机")]
        public string F_MobilePhone { get; set; }
        [Description("邮箱")]
        public string F_Email { get; set; }
        [Description("创建时间")]
        public DateTime? F_CreatorTime { get; set; }
    }
}
