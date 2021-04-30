using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRolesExample.Areas.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class RolesManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async  Task<IActionResult> Index()
        { 
            return View(await _roleManager.Roles.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }

            return RedirectToAction("Index");
        }
    }
}
