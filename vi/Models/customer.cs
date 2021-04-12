using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vi.Models
{
    public class customer
    {
        public int id { get; set; }
       
        [Required(ErrorMessage =" Please enter your Name")]
        [StringLength(255)]
        public string name { get; set; }
        
        [Display(Name ="is subscriobed to newsletter")]
        public bool isSubscribedToNewsletter { get; set; }
      
        [Display(Name ="Membership Type")]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        
        [Display(Name ="Birthdate")]
        [Min18YearIfAMember]
        public DateTime? DateOfBirth {get;set;}
    }
}