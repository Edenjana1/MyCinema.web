using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;
using MyCinema.Models;

namespace MyCinema.Pages.Purchases
{
    public class DetailsModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public DetailsModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        public Purchase Purchase { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await _context.Purchases.FirstOrDefaultAsync(m => m.MovieID == id);
            if (purchase == null)
            {
                return NotFound();
            }
            else
            {
                Purchase = purchase;
            }
            return Page();
        }
    }
}
