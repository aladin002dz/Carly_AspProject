using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubsribedToNewsLetter { get; set; }

        public MembershipType  MembershipType { get; set; }

        [Display(Name= "Type of Membership")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}