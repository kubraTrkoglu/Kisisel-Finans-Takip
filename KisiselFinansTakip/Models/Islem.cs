namespace KisiselFinansTakip.Models
{
    public class Islem
    {
        public int Id { get; set; }
        public int Kategori_Id { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Tarih { get; set; }
        public string Aciklama { get; set; }

        // Arayüzde (HTML) kategorinin adını göstermek için kullanacağım ekstra bir özellik
        public string KategoriAdi { get; set; }
        public string Tip { get; set; }
    }
}
