using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpressoApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpressoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        ExpressoDbContext _expressoDbContext;

        public MenusController(ExpressoDbContext expressoDbContext)
        {
            _expressoDbContext = expressoDbContext;
        }

        [HttpGet]
        public IActionResult GetMenus()
        {
            var menus = _expressoDbContext.Menus.Include("SubMenus");
            return Ok(menus);
        }

        [HttpGet("{id}")]
        public IActionResult GetMenu(int id)
        {
           var menu = _expressoDbContext.Menus.Include("SubMenus").FirstOrDefault(m=>m.Id==id);
            if (menu==null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
    }
}