using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Perkuliahan.Data;
using Perkuliahan.Models;
using Perkuliahan.Models.Entities;


namespace Perkuliahan.Controllers
{
    public class KuliahController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public KuliahController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Add()
        {
            ViewBag.MahasiswaList = new SelectList(dbContext.Mahasiswas, "Nim", "Nama_Mhs");
            ViewBag.MataKuliahList = new SelectList(dbContext.MataKuliahs, "Kode_MK", "Nama_MK");
            ViewBag.DosenList = new SelectList(dbContext.Dosens, "Nip", "Nama_Dosen");

            var viewModel = new AddKuliahViewModel();

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddKuliahViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var kuliah = new Kuliah
                {
                    Nim = viewModel.Nim,
                    Kode_MK = viewModel.Kode_MK,
                    Nip = viewModel.Nip,
                    Nilai = viewModel.Nilai
                };

                await dbContext.Kuliahs.AddAsync(kuliah);
                await dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kuliah berhasil ditambahkan.";
                ModelState.Clear();

                return RedirectToAction("List");
            }
            ViewBag.NimList = new SelectList(dbContext.Mahasiswas, "Nim", "Nama_Mhs");

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var kuliahs = await dbContext.Kuliahs
                .Include(k => k.Mahasiswa)
                .Include(k => k.MataKuliah)
                .Include(k => k.Dosen)
                .ToListAsync();

            return View(kuliahs);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int kuliahId)
        {
           var kuliah = await dbContext.Kuliahs.FindAsync(kuliahId);

            if (kuliah == null)
            {
                return NotFound();
            }

            ViewBag.MahasiswaList = new SelectList(dbContext.Mahasiswas, "Nim", "Nama_Mhs");
            ViewBag.MataKuliahList = new SelectList(dbContext.MataKuliahs, "Kode_MK", "Nama_MK");
            ViewBag.DosenList = new SelectList(dbContext.Dosens, "Nip", "Nama_Dosen");

            return View(kuliah);
  


        }

        [HttpPost]
        public async Task<IActionResult> Edit(Kuliah viewModel)
        {
                var kuliah = await dbContext.Kuliahs.FindAsync(viewModel.KuliahId);

     
                kuliah.Nim = viewModel.Nim;
                kuliah.Kode_MK = viewModel.Kode_MK;
                kuliah.Nip = viewModel.Nip;
                kuliah.Nilai = viewModel.Nilai;

                await dbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kuliah berhasil diupdate.";

         //       return RedirectToAction("List");

            ViewBag.MahasiswaList = new SelectList(dbContext.Mahasiswas, "Nim", "Nama_Mhs");
            ViewBag.MataKuliahList = new SelectList(dbContext.MataKuliahs, "Kode_MK", "Nama_MK");
            ViewBag.DosenList = new SelectList(dbContext.Dosens, "Nip", "Nama_Dosen");
            return RedirectToAction("List"); ;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Kuliah viewMode)
        {
            var kuliah = await dbContext.Kuliahs.AsNoTracking()
                .FirstOrDefaultAsync(x => x.KuliahId == viewMode.KuliahId);

            if (kuliah is not null)
            {
                dbContext.Kuliahs.Remove(viewMode);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            return RedirectToAction("List", "Kuliah");
        }


    }
}
