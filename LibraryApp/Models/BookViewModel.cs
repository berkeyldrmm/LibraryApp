namespace LibraryApp.Models
{
    //Kitap kaydedilirken sadece isim ve yazar bilgisi direkt olarak alınır.
    //Bu bilgileri karşılayabilmesi için bu viewModel sınıfı oluşturuldu.
    public class BookViewModel
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
    }
}
