using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblStudentRepository : RepositoryBase<TblStudent>
    {
        public TblStudentRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
