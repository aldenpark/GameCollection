using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using GameCollection.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<int> GameHistory { get; set; }
        //public IEnumerable<GameHistory> GameHistory { get; set; }

        // GET: api/<GameController>
        [HttpGet]
        public void Get()
        {
            //GameHistory = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, SD.GameHistorySessionId);
            SetHistory();
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            //SessionHelper.SetObjectAsJson(HttpContext.Session, SD.GameHistorySessionId, GameHistory);


            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null && id > 0)
            {
                var ghistory = _unitOfWork.GameHistory.GetFirstorDefault(h => h.ApplicationUserId == claim.Value && h.GameId == id);

                if(ghistory != null)
                {
                    _unitOfWork.GameHistory.Update(ghistory);
                }
                else
                {
                    var gameHistory = new GameHistory();
                    gameHistory.ApplicationUserId = claim.Value;
                    gameHistory.GameId = id;
                    gameHistory.DateModified = DateTime.Now;
                    _unitOfWork.GameHistory.Add(gameHistory);
                    _unitOfWork.Save();
                }

            }

            SetHistory();
        }

        public void SetHistory()
        {

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                    //GameHistory = _unitOfWork.GameHistory.GetAll(h => h.ApplicationUserId == claim.Value).OrderByDescending(x => x.Datemodified).Take(10);
                    var ghistory = _unitOfWork.GameHistory.GetAll(h => h.ApplicationUserId == claim.Value); // .OrderByDescending(x => x.Datemodified).Take(10);


                GameHistory = new List<int>();
                foreach (var hist in ghistory)
                {
                    GameHistory.Add(hist.GameId);
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, SD.GameHistorySessionId, GameHistory);
        }

    }
}
