using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblSubject
    {
        public TblSubject()
        {
            TblCourses = new HashSet<TblCourse>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; }

        public virtual ICollection<TblCourse> TblCourses { get; set; }
    }
}
