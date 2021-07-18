using System;
using System.Linq;
using System.Collections.Generic;
using MVCCourseTrain.ViewModels;
using System.Linq.Dynamic.Core;

namespace MVCCourseTrain.Models
{   
	public  class CourseRepository : EFRepository<Course>, ICourseRepository
	{
        public override IQueryable<Course> All()
        {
            return base.All().Where(p=>!p.IsDelete);
        }
        public Course FindOne(int id)
        {
            return this.All().FirstOrDefault(p => p.CourseID == id);
        }
        public IQueryable<Course> Search(CourseFilter filter)
        {
            var data = this.All();

            if (!String.IsNullOrEmpty(filter.keyword))
            {
                data = data.Where(p => p.Title.Contains(filter.keyword));
            }

            //data = data.OrderByDescending(p => p.Credits);
            data = data.OrderBy(filter.sortBy + " " + filter.sortDirection);

            return data;
        }
        public override void Delete(Course entity)
        {
            entity.IsDelete = true;
        }

    }


	public  interface ICourseRepository : IRepository<Course>
	{

	}
}