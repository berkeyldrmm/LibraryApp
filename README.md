Proje, bir kütüphanedeki kitapların takibini sağlamak amacıyla geliştirilmiş bir otomasyon uygulamasıdır.

Projede Asp.NET Core MVC, Entity Framework, HTML, CSS, Javascript, Jquery ve veritabanı tarafında Microsoft Sql Server (MsSql) araçları kullanılmıştır.
N katmanlı mimari kullanılarak geliştirilen uygulamada repository pattern uygulanarak tüm entity'lerin sahip olacağı metotlar tek bir yerde yazılmış ve her birine miras edilmiştir.

Kullanıcı girdilerini doğrulamak için Fluent Validation, loglama işlemleri için SeriLog kütüphaneleri kullanılmıştır.

Veritabanında öğrencilerin ve kitapların bulunduğu iki tane tablo vardır. Bu tablolar arasında bire çok ilişki kurulmuştur. Buna göre bir öğrenci birden fazla kitabı ödünç alabilirken, bir kitabı birden fazla öğrenci ödünç alamaz.

Veritabanında kaydı olan ve olmayan öğrenciler için iki farklı ödünç verme arayüzü vardır. Kayıtlı bir öğrenciye kitap vermek için öğrencinin mail adresi alınır ve kitap ve öğrenci arasında ilişki kurularak (foreign key aracılığıyla) kitap ödünç verilmiş olur. Kayıtlı olmayan, kütüphaneden ilk kez kitap alan bir öğrencinin isim soyisim mail ve opsiyonel olarak telefon numarası alınarak bir yandan öğrenciler tablosuna kaydı yapılırken (navigation property aracılığıyla) bir yandan aralarındaki ilişki de kurularak kitap ödünç verilmiş olur.

Yeni bir kitap eklenirken ismi veritabanında olan bir kitap eklenebilir çünkü aynı isimde farklı yazarlara ait kitaplar olabilir. Eğer ismi aynı olan bir veya daha fazla kayıt çıkarsa yazar isimleri kıyaslanır, eğer aynı değilse kaydedilir fakat eğer aynıysa aynı kitabın tekrar eklenemeyeceğiyle alakalı hata döndürülür.

Her öğrencinin mail adresi kendine özgü olmalıdır. Bu nedenle yeni öğrenciye kitap ödünç verilirken girilen mail adresine sahip bir öğrencinin olup olmadığı kontrol edilir. Eğer varsa hata döndürülür.

Tarih bilgisi o anki zamandan daha erken girilemez, girilirse hata döndürülür.

Hatalı endpoint'lere istek gönderilirse 404 sayfası, hatalı parametre gönderilirse hata mesajı döner.

Hem kitap ekleme hem de kitap ödünç verme sayfasında gerekli validasyonlar uygulanmıştır.

İncelediğiniz için teşekkür ederim.
