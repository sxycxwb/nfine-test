using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NFine.Repository.SystemManage
{	
	/// <summary>
	/// TaskRepository
	/// </summary>	
	public class TaskRepository:RepositoryBase<TaskEntity>,ITaskRepository
	{

	    public IQueryable<TaskViewModel> GetTaskList(Expression<Func<TaskViewModel, bool>> predicate)
	    {
            using (var db = new RepositoryBase().BeginTrans())
            {
                return db.IQueryable(predicate);
            }
        }

	    public int GetTaskCount(Expression<Func<TaskViewModel, bool>> predicate)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                return db.IQueryable(predicate).Count();
            }
        }
    }
}



