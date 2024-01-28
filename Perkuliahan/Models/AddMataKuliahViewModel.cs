using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models
{
    public class AddMataKuliahViewModel
    {
        [StringLength(25)]
        public string Nama_MK { get; set; }

        [Range(0, 99)]
        public int Sks { get; set; }
    }
}