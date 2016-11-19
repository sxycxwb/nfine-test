
using System;
namespace NFine.Domain.Entity.SystemManage
{
    /// <summary>
    /// Test_Report2Entity
    /// </summary>	
    public class Test_Report2Entity : IEntity<Test_Report2Entity>
    {
        public int F_Id { get; set; }
        public string F_Modle { get; set; }
        public string F_Month { get; set; }
        public decimal? F_Fee { get; set; }

    }
}



