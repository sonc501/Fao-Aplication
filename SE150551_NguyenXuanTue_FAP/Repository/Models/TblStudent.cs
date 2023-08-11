using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblStudent
    {
        public TblStudent()
        {
            TblStudentInCourses = new HashSet<TblStudentInCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<TblStudentInCourse> TblStudentInCourses { get; set; }
    }
}
