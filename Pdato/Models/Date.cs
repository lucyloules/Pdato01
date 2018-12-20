using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pdato.Models
{
    public class Date
    {
        [Key]
        public int DateId { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime ReservationTime { get; set; }

        public int StateId { get; set; }
    }
}