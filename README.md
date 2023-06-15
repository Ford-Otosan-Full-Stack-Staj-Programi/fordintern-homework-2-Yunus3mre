[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/3bErTxjD)
# fordintern-homework-2-Yunus3mre
fordintern-homework-2-Yunus3mre created by GitHub Classroom

Account ve Person adında iki adet Entity mevcut.
Bunlar arasında bire-çok ilişki var.Öyle ki bir Account entity'si birden fazla Person'a sahib olabilir.
İki adet account tipi var:admin,viewer
Kullanıcılar kendi tiplerine göre belirli apilere istek atabiliyor ve belirli dönütlere sahip olabiliyor.
Mesela Account içerisinde bulunana POST değeri sadece admin tipli kullanıcılar tarafından çağrılabiliyor.
Son olarak da tüm apiler authorize olmuş kullanıcılar tarafından çağrılabiliyor.
