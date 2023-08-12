using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblStudentInCourseRepository : RepositoryBase<TblStudentInCourse>
    {
        public TblStudentInCourseRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
