using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Musteri:IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Araç")]
        public int AracId { get; set; }

        [Required(ErrorMessage ="{0} boş bırakılamaz")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Adi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Soyadi { get; set; }

        [Display(Name = "Tc Kimlik Numarası")]
        [StringLength(11)]
        public string? TcNo { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        [StringLength(500)]
        public string? Adres { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(15)]
        public string? Telefon { get; set; }

        [Display(Name = "Notlar")]
        [StringLength(500)]
        public string? Notlar { get; set; }

        [Display(Name = "Araç")]
        public virtual Arac? Arac { get; set; }
    }
}
