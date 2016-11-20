
using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;
namespace NFine.Mapping.SystemManage
{	
	/// <summary>
	/// TaskMap
	/// </summary>	
	public class TaskMap:EntityTypeConfiguration<TaskEntity>
	{
	   public TaskMap()
	   {
	      this.ToTable("Sys_Task");
		  this.HasKey(t=>t.F_Id);
	   }
    }
}



