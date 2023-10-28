using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_App.Data;
using My_Scripture_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace My_Scripture_App.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly My_Scripture_AppContext _context;

        public IndexModel(My_Scripture_AppContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedDateSort { get; set; }

        public SelectList Books { get; set; }

        public SelectList DateSortOptions { get; set; }

        public async Task OnGetAsync()
        {
            // Define available book options for the dropdown
            var bookQuery = _context.Scripture
                .OrderBy(s => s.Book)
                .Select(s => s.Book)
                .Distinct()
                .ToList();
            Books = new SelectList(bookQuery);

            // Define available date sort options for the dropdown
            DateSortOptions = new SelectList(new List<string>
            {
                "Date Added (Ascending)",
                "Date Added (Descending)"
            });

            // Retrieve the list of scriptures
            var scriptures = from s in _context.Scripture
                             select s;

            // Apply search filter if SearchString is provided
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchString));
            }

            // Apply book filter if SelectedBook is provided
            if (!string.IsNullOrEmpty(SelectedBook))
            {
                scriptures = scriptures.Where(s => s.Book == SelectedBook);
            }

            // Apply sorting based on the SelectedDateSort parameter
            if (SelectedDateSort == "Date Added (Ascending)")
            {
                scriptures = scriptures.OrderBy(s => s.DateAdded);
            }
            else if (SelectedDateSort == "Date Added (Descending)")
            {
                scriptures = scriptures.OrderByDescending(s => s.DateAdded);
            }

            Scripture = await scriptures.AsNoTracking().ToListAsync();
        }
    }
}
