using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblSession
    {
        public TblSession()
        {
            TblAttendences = new HashSet<TblAttendence>();
        }

        public int Id { get; set; }
        public string SessionDate { get; set; }
        public TimeSpan? SlotStart { get; set; }
        public TimeSpan? SlotEnd { get; set; }
        public int? CourseId { get; set; }

        public virtual TblCourse Course { get; set; }
        public virtual ICollection<TblAttendence> TblAttendences { get; set; }
    }
}
