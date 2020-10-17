using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using GameCollection.Models.ViewModels;
using GameCollection.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameCollection.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public IEnumerable<CatalogGenre> GameObjList { get; set; }

        public void OnGet(int id)
        {
            //GameObj = _unitOfWork.Game.GetFirstorDefault(includeProperties: "Game,GameGenre", filter: g => g.GenreId == id);  // I'm doing something wrong because I can't geth the includeProperties to work
            GameObjList = _unitOfWork.CatalogGenre.GetAll(filter: g => g.GenreId == id, includeProperties: "Game");
        }

    }
}
