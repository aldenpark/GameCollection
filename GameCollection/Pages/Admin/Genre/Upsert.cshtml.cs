using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameCollection.Pages.Admin.Genre
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.GameGenre GenreObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            GenreObj = new Models.GameGenre();

            if (id != null)
            {
                GenreObj = _unitOfWork.GameGenre.GetFirstorDefault(u => u.Id == id);
                if (GenreObj == null)
                {
                    return NotFound(); // returns a 404 page
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (GenreObj.Id == 0) //means a brand new category
            {
                _unitOfWork.GameGenre.Add(GenreObj);
                _unitOfWork.Save(); //Saved on the Update
            }
            else
            {
                _unitOfWork.GameGenre.Update(GenreObj);
            }

            return RedirectToPage("./Index");
        }
    }
}
