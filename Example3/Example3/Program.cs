using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        public class AccountObj
        {
            public string HesapNo { get; set; }
            public int Sayi { get; set; }
        };

        static void Main(string[] args)
        {

            Console.WriteLine("Kaç Adet Hesap Numarası Grubu İstersin? (Max 5)");
            int group_sayisi = Convert.ToInt16(Console.ReadLine());
            
            for(int z = 0; z < 1;)
            {
                if (group_sayisi > 5)
                {
                    Console.WriteLine("Max 5 Girebilirsiniz!");
                     group_sayisi = Convert.ToInt16(Console.ReadLine());
                }                    
                else 
                    z = 1; 
            }

            for (int g = 1; g <= group_sayisi; g++)
            {
                Console.WriteLine("---------");
                Console.WriteLine(g + ".Grup Kaç Adet Banka Hesap Numarasına Sahip Olsun?");
                //Console.Write("Değer boyutunu giriniz = ");

                int boyut = int.Parse(Console.ReadLine());

                string[] hesNoArray = new string[boyut];

                for (int i = 0; i < hesNoArray.Length; i++)
                {                   
                    Console.Write("Banka Hesap Numarası Giriniz = ");

                    hesNoArray[i] = Console.ReadLine();
                    for (int z = 0; z < 1;)
                    {
                        if (hesNoArray[i].Length > 26)
                        {
                            Console.WriteLine("Max 26 karakter girebilirsiniz!");
                            hesNoArray[i] = Console.ReadLine();
                        }
                        else
                            z = 1;
                    }


                }
                Array.Sort(hesNoArray);

                string oncekihesNo = null;
                int count = 0;
                var ayniHesnoGruplu = new List<AccountObj>();

                foreach (var sayi in hesNoArray)
                {
                    var hesapCounter = new AccountObj();
                    hesapCounter.HesapNo = sayi.ToString();
                    hesapCounter.Sayi = 1;
                    if (oncekihesNo == sayi)
                    {
                        var oncekiObj = ayniHesnoGruplu.Where(x => x.HesapNo == oncekihesNo).First();
                        hesapCounter.Sayi = oncekiObj.Sayi;
                        ayniHesnoGruplu.Remove(oncekiObj);

                        hesapCounter.Sayi++;
                    }
                    else
                    {
                        hesapCounter.Sayi = 1;
                    }
                    ayniHesnoGruplu.Add(hesapCounter);
                    oncekihesNo = sayi;
                }
                //var hesNoList = ayniSayilar.Select(x => x.HesapNo).ToList() ;
                Console.WriteLine("---------------");
                foreach (var gruplananHesaplar in ayniHesnoGruplu)
                {
                    Console.WriteLine($"{ gruplananHesaplar.HesapNo} - { gruplananHesaplar.Sayi}" );

                }


            }

            Console.ReadKey();

        }
    }
}