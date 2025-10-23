using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public class HaftaSonuFiyat : Fiyat
    {
        public int SaatlikUcret { get; set; } = 120;
        public decimal hesapla()
        {
            return SaatlikUcret;
        }
    }
}
