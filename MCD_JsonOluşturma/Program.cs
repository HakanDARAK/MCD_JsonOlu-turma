using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MCD_JsonOluşturma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Personel> Personellerim = new List<Personel>();
            for (int i = 0; i < 1000; i++)
            {
                Personel P1 = new Personel();
                P1.ID=Guid.NewGuid();
                P1.Isim = FakeData.NameData.GetFirstName();
                P1.Soyisim=FakeData.NameData.GetSurname();
                P1.EmailAdres = $"{P1.Isim}.{P1.Soyisim}@{FakeData.NetworkData.GetDomain()}";
                P1.TelefonNumarasi = FakeData.PhoneNumberData.GetPhoneNumber();
                P1.Sehir = FakeData.PlaceData.GetCity();
                Personellerim.Add(P1);
            }

            Console.WriteLine("Bilgileriniz Json formatında kayıt edilecektir.");
            System.Threading.Thread.Sleep(1000);
            if (Directory.Exists("e:\\JsonIslemlerim\\"))
            {
                Console.WriteLine("Klasör var");
            }
            else
            {
                Directory.CreateDirectory("c:\\JsonIslemlerim\\");
            }
            string JsonPersonellerim = Newtonsoft.Json.JsonConvert.SerializeObject(Personellerim);
            File.WriteAllText("c:\\JsonIslemlerim\\Personellerim.json", JsonPersonellerim);
        }
    }
}
