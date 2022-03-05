namespace LatihanSoalAPI.Model
{
    public class MsPelanggan
    {
        public int Id { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public string? NoTelp { get; set; }
        public List<Transaksi>? Transaksi { get; set; }
    }
}
