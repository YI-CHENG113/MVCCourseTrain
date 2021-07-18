using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVCCourseTrain.Models
{   
	public  class TEST1Repository : EFRepository<TEST1>, ITEST1Repository
	{

	}

	public  interface ITEST1Repository : IRepository<TEST1>
	{

	}
}