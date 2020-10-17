using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCollection.DataAccess.Data.Repository.IRepository;
using GameCollection.Models;
using GameCollection.Utility;
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

        // GET: api/<GameController>
        [HttpGet]
        public void Get()
        {
            GameHistory = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, SD.GameHistorySessionId);
        }

        // GET api/<GameController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {
            // Could use this and save session history to db, would be usually for actuall tracking
            //var claimIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // HttpContext.Session.SetInt32(SD.SiteSessionId, db_id_from_history);

            GameHistory = SessionHelper.GetObjectFromJson<List<int>>(HttpContext.Session, SD.GameHistorySessionId);
            if (GameHistory == null)
            {
                GameHistory = new List<int>();
            }
            GameHistory.Add(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, SD.GameHistorySessionId, GameHistory);
        }

    }
}
