using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vi.Models;

namespace vi.viewModel
{
    public class RandomMovieViewModel
    {
        public movie movie { get; set; }
        public List<customer> customers { get; set; }
    }
}