using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GameCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.GameGenre.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.GameGenre.GetFirstorDefault(u => u.Id == id);

            if (objFromDb == null)
                return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.GameGenre.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
