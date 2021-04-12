using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using vi.Models;
using vi.Dtos;
namespace vi.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = " Please enter your Name")]
        [StringLength(255)]
        public string name { get; set; }

        public bool isSubscribedToNewsletter { get; set; }
        public MemberhipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

//       [Min18YearIfAMember]
        public DateTime? DateOfBirth { get; set; }
    }
}