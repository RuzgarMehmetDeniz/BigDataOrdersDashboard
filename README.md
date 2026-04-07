# Büyük Veri Analitiği Projesi

Bu proje, **SQL tabanlı veri yönetimi, makine öğrenimi ve Hugging Face entegrasyonu** ile büyük veri analitiği ve raporlama platformudur. Yaklaşık **500.000 satırlık veri seti** üzerinde çalışır ve müşteriler, siparişler, ürünler, kategoriler ve ülkelere göre detaylı analizler yapabilir. Ayrıca, proje DTO yapıları ile veri katmanları arasında güvenli ve optimize veri taşır.

---

## 🚀 Proje Amacı
- Büyük veri setleri üzerinde **veri analizi ve raporlama** yapmak  
- Zaman serisi verileri ve Hugging Face modelleri ile **günlük ve haftalık sipariş tahminleri** üretmek  
- Ürün ve kategori bazlı **istatistiksel analizler** ile işletme kararlarını desteklemek  
- DTO kullanımı ile veri katmanları arasında **güvenli ve optimize veri aktarımı** sağlamak  

---

## 🗂️ Veri Seti ve DTO Kullanımı

Projede veriler **DTO (Data Transfer Object) yapıları** ile taşınır. Bu sayede hem veri güvenliği sağlanır hem de gereksiz veri yükü azaltılır. Kullanılan DTO’lar:  

- **ChartDtos:** Grafik ve raporlama verileri için  
- **CustomerDtos:** Müşteri bilgileri ve sipariş geçmişi  
- **ForecastDtos:** Zaman serisi tahmin verileri ve ML çıktıları  
- **LoyaltyDtos:** Müşteri sadakat puanları ve ilişkili bilgiler  
- **LoyaltyMLDtos:** Makine öğrenimi çıktıları  
  - `LoyaltyScoreMLDataDto` – Tahmin için veri girişi  
  - `LoyaltyScoreMLPredictionDto` – Tahmin sonucu  
  - `ResultLoyaltyScoreMLDto` – Tahmin sonuçlarının işlenmiş hali  

---

## 💡 Projede Gerçekleştirilen İşler

### SQL ve Veri Yönetimi
- İlişkisel veritabanı tasarımı ve normalizasyon  
- CRUD operasyonları ve hızlı veri sorguları  
- Kategori, ürün ve müşteri bazlı detaylı raporlar  
- Büyük veri setlerinde performans optimizasyonu  

### Makine Öğrenimi ve Hugging Face
- **Zaman serisi tahminleri** için Microsoft.ML.TimeSeries kullanımı  
- **Hugging Face** ile NLP tabanlı veri analizleri ve hazır ML modelleri  
- Günlük sipariş tahmini, trend analizi ve talep öngörüsü  
- Müşteri segmentasyonu ve satın alma davranış tahmini  

### İstatistiksel Analizler ve Raporlama
- Ürün ve kategori performans ölçümü  
- Ülke bazlı sipariş yoğunluğu ve dağılım analizi  
- Ortalama sipariş miktarı, toplam gelir ve trend takibi  
- Grafik ve tablo tabanlı görselleştirme  

---

## 🧠 Kullanılan Teknolojiler ve Paketler

| Paket / Teknoloji | Versiyon | Kullanım Amacı |
|------------------|----------|----------------|
| Microsoft.EntityFrameworkCore | 8.0.25 | ORM ile veri tabanı işlemleri |
| Microsoft.EntityFrameworkCore.SqlServer | 8.0.25 | SQL Server bağlantısı |
| Microsoft.EntityFrameworkCore.Tools | 8.0.25 | Migration ve araç desteği |
| Microsoft.ML.TimeSeries | 5.0.0 | Zaman serisi tahminleri |
| Microsoft.VisualStudio.Web.CodeGeneration.Design | 8.0.23 | Kod üretim araçları |
| Hugging Face Transformers | 5.x | NLP ve hazır ML modelleri kullanımı |
| DTO’lar (Chart, Customer, Forecast, Loyalty, LoyaltyML) | - | Veri katmanları arası güvenli ve optimize veri taşınması |

---

## 📊 Öne Çıkan Analizler ve Raporlar
- Ülke bazlı sipariş yoğunluğu ve dağılımı  
- Kategori ve ürün bazlı satış performansı  
- Günlük ve haftalık sipariş tahminleri  
- Müşteri segmentasyonu ve alışkanlık analizi  
- NLP tabanlı analizler ile müşteri yorum ve metin analizleri  
- DTO ile veri katmanları arası güvenli ve optimize veri aktarımı  

---

## 📌 Proje Notları
- Büyük veri setleri ile test edilmiş ve optimize edilmiştir  
- SQL + ML + Hugging Face + DTO entegrasyonu ile gerçek dünya senaryolarına uygundur  
- Veri analizi, raporlama ve tahminleme için kapsamlı bir çözüm sunar  
- İş zekası ve analitik karar destek sistemleri için uygundur  
- Hem teknik hem de iş analisti bakış açısıyla değerlendirilebilir

---
# ![Dashboard1](https://github.com/user-attachments/assets/eb2d61b5-ea14-4677-abb1-1ab023830222)

# ![Dashboard2](https://github.com/user-attachments/assets/86fab832-a337-4dd7-a474-1c6ec55a538a)

# ![CustomerAnalist](https://github.com/user-attachments/assets/f5c882c8-e57b-43ff-8dce-ed9a5f9b708b)

# ![Category](https://github.com/user-attachments/assets/e2f3a695-5b89-4bf2-ae15-d0b22b9e4835)

# ![Product](https://github.com/user-attachments/assets/f7b6b7ee-1be8-42a7-afa3-8b193f5da337)

# ![Orders](https://github.com/user-attachments/assets/b26455af-f8f6-4008-83e1-b1da47cf869f)

# ![Statistics](https://github.com/user-attachments/assets/b3715bb8-2d08-40f5-8a6d-509cad88694e)

# ![Statistics2](https://github.com/user-attachments/assets/a52d3ff0-60fa-473f-8cfe-fb8a69772fd1)

# ![Forecast2](https://github.com/user-attachments/assets/b03a0c9c-c78f-4644-833c-753635935267)

# ![Forecast](https://github.com/user-attachments/assets/a4d4953d-078b-48c4-99e7-1b7c07195dae)

# ![Message](https://github.com/user-attachments/assets/e8a38eac-b41f-4f46-a3df-ca0762156253)

# ![Review](https://github.com/user-attachments/assets/80ccc2f6-3d0d-4978-96c9-ec3c1fd6204b)
