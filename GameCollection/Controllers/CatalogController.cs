using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller  // ControllerBase does not haved view support so you can't return a json object
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatalogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<GameController>
        [HttpGet]
        public IActionResult Get()
        {
            var gameObj = _unitOfWork.Game.GetAll(orderBy: o => o.OrderBy(i => i.DisplayOrder));
            return Json(new { data = gameObj }); // eagerloading
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GameController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Game.GetFirstorDefault(u => u.Id == id);

            if (objFromDb == null)
                return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.Game.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
