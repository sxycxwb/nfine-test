
//------------------------------------------------------------------------------
// <博客园-枫伶忆 http://www.cnblogs.com/fenglingyi/>
//     此代码由T4模板自动生成
//	   生成时间 2016-11-20 21:14:04 by 枫伶忆
//     对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
//     QQ:549387177
// <博客园-枫伶忆 http://www.cnblogs.com/fenglingyi/>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using NFine.Code;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using NFine.Repository.SystemManage;
namespace NFine.Application.SystemManage
{
    /// <summary>
    /// TaskApp
    /// </summary>	
    public class TaskApp
    {
        private ITaskRepository service = new TaskRepository();
        private IOrganizeRepository orgSerivce = new OrganizeRepository();

        /// <summary>
        /// 获取任务列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<TaskViewModel> GetList(Pagination page = null, string status = "")
        {
            var expression = GetExpression(status);
            var list = service.GetTaskList(expression);
            if (page != null && page.page == 0 && page.rows != 0)//分页处理
                list.Skip(page.rows * (page.page - 1)).Take(page.rows).AsQueryable();
            return list.ToList();
        }

        /// <summary>
        /// 获取任务数量
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetCount(string status = "")
        {
            var expression = GetExpression(status);
            var count = service.GetTaskCount(expression);
            return count;
        }

        private Expression<Func<TaskViewModel, bool>> GetExpression(string status)
        {
            var currentUserId = OperatorProvider.Provider.GetCurrent().UserId;//用户ID
            var deptmentId = OperatorProvider.Provider.GetCurrent().DepartmentId;//部门ID
            var deptList = orgSerivce.IQueryable(t => t.F_ParentId == deptmentId && t.F_DeleteMark == false).ToList();//查询有效下级部门ID
            var deptmentIdList = new List<string>();

            var expression = ExtLinq.True<TaskViewModel>();
            if (deptList.Count > 0) //说明该用户为上级用户
            {
                deptList.ForEach(t => { deptmentIdList.Add(t.F_Id); });
                expression =
                    expression.And(t => deptmentIdList.Contains(t.F_DepartmentId) || t.F_CreatorUserId == currentUserId);
            }
            else //否则只查询自己
            {
                expression.And(t => t.F_CreatorUserId == currentUserId);
            }

            if (!string.IsNullOrEmpty(status))
                expression.And(t => t.F_Status == Convert.ToInt32(status));
            return expression;
        }

        public TaskEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }

        public void Delete(TaskEntity entity)
        {
            service.Delete(entity);
        }

        public void SubmitForm(TaskEntity entity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                service.Update(entity);
            }
            else
            {
                entity.Create();
                service.Insert(entity);
            }
        }

    }
}



