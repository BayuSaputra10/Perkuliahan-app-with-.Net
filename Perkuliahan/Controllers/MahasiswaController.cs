using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Perkuliahan.Data;
using Perkuliahan.Models;
using Perkuliahan.Models.Entities;
using PagedList;

namespace Perkuliahan.Controllers
{
    public class MahasiswaController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public MahasiswaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> add(AddMahasiswaViewModel viewModel)
        {
            var mahasiswa = new Mahasiswa
            {
                Nama_Mhs = viewModel.Nama_Mhs,
                Tgl_lahir = viewModel.Tgl_lahir,
                Alamat = viewModel.Alamat,
                Jenis_Kelamin = viewModel.Jenis_Kelamin
            };
            await dbContext.Mahasiswas.AddAsync(mahasiswa);
            await dbContext.SaveChangesAsync();
            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Mahasiswa berhasil ditambahkan.";
                ModelState.Clear();
            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List(string cariString,int? pageNumber)
        {
            int pageSize = 5;
            var mahasiswa = await dbContext.Mahasiswas.ToListAsync();

            if (!String.IsNullOrEmpty(cariString))
            {
                mahasiswa = await dbContext.Mahasiswas
                    .Where(n => n.Nama_Mhs.Contains(cariString))
                    .ToListAsync();
            }

            return View(PaginatedList<Mahasiswa>.Create(dbContext.Mahasiswas.ToList()
                ,pageNumber ?? 1,pageSize));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string nim)
        {
            var mahasiswa = await dbContext.Mahasiswas.FindAsync(nim);
            return View(mahasiswa);
    }

        [HttpPost]
        public async Task<IActionResult> Edit(Mahasiswa viewModel)
        {
            var mahasiswa = await dbContext.Mahasiswas.FindAsync(viewModel.Nim);

            if(mahasiswa is not null)
            {
                mahasiswa.Nama_Mhs = viewModel.Nama_Mhs;
                mahasiswa.Tgl_lahir = viewModel.Tgl_lahir;
                mahasiswa.Alamat = viewModel.Alamat;
                mahasiswa.Jenis_Kelamin = viewModel.Jenis_Kelamin;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Mahasiswa");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Mahasiswa viewMode)
        {
            var mahasiswa = await dbContext.Mahasiswas.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nim == viewMode.Nim);

            if (mahasiswa is not null)
            {
                dbContext.Mahasiswas.Remove(viewMode);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Mahasiswa");
        }
    }
}
