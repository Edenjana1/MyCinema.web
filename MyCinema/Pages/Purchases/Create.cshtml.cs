﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCinema.Data;
using MyCinema.Models;

namespace MyCinema.Pages.Purchases
{
    public class CreateModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public CreateModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SerieID"] = new SelectList(_context.Series, "SerieID", "SerieID");
            return Page();
        }

        [BindProperty]
        public Purchase Purchase { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Purchases.Add(Purchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
