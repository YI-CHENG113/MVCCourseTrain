using System;
using System.Linq;
using System.Collections.Generic;

namespace MVCCourseTrain.Models
{
	public  class PersonRepository : EFRepository<Person>, IPersonRepository
	{
		public IEnumerable<System.Web.Mvc.SelectListItem> GetPersonForSelectList()
		{
			return this.All().Select(p => new System.Web.Mvc.SelectListItem()
			{
				Text = p.FirstName + " " + p.LastName,
				Value = p.ID.ToString()
			});
		}

	}

	public  interface IPersonRepository : IRepository<Person>
	{

	}
}