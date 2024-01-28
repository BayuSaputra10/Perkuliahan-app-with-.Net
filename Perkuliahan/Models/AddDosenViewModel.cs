using System.ComponentModel.DataAnnotations;

namespace Perkuliahan.Models
{
    public class AddDosenViewModel
    {
        [MaxLength(25)]
        public string Nama_Dosen { get; set; }
    }
}
