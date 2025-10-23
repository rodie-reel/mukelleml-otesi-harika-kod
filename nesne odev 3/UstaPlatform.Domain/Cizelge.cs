using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain
{
    public class Cizelge
    {
        public int Id { get; set; }
        public string ustaAd { get; set; }
        public DateTime isZamani { get; set; }
        public string musteriAd { get; set; }
        public override string ToString()
        {
            
            return 
                $"İsin Tarihi : {isZamani.ToString("dddd")}\n" +
                $"Musterini Adi : {musteriAd}\n";
        }
    }
}
