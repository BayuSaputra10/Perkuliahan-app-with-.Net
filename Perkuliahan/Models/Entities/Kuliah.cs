using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models.Entities
{
    public class Kuliah
    {

        [Key]
        public int KuliahId { get; set; }

        [StringLength(9)]
        public string Nim { get; set; }

        [StringLength(6)]
        public string Kode_MK { get; set; }

        [StringLength(12)]
        public string Nip { get; set; }

        [StringLength(1)]
        public string Nilai { get; set; }


        [ForeignKey("Nim")]
        public virtual Mahasiswa Mahasiswa { get; set; }
        [ForeignKey("Kode_MK")]
        public virtual MataKuliah MataKuliah { get; set; }
        [ForeignKey("Nip")]
        public virtual Dosen Dosen { get; set; }
    }
}

