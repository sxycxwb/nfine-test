
using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;
namespace NFine.Mapping.SystemManage
{	
	/// <summary>
	/// TaskMap
	/// </summary>	
	public class TaskViewMapping : EntityTypeConfiguration<TaskViewModel>
	{
	   public TaskViewMapping()
	   {
	      this.ToTable("Sys_TaskView");
		  this.HasKey(t=>t.F_Id);
	   }
    }
}



