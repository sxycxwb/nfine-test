using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Application.SystemManage.User.DTO
{
    public class UserExcelInPut
    {
        public string F_Account { get; set; }
        public string F_RealName { get; set; }
        public string F_NickName { get; set; }
        public bool? F_Gender { get; set; }
        public DateTime? F_Birthday { get; set; }
        public string F_MobilePhone { get; set; }
        public string F_Email { get; set; }
        public string F_WeChat { get; set; }
        public string F_ManagerId { get; set; }
        public int? F_SecurityLevel { get; set; }
        public string F_Signature { get; set; }
        public DateTime? F_CreatorTime { get; set; }
    }
}
