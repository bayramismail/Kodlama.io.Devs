# Domain Driven Design(DDD)

 Kompleks gereksinimlerin var olduğu bir dünyada, sürekli değişen temel business kurallarını birbirine derinlemesine bağlayan bir yazılım geliştirme yaklaşımıdır.
## Domain Driven Design’ın Kullanım Amaçları
   Sepetten sorumlu bir microservice, fatura işlemlerinden sorumlu bir microservice ve buna benzer yapılardan oluşan servislerde çok fazla business kuralları olabileceği için buradaki karmaşıklığı yönetebilmek ve kodlarımızı sürdürülebilir kılmak için bu yaklaşımı kullanabiliriz.
 Bir blog sitesi vb. yapılarda çok fazla business kuralı yer almayacağı için DDD yaklaşımını kullanmak gereksizdir.
 Makale ekleme, makaleleri listeleme vb. CRUD işlemler gerçekleştiği için çok fazla karmaşık bir yapı mevcut değildir ve buna rağmen DDD kullanırsanız kodunuzu aslında gereksiz yere karmaşık bir hale getireceksiniz.
## DDD (Odaklı Mikro Hizmet Tasarlama)

 . Etki alanı odaklı tasarım (DDD), kullanım örneklerinizle ilgili olarak işletmenin gerçekliğine göre modellemeyi destekler.
 DDD, uygulama oluşturma bağlamında sorunlardan etki alanı olarak bahseder. Bağımsız sorun alanlarını Sınırlanmış Bağlamlar olarak tanımlar (her Sınırlanmış Bağlam bir mikro hizmetle ilişkilendirilir) 
 ve bu sorunlar hakkında konuşmak için ortak bir dili vurgular. 
 . Bazen bu DDD teknik kuralları ve desenleri, DDD yaklaşımlarını uygulamak için dik bir öğrenme eğrisi olan engeller olarak algılanıyor. Ancak önemli olan, desenlerin kendisi değil, 
 kodu iş sorunlarıyla uyumlu olacak şekilde düzenlemek ve aynı iş terimlerini (her yerde kullanılan dil) kullanmaktır.
 
 ## DDD (Mikro Hizmetlerindeki Katmanlar)
 
  Önemli iş ve teknik karmaşıklığı olan çoğu kurumsal uygulama birden çok katmanla tanımlanır. Katmanlar mantıksal bir yapıttır ve hizmetin dağıtımıyla ilgili değildir.
  Geliştiricilerin koddaki karmaşıklığı yönetmesine yardımcı olmak için vardır. 
  Farklı katmanların (etki alanı modeli katmanıyla sunu katmanı gibi) farklı türleri olabilir ve bu türler arasında çevirileri zorunlu hale getirir.
 
          
 ![domain-driven-design-microservice](https://user-images.githubusercontent.com/83179561/190402680-f2c334af-6470-42bc-96c4-ffec4b1141fc.png)
                   
### Domain : 
Domain nesnelerinin doğal yapısına sığmayan işletme mantığını kapsar. Bunlar CRUD işlemleri değildir. CRUD işelmeri repository bünyesinde gelişir.

### Application :
Sistem dışı kullanıcılar için oluşturulur. Örneğin Web servisleri veya Web arayüzleri bu servislerle haberleşirler.
Kullanıcılara sunulan CRUD işlemleri burada tanımlanabilir.

### Infrastructure : 
 Dış kaynaklarla yapılan iletişimler için oluşturulur. (File, SMS, SMTP, MSMQ).
# Kaynak
   https://www.bayramucuncu.com/category/domain-driven-design/
   
   https://docs.microsoft.com/tr-tr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
