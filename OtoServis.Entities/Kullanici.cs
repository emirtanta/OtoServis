using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Kullanici:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Ad")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string Soyadi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Telefon")]
        public string? Telefon { get; set; }

        [StringLength(50)]
        [Display(Name = "Kullanıcı Adı")]
        public string? KullaniciAdi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool AktifMi { get; set; }

        [Display(Name = "Eklenme Tarihi")]
        [ScaffoldColumn(false)]
        public DateTime? EklenmeTarihi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Kullanıcı Rolü")]
        public int RolId { get; set; }

        public virtual Rol? Rol { get; set; }
        public Guid? UserGuild { get; set; }=Guid.NewGuid();
    }
}
