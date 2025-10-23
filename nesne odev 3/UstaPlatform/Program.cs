using System.Data.Common;
using System.Runtime.InteropServices;
using UstaPlatform.Domain;

namespace UstaPlatform
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            List<Usta> list1 = new List<Usta>();
            List<Vatandas> list2 = new List<Vatandas>();
            List<Cizelge> list3 = new List<Cizelge>();
            int secim = 0;
            while (secim != 5)
            {
                Console.WriteLine("---------------------------------- \n" +
                    "1 =) Usta Giris \n" +
                    "2 =) Vatandas Giris \n" +
                    "3 =) Talep Olusturma \n" +
                    "4 =) Degerlendirme \n" +
                    "5 =) Cikis \n" +
                    "Ne tur islem yapmak istiyorsunuz ? \n" +
                    "----------------------------------");
                secim = Convert.ToInt32(Console.ReadLine());
                if (secim == 1)
                {
                    int altsecim = 0;
                    Random random = new Random();   
                    while (altsecim != 4)
                    {
                        Console.WriteLine("---------------------------------- \n" +
                            "1 =) Yeni Usta Kayit \n" +
                            "2 =) Mevcut Ustalari Goster \n" +
                            "3 =) Aktif Usta Rotasi Goster \n" +
                            "4 =) Geri Don \n" +
                            "Devam edebilmek icin islem seciniz \n" +
                            "----------------------------------");
                        altsecim = Convert.ToInt32(Console.ReadLine());
                        if (altsecim == 1)
                        {
                            int id, puan;
                            string ad, soyad, uzmanlikalani, yetenek;
                            id = random.Next(0, 100);
                            Console.WriteLine("Usta'nin adini giriniz :");
                            ad = Console.ReadLine();
                            Console.WriteLine("Usta'nin soyadini giriniz :");
                            soyad = Console.ReadLine();
                            Console.WriteLine("Usta'nin uzmanlik alanini giriniz :");
                            uzmanlikalani = Console.ReadLine();
                            Console.WriteLine("Usta'nin yetenegini giriniz :");
                            yetenek = Console.ReadLine();
                            Usta usta1 = new Usta()
                            {
                                Id = id,
                                Ad = ad,
                                Soyad = soyad,
                                UzmanlikAlani = uzmanlikalani,
                                Yetenek = yetenek,
                                Yogunluk = false,
                                Puan = 0,
                                KayitZamani = DateTime.Now
                            };
                            list1.Add(usta1);
                            continue;
                        }
                        if (altsecim == 2)
                        {
                            if (list1.Count == 0)
                            {
                                Console.WriteLine("Henuz kayit yok....");
                            }
                            else
                            {
                                foreach (Usta i in list1)
                                {
                                    Console.WriteLine(i);
                                }
                            }
                        }
                        if (altsecim == 3)
                        {
                            int ustaId;
                            if (list1.Count != 0)
                            {
                                Console.WriteLine("Rotanizi Gormek İcin Usta Id'nizi giriniz :");
                                ustaId = Convert.ToInt32(Console.ReadLine());
                                if(list3.Count == 0)
                                {
                                    Console.WriteLine("Aktif bir rotaniz yok");
                                }
                                else
                                {
                                    foreach (Usta i in list1)
                                    {
                                        if (ustaId == i.Id)
                                        {
                                            foreach (Cizelge k in list3)
                                            {
                                                Console.WriteLine(k);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Id ile eslesen bir usta bulunamadi !!!");
                                        }
                                    }
                                }
                                    
                            }
                            else
                            {
                                Console.WriteLine("Henuz kayitli usta yok !!!");
                            }

                        }

                    }
                }
                if(secim == 2)
                {
                    int altsecim = 0;
                    Random random = new Random();
                    while (altsecim != 3)
                    {
                        Console.WriteLine("---------------------------------- \n" +
                            "1 =) Yeni Vatandas Kayit \n" +
                            "2 =) Mevcut Vatandaslari Goster \n" +
                            "3 =) Geri Don \n" +
                            "Devam edebilmek icin islem seciniz \n" +
                            "----------------------------------");
                        altsecim = Convert.ToInt32(Console.ReadLine());
                        if(altsecim == 1)
                        {
                            int id;
                            string ad, soyad, talep;
                            id = random.Next(0, 100);
                            Console.WriteLine("Ad'nizi giriniz :");
                            ad = Console.ReadLine();
                            Console.WriteLine("Soyad'inizi giriniz :");
                            soyad = Console.ReadLine();
                            Vatandas vatandas1 = new Vatandas()
                            {
                                Id = id,

                                Ad = ad,
                                Soyad = soyad
                            };
                            list2.Add(vatandas1);
                            continue;
                        }
                        if (altsecim == 2)
                        {
                            if (list2.Count == 0)
                            {
                                Console.WriteLine("Henuz kayit yok....");
                            }
                            else
                            {
                                foreach (Vatandas i in list2)
                                {
                                    Console.WriteLine(i);
                                }
                            }
                        }
                    }
                }
                if(secim == 3)
                {
                    int id, altsecim = 0, saat;
                    string istek, gun;
                    decimal toplamUcret = 0;
                    Console.WriteLine("Vatandaslik id'nizi giriniz ");
                    id = Convert.ToInt32(Console.ReadLine());
                    Vatandas Vbulunan = list2.FirstOrDefault(x => x.Id == id);
                    Talep talep = new Talep();
                    gun = talep.KayitZamani.ToString("dddd");
                    HaftaSonuFiyat sonFiyat = new HaftaSonuFiyat();
                    HaftaİciFiyat icFiyat = new HaftaİciFiyat();
                    Cizelge cizelge = new Cizelge();
                    if (Vbulunan == null)
                    {
                        Console.WriteLine("Id'niz herhangi bir kisiyle eslesemedi! Lutfen once kayit yaptiriniz!");
                    }
                    else
                    {
                        while (altsecim !=3)
                        {
                            Console.WriteLine("----------------------------------\n");
                            Console.WriteLine($"Hos geldin {Vbulunan.Ad} {Vbulunan.Soyad}!\n");
                            Console.Write("1 =) Mevcut Taleplerimi Goster \n" +
                                "2 =) Yeni Talep Olustur \n" +
                                "3 =) Geri Don \n");
                            altsecim = Convert.ToInt32(Console.ReadLine());
                            if (altsecim == 1)
                            {
                                if(list3.Count != 0)
                                {
                                    Console.WriteLine($"----------------------------------\n" +
                                        $"İsi yapicak ustanin adi : {cizelge.ustaAd} \n" +
                                        $"İsin tarihi : {cizelge.isZamani.ToString("dddd")} \n" +
                                        $"Ucret : {toplamUcret} \n" +
                                        $"----------------------------------\n");
                                }
                                else
                                {
                                    Console.WriteLine("----------------------------------\n" +
                                        "Henuz onceden olusturulmus bir talebiniz bulunmamaktadir !!!!");
                                }
                            }
                            if (altsecim == 2)
                            {
                                Console.WriteLine("Hangi konuda yardima ihtiyaciniz var?");
                                istek = Console.ReadLine();
                                List<Usta> ubulunanlar = list1
                                .Where(y => y.UzmanlikAlani.Equals(istek, StringComparison.OrdinalIgnoreCase))
                                .ToList();
                                if (list1.Count != 0)
                                {
                                    if (ubulunanlar.Count == 0)
                                    {
                                        Console.WriteLine("----------------------------------\n" +
                                            "Aradiginiz kritere uygun musait usta veya ustalar bulunamadi");
                                        break;
                                    }
                                    foreach (Usta ubulunan in ubulunanlar)
                                    {
                                        if (ubulunan.Yogunluk == false)
                                        {
                                            Console.WriteLine("---------------------------------- \n" +
                                                $"{istek} kriterine uygun usta: \n" +
                                                $"ID'si:{ubulunan.Id} \n" +
                                                $"Adi:{ubulunan.Ad} \n" +
                                                $"Soyadi: {ubulunan.Soyad} \n" +
                                                $"Uzmanlik alani: {ubulunan.UzmanlikAlani} \n" +
                                                $"Yetenegi: {ubulunan.Yetenek} \n" +
                                                $"Puani: {ubulunan.Puan} \n");
                                            if (gun == "Saturday")
                                            {
                                                Console.WriteLine($"Saatlik ucreti {sonFiyat.hesapla()}");
                                            }
                                            else if (gun == "Sunday")
                                            {
                                                Console.WriteLine($"Saatlik ucreti {sonFiyat.hesapla()}");
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Saatlik ucret {icFiyat.hesapla()}");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Aradiginiz kritere uygun musait usta veya ustalar bulunamadi");
                                            break;
                                        }
                                    }
                                    Console.WriteLine("---------------------------------- \n" +
                                        "Hangi ustayi secmek istiyorsan o ustanin Id'sini giriniz :");
                                    talep.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("---------------------------------- \n" +
                                        "İs suresini(tahmini saat) giriniz :");
                                    saat = Convert.ToInt32(Console.ReadLine());
                                    if (gun == "Cumartesi")
                                    {
                                        toplamUcret = saat * sonFiyat.hesapla();
                                    }
                                    else if (gun == "Pazar")
                                    {
                                        toplamUcret = saat * sonFiyat.hesapla();
                                    }
                                    else
                                    {
                                        toplamUcret = saat * icFiyat.hesapla();
                                    }
                                    foreach (Usta ubuluan in ubulunanlar)
                                    {
                                        int karar;
                                        if(talep.Id == ubuluan.Id)
                                        {
                                            Console.WriteLine("---------------------------------- \n" +
                                                $"{ubuluan.Ad} {ubuluan.Soyad} adli ustayi {toplamUcret} tl karsiliginda onaylıyor musunuz?\n" +
                                                $"1=) Evet \n" +
                                                $"2=) Hayir\n" +
                                                $"---------------------------------- \n");
                                            karar = Convert.ToInt32(Console.ReadLine());
                                            if(karar == 1)
                                            {
                                                cizelge.Id = ubuluan.Id;
                                                cizelge.isZamani = talep.KayitZamani;
                                                cizelge.ustaAd = ubuluan.Ad;
                                                cizelge.musteriAd = Vbulunan.Ad;
                                                list3.Add(cizelge);
                                                ubuluan.Yogunluk = true;
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Henuz kayitli usta yok !!!");
                                }
                            }
                        }
                        
                    }
                }
                if(secim == 4)
                {
                    if (list1.Count == 0)
                    {
                        Console.WriteLine("Degerlendirme yapilabilmesi icin once usta kaydi olmasi gerekir !!");
                    }
                    if (list2.Count == 0)
                    {
                        Console.WriteLine("Degerlendirme yapilabilmesi icin once vatandas kaydi olmasi gerekir !!");
                    }
                    if (list3.Count == 0)
                    {
                        Console.WriteLine("Degerlendirme yapilabilmesi icin once en az  bir kere talep olusturmali !!");
                    }
                    else if (list1.Count != 0 && list2.Count != 0 && list3.Count != 0)
                    {
                        foreach(Cizelge i in list3)
                        {
                            Usta hedefUsta = list1.FirstOrDefault(u => u.Id == i.Id);
                            if (hedefUsta != null)
                            {
                                int yeniPuan;
                                Console.WriteLine($"{i.isZamani:dddd} tarihli talebinizi 1(cok kotu) ila 5(cok iyi) arasinda degerlendiriniz: ");
                                yeniPuan = Convert.ToInt32(Console.ReadLine());
                                hedefUsta.Puan = yeniPuan;
                                Console.WriteLine("Degerlendirme yaptiginiz icin tesekkurler!");
                                hedefUsta.Yogunluk = false;
                            }
                        }
                    }
                }
            }
            return;
        }
    }
}
