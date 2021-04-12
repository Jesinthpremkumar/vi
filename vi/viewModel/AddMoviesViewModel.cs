using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vi.Models;

namespace vi.viewModel
{
    public class AddMoviesViewModel
    {
        public List<Genre> Genres { get; set; }
        public movie Movie { get; set; }
    }
}