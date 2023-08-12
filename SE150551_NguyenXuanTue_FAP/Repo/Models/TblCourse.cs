using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblCourse
    {
        public TblCourse()
        {
            TblSessions = new HashSet<TblSession>();
            TblStudentInCourses = new HashSet<TblStudentInCourse>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public string CourseCode { get; set; }
        public string Instructor { get; set; }
        public string CourseDescription { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int Status { get; set; }

        public virtual TblSemester Semester { get; set; }
        public virtual TblSubject Subject { get; set; }
        public virtual ICollection<TblSession> TblSessions { get; set; }
        public virtual ICollection<TblStudentInCourse> TblStudentInCourses { get; set; }
    }
}
