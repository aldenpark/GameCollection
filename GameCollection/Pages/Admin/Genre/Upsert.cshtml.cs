using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameCollection.Pages.Admin.Genre
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
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

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files; // get, post, put, etc....

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (GenreObj.Id == 0) //means a brand new category
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\gamegenreitems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                GenreObj.Image = @"\images\gamegenreitems\" + fileName + extension;

                _unitOfWork.GameGenre.Add(GenreObj);
                _unitOfWork.Save(); //Saved on the Update
            }
            else
            {
                var objFromDb = _unitOfWork.GameGenre.Get(GenreObj.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\gamegenreitems");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    GenreObj.Image = @"\images\gamegenreitems\" + fileName + extension;
                }
                else
                {
                    GenreObj.Image = objFromDb.Image;
                }

                _unitOfWork.GameGenre.Update(GenreObj);
            }

            return RedirectToPage("./Index");
        }
    }
}
