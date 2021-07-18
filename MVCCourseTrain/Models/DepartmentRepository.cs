using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourseTrain.Models
{   
	public  class DepartmentRepository : EFRepository<Department>, IDepartmentRepository
	{
		public Department FindOne(int id)
		{
			return base.All().FirstOrDefault(p => p.DepartmentID == id);
		}

	}

	public  interface IDepartmentRepository : IRepository<Department>
	{

	}
}