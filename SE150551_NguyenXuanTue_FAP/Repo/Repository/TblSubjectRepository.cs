using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class TblSubjectRepository : RepositoryBase<TblSubject>
    {
        public TblSubjectRepository(CourseManagementContext context) : base(context)
        {
        }
    }
}
