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
    public class DetailsModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public DetailsModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        public Serie Serie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FirstOrDefaultAsync(m => m.SerieID == id);
            if (serie == null)
            {
                return NotFound();
            }
            else
            {
                Serie = serie;
            }
            return Page();
        }
    }
}
