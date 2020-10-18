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
    public class GameDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Game GameObj { get; set; }

        public void OnGet(int id)
        {
            GameObj = _unitOfWork.Game.Get(id);
        }
    }
}
