using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblSemester
    {
        public TblSemester()
        {
            TblCourses = new HashSet<TblCourse>();
        }

        public int Id { get; set; }
        public string SemesterName { get; set; }

        public virtual ICollection<TblCourse> TblCourses { get; set; }
    }
}
