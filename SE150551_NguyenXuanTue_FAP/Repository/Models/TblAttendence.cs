using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class TblAttendence
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public DateTime? DateAttendence { get; set; }
        public int? Status { get; set; }

        public virtual TblSession Session { get; set; }
    }
}
