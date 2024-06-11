using System;
using System.Collections.Generic;
using System.IO;

public class Ev
{
    public int OdaSayisi { get; set; }
    public int KatNumarasi { get; set; }
    public int Alan { get; set; }

    public Ev(int odaSayisi, int katNumarasi, int alan)
    {
        OdaSayisi = odaSayisi;
        KatNumarasi = katNumarasi;
        Alan = alan;
    }
    
    public override string ToString()
    {
        return $"Oda Sayısı: {OdaSayisi}, Kat Numarası: {KatNumarasi}, Alan: {Alan} m²";
    }
}

public class KiralikEv : Ev
{
    public int Kira { get; set; }
    public int Depozito { get; set; }

    public KiralikEv(int odaSayisi, int katNumarasi, int alan, int kira, int depozito)
        : base(odaSayisi, katNumarasi, alan)
    {
        Kira = kira;
        Depozito = depozito;
    }

    public override string ToString()
    {
        return $"Kiralık Ev -> {base.ToString()}, Kira: {Kira}, Depozito: {Depozito}";
    }
}

public class SatilikEv : Ev
{
    public int Fiyat { get; set; }

    public SatilikEv(int odaSayisi, int katNumarasi, int alan, int fiyat)
        : base(odaSayisi, katNumarasi, alan)
    {
        Fiyat = fiyat;
    }

    public override string ToString()
    {
        return $"Satılık Ev -> {base.ToString()}, Fiyat: {Fiyat}";
    }
}

class Program
{
    static List<Ev> evler = new List<Ev>();
    static string dosyaAdi = "evler.txt";

    static void EvBilgileriniKaydet(Ev ev)
    {
        using (StreamWriter writer = new StreamWriter(dosyaAdi, true))
        {
            writer.WriteLine(ev.ToString());
        }
    }

    static void KiralikEvGirisi()
    {
        Console.Write("Evin oda sayısı: ");
        int odaSayisi = int.Parse(Console.ReadLine());
        Console.Write("Evin kat numarası: ");
        int katNumarasi = int.Parse(Console.ReadLine());
        Console.Write("Evin alanı (m²): ");
        int alan = int.Parse(Console.ReadLine());
        Console.Write("Evin kirası: ");
        int kira = int.Parse(Console.ReadLine());
        Console.Write("Evin depozitosu: ");
        int depozito = int.Parse(Console.ReadLine());

        KiralikEv kiralikEv = new KiralikEv(odaSayisi, katNumarasi, alan, kira, depozito);
        evler.Add(kiralikEv);
        EvBilgileriniKaydet(kiralikEv);
        Console.WriteLine("Girilen ev bilgileri kaydedildi.");
    }

    static void SatilikEvGirisi()
    {
        Console.Write("Evin oda sayısı: ");
        int odaSayisi = int.Parse(Console.ReadLine());
        Console.Write("Evin kat numarası: ");
        int katNumarasi = int.Parse(Console.ReadLine());
        Console.Write("Evin alanı (m²): ");
        int alan = int.Parse(Console.ReadLine());
        Console.Write("Evin fiyatı: ");
        int fiyat = int.Parse(Console.ReadLine());

        SatilikEv satilikEv = new SatilikEv(odaSayisi, katNumarasi, alan, fiyat);
        evler.Add(satilikEv);
        EvBilgileriniKaydet(satilikEv);
        Console.WriteLine("Girilen ev bilgileri kaydedildi.");
    }

    static void KayitliEvleriGoster()
    {
        if (!File.Exists(dosyaAdi))
        {
            Console.WriteLine("Kayıtlı ev yok.");
            return;
        }

        using (StreamReader reader = new StreamReader(dosyaAdi))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1-Kiralık ev");
            Console.WriteLine("2-Satılık ev");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.WriteLine("1-Kayıtlı ev görüntüleme");
                Console.WriteLine("2-Yeni ev girişi");
                Console.Write("Seçiminiz: ");
                string altSecim = Console.ReadLine();

                if (altSecim == "1")
                {
                    KayitliEvleriGoster();
                }
                else if (altSecim == "2")
                {
                    KiralikEvGirisi();
                }
            }
            else if (secim == "2")
            {
                Console.WriteLine("1-Kayıtlı ev görüntüleme");
                Console.WriteLine("2-Yeni ev girişi");
                Console.Write("Seçiminiz: ");
                string altSecim = Console.ReadLine();

                if (altSecim == "1")
                {
                    KayitliEvleriGoster();
                }
                else if (altSecim == "2")
                {
                    SatilikEvGirisi();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim.");
            }
        }
    }
}
