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
    public class IndexModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public IndexModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Purchase = await _context.Purchases.ToListAsync();
        }
    }
}
