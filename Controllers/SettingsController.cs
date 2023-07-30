
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLPInfotech.Models;

namespace ProjectLPInfotech.Controllers
{

    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var settings = _context.Settings.ToList();
            return View(settings);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setting == null)
            {
                return NotFound();
            }

            return PartialView("_DetailsPartial", setting);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new Setting();
            return PartialView("_CreatePartial", model);
        }

        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                var set = new Setting
                {
                    Key = setting.Key,
                    Value = setting.Value,
                    Value2 = setting.Value2,
                    Description = setting.Description,
                    Created = DateTime.Now,
                    LastModified = DateTime.Now,
                    IsDeleted = false
                };
                _context.Settings.Add(set);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }


        [HttpGet]
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = _context.Settings.Find(id);
            if (setting == null)
            {
                return NotFound();
            }
            return PartialView("_EditPartial", setting);
            //return View(setting);
        }

        [HttpPost]
        
        public IActionResult Edit(long id, Setting setting)
        {
            if (id != setting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Entry(setting).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Settings == null)
            {
                return NotFound();
            }

            var setting = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (setting == null)
            {
                return NotFound();
            }
            return PartialView("_DeletePartial", setting);
            //return View(setting);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Settings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Settings'  is null.");
            }
            var setting = await _context.Settings.FindAsync(id);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SettingExists(long id)
        {
            return (_context.Settings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
