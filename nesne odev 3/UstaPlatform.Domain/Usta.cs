using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public class Usta
    {
        public int Id { get; init; }
        public string Ad { get; init; }
        public string Soyad { get; init; }
        public string UzmanlikAlani { get; set; }
        public string Yetenek { get; set; }
        public int Puan { get; set; }
        public bool Yogunluk { get; set; }
        public DateTime KayitZamani { get; init; } 

        public override string ToString()
        {
            return $"ID: {Id} | AD: {Ad} | SOYAD: {Soyad} | Uzmanlık: {UzmanlikAlani} | " +
                   $"Yetenek: {Yetenek} | Puan: {Puan} | " +
                   $"Yoğunluk: {(Yogunluk ? "Dolu" : "Müsait")}"; // ilk yazdigimizi 1 sonrakini 0 olarak algiliyor  biz basta yogunlugu false olarak verdik

        }
    }
}
