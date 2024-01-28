using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models.Entities
{
    public class MataKuliah
    {

        public MataKuliah()
        {
            Kode_MK = GenerateUniqueMK();
        }
        [Key]
        [StringLength(6)]
        public string Kode_MK { get; set; }

        [StringLength(25)]
        public string Nama_MK { get; set; }

        [Range(0, 99)]
        public int Sks { get; set; }
        public virtual ICollection<Kuliah> Kuliahs { get; set; }

        private string GenerateUniqueMK()
        {
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 8);

            return uniquePart.Substring(0, Math.Min(uniquePart.Length, 6));
        }
    }
}
