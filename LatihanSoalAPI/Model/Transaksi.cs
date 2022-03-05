namespace LatihanSoalAPI.Model
{
    public class Transaksi
    {
        public int Id { get; set; }
        public string? KodeTransaksi { get; set; }
        public DateTime Tanggal { get; set; }
        public int PelangganId { get; set; }
        public MsPelanggan Pelanggan { get; set; }
        public List<TransaksiDetail>? TransaksiDetail { get; set; }
        public decimal Total { get; set; }
    }
}
