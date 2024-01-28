using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models.Entities
{
    public class Dosen
    {
        public Dosen()
        {
            Nip = GenerateUniqueNip();
        }
        [Key, MaxLength(12)]
        public string Nip { get; set; }

        [MaxLength(25)]
        public string Nama_Dosen { get; set; }
        public virtual Kuliah Kuliah { get; set; }

        private string GenerateUniqueNip()
        {
            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 8);

            return uniquePart.Substring(0, Math.Min(uniquePart.Length, 12));
        }
    }
}
