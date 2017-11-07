using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carly.Models;

namespace Carly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}