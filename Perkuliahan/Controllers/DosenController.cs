using Microsoft.AspNetCore.Mvc;
using Perkuliahan.Data;
using Perkuliahan.Models.Entities;
using Perkuliahan.Models;
using Microsoft.EntityFrameworkCore;

namespace Perkuliahan.Controllers
{
    public class DosenController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DosenController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(AddDosenViewModel viewModel)
        {
            var dosen = new Dosen
            {
                Nama_Dosen = viewModel.Nama_Dosen
            };
            await dbContext.Dosens.AddAsync(dosen);
            await dbContext.SaveChangesAsync();

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Dosen berhasil ditambahkan.";
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var dosen = await dbContext.Dosens.ToListAsync();
            return View(dosen);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string nim)
        {
            var dosen= await dbContext.Dosens.FindAsync(nim);
            return View(dosen);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dosen viewModel)
        {
            var dosen = await dbContext.Dosens.FindAsync(viewModel.Nip);

            if (dosen is not null)
            {
                dosen.Nama_Dosen = viewModel.Nama_Dosen;

                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }

            return RedirectToAction("List", "Dosen");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Dosen viewMode)
        {
            var dosen = await dbContext.Dosens.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nip == viewMode.Nip);

            if (dosen is not null)
            {
                dbContext.Dosens.Remove(viewMode);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            return RedirectToAction("List", "Dosen");
        }
    }
}
