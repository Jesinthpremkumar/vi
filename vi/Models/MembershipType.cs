using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vi.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string MembershipName { get; set; }
        public short SignUpFee { get; set; }

        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte unkown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}