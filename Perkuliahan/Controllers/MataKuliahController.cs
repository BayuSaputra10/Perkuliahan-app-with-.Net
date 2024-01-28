using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perkuliahan.Models.Entities;
using Perkuliahan.Models;
using Perkuliahan.Data;

namespace Perkuliahan.Controllers
{
    public class MataKuliahController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public MataKuliahController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> add(AddMataKuliahViewModel viewModel)
        {
            var mataKuliah = new MataKuliah
            {
                Nama_MK = viewModel.Nama_MK,
                Sks = viewModel.Sks
            };
            await dbContext.MataKuliahs.AddAsync(mataKuliah);
            await dbContext.SaveChangesAsync();

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Mata Kuliah berhasil ditambahkan.";
                ModelState.Clear();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var mataKuliah = await dbContext.MataKuliahs.ToListAsync();
            return View(mataKuliah);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string kodeMk)
        {
            var mataKuliah= await dbContext.MataKuliahs.FindAsync(kodeMk);
            return View(mataKuliah);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MataKuliah viewModel)
        {
            var mataKuliah = await dbContext.MataKuliahs.FindAsync(viewModel.Kode_MK);

            if (mataKuliah is not null)
            {
                mataKuliah.Nama_MK = viewModel.Nama_MK;
                mataKuliah.Sks = viewModel.Sks;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "MataKuliah");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MataKuliah viewMode)
        {
            var mataKuliah = await dbContext.MataKuliahs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Kode_MK == viewMode.Kode_MK);

            if (mataKuliah is not null)
            {
                dbContext.MataKuliahs.Remove(viewMode);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "MataKuliah");
        }
    }
}
