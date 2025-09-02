Uygulama katmanlı mimariye sahip.


Application, Domain ve Infrastructure uygulamanın çekirdeğini oluşturur. 

Bu çekirdek; API, Worker, Console v.b. dışa açılacak uygulamalara hizmet eder. Dışa açılacak uygulamalar (API v.b.) tarafından ihtiyaç duyulabilecek transactional işlemleri yönetebilmek için UnitOfWork desenini uyguladım.