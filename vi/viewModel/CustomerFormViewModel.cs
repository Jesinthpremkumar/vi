using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vi.Models;
namespace vi.viewModel
{
    public class CustomerFormViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public customer customer { get; set; }
    }
}