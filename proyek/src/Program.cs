
namespace Proyek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Makanan makanan = new Makanan("Nasi Goreng", 15000, 5);
            Minuman minuman = new Minuman("Es Teh", 5000, 10);
            PaketHemat paket = new PaketHemat("Paket Hemat", 20000, 10, 3000);

            Pesanan pesanan = new Pesanan();

            pesanan.TambahProduk(makanan, 1);
            pesanan.TambahProduk(minuman, 2);
            pesanan.TambahProduk(paket, 1);

            Kasir kasir = new Kasir(new DiskonMahasiswa());

            Console.WriteLine("=== DEMO KASIR KANTIN ===");

            using (PenyimpananPesanan penyimpanan = new PenyimpananPesanan())
            {
                Console.WriteLine("Penyimpanan pesanan siap digunakan.");

                try
                {
                    Console.WriteLine("\nPembayaran dengan uang kurang:");
                    kasir.ProsesPembayaran(pesanan, 10000);
                }
                catch (PembayaranException ex)
                {
                    Console.WriteLine($"Pembayaran gagal: {ex.Message}");
                }

                try
                {
                    Console.WriteLine("\nPembayaran dengan uang cukup:");
                    kasir.ProsesPembayaran(pesanan, 50000);
                }
                catch (PembayaranException ex)
                {
                    Console.WriteLine($"Pembayaran gagal: {ex.Message}");
                }

                try
                {
                    Console.WriteLine("\nPercobaan memesan stok berlebihan:");

                    Pesanan pesananBaru = new Pesanan();
                    pesananBaru.TambahProduk(makanan, 100);
                }
                catch (StokHabisException ex)
                {
                    Console.WriteLine($"Pesanan gagal: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nDemo selesai.");
                }
            }
        }
    }
}
