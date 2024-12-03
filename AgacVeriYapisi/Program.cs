using System;
// Bilgileri her classın üzerinde vereceğim.

// İkili Arama Ağacı
// Her düğümün bir sol ve bir sağ alt düğümü olduğu bir veri yapısıdır.
// Sol alt ağactaki tüm düğümler kök düğümden daha küçük değerleri içerir
// Sağ alt ağaçtaki tüm düğümler kök düğümden daha büyük değerleri içerir
// Veri sıralama, veri arama gibi alanlarda verilerin hızlı bir şekilde sıralanması ve aranması için kullanılır.
class IkiliAramaAgaci
{
    class Dugum
    {
        public int Veri;
        public Dugum Sol, Sag;

        public Dugum(int veri)
        {
            Veri = veri;
            Sol = Sag = null;
        }
    }

    Dugum kok;

    public void Ekle(int veri)
    {
        kok = EkleRec(kok, veri);
    }

    private Dugum EkleRec(Dugum kok, int veri)
    {
        if (kok == null)
            return new Dugum(veri);

        if (veri < kok.Veri)
            kok.Sol = EkleRec(kok.Sol, veri);
        else if (veri > kok.Veri)
            kok.Sag = EkleRec(kok.Sag, veri);

        return kok;
    }

    public void Gez()
    {
        GezRec(kok);
        Console.WriteLine();
    }

    private void GezRec(Dugum kok)
    {
        if (kok != null)
        {
            GezRec(kok.Sol);
            Console.Write(kok.Veri + " ");
            GezRec(kok.Sag);
        }
    }
}

// Kodlama Ağacı
// Kodlama Ağaçları genellikle Huffman Algoritması kullanılarak veri sıkıştırmada kullanılır.
// Her karakterin geçtiği sıklığa göre bir ağaç oluşturulur. 
// Düşük sıklıkta geçen karakterler daha uzun kodlarla, sık geçen karakterler daha kısa kodlarla temsil edilir.
// Veri sıkıştırma alanında kullanılır.
class KodlamaAgaci
{
    public void OrnekGoster()
    {
        Console.WriteLine("A -> 00");
        Console.WriteLine("B -> 01");
        Console.WriteLine("C -> 10");
    }
}

// Sözlük Ağacı
// Sözlük Ağaçları, genellikle kelime veya dizilerin hızlı bir şekilde aranması ve otomatik tamamlama gibi işlemler için kullanılır.
// Her düğüm bir harfi temsil eder ve kelimelerin sonu işaretlenir (Örneğin bir ağaçta yer alan elma ve el kelimeleri
// aynı kökten başlar bu durumda ayırt etmek için son düğümler işaretlenir el kelimesinde 'l' harfi elma kelimesinde 'a' harfi)
// Otomatik tamamlama ve kelime doğrulamada kullanılır. 
class SozlukAgaci
{
    string[] sozluk = { "elma", "armut", "erik" };

    public bool Ara(string kelime)
    {
        foreach (var item in sozluk)
        {
            if (item == kelime)
                return true;
        }
        return false;
    }
}

// Kümeleme Ağacı
// Kümeleme Ağacı, öncelikli kuyruk gibi veri yapılarında kullanılan özel bir ikili ağaçtır.
// Tam bir ikili ağaçtır (her seviyede düğümler tam doludur). Kökten başlayarak alt düğümlerle bir düzen oluşturur.
// Her düğümün belirli bir düzenle sıralandığı bir yapı sunar. Heap, Max Heap veya Min Heap olmak üzere ikiye ayrılır.
// Max Heap: Kök düğüm en büyük elemandır. Min Heap: Kök düğüm en küçük elemandır.
// Öncelik sırası ya da sıralama algoritmalarında (heap sort) kullanılır.
class KumelemeAgaci
{
    int[] dizi = new int[10];
    int boyut = 0;

    public void Ekle(int deger)
    {
        dizi[boyut] = deger;
        boyut++;
        Array.Sort(dizi, 0, boyut);
    }

    public int EnBuyuk()
    {
        return dizi[boyut - 1];
    }

    public int EnKucuk()
    {
        return dizi[0];
    }
}

class Program
{
    static void Main()
    {
        // İkili Arama Ağacı
        IkiliAramaAgaci ikiliAgac = new IkiliAramaAgaci();
        ikiliAgac.Ekle(50);
        ikiliAgac.Ekle(30);
        ikiliAgac.Ekle(70);
        Console.WriteLine("İkili Arama Ağacı:");
        ikiliAgac.Gez();

        // Kodlama Ağacı
        KodlamaAgaci kodlamaAgaci = new KodlamaAgaci();
        Console.WriteLine("\nKodlama Ağacı:");
        kodlamaAgaci.OrnekGoster();

        // Sözlük Ağacı
        SozlukAgaci sozlukAgaci = new SozlukAgaci();
        Console.WriteLine("\nSözlük Ağacı:");
        Console.WriteLine($"'elma' bulundu mu? {sozlukAgaci.Ara("elma")}");
        Console.WriteLine($"'muz' bulundu mu? {sozlukAgaci.Ara("muz")}");

        // Kümeleme Ağacı
        KumelemeAgaci kumelemeAgaci = new KumelemeAgaci();
        kumelemeAgaci.Ekle(10);
        kumelemeAgaci.Ekle(30);
        kumelemeAgaci.Ekle(20);
        Console.WriteLine("\nKümeleme Ağacı:");
        Console.WriteLine($"En büyük eleman: {kumelemeAgaci.EnBuyuk()}");
        Console.WriteLine($"En küçük eleman: {kumelemeAgaci.EnKucuk()}");
    }
}
