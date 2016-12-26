using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uygulama.Models
{
    public class User
    {
        [DisplayName("Ad"), Required(), MinLength(2), MaxLength(30), RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf girişi yapınız ve Türkçe karakter kullanmayınız!")]
        public string Name { get; set; }
        [DisplayName("Soyad"), Required(), MinLength(2), MaxLength(30), RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Lütfen sadece harf girişi yapınız ve Türkçe karakter kullanmayınız!")]
        public string Surname { get; set; }
        [DisplayName("Mail"), Required(), MaxLength(40), EmailAddress()]
        public string Email { get; set; }
        [DisplayName("Telefon"), Required(), StringLength(10, ErrorMessage = "Lütfen numaranızın başına sıfır eklemeyiniz."), DataType(DataType.PhoneNumber), Range(5000000000, 5999999999, ErrorMessage = "Gerçek bir telefon numarası giriniz!")]
        public string Phone { get; set; }
        [DisplayName("Yaş"), Range(1, 100)]
        public int Age { get; set; }
        [DisplayName("Cinsiyet"), Required(), StringLength(5, ErrorMessage = "Yanlış değer giriyorsunuz!")]
        public string Gender { get; set; }
    }
}