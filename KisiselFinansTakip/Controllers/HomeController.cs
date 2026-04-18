using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Dapper;
using KisiselFinansTakip.Models;

namespace KisiselFinansTakip.Controllers
{
    public class HomeController : Controller
    {
        // appsettings.json içine yazdýðýmýz baðlantý adresini buraya alýyoruz
        private readonly string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // 1. Ýþlemleri ve Kategori adlarýný veritabanýndan çekiyoruz (JOIN sihirbazlýðý)
                string sql = @"
                    SELECT i.Id, i.Miktar, i.Tarih, i.Aciklama, 
                           k.Ad AS KategoriAdi, k.Tip 
                    FROM Islemler i 
                    INNER JOIN Kategoriler k ON i.kategori_id = k.id 
                    ORDER BY i.tarih DESC";

                // Dapper tek satýrda bu karmaþýk SQL'i çalýþtýrýp bizim C# listemize dönüþtürüyor!
                var islemler = connection.Query<Islem>(sql).ToList();

                // 2. Üst taraftaki özet kartlar için toplam gelir ve gideri hesaplýyoruz
                // Eðer hiç veri yoksa hata vermemesi için COALESCE(SUM(), 0) kullanýyoruz.
                ViewBag.ToplamGelir = connection.ExecuteScalar<decimal>(
                    "SELECT COALESCE(SUM(miktar), 0) FROM Islemler i JOIN Kategoriler k ON i.kategori_id = k.id WHERE k.tip = 'Gelir'");

                ViewBag.ToplamGider = connection.ExecuteScalar<decimal>(
                    "SELECT COALESCE(SUM(miktar), 0) FROM Islemler i JOIN Kategoriler k ON i.kategori_id = k.id WHERE k.tip = 'Gider'");

                ViewBag.NetBakiye = ViewBag.ToplamGelir - ViewBag.ToplamGider;

                // Çektiðimiz listeyi HTML sayfasýna gönderiyoruz
                return View(islemler);
            }


        }
        // 1. Yeni Ekle Sayfasýný Açarken Çalýþan Kod (GET)
        [HttpGet]
        public IActionResult Ekle()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Formdaki açýlýr listeye (dropdown) kategorileri göndermemiz lazým
                var kategoriler = connection.Query<Kategori>("SELECT * FROM Kategoriler ORDER BY Ad").ToList();
                ViewBag.Kategoriler = kategoriler;
                return View();
            }
        }

        // 2. Form Doldurulup 'Kaydet'e Basýldýðýnda Çalýþan Kod (POST)
        [HttpPost]
        public IActionResult Ekle(Islem yeniIslem)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string sql = @"
                    INSERT INTO Islemler (Kategori_Id, Miktar, Aciklama) 
                    VALUES (@Kategori_Id, @Miktar, @Aciklama)";

                // Dapper, formdan gelen 'yeniIslem' içindeki verileri @ parametreleriyle otomatik eþleþtirir
                connection.Execute(sql, yeniIslem);

                // Ýþlem bitince ana sayfaya (Index) geri dön
                return RedirectToAction("Index");
            }
        }
    }
}