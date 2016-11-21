
//------------------------------------------------------------------------------
// <博客园-枫伶忆 http://www.cnblogs.com/fenglingyi/>
//     此代码由T4模板自动生成
//	   生成时间 2016-11-20 21:14:04 by 枫伶忆
//     对此文件的更改可能会导致不正确的行为，并且如果重新生成代码，这些更改将会丢失。
//     QQ:549387177
// <博客园-枫伶忆 http://www.cnblogs.com/fenglingyi/>
//------------------------------------------------------------------------------
using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NFine.Code;

namespace NFine.Domain.IRepository.SystemManage
{	
	/// <summary>
	/// TaskRepository
	/// </summary>	
	public interface ITaskRepository:IRepositoryBase<TaskEntity>
	{
       int GetTaskCount(Expression<Func<TaskViewModel, bool>> predicate);

        List<TaskViewModel> GetTaskList(Pagination page,Expression<Func<TaskViewModel, bool>> predicate);
    }
}



