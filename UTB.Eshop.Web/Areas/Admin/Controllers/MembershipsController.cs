using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UTB.Eshop.Web.Models.Database;
using UTB.Eshop.Web.Models.Entities;
using UTB.Eshop.Web.Models.Identity;
using System.Linq;

namespace UTB.Eshop.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Manager))]
    public class MembershipsController : Controller
    {
        private readonly EshopDbContext _context;

        public MembershipsController(EshopDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Memberships
        public async Task<IActionResult> Index()
        {
            return View(await _context.Memberships.ToListAsync());
        }

        // GET: Admin/Memberships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Admin/Memberships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Memberships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Discount,Status")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membership);
        }

        // GET: Admin/Memberships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships.FindAsync(id);
            if (membership == null)
            {
                return NotFound();
            }
            return View(membership);
        }

        // POST: Admin/Memberships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Discount,Status")] Membership membership)
        {
            if (id != membership.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membership);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(membership.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(membership);
        }

        // GET: Admin/Memberships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Admin/Memberships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membership = await _context.Memberships.FindAsync(id);
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Memberships.Any(e => e.Id == id);
        }
    }
}
