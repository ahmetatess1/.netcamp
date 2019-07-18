using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NetCampWeb.Models.Entities
{
    public class Ogrenci
    {
        public long Id { get; set;}
        [Required]
        [MaxLength(10,ErrorMessage ="Kullanıcı Adı Maksimum 10 karakter olabilir")]
        [MinLength(3,ErrorMessage ="Kullanıcı Adı Minimum 3 karakter olabilir")]
        public string KullaniciAdi { get; set; }
        [Required]
        public string Parola { get; set; }    
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int Yasi { get; set; }
    }
}
