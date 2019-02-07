using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoApi.Data;
using ExpressoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpressoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private ExpressoDbContext _expressoDbContext;

        public ReservationsController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }

        [HttpPost]
        public IActionResult Post(Reservation reservation)
        {
            _expressoDbContext.Reservations.Add(reservation);
            _expressoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}