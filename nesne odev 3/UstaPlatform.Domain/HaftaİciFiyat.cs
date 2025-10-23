using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public class HaftaİciFiyat : Fiyat
    {
        public decimal SaatlikUcret { get; set; } = 100;
        public decimal hesapla()
        {
            return SaatlikUcret;
 
        }
    }
}
