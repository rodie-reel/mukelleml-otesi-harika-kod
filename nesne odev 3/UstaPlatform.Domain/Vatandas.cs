using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public class Vatandas
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        
        public  DateTime KayitZamani { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} | AD: {Ad} | SOYAD: {Soyad}";
        }

    }
}
