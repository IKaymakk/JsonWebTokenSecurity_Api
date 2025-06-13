🔐 JsonWebTokenSecurity API (.NET 8)
JsonWebTokenSecurity, modern web uygulamalarında kimlik doğrulama ve yetkilendirme işlemlerini güvenli ve ölçeklenebilir şekilde gerçekleştirmek üzere geliştirilmiş bir .NET Core 8 Web API projesidir. Bu projede, kullanıcı doğrulama süreçleri tamamen JWT (JSON Web Token) altyapısı üzerinden gerçekleştirilir.

🎯 Proje Amacı
Bu proje, güvenli API erişimi için token tabanlı bir kimlik doğrulama sistemini sıfırdan inşa etmeyi amaçlamaktadır. Modern mikroservis yapılarında kullanılan JWT sistemi, doğru kurgulandığında hem performanslı hem de güvenli bir oturum yönetimi sağlar. Bu projede:

Giriş (Login) işlemlerinde access token ve refresh token üretimi

Token geçerlilik kontrolleri

Korunan endpoint’lere token ile erişim

Kullanıcı rollerine göre yetkilendirme işlemleri
başarıyla uygulanmıştır.

⚙️ Kullanılan Teknolojiler
Teknoloji	Açıklama
.NET 8 Web API	En güncel .NET Core sürümü
Entity Framework Core	MSSQL ile veri erişimi
JWT (System.IdentityModel.Tokens.Jwt)	Token üretimi ve doğrulama
MSSQL	Kullanıcı verilerinin saklandığı veri tabanı
Postman	API testleri ve doğrulama işlemleri

🔐 Uygulanan Güvenlik Akışı
Kullanıcı giriş yapar → POST /login

Doğru bilgiler ile token üretilir (access + refresh)

Token taşıyan kullanıcı, [Authorize] olan endpoint’lere erişebilir

Token süresi dolduğunda, refresh token ile yeni token alınabilir

Geçersiz token durumunda API koruma sağlar

📁 Proje Yapısı
Controllers/ → Giriş ve yetkilendirme işlemleri

Models/ → DTO ve Entity tanımları

Services/ → Token üretimi, doğrulama, kullanıcı işlemleri

Configuration/ → Token ayarları ve kimlik doğrulama yapılandırması

🧪 Test Süreci
Tüm endpoint'ler Postman üzerinden test edilmiş olup:

Token üretimi

Token ile erişim

Yetkisiz erişim denetimi

Token yenileme (refresh) işlemleri
başarıyla doğrulanmıştır.
