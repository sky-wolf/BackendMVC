using LexiconMVC.Models;
using LexiconMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace LexiconMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            role.NormalizedName = role.Name.ToUpper();
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole role)
        {
            IdentityRole roletoupdate = await _roleManager.FindByIdAsync(role.Id);

            if(roletoupdate != null)
            {
                roletoupdate.Name = role.Name;
                roletoupdate.NormalizedName = role.Name.ToUpper();
                await _roleManager.UpdateAsync(roletoupdate);
            }            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        public IActionResult AddUserToRole()
        {
            ViewBag.Users = new SelectList(_userManager.Users, "Id", "UserName");
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(string userid, string rolename)
        {
            var user = await _userManager.FindByIdAsync(userid);
            await _userManager.AddToRoleAsync(user, rolename);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddRoleToUser(string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            ViewBag.UserId = userid;
            ViewBag.Name = $"{user.FirstName} {user.LastName}";
            ViewBag.Roles = new SelectList(_roleManager.Roles, "Name", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(string userid, string rolename)
        {
            var user = await _userManager.FindByIdAsync(userid);
            
            await _userManager.AddToRoleAsync(user, rolename);

            return RedirectToAction("ShowUserRoles", new { id = userid });
           
        }

        public async Task<IActionResult> AddUserToAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id); 

            await _userManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction("Index", "Identity");
        }

        public async Task<IActionResult> ShowUserRoles(string id)
        {
            UserRoleViewModel vm = new UserRoleViewModel();

            var user = await _userManager.FindByIdAsync(id);

            var assigned = new List<string>(await _userManager.GetRolesAsync(user));

            vm.UserId = user.Id;
            vm.Name = $"{user.FirstName} {user.LastName}";
            vm.Roles.AddRange(assigned);
            return View(vm);
        }

        public async Task<IActionResult> RemoveRoleFromUser(string rolename, string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            await _userManager.RemoveFromRoleAsync(user, rolename);

            return RedirectToAction("ShowUserRoles", new { id = userid });
        }
    }
}
