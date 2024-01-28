using Perkuliahan.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models
{
    public class AddMahasiswaViewModel
    {
        public string Nama_Mhs { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tgl_lahir { get; set; }

        [StringLength(50)]
        public string Alamat { get; set; }

        [EnumDataType(typeof(JenisKelaminEnum))]
        public JenisKelaminEnum Jenis_Kelamin { get; set; }
    }
}
