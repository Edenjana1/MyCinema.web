﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyCinema.Data;
using MyCinema.Models;

namespace MyCinema.Pages.Costumers
{
    public class DeleteModel : PageModel
    {
        private readonly MyCinema.Data.MyCinemaContext _context;

        public DeleteModel(MyCinema.Data.MyCinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Costumer Costumer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumers.FirstOrDefaultAsync(m => m.IdentityCard == id);

            if (costumer == null)
            {
                return NotFound();
            }
            else
            {
                Costumer = costumer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costumer = await _context.Costumers.FindAsync(id);
            if (costumer != null)
            {
                Costumer = costumer;
                _context.Costumers.Remove(Costumer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
