# fordintern-homework-2-Yunus3mre
fordintern-homework-2-Yunus3mre created by GitHub Classroom

Account ve Person adında iki adet Entity mevcut.
Bunlar arasında bire-çok ilişki var.Öyle ki bir Account entity'si birden fazla Person'a sahib olabilir.
İki adet account tipi var:admin,viewer
Kullanıcılar kendi tiplerine göre belirli apilere istek atabiliyor ve belirli dönütlere sahip olabiliyor.
Mesela Account içerisinde bulunana POST değeri sadece admin tipli kullanıcılar tarafından çağrılabiliyor.
Son olarak da tüm apiler authorize olmuş kullanıcılar tarafından çağrılabiliyor.
