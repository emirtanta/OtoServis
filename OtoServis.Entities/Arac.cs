using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Arac:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Marka Adı")]
        public int MarkaId { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Renk")]
        [StringLength(50)]
        public string Renk { get; set; }

        [Display(Name = "Fiyatı")]
        public decimal Fiyati { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Modeli")]
        [StringLength(50)]
        public string Modeli { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Kasa Tipi")]
        [StringLength(50)]
        public string KasaTipi { get; set; }

        [Display(Name = "Model Yılı")]
        public int ModelYili { get; set; }

        [Display(Name = "Satışta mı?")]
        public bool SatistaMi { get; set; }

        [Display(Name = "Anasayfa?")]
        public bool Anasayfa { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Notlar")]
        [StringLength(1000)]
        public string Notlar { get; set; }

        [Display(Name = "Resim1")]
        [StringLength(500)]
        public string? Resim1 { get; set; }

        [Display(Name = "Resim2")]
        [StringLength(500)]
        public string? Resim2 { get; set; }

        [Display(Name = "Resim3")]
        [StringLength(500)]
        public string? Resim3 { get; set; }

        //araç sınıfı ile Marka sınıfı arasındaki bağlantı
        public virtual Marka? Marka { get; set; }
    }
}
