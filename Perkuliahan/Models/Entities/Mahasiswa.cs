using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Perkuliahan.Models.Entities
{
    public class Mahasiswa
    {
        [Key]
        [StringLength(9)]
        public string Nim { get; set; }
        public Mahasiswa()
        {
            Nim = GenerateUniqueNim();
        }

        [StringLength(25)]
        public string Nama_Mhs { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tgl_lahir { get; set; }

        [StringLength(50)]
        public string Alamat { get; set; }

        [EnumDataType(typeof(JenisKelaminEnum))]
        public JenisKelaminEnum Jenis_Kelamin { get; set; }
        public virtual ICollection<Kuliah> Kuliahs { get; set; }

        private string GenerateUniqueNim()
        {
            string yearPart = DateTime.Now.Year.ToString();

            string uniquePart = Guid.NewGuid().ToString("N").Substring(0, 4);

            string result = yearPart + uniquePart;

            return result.Substring(0, Math.Min(result.Length, 9));
        }
    }

    public enum JenisKelaminEnum
    {
        LakiLaki,
        Perempuan
    }



}
