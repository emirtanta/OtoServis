using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Servis:IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServiseGelisTarihi { get; set; }

        [Required(ErrorMessage = "{0} Boş bırakılamaz")]
        [Display(Name = "Araç Sorunu")]
        public string AracSorunu { get; set; }

        [Display(Name = "Servis Ücreti")]
        public decimal ServisUcreti { get; set; }

        [Display(Name = "Servisten Çıkış Tarihi")]
        public DateTime ServistenCikisTarihi { get; set; }

        [Display(Name = "Yapılan İşlemler")]
        public string? YapilanIslemler { get; set; }

        [Display(Name = "Garanti Kapsamında mı?")]
        public bool GarantiKapsamindaMi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(15)]
        [Display(Name = "Araç Plaka")]
        public string AracPlaka { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Marka")]
        public string Marka { get; set; }

        [StringLength(50)]
        [Display(Name = "Kasa Tipi")]
        public string? KasaTipi { get; set; }

        [StringLength(50)]
        [Display(Name = "Şase No")]
        public string? SaseNo { get; set; }

        [Required(ErrorMessage ="{0} boş bırakılamaz")]
        [StringLength(2000)]
        [Display(Name = "Notlar")]
        public string Notlar { get; set; }

    }
}
