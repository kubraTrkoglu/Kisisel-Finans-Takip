# 📊 Kişisel Finans ve Gider Takip Sistemi

Kişisel gelir ve giderlerinizi kolayca takip edebileceğiniz, net bakiyenizi hesaplayan ve harcamalarınızı kategorize eden dinamik bir web uygulamasıdır. 
Bu proje, MVC mimarisi kullanılarak geliştirilmiş olup, veritabanı işlemleri için mikro-ORM aracı olan Dapper tercih edilerek yüksek performans hedeflenmiştir.

## 🚀 Kullanılan Teknolojiler

* Backend: C#, ASP.NET Core MVC 8.0
* Veritabanı: MySQL
* ORM: Dapper (Hızlı ve güvenli SQL sorguları için)
* Frontend: HTML5, CSS3, Bootstrap 5
* Mimari: N-Tier & MVC Pattern

## ✨ Özellikler

* Dinamik Dashboard:Toplam gelir, toplam gider ve anlık net bakiyeyi tek ekranda görüntüleme.
<img width="1692" height="357" alt="Ekran görüntüsü 2026-04-18 151421" src="https://github.com/user-attachments/assets/bd0d26ec-90f0-4c99-beb3-16f6be1cf08e" />

* Kategori Yönetimi: İşlemleri 'Gelir' veya 'Gider' olarak dinamik kategorilere ayırma (Maaş, Market, Fatura vb.).
  
* Hızlı Veri Girişi: Kullanıcı dostu form arayüzü ile anında yeni işlem ekleme.
 <img width="1137" height="694" alt="Ekran görüntüsü 2026-04-18 151213" src="https://github.com/user-attachments/assets/b1c77ed0-cbb0-4774-9143-658420115c60" />
<img width="1303" height="914" alt="Ekran görüntüsü 2026-04-18 151145" src="https://github.com/user-attachments/assets/44e07bae-5ddb-4d0f-bdc1-023d95d9024b" />
<img width="1296" height="911" alt="Ekran görüntüsü 2026-04-18 151117" src="https://github.com/user-attachments/assets/02a9af02-c9c4-4a3b-ad2f-22f5b6e5639a" />

* İlişkisel Veritabanı: Veri tekrarını önleyen (Normalizasyon) Foreign Key destekli sağlam veritabanı mimarisi.
