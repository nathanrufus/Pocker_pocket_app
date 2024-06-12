using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokerPocket.Data;
using PokerPocket.Models;
using System.IO;
using System.Linq;
using System.Security.Claims; // Add this namespace for ClaimTypes
using System.Threading.Tasks;

namespace PokerPocket.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Profile
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(int.Parse(userId));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User model, IFormFile picture)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Find(model.Id);
                if (user == null)
                {
                    return NotFound();
                }

                user.UserName = model.UserName;
                user.Email = model.Email;

                if (picture != null)
                {
                    var picturePath = Path.Combine("wwwroot/uploads", picture.FileName);
                    using (var stream = System.IO.File.Create(picturePath))
                    {
                        await picture.CopyToAsync(stream);
                    }
                    user.PictureUrl = $"/uploads/{picture.FileName}";
                }

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
