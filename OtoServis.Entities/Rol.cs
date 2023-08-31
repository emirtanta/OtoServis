﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities
{
    public class Rol:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz")]
        [StringLength(50)]
        [Display(Name = "Adı")]
        public string Adi { get; set; }
    }
}
