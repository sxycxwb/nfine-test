using NFine.Data;
using NFine.Domain.Entity.SystemManage;
using NFine.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NFine.Code;

namespace NFine.Repository.SystemManage
{	
	/// <summary>
	/// TaskRepository
	/// </summary>	
	public class TaskRepository:RepositoryBase<TaskEntity>,ITaskRepository
	{

	    public List<TaskViewModel> GetTaskList(Pagination page,Expression<Func<TaskViewModel, bool>> predicate)
	    {
            using (var db = new RepositoryBase())
            {
                var list = db.IQueryable(predicate);
                if (page != null && page.page == 0 && page.rows != 0)//分页处理
                    list = list.Skip(page.rows * (page.page - 1)).Take(page.rows).AsQueryable();
                return db.IQueryable(predicate).ToList();
            }
        }

	    public int GetTaskCount(Expression<Func<TaskViewModel, bool>> predicate)
        {
            using (var db = new RepositoryBase())
            {
                return db.IQueryable(predicate).Count();
            }
        }
    }
}



