using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblStudentInCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public virtual TblCourse Course { get; set; }
        public virtual TblStudent Student { get; set; }
    }
}
