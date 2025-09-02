Solution klasörü altında .env dosyasında;
API uygulamasının ayağa kalkacağı port,
mssql'in ayağa kalkacağı port,
mssql için 'sa' kullanıcısının parolası
yer alıyor. Dilerseniz sadece .env dosyasında değişiklik yaparak uygulamayı ayağa kaldırabilirsiniz.

Projeyi ve Mssql'i ayağa kaldırmak için; docker yüklü sisteminizde, terminal ile Solution klasörüne(ECom) giderek
(docker-compose up --build)
komutunu çalıştırmanız yetecektir.

BaseUrl'den(mevcutta http://localhost:4400) swagger dökümanlarına ulaşabilirsiniz.

Docker içinde development sertifikası oluşturmadığım için sadece http kullanılıyor.