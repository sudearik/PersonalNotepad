using NotDefteri.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotDefteri.Services
{
    public class NotServices
    {
        private List<Kategori> Kategoriler;
        private readonly string dosyaYolu;

        // 
        public NotServices(string filePath = "Data.json")
        {
            //bin klasörünü hedef alıyor
            dosyaYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
          
            VerileriGetir();
        }
        public List<Kategori> GetAllCategories()
        {
            return Kategoriler;
        }

        private void VerileriGetir()
        {
            if (File.Exists(dosyaYolu))
            {
                var json = File.ReadAllText(dosyaYolu);
                Kategoriler = JsonSerializer.Deserialize<List<Kategori>>(json) ?? new List<Kategori>();
            }
            else
            {
                Kategoriler = new List<Kategori>();
                SaveData();
            }
        }
        private void SaveData()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(Kategoriler, options);
            File.WriteAllText(dosyaYolu, json);
        }
        public void GuncelleNot(string kategoriName, string originalHeader, string newHeader, string newContent)
        {
            if (string.IsNullOrWhiteSpace(kategoriName))
                throw new ArgumentException("Kategori adı boş olamaz.");
            if (string.IsNullOrWhiteSpace(originalHeader))
                throw new ArgumentException("Orijinal başlık boş olamaz.");

            var kategori = Kategoriler
                .SingleOrDefault(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase));
            if (kategori == null)
                throw new Exception("Böyle bir kategori yok");

            var not = kategori.Notlar
                .SingleOrDefault(n => n.Baslik.Equals(originalHeader, StringComparison.OrdinalIgnoreCase));
            if (not == null)
                throw new Exception("Güncellenecek not bulunamadı.");

            // Başlık değiştiyse tekrar kontrol
            if (
                !originalHeader.Equals(newHeader, StringComparison.OrdinalIgnoreCase)
                &&
                kategori.Notlar.Any(n => n.Baslik.Equals(newHeader, StringComparison.OrdinalIgnoreCase)))
                    throw new Exception($"'{newHeader}' başlıklı bir not zaten mevcut.");

            // Güncelle
            not.Baslik = newHeader.Trim();
            not.İcerik = newContent;
            not.GuncellenmeTarihi = DateTime.Now;
            SaveData();
        }
       

     
        public void YeniNotOlustur(Not not, string kategoriName)
        {
            if (string.IsNullOrWhiteSpace(kategoriName))
                throw new ArgumentException("Kategori adı boş olamaz.");

            var kategori = Kategoriler.SingleOrDefault(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase));
            if (kategori == null)
            {
                kategori = new Kategori { KategoriAdi = kategoriName.Trim() };
                Kategoriler.Add(kategori);
            }

            // Aynı başlığa sahip not kontrolü
            if (kategori.Notlar.Any(n => n.Baslik.Equals(not.Baslik, StringComparison.OrdinalIgnoreCase)))
                throw new Exception($"'{not.Baslik}' başlıklı bir not zaten mevcut.");

            kategori.Notlar.Add(not);
            SaveData();
        }

        public void KategoriOlustur(string kategoriName)
        {
            if (string.IsNullOrWhiteSpace(kategoriName))
                throw new ArgumentException("Kategori adı boş olamaz.");

            if (Kategoriler.Any(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Bu isimde bir kategori zaten mevcut.");

            Kategoriler.Add(new Kategori { KategoriAdi = kategoriName.Trim() });
            SaveData();
        }

        public void NotSil(string notBaslik, string kategoriName)
        {
            if (string.IsNullOrEmpty(kategoriName) || string.IsNullOrEmpty(notBaslik))
                throw new ArgumentNullException("not ya da kategori adı boş geçilemez");

            var kategori = Kategoriler
                .SingleOrDefault(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase));
            if (kategori != null)
            {
                var not = kategori.Notlar
                    .SingleOrDefault(n => n.Baslik.Equals(notBaslik, StringComparison.OrdinalIgnoreCase));
                if (not != null)
                {
                    kategori.Notlar.Remove(not);
                    SaveData();
                }
            }
        }

        public void KategoriSil(string kategoriName)
        {
            var kategori = Kategoriler
                .SingleOrDefault(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase));
            if (kategori != null)
            {
                Kategoriler.Remove(kategori);
                SaveData();
            }
        }

        public List<Not> Ara(string kategoriName)
        {
            var kategori = Kategoriler
                .SingleOrDefault(k => k.KategoriAdi.Equals(kategoriName, StringComparison.OrdinalIgnoreCase));
            if (kategori == null)
                throw new Exception("Böyle bir kategori yok");

            return kategori.Notlar;
        }
        public List<Not> BasligaGoreAra(string header)
        {
            if (string.IsNullOrWhiteSpace(header))
                throw new ArgumentException("Arama terimi boş olamaz.");

            return Kategoriler
                .SelectMany(k => k.Notlar)
                .Where(n => n.Baslik.Contains(header, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }
}
