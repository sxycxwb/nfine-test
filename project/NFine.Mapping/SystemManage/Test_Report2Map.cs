using NFine.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;
namespace NFine.Mapping.SystemManage
{	
	/// <summary>
	/// Test_Report2Map
	/// </summary>	
	public class Test_Report2Map:EntityTypeConfiguration<Test_Report2Entity>
	{
	   public Test_Report2Map()
	   {
	      this.ToTable("Test_Report2");
          this.HasKey(t => t.F_Id);
        }
    }
}



