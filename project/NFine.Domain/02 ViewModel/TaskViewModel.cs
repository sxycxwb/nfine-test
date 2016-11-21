using System;
namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// TaskEntity
    /// </summary>	
    public class TaskViewModel
    {
        public string F_Id { get; set; }
        public string F_TaskDescription { get; set; }
        public bool? F_DeleteMark { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
        public int F_Status { get; set; }
        public string F_DepartmentId { get; set; }
        public string F_DepartmentName { get; set; }
    }
}



