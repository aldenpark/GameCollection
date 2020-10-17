using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using GameCollection.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameCollection.Pages.Admin.Catalog
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
        public GameVM GameObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            // Map other models to new bind Object (Could do it long hand and bind each model to different objects)
            IEnumerable<CatalogGenre> selGenre = _unitOfWork.CatalogGenre.GetAll(c => c.GameId == id, includeProperties: "Genre");

            GameObj = new GameVM
            {
                Game = new Models.Game(),
                SelectedGenres = new int[selGenre.Count()],
                GenreList = _unitOfWork.GameGenre.GetGameGenreListForDropDown()
            };


            if (id != null)
            {
                GameObj.Game = _unitOfWork.Game.GetFirstorDefault(u => u.Id == id);
                if (GameObj == null)
                {
                    return NotFound(); // returns a 404 page
                }

                //List<SelectListItem> items = new List<SelectListItem>();
                //foreach(var sel in selGenre)
                //{
                //    //items.Add(new SelectListItem { Text = sel.Genre.Name, Value = sel.GenreId.ToString() });
                //    items.Add(new SelectListItem { Text = sel.Genre.Name, Value = sel.GenreId.ToString() });
                //}
                //GameObj.SelectedGenres = items;

                int SelectedGenresCount = 0;
                foreach (var sel in selGenre)
                {
                    GameObj.SelectedGenres[SelectedGenresCount] = sel.GenreId;
                    SelectedGenresCount++;
                }
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            // List<SelectListItem> selectedItems = model.TeaList.Where(p => model.SelectedTeaIds.Contains(int.Parse(p.Value))).ToList();
            //if (GameObj.SelectedGenres != null)
            //{
            //    List<SelectListItem> selectedItems = GameObj.GenreList.Where(p => GameObj.SelectedGenres.Contains(p.Value)).ToList();
            //

            //GameObj.SelectedGenres
            //_unitOfWork.CatalogGenre.RemoveRange(_unitOfWork.CatalogGenre.GetAll(c => c.GameId == GameObj.Game.Id));

            //Teacher teacher = new Teacher();
            //teacher = db.Teacher.Include("TeacherSubjects").FirstOrDefault(x => x.Id == model.Id);

            //List<TeacherSubjects> teacherSubjects = new List<TeacherSubjects>();
            //teacher.TeacherSubjects.ToList().ForEach(result => teacherSubjects.Add(result));
            //db.TeacherSubjects.RemoveRange(teacherSubjects);
            //db.SaveChanges();

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files; // get, post, put, etc....

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (GameObj.Game.Id == 0) //means a brand new category
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\gameitems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                GameObj.Game.Image = @"\images\gameitems\" + fileName + extension;

                _unitOfWork.Game.Add(GameObj.Game);
                _unitOfWork.Save(); //Saved on the Update
            }
            else
            {
                var objFromDb = _unitOfWork.GameGenre.Get(GameObj.Game.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\gameitems");
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

                    GameObj.Game.Image = @"\images\gameitems\" + fileName + extension;
                }
                else
                {
                    GameObj.Game.Image = objFromDb.Image;
                }

                _unitOfWork.Game.Update(GameObj.Game);
            }

            _unitOfWork.CatalogGenre.RemoveRange(_unitOfWork.CatalogGenre.GetAll(c => c.GameId == GameObj.Game.Id));
            
            foreach(var selectedGenre in GameObj.SelectedGenres)
            {
                //_unitOfWork.CatalogGenre.Add(selectedGenre);
                _unitOfWork.CatalogGenre.Add(new CatalogGenre
                {
                    GameId = GameObj.Game.Id,
                    //GenreId = int.Parse(selectedGenre.Value)
                    GenreId = selectedGenre
                });
            }
            _unitOfWork.Save();


            return RedirectToPage("./Index");
        }
    }
}
