using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;
using MyCinema.Models;

namespace MyCinema.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public IndexModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Serie = await _context.Series.ToListAsync();
        }
    }
}
